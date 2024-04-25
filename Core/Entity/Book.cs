namespace Core.Entity
{
    public class Book: BaseEntity
    {        
        public required string Name { get; set; }

        public required string Publisher { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Book()
        {
            CreationDate = DateTime.Now;
        }

    }
}
