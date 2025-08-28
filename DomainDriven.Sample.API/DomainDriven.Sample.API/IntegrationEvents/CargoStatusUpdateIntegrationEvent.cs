namespace DomainDriven.Sample.API.IntegrationEvents
{
    public record CargoStatusUpdateIntegrationEvent(Guid OrderId, CargoStatusDto CargoStatus)
    {
    }
    public enum CargoStatusDto
    {
        PickedUp = 1,         // Kargo teslim alındı
        InTransit,            // Yolda
        AtDistributionCenter, // Dağıtım merkezine ulaştı
        OutForDelivery,       // Teslimata çıktı
        Delivered,            // Teslim edildi
        Cancelled,            // İptal edildi
        Rejected,             // Reddedildi (örn. fiyat reddi)
        Returned              // İade edildi

    }
}
