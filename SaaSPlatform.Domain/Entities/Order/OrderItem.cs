namespace SaaSPlatform.Domain.Entities.Order;

public class OrderItem
{
    public Guid OrderId { get; private set; }

    public string ProductName { get; private set; }

    public decimal UnitPrice { get; private set; }

    public int Quantity { get; private set; }

    public decimal TotalPrice => Quantity * UnitPrice;

    private OrderItem()
    {

    }

    public OrderItem(Guid orderId, string productName, decimal unitPrice, int quantity)
    {
        OrderId = orderId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}