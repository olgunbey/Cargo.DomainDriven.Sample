namespace DomainDriven.Sample.API.Feature.Location.Dtos
{
    public record GetAllCityResponseDto(Guid CityId,string Name,List<DistrictResponseDto> DistrictResponses)
    {
    }
    public record DistrictResponseDto(Guid DistrictId,string Name)
    {
    }
}
