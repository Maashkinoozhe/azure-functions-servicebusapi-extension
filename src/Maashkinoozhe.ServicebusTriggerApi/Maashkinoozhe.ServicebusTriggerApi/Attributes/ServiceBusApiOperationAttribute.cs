namespace Maashkinoozhe.ServicebusTriggerApi.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ServiceBusApiOperationAttribute : Attribute
{
    public string OperationName { get; }
    public Type ContentType { get; }

    public ServiceBusApiOperationAttribute(
        string operationName,
        Type contentType
        )
    {
        OperationName = operationName;
        ContentType = contentType;
    }
}