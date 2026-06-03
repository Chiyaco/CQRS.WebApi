namespace SaaSPlatform.Domain.Entities.Customer;

public sealed class Email
{
    public string Value { get; }

    private Email() { }

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("Email address is required");

        if (!IsValid(email))
            throw new ArgumentException("The email address is not valid.");

        Value = email;
    }

    protected static bool IsValid(string email)
    {
        return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
    }

    public override string ToString() => Value;
}
