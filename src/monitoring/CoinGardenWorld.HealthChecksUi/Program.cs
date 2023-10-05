namespace CoinGardenWorld.HealthChecksUi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var startup = new Startup(builder.Configuration); // My custom startup class.

            startup.ConfigureServices(builder.Services); // Add services to the container.

            var app = builder.Build();
             
            startup.Configure(app, app.Environment); // Configure the HTTP request pipeline.

            app.MapGet("/", async opt => opt.Response.Redirect("status"));
             
            app.Run();
        }
    }
}
