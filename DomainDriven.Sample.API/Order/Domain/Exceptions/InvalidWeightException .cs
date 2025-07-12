namespace DomainDriven.Sample.API.Order.Domain.Exceptions
{
    public class InvalidWeightException(string msg) : Exception(msg)
    {
    }
}
