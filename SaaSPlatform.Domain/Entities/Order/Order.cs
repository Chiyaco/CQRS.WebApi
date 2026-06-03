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
        CreatedDateTime = DateTime.Now;
    }

    public void AddItem(
        Guid orderId,
        string productName,
        decimal unitPrice,
        int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException();

        _items.Add(new OrderItem(
            orderId,
            productName,
            unitPrice,
            quantity));
    }

    public decimal GetTotal => _items.Sum(x => x.TotalPrice);
}
