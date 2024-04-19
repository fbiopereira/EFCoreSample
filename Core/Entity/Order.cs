namespace Core.Entity
{
    public class Order : BaseEntity
    {        
        public int ClientId{ get; set; }
        public int BookId { get; set; }

        public Client Client { get; set; }
        public Book Book { get; set; }

    }
}
