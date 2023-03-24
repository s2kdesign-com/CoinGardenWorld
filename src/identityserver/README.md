## CoinGarden.World IdentityServer (version 6.2.0)
Used template: 
https://github.com/DuendeSoftware/IdentityServer.Templates

How to update it 

1. Delete the folder `CoinGardenWorld.IdentityServer`
2. open powershell and run `dotnet new isef -n CoinGardenWorld.IdentityServer`
3. Delete all migrations in `Migrations` folder
4. Change `HostingExtensions.cs`
```c#
...
    // this adds the config data from DB (clients, resources, CORS)
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => 
            b.UseSqlServer(connectionString, sqlOpt => sqlOpt.MigrationsAssembly(typeof(Program).Assembly.FullName));
    })
    // this adds the operational data from DB (codes, tokens, consents)
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlServer(connectionString, sqlOpt => sqlOpt.MigrationsAssembly(typeof(Program).Assembly.FullName));
    });
...
```
6. Change `appsettings.json`
```json
  "ConnectionStrings": { 
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=IdentityServer.db;Integrated Security=true;MultipleActiveResultSets=true"
  }
```
7. Run migrations in folder `cd .\CoinGardenWorld.IdentityServer` 
 - `dotnet ef migrations add InitialCreate --context ConfigurationDbContext  --output-dir Migrations/ConfigurationDb -- --provider SqlServer `
 - `dotnet ef migrations add InitialCreate --context PersistedGrantDbContext  --output-dir Migrations/PersistedGrantDb -- --provider SqlServer` 
 - `dotnet ef migrations add InitialCreate --context ApplicationDbContext  --output-dir Migrations/ApplicationDb -- --provider SqlServer` 
8. Finally run `dotnet run /seed`

--- 
P.S

Update the content for images: `<img src="~/_Content/CoinGardenWorld.IdentityServer.Theme/images/logo_250x250.png" class="logo">`

Don't forget to enable server session 
```c#
// if you want to use server-side sessions: https://blog.duendesoftware.com/posts/20220406_session_management/
// then enable it
isBuilder.AddServerSideSessions();
//
// and put some authorization on the admin/management pages using the same policy created above
builder.Services.Configure<RazorPagesOptions>(options =>
    options.Conventions.AuthorizeFolder("/ServerSideSessions", "admin"));
```

and use ASPNET Identity: (check commit: [eb56022f420d293ef6bf8cf32169f2815fe3a4aa [eb56022]](https://github.com/s2kdesign-com/CoinGardenWorld/commit/eb56022f420d293ef6bf8cf32169f2815fe3a4aa)) for details and all needed changes
https://stackoverflow.com/a/66686348/5030622
