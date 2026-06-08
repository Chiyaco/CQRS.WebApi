namespace SaaSPlatform.Domain.Entities.Customer;

public class Customer : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Email Email { get; private set; }

    private Customer() { }

    public Customer(string firstName, string lastName, Email email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(nameof(firstName), "first name should not be null");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException(nameof(lastName),"last name should not be null");

        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CreatedDateTime = DateTime.UtcNow;
    }

    public void ChangeEmailAddress(Email email)
    {
        Email = email;
        Touch();
    }
}
