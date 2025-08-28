namespace DomainDriven.Sample.API.IntegrationEvents
{
    public record UpdateStatusAtDistributionCenterOrderEvent(
        Guid OrderId,
        EventOrderStatus EventOrderStatus,
        Guid CityId,
        string CityName,
        Guid DistrictId,
        string DistrictName,
        string detail)
    {
    }
    public enum EventOrderStatus
    {
        PickedUp = 1,             // Kargo teslim alındı
        InTransit,            // Yolda
        AtDistributionCenter, // Dağıtım merkezine ulaştı
        OutForDelivery,       // Teslimata çıktı
        Delivered,            // Teslim edildi
        Cancelled,           // İptal edildi
        Rejected,            // Reddedildi (örn. fiyat reddi)
        Returned             // İade edildi
    }
}
