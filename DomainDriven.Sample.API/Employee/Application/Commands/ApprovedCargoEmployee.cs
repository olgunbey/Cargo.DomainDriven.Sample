using DomainDriven.Sample.API.Employee.Application.IRepositories;
using DomainDriven.Sample.API.Employee.Domain.Repositories;
using MediatR;

namespace DomainDriven.Sample.API.Employee.Application.Commands
{
    public class ApprovedCargoEmployeeRequest : IRequest
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public bool Approved { get; set; }
    }
    public class ApprovedCargoEmployeeHandler(IEmployeeDbContext employeeDbContext, IApprovedCargoEmployee approvedCargoEmployee) : IRequestHandler<ApprovedCargoEmployeeRequest>
    {
        public async Task Handle(ApprovedCargoEmployeeRequest request, CancellationToken cancellationToken)
        {
            var generateApprovedEmployee = approvedCargoEmployee.CreateApprovedEmployee(request.OrderId, request.EmployeeId);

            generateApprovedEmployee.SetApproval(request.Approved);

            employeeDbContext.GetDbSet<Domain.Aggregates.ApprovedCargoEmployee>().Add(generateApprovedEmployee);
            await employeeDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
