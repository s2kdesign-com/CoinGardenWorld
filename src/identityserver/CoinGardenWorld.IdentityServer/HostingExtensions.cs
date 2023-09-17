using Duende.IdentityServer;
using CoinGardenWorld.IdentityServer;
using CoinGardenWorld.IdentityServer.Pages.Admin.ApiScopes;
using CoinGardenWorld.IdentityServer.Pages.Admin.Clients;
using CoinGardenWorld.IdentityServer.Pages.Admin.IdentityScopes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using CoinGardenWorld.IdentityServer.Migrations;
using CoinGardenWorld.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace CoinGardenWorld.IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        var configuration = builder.Configuration;
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        var isBuilder = builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v5/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })

            // this adds the config data from DB (clients, resources, CORS)
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString, dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
            })
            // this is something you will want in production to reduce load on and requests to the DB
#if !DEBUG
            .AddConfigurationStoreCache()
#endif
            
            // this adds the operational data from DB (codes, tokens, consents)
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString, dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));

                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
                options.RemoveConsumedTokens = true;
            })
            .AddAspNetIdentity<ApplicationUser>();

        builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to https://localhost:5001/signin-google
                options.ClientId = "copy client ID from Google here";
                options.ClientSecret = "copy client secret from Google here";
            })
            .AddOpenIdConnect("oidc", options =>
            {
                builder.Configuration.GetSection("OpenIDConnectSettings").Bind(options);
                options.Authority = configuration["OpenIDConnectSettings:Authority"];
                options.ClientId = configuration["OpenIDConnectSettings:ClientId"];
                options.ClientSecret = configuration["OpenIDConnectSettings:ClientSecret"];

                options.ResponseType = "code";
                options.ResponseMode = "query";

                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("api");
                options.Scope.Add("offline_access");

                options.MapInboundClaims = false;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
            });


        // this adds the necessary config for the simple admin/config pages
        {
            builder.Services.AddAuthorization(options =>
                options.AddPolicy("admin",
                    policy => policy.RequireClaim("role", "admin"))
            );

            builder.Services.Configure<RazorPagesOptions>(options =>
                options.Conventions.AuthorizeFolder("/Admin", "admin"));

            builder.Services.AddTransient<ClientRepository>();
            builder.Services.AddTransient<IdentityScopeRepository>();
            builder.Services.AddTransient<ApiScopeRepository>();
        }
        
        // if you want to use server-side sessions: https://blog.duendesoftware.com/posts/20220406_session_management/
        // then enable it
        isBuilder.AddServerSideSessions();
        //
        // and put some authorization on the admin/management pages using the same policy created above
        builder.Services.Configure<RazorPagesOptions>(options =>
            options.Conventions.AuthorizeFolder("/ServerSideSessions", "admin"));

        // Add HealthChecks 
        builder.Services.AddHealthChecks().AddCheck("self", () =>
            HealthCheckResult.Healthy("Build Version: " + Assembly.GetExecutingAssembly()?.GetName().Version))
            .AddSqlServer(connectionString, "SELECT TOP (1) * FROM [dbo].[Clients]")
            ;
        
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        
        app.MapRazorPages()
            .RequireAuthorization();

        app
            .UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            })
            .UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true
            });

        return app;
    }
}