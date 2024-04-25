using Core.Entity;

namespace Core.Input
{
    public class BookDto
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public required string Name { get; set; }

        public required string Publisher { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
