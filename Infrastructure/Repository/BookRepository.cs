using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class BookRepository:EFRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
    
}
