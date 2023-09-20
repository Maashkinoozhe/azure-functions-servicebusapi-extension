using Maashkinoozhe.ServicebusTriggerApi.Abstractions;
using Maashkinoozhe.ServicebusTriggerApi.Functions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Script.Description;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Reflection;

namespace Maashkinoozhe.ServicebusTriggerApi;

public class ServiceBusTriggerApiHttpTriggerProvider : IFunctionProvider
{
    public Task<ImmutableArray<FunctionMetadata>> GetFunctionMetadataAsync()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var functionMetadata = new FunctionMetadata()
        {
            Name = "banane",
            FunctionDirectory = null,
            ScriptFile = $"assembly:{assembly.FullName}",
            EntryPoint = $"{assembly.GetName().Name}.Functions.{typeof(ServiceBusTriggerApiHttpTrigger).Name}.{nameof(ServiceBusTriggerApiHttpTrigger.RenderUIAsync)}",
            Language = "DotNetAssembly"
        };

        var f1 = new HttpBindingMetadata()
        {
            Methods = new List<string>() { HttpMethods.Get },
            Route = "servicebustriggerapi/ui",
            AuthLevel = AuthorizationLevel.Anonymous
        };

        functionMetadata.Bindings.Add(BindingMetadata.Create(JObject.FromObject(f1)));

        return Task.FromResult(ImmutableArray.Create(functionMetadata));
    }

    public ImmutableDictionary<string, ImmutableArray<string>> FunctionErrors  => new Dictionary<string, ImmutableArray<string>>().ToImmutableDictionary();
}