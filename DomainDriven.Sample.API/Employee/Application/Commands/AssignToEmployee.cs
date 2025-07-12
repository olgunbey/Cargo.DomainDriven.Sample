using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Employee.Application.Commands
{
    public class AssignToEmployeeRequest : IRequest<bool>
    {
        public int EmployeeId { get; set; }
        public int CargoId { get; set; }
    }
    public class AssignToEmployeeHandler(DbContext applicationDbContext) : IRequestHandler<AssignToEmployeeRequest, bool>
    {
        public async Task<bool> Handle(AssignToEmployeeRequest request, CancellationToken cancellationToken)
        {
            DbSet<Domain.Aggregates.Employee> dbEmployee = applicationDbContext.Set<Domain.Aggregates.Employee>();

            Domain.Aggregates.Employee? employee = await dbEmployee.FindAsync(request.EmployeeId);

            if (employee == null)
                return false;

            employee.AssignCargo(request.CargoId);
            await applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }

}
