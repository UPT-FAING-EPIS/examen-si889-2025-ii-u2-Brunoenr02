namespace OrderApp;

/// <summary>
/// Implementa el patrón Builder para la creación fluida y flexible de objetos <see cref="PurchaseOrder"/>.
/// Este builder proporciona valores por defecto razonables y permite configurar solo las propiedades necesarias.
/// </summary>
/// <remarks>
/// El patrón Builder es especialmente útil cuando una clase tiene muchos parámetros opcionales.
/// Proporciona una interfaz fluida que mejora la legibilidad del código.
/// 
/// <para>
/// Valores por defecto:
/// <list type="bullet">
/// <item><description>Quantity: 1</description></item>
/// <item><description>ShippingMethod: "Estándar"</description></item>
/// <item><description>GiftWrap: false</description></item>
/// <item><description>Notes: string.Empty</description></item>
/// </list>
/// </para>
/// </remarks>
/// <example>
/// Ejemplo de uso básico:
/// <code>
/// var order = new PurchaseOrderBuilder("Carlos Ruiz", "Tablet")
///     .WithQuantity(2)
///     .WithShipping("Express")
///     .WithGiftWrap()
///     .WithNotes("Entregar en horario de oficina")
///     .Build();
/// </code>
/// </example>
public class PurchaseOrderBuilder
{
    /// <summary>
    /// Nombre del cliente (campo obligatorio).
    /// </summary>
    private readonly string _customerName;
    
    /// <summary>
    /// Nombre del producto (campo obligatorio).
    /// </summary>
    private readonly string _product;
    
    /// <summary>
    /// Cantidad de unidades. Valor por defecto: 1.
    /// </summary>
    private int _quantity = 1;
    
    /// <summary>
    /// Método de envío. Valor por defecto: "Estándar".
    /// </summary>
    private string _shippingMethod = "Estándar";
    
    /// <summary>
    /// Indica si incluye envoltura de regalo. Valor por defecto: false.
    /// </summary>
    private bool _giftWrap = false;
    
    /// <summary>
    /// Notas adicionales. Valor por defecto: string.Empty.
    /// </summary>
    private string _notes = string.Empty;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="PurchaseOrderBuilder"/> con los campos obligatorios.
    /// </summary>
    /// <param name="customerName">Nombre del cliente. Campo obligatorio.</param>
    /// <param name="product">Nombre del producto. Campo obligatorio.</param>
    /// <remarks>
    /// Los campos obligatorios se establecen en el constructor para garantizar que una orden
    /// siempre tenga la información mínima necesaria.
    /// </remarks>
    /// <example>
    /// <code>
    /// var builder = new PurchaseOrderBuilder("María López", "Smartphone");
    /// </code>
    /// </example>
    public PurchaseOrderBuilder(string customerName, string product)
    {
        _customerName = customerName;
        _product = product;
    }

    /// <summary>
    /// Configura la cantidad de unidades del producto.
    /// </summary>
    /// <param name="quantity">Número de unidades a ordenar.</param>
    /// <returns>La instancia actual del builder para permitir el encadenamiento de métodos.</returns>
    /// <example>
    /// <code>
    /// var builder = new PurchaseOrderBuilder("Cliente", "Producto")
    ///     .WithQuantity(5);
    /// </code>
    /// </example>
    public PurchaseOrderBuilder WithQuantity(int quantity)
    {
        _quantity = quantity;
        return this;
    }

    /// <summary>
    /// Configura el método de envío para la orden.
    /// </summary>
    /// <param name="shippingMethod">Método de envío (ej: "Estándar", "Express", "Internacional").</param>
    /// <returns>La instancia actual del builder para permitir el encadenamiento de métodos.</returns>
    /// <example>
    /// <code>
    /// var builder = new PurchaseOrderBuilder("Cliente", "Producto")
    ///     .WithShipping("Express");
    /// </code>
    /// </example>
    public PurchaseOrderBuilder WithShipping(string shippingMethod)
    {
        _shippingMethod = shippingMethod;
        return this;
    }

    /// <summary>
    /// Habilita la envoltura de regalo para la orden.
    /// </summary>
    /// <returns>La instancia actual del builder para permitir el encadenamiento de métodos.</returns>
    /// <remarks>
    /// Este método establece la propiedad GiftWrap en true. No hay método para deshabilitarlo
    /// ya que el valor por defecto es false.
    /// </remarks>
    /// <example>
    /// <code>
    /// var builder = new PurchaseOrderBuilder("Cliente", "Producto")
    ///     .WithGiftWrap();
    /// </code>
    /// </example>
    public PurchaseOrderBuilder WithGiftWrap()
    {
        _giftWrap = true;
        return this;
    }

    /// <summary>
    /// Agrega notas o instrucciones especiales a la orden.
    /// </summary>
    /// <param name="notes">Texto con las notas o instrucciones adicionales.</param>
    /// <returns>La instancia actual del builder para permitir el encadenamiento de métodos.</returns>
    /// <example>
    /// <code>
    /// var builder = new PurchaseOrderBuilder("Cliente", "Producto")
    ///     .WithNotes("Llamar antes de entregar");
    /// </code>
    /// </example>
    public PurchaseOrderBuilder WithNotes(string notes)
    {
        _notes = notes;
        return this;
    }

    /// <summary>
    /// Construye y retorna una nueva instancia de <see cref="PurchaseOrder"/> con la configuración establecida.
    /// </summary>
    /// <returns>Una nueva instancia inmutable de <see cref="PurchaseOrder"/>.</returns>
    /// <remarks>
    /// Este método debe ser llamado al final de la cadena de configuración para crear el objeto final.
    /// Una vez llamado, el builder puede ser reutilizado para crear otra orden con la misma configuración base.
    /// </remarks>
    /// <example>
    /// <code>
    /// var order = new PurchaseOrderBuilder("Pedro Sánchez", "Monitor")
    ///     .WithQuantity(2)
    ///     .WithShipping("Express")
    ///     .Build();
    /// </code>
    /// </example>
    public PurchaseOrder Build()
    {
        return new PurchaseOrder(
            _customerName,
            _product,
            _quantity,
            _shippingMethod,
            _giftWrap,
            _notes
        );
    }
}