namespace OrderApp;

public class PurchaseOrderBuilder
{
    // Campos privados para almacenar el estado de la construcción
    private readonly string _customerName;
    private readonly string _product;
    private int _quantity = 1; // Valor por defecto
    private string _shippingMethod = "Estándar"; // Valor por defecto
    private bool _giftWrap = false; // Valor por defecto
    private string _notes = string.Empty; // Valor por defecto

    // Forzamos los campos requeridos (Cliente y Producto) en el constructor del Builder
    public PurchaseOrderBuilder(string customerName, string product)
    {
        _customerName = customerName;
        _product = product;
    }

    // Métodos "Fluent" para configurar las opciones
    
    public PurchaseOrderBuilder WithQuantity(int quantity)
    {
        _quantity = quantity;
        return this; // Permite encadenar métodos
    }

    public PurchaseOrderBuilder WithShipping(string shippingMethod)
    {
        _shippingMethod = shippingMethod;
        return this;
    }

    // Un método simple para una opción booleana
    public PurchaseOrderBuilder WithGiftWrap()
    {
        _giftWrap = true;
        return this;
    }

    public PurchaseOrderBuilder WithNotes(string notes)
    {
        _notes = notes;
        return this;
    }

    // El método final que construye y devuelve el objeto
    public PurchaseOrder Build()
    {
        // Aquí se llama al constructor de la clase real
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