namespace OrderApp;

/// <summary>
/// Representa una orden de compra inmutable con información del cliente, producto y opciones de envío.
/// Esta clase implementa el patrón de objeto inmutable, donde todas las propiedades son de solo lectura
/// y se establecen en el momento de la construcción.
/// </summary>
/// <remarks>
/// Se recomienda utilizar la clase <see cref="PurchaseOrderBuilder"/> para crear instancias de esta clase
/// de manera más flexible y legible.
/// </remarks>
public class PurchaseOrder
{
    /// <summary>
    /// Obtiene el nombre del cliente que realiza la orden.
    /// </summary>
    /// <value>Nombre completo del cliente. No puede ser nulo ni vacío.</value>
    public string CustomerName { get; }
    
    /// <summary>
    /// Obtiene el nombre del producto ordenado.
    /// </summary>
    /// <value>Nombre del producto. No puede ser nulo ni vacío.</value>
    public string Product { get; }
    
    /// <summary>
    /// Obtiene la cantidad de unidades del producto.
    /// </summary>
    /// <value>Número entero que representa las unidades ordenadas.</value>
    public int Quantity { get; }
    
    /// <summary>
    /// Obtiene el método de envío seleccionado para la orden.
    /// </summary>
    /// <value>Método de envío (ej: "Estándar", "Express").</value>
    public string ShippingMethod { get; }
    
    /// <summary>
    /// Indica si la orden incluye envoltura de regalo.
    /// </summary>
    /// <value><c>true</c> si incluye envoltura de regalo; de lo contrario, <c>false</c>.</value>
    public bool GiftWrap { get; }
    
    /// <summary>
    /// Obtiene las notas adicionales para la orden.
    /// </summary>
    /// <value>Notas o instrucciones especiales. Retorna cadena vacía si no hay notas.</value>
    public string Notes { get; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="PurchaseOrder"/>.
    /// </summary>
    /// <param name="customerName">Nombre del cliente. No puede ser nulo ni vacío.</param>
    /// <param name="product">Nombre del producto. No puede ser nulo ni vacío.</param>
    /// <param name="quantity">Cantidad de unidades del producto.</param>
    /// <param name="shippingMethod">Método de envío seleccionado.</param>
    /// <param name="giftWrap">Indica si incluye envoltura de regalo.</param>
    /// <param name="notes">Notas o instrucciones adicionales. Puede ser nulo.</param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="customerName"/> o <paramref name="product"/> son nulos o vacíos.
    /// </exception>
    /// <example>
    /// <code>
    /// var order = new PurchaseOrder("Juan Pérez", "Laptop", 1, "Express", false, "Entregar en oficina");
    /// </code>
    /// </example>
    public PurchaseOrder(string customerName, string product, int quantity, 
                         string shippingMethod, bool giftWrap, string notes)
    {
        // Validación de campos obligatorios
        if (string.IsNullOrEmpty(customerName))
            throw new ArgumentNullException(nameof(customerName));
        if (string.IsNullOrEmpty(product))
            throw new ArgumentNullException(nameof(product));
            
        CustomerName = customerName;
        Product = product;
        Quantity = quantity;
        ShippingMethod = shippingMethod;
        GiftWrap = giftWrap;
        Notes = notes ?? string.Empty;
    }

    /// <summary>
    /// Genera un resumen textual de la orden de compra.
    /// </summary>
    /// <returns>
    /// Una cadena que describe la orden completa, incluyendo cliente, producto, cantidad, 
    /// método de envío, envoltura de regalo (si aplica) y notas (si existen).
    /// </returns>
    /// <example>
    /// <code>
    /// var order = new PurchaseOrder("Ana García", "Tablet", 2, "Estándar", true, "Urgente");
    /// string resumen = order.Summary();
    /// // Resultado: "Ana García ordenó 2 unidad(es) de Tablet con envío Estándar y envoltura de regalo. Nota: Urgente"
    /// </code>
    /// </example>
    public string Summary()
    {
        return $"{CustomerName} ordenó {Quantity} unidad(es) de {Product} con envío {ShippingMethod}" +
               (GiftWrap ? " y envoltura de regalo." : ".") +
               (!string.IsNullOrEmpty(Notes) ? $" Nota: {Notes}" : "");
    }
}