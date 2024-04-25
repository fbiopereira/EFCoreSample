using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClientRepository : EFRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Client GetSixMonthOrders(int id)
        {
            var client = _context.Client
                .Include(c => c.Orders)
                .ThenInclude(o => o.Book)                
                .FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Client not found");

            // O select é necessário para não ocorrer erro de referência circular
            client.Orders = client.Orders.Where(o => o.CreationDate >= DateTime.Now.AddMonths(-6))
                .Select(o =>
                {
                    o.Client = null;
                    o.Book.Orders = null;
                    return o;
                })
                .ToList();

            return client;
        }
    }
}
