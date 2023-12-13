using Spark.Library.Routing;

namespace SparkPoc.Application.Startup;

public static class RegisterRoutesExtension
{
	public static void RegisterRoutes(this WebApplication app)
	{
		var routes = typeof(Program).Assembly
			.GetTypes()
			.Where(t => t.IsAssignableTo(typeof(IRoute))
			            && !t.IsAbstract && !t.IsInterface)
			.Select(Activator.CreateInstance)
			.Cast<IRoute>();

		foreach (var route in routes)
		{
			route.Map(app);
		}
	}
}