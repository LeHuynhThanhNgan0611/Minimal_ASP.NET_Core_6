using System.Runtime.CompilerServices;

namespace MinimalNet6.MyMapEndpoints
{
    public static class MapEndpoints
    {
        public static WebApplication MapUserEndPoint(this WebApplication app)
        {
            app.MapGet(pattern: "/Users", () => new string[] { "admin", "guest" });
            app.MapGet(pattern: "/Users/{name}", (string name) => $"Hello {name}");
            return app;
        }

        public static WebApplication MapWeathereForcast(this WebApplication app)
        {
            var summaries = new[]
              {
                  "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
              };

            app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateTime.Now.AddDays(index),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");
            return app;
        }
    }
}
