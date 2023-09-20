using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Maashkinoozhe.ServicebusTriggerApi.Functions;

public class ServiceBusTriggerApiHttpTrigger
{
    //[FunctionName(nameof(ServiceBusTriggerApiHttpTrigger.RenderUIAsync))]
    public static async Task<IActionResult> RenderUIAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "servicebustriggerapi/ui")] HttpRequest req)
    {
        var response = new ContentResult()
        {
            Content = "<html><body><h1>ServiceBusTriggerApi</h1><p>This HTTP triggered function executed successfully.</p></body></html>",
            ContentType = "text/html",
            StatusCode = StatusCodes.Status200OK
        };

        return response;
    }
}