using SparkPoc.Application.Jobs;
using Coravel;

namespace SparkPoc.Application.Startup;

public static class ScheduledJobsRegistration
{
    public static IServiceProvider SetupScheduledJobs(this IServiceProvider services)
    {
        services.UseScheduler(scheduler =>
        {
            // example scheduled job
            //scheduler
            //    .Schedule<ExampleJob>()
            //    .EveryFiveMinutes();
        });
        return services;
    }
}
