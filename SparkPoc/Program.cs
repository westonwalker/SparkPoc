using Spark.Library.Config;
using Spark.Library.Environment;
using Spark.Library.Routing;
using SparkPoc.Application.Startup;
using SparkPoc.Pages;

EnvManager.LoadConfig();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetupAppConfig();
builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
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
