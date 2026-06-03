namespace SaaSPlatform.Domain.Entities.Customer;

public class Customer : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Email Email { get; private set; }

    private Customer() { }

    public Customer(string firstName, string lastName, Email email)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CreatedDateTime = DateTime.Now;
    }

    public void ChangeEmailAddress(Email email)
    {
        Email = email;
        Touch();
    }
}
