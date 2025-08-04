# Cargo.DomainDriven.Sample

Bu proje Domain Driven Design (DDD) prensipleriyle geliştirilmiş bir kargo yönetim örneğidir.

## Domain Driven Design - Bounded Context Diagram

```mermaid
flowchart LR
    %% ==== BOUNDED CONTEXTS ====
    subgraph LocationBC[Location BC]
        L1[Location Aggregate - No events emitted]
    end

    subgraph ProductBC[Product BC]
        P1[Product Aggregate]
        DE1((Domain Event: UpdateProductEvent))
        IE1((Integration Event: UpdateProductIntegrationEvent - Updates Cargo BC & Order BC Product Read Models))
    end

    subgraph OrderBC[Order BC]
        O1[Order Aggregate]
        DE2((Domain Event: CreateOrderEvent))
        IE2((Integration Event: OrderReceivedIntegrationEvent - Updates Product BC Product table))
    end

    subgraph CargoBC[Cargo BC]
        C1[Cargo Aggregate]
        DE3((Domain Event: GenerateCargoEvent))
        IE3((Integration Event: CargoStatusUpdateIntegrationEvent - Updates Order BC Status))
        DE4((Domain Event: UpdateCargoStatusEvent))
        IE4((Integration Event: CargoStatusUpdateIntegrationEvent - Updates Order BC Status))
    end

    %% ==== FLOW CONNECTIONS ====
    P1 --> DE1 --> IE1
    IE1 -->|Update Read Models| C1
    IE1 -->|Update Read Models| O1

    O1 --> DE2 --> IE2
    IE2 -->|Update Product Table| P1

    C1 --> DE3 --> IE3
    IE3 -->|Update Status| O1

    C1 --> DE4 --> IE4
    IE4 -->|Update Status| O1


```
## Event Yönetimi ve Veri Tutarlılığı
- Bounded Context içerisindeki domainler arası iletişim Domain Event ile sağlanır.
- Bounded Context’ler arasındaki iletişim ise Integration Event mekanizmasıyla gerçekleştirilir.
- Audit (denetim) için, temel event sınıfına ShouldLogEvent özelliği eklenmiştir.
  - Bu özellik true olduğunda event, EventStore'a yazılır ve böylece audit altyapısı oluşturulur.
- Integration Eventler, iletişim ve mesajlaşma yönetimi için MassTransit kütüphanesi ile yönetilmektedir.
- Domain Eventler ise, uygulama içi işlem ve koordinasyon için MediatR yapısı kullanılarak yönetilir.
- Aggregatelar sadece kendi verilerini tutacak şekilde tasarlanmıştır.
  - Bu amaçla, Bounded Context’ler arası veri tutarlılığını sağlamak için Read Modeller oluşturulmuştur.
  - Böylece, aggregatelar sadece kendi sorumluluk alanlarındaki verilerle ilgilenir ve karmaşıklık azaltılır.

