using Core.Entity;

namespace Core.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        void BulkAdd(IEnumerable<Book> books);
    }
}
