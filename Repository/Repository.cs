using Microsoft.EntityFrameworkCore;
using repository_pattern.Interfaces;
using repository_pattern.Models;

namespace repository_pattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RepositoryPatternContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(RepositoryPatternContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
