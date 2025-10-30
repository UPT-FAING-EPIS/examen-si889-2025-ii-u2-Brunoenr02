namespace OrderApp;

public class PurchaseOrder
{
    // Propiedades de solo lectura (inmutables después de la creación)
    public string CustomerName { get; }
    public string Product { get; }
    public int Quantity { get; }
    public string ShippingMethod { get; }
    public bool GiftWrap { get; }
    public string Notes { get; }

    // El constructor ahora asigna todas las propiedades.
    // Lo hacemos 'public' para que el Builder (que puede estar en otro archivo) pueda llamarlo.
    public PurchaseOrder(string customerName, string product, int quantity, 
                         string shippingMethod, bool giftWrap, string notes)
    {
        // Podríamos agregar validaciones aquí (ej. Quantity > 0)
        if (string.IsNullOrEmpty(customerName))
            throw new ArgumentNullException(nameof(customerName));
        if (string.IsNullOrEmpty(product))
            throw new ArgumentNullException(nameof(product));
            
        CustomerName = customerName;
        Product = product;
        Quantity = quantity;
        ShippingMethod = shippingMethod;
        GiftWrap = giftWrap;
        Notes = notes ?? string.Empty; // Asegurarnos de no tener un 'null'
    }

 
    // El método Summary no necesita cambios
    public string Summary()
    {
        return $"{CustomerName} ordenó {Quantity} unidad(es) de {Product} con envío {ShippingMethod}" +
               (GiftWrap ? " y envoltura de regalo." : ".") +
               (!string.IsNullOrEmpty(Notes) ? $" Nota: {Notes}" : "");
    }
}