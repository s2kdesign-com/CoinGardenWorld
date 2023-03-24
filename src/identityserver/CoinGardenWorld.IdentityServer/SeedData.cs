using Microsoft.EntityFrameworkCore;
using Serilog;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using CoinGardenWorld.IdentityServer.Migrations;
using CoinGardenWorld.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using IdentityModel;
using System.Security.Claims;

namespace CoinGardenWorld.IdentityServer;

public class SeedData {
    public static void MigrateDatabase(WebApplication app, bool addTestData = false) {

        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope()) {

            scope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();

            scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

            var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            context.Database.Migrate();

            // Even if addTestData=true we will not populate the data if there is existing rows in the tables
            if (addTestData)
            {
                EnsureSeedData(context);

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                AddUsers(userMgr, roleMgr);
            }



        }
    }

    private static void AddUsers(UserManager<ApplicationUser> userMgr, RoleManager<IdentityRole> roleMgr)
    {
        Log.Debug("Users being populated");

        var alice = userMgr.FindByNameAsync("alice").Result;
        if (alice == null) {
            alice = new ApplicationUser {
                UserName = "alice",
                Email = "AliceSmith@email.com",
                EmailConfirmed = true,
            };
            var result = userMgr.CreateAsync(alice, "Pass123$").Result;
            if (!result.Succeeded) {
                throw new Exception(result.Errors.First().Description);
            }

            result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;
            if (!result.Succeeded) {
                throw new Exception(result.Errors.First().Description);
            }
            Log.Debug("alice created");


        }
        else {
            Log.Debug("alice already exists");
        }

        var bob = userMgr.FindByNameAsync("bob").Result;
        if (bob == null) {
            bob = new ApplicationUser {
                UserName = "bob",
                Email = "BobSmith@email.com",
                EmailConfirmed = true
            };
            var result = userMgr.CreateAsync(bob, "Pass123$").Result;
            if (!result.Succeeded) {
                throw new Exception(result.Errors.First().Description);
            }

            result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim("location", "somewhere")
                        }).Result;
            if (!result.Succeeded) {
                throw new Exception(result.Errors.First().Description);
            }
            Log.Debug("bob created");
        }
        else {
            Log.Debug("bob already exists");
        }

        Log.Debug("Roles being populated");

        var adminRole = roleMgr.FindByIdAsync("admin").Result;
        if (adminRole == null)
        {
            var roleResult = roleMgr.CreateAsync(new IdentityRole("admin")).Result;
            if (!roleResult.Succeeded)
            {
                throw new Exception(roleResult.Errors.First().Description);
            }
            Log.Debug("admin role created");

            Log.Debug("Making Alice admin role");
            IdentityResult identityResult = userMgr.AddToRoleAsync(alice, "admin").Result;
            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.First().Description);
            }
            Log.Debug("Alice is now admin");
        }
    }

    private static void EnsureSeedData(ConfigurationDbContext context) {
        if (!context.Clients.Any()) {
            Log.Debug("Clients being populated");
            foreach (var client in Config.Clients.ToList()) {
                context.Clients.Add(client.ToEntity());
            }
            context.SaveChanges();
        }
        else {
            Log.Debug("Clients already populated");
        }

        if (!context.IdentityResources.Any()) {
            Log.Debug("IdentityResources being populated");
            foreach (var resource in Config.IdentityResources.ToList()) {
                context.IdentityResources.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
        else {
            Log.Debug("IdentityResources already populated");
        }

        if (!context.ApiScopes.Any()) {
            Log.Debug("ApiScopes being populated");
            foreach (var resource in Config.ApiScopes.ToList()) {
                context.ApiScopes.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
        else {
            Log.Debug("ApiScopes already populated");
        }

        if (!context.IdentityProviders.Any()) {
            Log.Debug("OIDC IdentityProviders being populated");
            context.IdentityProviders.Add(new OidcProvider {
                Scheme = "demoidsrv",
                DisplayName = "IdentityServer",
                Authority = "https://demo.duendesoftware.com",
                ClientId = "login",
            }.ToEntity());
            context.SaveChanges();
        }
        else {
            Log.Debug("OIDC IdentityProviders already populated");
        }
    }
}
