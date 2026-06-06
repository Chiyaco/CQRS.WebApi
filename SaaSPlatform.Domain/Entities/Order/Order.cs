namespace SaaSPlatform.Domain.Entities.Order;

public class Order : BaseEntity
{
    private readonly List<OrderItem> _items = new();

    public Guid CustomerId { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order()
    {

    }

    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreatedDateTime = DateTime.UtcNow;
    }

    public void AddItem(
        string productName,
        decimal unitPrice,
        int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be > 0");

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be > 0");

        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Product name is required");

        _items.Add(new OrderItem(productName, unitPrice, quantity));
    }

    public decimal GetTotal => _items.Sum(x => x.TotalPrice);
}
