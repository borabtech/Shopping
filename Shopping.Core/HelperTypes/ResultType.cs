using Shopping.Core.Enumerations;

namespace Shopping.Core.HelperTypes;

public class ResultType<T>
{
    public EnumStatusType Status { get; set; }
    public required string Message { get; set; }
    public T? Data { get; set; }
}