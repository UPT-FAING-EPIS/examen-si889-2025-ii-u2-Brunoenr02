---
_layout: landing
---

# OrderApp - Patrón Builder

Bienvenido a la documentación oficial de **OrderApp**, una aplicación que implementa el patrón de diseño Builder para la creación de órdenes de compra.

## 📚 Documentación

- [README - Guía Completa](README.md)
- [Diagrama de Clases](disenio.md)
- [Reporte de Cobertura](coverage/index.html)

## 🏗️ Arquitectura

### PurchaseOrder (Producto)
Clase inmutable que representa una orden de compra con propiedades de solo lectura.

### PurchaseOrderBuilder (Constructor)
Constructor que proporciona una interfaz fluida para crear objetos `PurchaseOrder`.

## 💻 Ejemplo de Uso

```csharp
var order = new PurchaseOrderBuilder("Carlos Ruiz", "Tablet")
    .WithQuantity(2)
    .WithShipping("Express")
    .WithGiftWrap()
    .WithNotes("Entregar en horario de oficina")
    .Build();
```

## 🚀 Ventajas del Patrón Builder

1. **Legibilidad**: Código más claro y expresivo
2. **Flexibilidad**: Fácil agregar nuevos parámetros
3. **Inmutabilidad**: Objetos seguros y thread-safe
4. **Validación**: Centralizada en un solo lugar

---

**Universidad Privada de Tacna - FAING - EPIS** | *Documentación generada con DocFX*
