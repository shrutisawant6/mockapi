
using MockAPI.CoreServices;
using MockAPI.SharedServices;
using Serilog;

namespace MockAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Configure Serilog
                string logFileLocation = builder.Configuration["Log:FileLocation"];
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(logFileLocation, rollingInterval: RollingInterval.Day)
                    .Enrich.FromLogContext()
                    .ReadFrom.Configuration(builder.Configuration)
                    .CreateLogger();

                builder.Host.UseSerilog();//default logger replaced

                // Add services to the container.
                builder.Services.AddSingleton<IHttpService, HttpService>();
                builder.Services.AddScoped<IAssetsService, AssetsService>();


                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.EnableAnnotations();
                });

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application has failed start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
