namespace CQRS.WebApi.Data
{
    public interface IAuditEntity
    {
        DateTime CreatedAt { get; set; }

        DateTime ModifiedAt { get; set; }
    }
}
