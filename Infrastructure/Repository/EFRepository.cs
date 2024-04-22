using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            entity.CreationDate = DateTime.Now;
            _dbSet.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
            SaveChanges();
        }

        public IList<T> GetAll()        
            => _dbSet.ToList();
        

        public T GetById(int id)        
            => _dbSet.FirstOrDefault(entity => entity.Id == id);            
        

        public void Update(T entity)
        {
           _dbSet.Update(entity);
            SaveChanges();

        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
