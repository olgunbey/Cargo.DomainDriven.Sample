using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Entities
{
    public class ProductItem : IEntity
    {
        public ProductItem()
        {

        }
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; private set; }


        public ProductItem(Guid id, int count)
        {
            this.Count = count;
            this.Id = id;
        }
    }
}
