namespace Core.Entity
{
    public class Order : BaseEntity
    {        
        public int ClientId{ get; set; }
        public int BookId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Book Book { get; set; }

    }
}
