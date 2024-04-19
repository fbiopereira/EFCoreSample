namespace Core.Entity
{
    public class Book: BaseEntity
    {        
        public required string Name { get; set; }

        public required string Publisher { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
