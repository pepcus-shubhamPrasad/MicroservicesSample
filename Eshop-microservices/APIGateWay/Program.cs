using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();
// Add HTTPS redirection
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7005; // API Gateway HTTPS port
});
var app = builder.Build();
app.UseOcelot().Wait();
app.MapGet("/", () => "Hello World!");

app.Run();
