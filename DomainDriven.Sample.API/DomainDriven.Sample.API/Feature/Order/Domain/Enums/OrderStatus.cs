namespace DomainDriven.Sample.API.Feature.Order.Domain.Enums
{
    public enum OrderStatus
    {
        PickedUp = 1,             // Kargo teslim alındı
        InTransit,            // Yolda
        AtDistributionCenter, // Dağıtım merkezine ulaştı
        OutForDelivery,       // Teslimata çıktı
        Delivered,            // Teslim edildi
        Cancelled,           // İptal edildi
        Rejected,            // Reddedildi (örn. fiyat reddi)
        Returned,             // İade edildi
        Accepted,             // Sipariş alındı
        Processing            //Hazırlanıyor
    }
}
