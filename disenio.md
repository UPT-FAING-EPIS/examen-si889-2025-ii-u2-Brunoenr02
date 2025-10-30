# Diagrama de Clases - OrderApp

## Patrón Builder Implementado

Este diagrama muestra la implementación del patrón Builder para la creación de objetos `PurchaseOrder`.

```mermaid
classDiagram
    direction LR
    
    class PurchaseOrder {
        +String CustomerName
        +String Product
        +Int Quantity
        +String ShippingMethod
        +Boolean GiftWrap
        +String Notes
        +PurchaseOrder(customerName, product, quantity, shippingMethod, giftWrap, notes)
        +Summary() String
    }
    
    class PurchaseOrderBuilder {
        -String _customerName
        -String _product
        -Int _quantity
        -String _shippingMethod
        -Boolean _giftWrap
        -String _notes
        +PurchaseOrderBuilder(customerName, product)
        +WithQuantity(quantity) PurchaseOrderBuilder
        +WithShipping(shippingMethod) PurchaseOrderBuilder
        +WithGiftWrap() PurchaseOrderBuilder
        +WithNotes(notes) PurchaseOrderBuilder
        +Build() PurchaseOrder
    }
    
    PurchaseOrderBuilder ..> PurchaseOrder : creates
    PurchaseOrderBuilder --> PurchaseOrder : builds

    note for PurchaseOrder "Objeto inmutable con\npropiedades de solo lectura"
    note for PurchaseOrderBuilder "Constructor que proporciona\nuna interfaz fluida para\ncrear órdenes de compra"
```

## Descripción del Patrón

### PurchaseOrder (Producto)
- **Responsabilidad**: Representar una orden de compra inmutable
- **Características**: 
  - Propiedades de solo lectura
  - Validación en el constructor
  - Método Summary() para obtener descripción

### PurchaseOrderBuilder (Constructor)
- **Responsabilidad**: Construir objetos PurchaseOrder de forma fluida
- **Características**:
  - Campos obligatorios en el constructor
  - Métodos With*() que retornan el builder (fluent interface)
  - Valores por defecto razonables
  - Método Build() para crear el objeto final

## Relaciones

- **PurchaseOrderBuilder creates PurchaseOrder**: El builder es responsable de crear instancias de PurchaseOrder
- **Fluent Interface**: Los métodos With*() retornan el propio builder para permitir encadenamiento

## Ejemplo de Uso

```csharp
var order = new PurchaseOrderBuilder("Cliente", "Producto")
    .WithQuantity(2)
    .WithShipping("Express")
    .WithGiftWrap()
    .WithNotes("Entregar en oficina")
    .Build();
```
