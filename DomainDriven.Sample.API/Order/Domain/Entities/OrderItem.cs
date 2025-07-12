using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Order.Domain.Exceptions;

namespace DomainDriven.Sample.API.Order.Domain.Entities
{
    public class OrderItem : IEntity
    {
        public OrderItem()
        {

        }
        public OrderItem(string name, decimal weight, int _count)
        {
            Name = name;
            Weight = weight;

            if (_count <= 0)
            {
                Count = 1;
            }
            else
            {
                Count = _count;
            }
            if (Weight <= 0)
            {
                throw new InvalidWeightException("Weight cannot be negative.");
            }
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Count { get; private set; }
        public decimal Weight { get; private set; }


    }
}
