using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Customer.Domain.ValueObjects;

namespace DomainDriven.Sample.API.Customer.Domain.Aggregates
{
    public class Customer : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public CurrentLocation CurrentLocation { get; private set; }
        public Customer CreateCustomer(string firstName, string lastName, string phoneNumber, string email, string password, int cityId, int districtId, string detail)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(detail))
            {
                throw new ArgumentException("All fields are required.");
            }
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Password = password;
            this.CurrentLocation = new CurrentLocation(cityId, districtId, detail);
            return this;
        }
    }
}

