using Spark.Library.Config;
using Spark.Library.Environment;
using Spark.Library.Routing;
using SparkPoc.Application.Startup;
using SparkPoc.Pages;
using Tailwind;
using Vite.AspNetCore.Extensions;

EnvManager.LoadConfig();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetupAppConfig();
builder.Services.AddViteServices();
builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    // Do something only in dev environments
    app.UseViteDevMiddleware();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseSession();
app.UseAntiforgery();
app.MapRazorComponents<Routes>();
app.MapMinimalApis<Program>();

app.Services.SetupScheduledJobs();
app.Services.SetupEvents();

app.Run();
