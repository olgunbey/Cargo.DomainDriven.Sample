namespace DomainDriven.Sample.API
{
    public interface IJob
    {
        public Task OrderStateToProcessing();
        public Task OrderStateToAtDistributionCenter();
    }
}
