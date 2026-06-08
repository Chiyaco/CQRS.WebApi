namespace SaaSPlatform.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Name { get; private set; }

    public decimal Price { get; private set; }

    private Product() { }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required.");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        CreatedDateTime = DateTime.Now;
    }

    public void ChangePrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("Price must be greater than zero.");

        Price = price;
        Touch();
    }
}