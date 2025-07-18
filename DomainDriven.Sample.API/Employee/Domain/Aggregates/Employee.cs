﻿using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Domain.Events;

namespace DomainDriven.Sample.API.Employee.Domain.Aggregates
{
    public class Employee : AggregateRoot
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public int CityId { get; private set; }
        public decimal Point { get; private set; }
        public decimal Price { get; private set; }
        //public void AssignCargo(int cargoId)
        //{
        //    if (_cargoIds.Contains(cargoId))
        //    {
        //        throw new InvalidOperationException("Cargo is already assigned to this employee.");
        //    }
        //    _cargoIds.Add(cargoId);
        //    RaiseDomainEvent(new CargoAssignedNotification(this.Id, cargoId));
        //}
        public void AddEmployee(string name, string phoneNumber, int cityId, decimal price)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.CityId = cityId;
            this.Price = price;
        }
    }
}
