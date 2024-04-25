using Core.Entity;

namespace Core.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetSixMonthOrders(int id);

    }
}
