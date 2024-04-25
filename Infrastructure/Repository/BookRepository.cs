using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class BookRepository:EFRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void BulkAdd(IEnumerable<Book> books)
        {
            var time1 = System.Diagnostics.Stopwatch.StartNew();
            
            _context.AddRange(books);
            _context.SaveChanges();

            time1.Stop();
            var milliseconds1 = time1.ElapsedMilliseconds;
            
            var time2 = System.Diagnostics.Stopwatch.StartNew();
            
            _context.BulkInsert(books);

            time2.Stop();
            var milliseconds2 = time2.ElapsedMilliseconds;

            System.Diagnostics.Debug.WriteLine($"EF Core: {milliseconds1}ms, EF Core Plus: {milliseconds2}ms");

        }
    }
    
}
