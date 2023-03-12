using CQRS.WebApi.Data;

namespace CQRS.WebApi.Entity
{
    public class Product : BaseEntity, IAuditEntity
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public bool IsActive { get; set; } 

        public string Description { get; set; }

        public decimal Rate { get; set; }

        public decimal BuyingPrice { get; set; }

        public string ConfidentialData { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
