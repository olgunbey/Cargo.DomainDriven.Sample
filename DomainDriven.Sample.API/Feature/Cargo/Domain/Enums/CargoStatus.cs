namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Enums
{
    public enum CargoStatus
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
