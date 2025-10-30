using OrderApp;
using Xunit;

/// <summary>
/// Contiene las pruebas unitarias para verificar el correcto funcionamiento 
/// del patrón Builder implementado en <see cref="PurchaseOrder"/> y <see cref="PurchaseOrderBuilder"/>.
/// </summary>
/// <remarks>
/// Estas pruebas validan:
/// <list type="bullet">
/// <item><description>La creación de órdenes con valores por defecto</description></item>
/// <item><description>La creación de órdenes con todas las opciones configuradas</description></item>
/// <item><description>El manejo correcto de valores opcionales (como notas)</description></item>
/// <item><description>La generación correcta del resumen de la orden</description></item>
/// </list>
/// </remarks>
public class PurchaseOrderTests
{
    /// <summary>
    /// Verifica que se puede crear una orden básica utilizando solo los campos obligatorios
    /// y que los valores por defecto se aplican correctamente.
    /// </summary>
    /// <remarks>
    /// Esta prueba valida que:
    /// <list type="bullet">
    /// <item><description>El builder funciona con solo CustomerName y Product</description></item>
    /// <item><description>Quantity por defecto es 1</description></item>
    /// <item><description>ShippingMethod por defecto es "Estándar"</description></item>
    /// <item><description>El resumen se genera correctamente sin opciones adicionales</description></item>
    /// </list>
    /// </remarks>
    [Fact]
    public void CrearOrdenBasica_DeberiaRetornarResumenCorrecto()
    {
        // Arrange: Crear una orden con solo los campos obligatorios
        // Quantity (1) y ShippingMethod (Estándar) se toman de los valores por defecto
        var order = new PurchaseOrderBuilder("Carlos Ruiz", "Tablet")
            .Build();
 
        // Act: Generar el resumen de la orden
        var resumen = order.Summary();
 
        // Assert: Verificar que el resumen sea el esperado
        Assert.Equal("Carlos Ruiz ordenó 1 unidad(es) de Tablet con envío Estándar.", resumen);
    }
 
    /// <summary>
    /// Verifica que se pueden configurar todas las opciones disponibles (cantidad, envío, envoltura y notas)
    /// y que todas aparecen correctamente en el resumen.
    /// </summary>
    /// <remarks>
    /// Esta prueba valida:
    /// <list type="bullet">
    /// <item><description>El encadenamiento fluido de múltiples métodos del builder</description></item>
    /// <item><description>La configuración personalizada de cantidad</description></item>
    /// <item><description>La configuración personalizada del método de envío</description></item>
    /// <item><description>La activación de envoltura de regalo</description></item>
    /// <item><description>La inclusión de notas especiales</description></item>
    /// <item><description>La generación correcta del resumen completo</description></item>
    /// </list>
    /// </remarks>
    [Fact]
    public void CrearOrdenConEnvolturaYNotas_DeberiaIncluirAmbos()
    {
        // Arrange: Crear una orden completa con todas las opciones
        // Encadenamos los métodos para sobreescribir los valores por defecto
        var order = new PurchaseOrderBuilder("Lucía Gómez", "Smartphone")
            .WithQuantity(2)
            .WithShipping("Express")
            .WithGiftWrap()
            .WithNotes("Entregar en horario de oficina")
            .Build();
 
        // Act: Generar el resumen de la orden
        var resumen = order.Summary();
 
        // Assert: Verificar que el resumen incluya todas las opciones configuradas
        Assert.Equal("Lucía Gómez ordenó 2 unidad(es) de Smartphone con envío Express y envoltura de regalo. Nota: Entregar en horario de oficina", resumen);
    }
 
    /// <summary>
    /// Verifica que una orden con envoltura de regalo pero sin notas
    /// genera un resumen correcto que omite la sección de notas.
    /// </summary>
    /// <remarks>
    /// Esta prueba valida:
    /// <list type="bullet">
    /// <item><description>El manejo correcto de campos opcionales no configurados</description></item>
    /// <item><description>Se usa Quantity=1 por defecto</description></item>
    /// <item><description>Se usa ShippingMethod="Estándar" por defecto</description></item>
    /// <item><description>Notes se mantiene como string.Empty cuando no se configura</description></item>
    /// <item><description>El resumen no incluye la sección de notas cuando está vacía</description></item>
    /// </list>
    /// </remarks>
    [Fact]
    public void CrearOrdenSinNotas_DeberiaOmitirNotas()
    {
        // Arrange: Crear una orden con envoltura pero sin notas
        // Se usan Quantity=1 y Shipping=Estándar por defecto
        // Notes se queda como string.Empty (por defecto)
        var order = new PurchaseOrderBuilder("Pedro", "Monitor")
            .WithGiftWrap()
            .Build();
 
        // Act: Generar el resumen de la orden
        var resumen = order.Summary();
 
        // Assert: Verificar que el resumen incluya la envoltura pero omita las notas
        Assert.Equal("Pedro ordenó 1 unidad(es) de Monitor con envío Estándar y envoltura de regalo.", resumen);
    }
}