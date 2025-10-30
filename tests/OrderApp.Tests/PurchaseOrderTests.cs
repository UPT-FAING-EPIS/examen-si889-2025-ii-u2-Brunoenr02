using OrderApp;
using Xunit;

public class PurchaseOrderTests
{
    [Fact]
    public void CrearOrdenBasica_DeberiaRetornarResumenCorrecto()
    {
        // Usamos el builder.
        // CustomerName y Product son requeridos por el constructor del Builder.
        // Quantity (1) y ShippingMethod (Estándar) se toman de los valores por defecto.
        var order = new PurchaseOrderBuilder("Carlos Ruiz", "Tablet")
            .Build(); // ¡Así de simple!
 
        var resumen = order.Summary();
 
        Assert.Equal("Carlos Ruiz ordenó 1 unidad(es) de Tablet con envío Estándar.", resumen);
    }
 
    [Fact]
    public void CrearOrdenConEnvolturaYNotas_DeberiaIncluirAmbos()
    {
        // Encadenamos los métodos para sobreescribir los valores por defecto
        var order = new PurchaseOrderBuilder("Lucía Gómez", "Smartphone")
            .WithQuantity(2)
            .WithShipping("Express")
            .WithGiftWrap()
            .WithNotes("Entregar en horario de oficina")
            .Build();
 
        var resumen = order.Summary();
 
        Assert.Equal("Lucía Gómez ordenó 2 unidad(es) de Smartphone con envío Express y envoltura de regalo. Nota: Entregar en horario de oficina", resumen);
    }
 
    [Fact]
    public void CrearOrdenSinNotas_DeberiaOmitirNotas()
    {
        // Similar al primer test, pero añadiendo la envoltura de regalo.
        // Se usan Quantity=1 y Shipping=Estándar por defecto.
        // Notes se queda como string.Empty (por defecto), lo cual es correcto.
        var order = new PurchaseOrderBuilder("Pedro", "Monitor")
            .WithGiftWrap()
            .Build();
 
        var resumen = order.Summary();
 
        Assert.Equal("Pedro ordenó 1 unidad(es) de Monitor con envío Estándar y envoltura de regalo.", resumen);
    }
}