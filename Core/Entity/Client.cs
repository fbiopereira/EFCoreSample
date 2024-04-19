namespace Core.Entity
{
    public class Client : BaseEntity
    {        
        public required string Name{ get; set; }
        
        public DateTime? BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }



    }
}
