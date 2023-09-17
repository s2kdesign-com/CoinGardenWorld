
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CoinGardenWorld.HealthChecksUi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add serices to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext...
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());

            services.AddHealthChecksUI().AddInMemoryStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

            app.UseHealthChecksUI(config =>
            {
               // config.ResourcesPath = string.IsNullOrEmpty(pathBase) ? "/ui/resources" : $"{pathBase}/ui/resources";
                config.UIPath = "/status";
                config.AddCustomStylesheet(Path.Join("wwwroot", "css", "coingarden.css"));
            });
        }
    }
}
