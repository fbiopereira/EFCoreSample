namespace Core.Entity
{
    public class Client : BaseEntity
    {        
        public required string Name{ get; set; }
        
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }



    }
}
