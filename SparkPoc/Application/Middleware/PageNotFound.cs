namespace SparkPoc.Application.Middleware;

public class PageNotFound
{
	private readonly RequestDelegate _next;

	public PageNotFound(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IConfiguration config)
	{
		await _next(context);

		if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
		{
			string originalPath = context.Request.Path.Value;
			context.Items["originalPath"] = originalPath;
			context.Request.Path = config.GetValue<string>("Spark:PageNotFoundPath", "/not-found");
			await _next(context);
		}
	}
}

public static class PageNotFoundExtensions
{
	public static IApplicationBuilder UsePageNotFoundMiddleware(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<PageNotFound>();
	}
}