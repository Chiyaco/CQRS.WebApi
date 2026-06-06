using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSPlatform.Domain.Entities.Customer;

namespace SaaSPlatform.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(300);

        builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("Email");
            }
        );
    }
}
