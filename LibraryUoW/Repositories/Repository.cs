using LibraryUoW.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryUoW.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BooksContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(BooksContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public void Update(T entity) => _dbSet.Update(entity);
    }
}
