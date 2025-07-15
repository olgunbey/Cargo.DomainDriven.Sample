using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Application.Dtos;
using DomainDriven.Sample.API.Employee.Application.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Employee.Application.Queries
{
    public class GetAvailableEmployeesByCity : IRequest<ResponseDto<List<GetEmployeeByCityIdResponseDto>>>
    {
        public int CityId { get; set; }
    }
    public class GetEmployeeByCıtyIdRequestHandler(IEmployeeDbContext employeeDbContext) : IRequestHandler<GetAvailableEmployeesByCity, ResponseDto<List<GetEmployeeByCityIdResponseDto>>>
    {
        public async Task<ResponseDto<List<GetEmployeeByCityIdResponseDto>>> Handle(GetAvailableEmployeesByCity request, CancellationToken cancellationToken)
        {
            var getEmployeeByCityId = await employeeDbContext.GetDbSet<Domain.Aggregates.Employee>()
                   .Where(y => y.CityId == request.CityId)
                   .Select(y => new GetEmployeeByCityIdResponseDto()
                   {
                       Name = y.Name,
                       PhoneNumber = y.PhoneNumber,
                       Point = y.Point,
                       Price = y.Price
                   }).ToListAsync(cancellationToken);

            return getEmployeeByCityId.Any()
                ? ResponseDto<List<GetEmployeeByCityIdResponseDto>>.Success(getEmployeeByCityId)
                : ResponseDto<List<GetEmployeeByCityIdResponseDto>>.Fail("No employees found for the specified city.", 404);

        }
    }
}
