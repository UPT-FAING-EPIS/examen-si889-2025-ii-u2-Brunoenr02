```mermaid
classDiagram

class PurchaseOrder
PurchaseOrder : +String CustomerName
PurchaseOrder : +String Product
PurchaseOrder : +Int Quantity
PurchaseOrder : +String ShippingMethod
PurchaseOrder : +Boolean GiftWrap
PurchaseOrder : +String Notes
PurchaseOrder : +Summary() String

class PurchaseOrderBuilder
PurchaseOrderBuilder : +WithQuantity() PurchaseOrderBuilder
PurchaseOrderBuilder : +WithShipping() PurchaseOrderBuilder
PurchaseOrderBuilder : +WithGiftWrap() PurchaseOrderBuilder
PurchaseOrderBuilder : +WithNotes() PurchaseOrderBuilder
PurchaseOrderBuilder : +Build() PurchaseOrder



```
