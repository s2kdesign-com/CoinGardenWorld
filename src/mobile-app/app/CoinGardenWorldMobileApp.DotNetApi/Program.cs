using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var microsoftIdentityOptions = new MicrosoftIdentityOptions();
builder.Configuration.GetSection("AzureAd").Bind(microsoftIdentityOptions);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = $"{Assembly.GetExecutingAssembly().GetName().Version}",
        Title = "CGW - Mobile APP API",
        Description = "Backend service API for all external functions of CoinGarden Mobile API.",
        TermsOfService = new Uri("https://coingarden.world/terms-and-conditions"),
        Contact = new OpenApiContact
        {
            Name = "admin@CoinGarden.World",
            Url = new Uri("http://coingarden.world")
        },
        License = new OpenApiLicense
        {
            Name = "GNU General Public License v3.0",
            Url = new Uri("https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/LICENSE.txt")
        }
    });


    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Enabled OAuth security in Swagger
    var scopesConfig = builder.Configuration.GetValue<string>("AzureAd:Scopes").Split(' ');
    var scopes = new Dictionary<string, string>();
    foreach (var scope in scopesConfig)
    {
        scopes.Add($"https://{microsoftIdentityOptions.Domain}/{microsoftIdentityOptions.ClientId}/{scope}", "");

    }
    options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                },
                Scheme = "oauth2",
                Name = "oauth2",
                In = ParameterLocation.Header
            },
            new List <string> ()
        }
    });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri($"{microsoftIdentityOptions.Instance}/{microsoftIdentityOptions.Domain}/{microsoftIdentityOptions.SignUpSignInPolicyId}/oauth2/v2.0/authorize"),
                TokenUrl = new Uri($"{microsoftIdentityOptions.Instance}/{microsoftIdentityOptions.Domain}/{microsoftIdentityOptions.SignUpSignInPolicyId}/oauth2/v2.0/token"),
                Scopes = scopes
            }
        }
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        //Localhost-CoinGarden-Mobile-Web-SwaggerUI
        options.OAuthAppName("Swagger Client");
        options.OAuthClientId(builder.Configuration.GetValue<string>("SwaggerUI:ClientId"));
        options.OAuthClientSecret(builder.Configuration.GetValue<string>("SwaggerUI:ClientSecret"));
        options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
        
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
