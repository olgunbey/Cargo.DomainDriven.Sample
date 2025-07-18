﻿using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Order.Domain.Entities;
using DomainDriven.Sample.API.Order.Domain.Events;
using DomainDriven.Sample.API.Order.Domain.Repository;

namespace DomainDriven.Sample.API.Order.Domain.Aggregates
{
    public class Order : AggregateRoot, IOrder
    {
        public Order()
        {
            _orderItems = new List<OrderItem>();
        }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public int CustomerId { get; private set; }
        public TargetLocation TargetLocation { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsApproved { get; private set; }

        public void AddOrderItem(string name, decimal weight, int count)
        {
            var orderItem = new OrderItem(name, weight, count);
            _orderItems.Add(orderItem);
        }

        public Order GenerateOrder(int customerId, int cityId, int districtId, string details)
        {
            this.CustomerId = customerId;
            this.TargetLocation = new TargetLocation(cityId, districtId, details);
            this.CreatedDate = DateTime.UtcNow;
            return this;
        }
        public void SetApproved(bool approved)
        {
            this.IsApproved = approved;
        }
    }
}