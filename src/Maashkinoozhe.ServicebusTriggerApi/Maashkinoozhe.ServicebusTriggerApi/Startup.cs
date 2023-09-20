using Maashkinoozhe.ServicebusTriggerApi;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.Script.Description;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]

namespace Maashkinoozhe.ServicebusTriggerApi;

/// <summary>
/// This represents the startup entity for OpenAPI endpoints registration
/// </summary>
public class Startup : IWebJobsStartup
{
    /// <inheritdoc />
    public void Configure(IWebJobsBuilder builder)
    {
        builder.Services.AddSingleton<IFunctionProvider, ServiceBusTriggerApiHttpTriggerProvider>();
    }
}