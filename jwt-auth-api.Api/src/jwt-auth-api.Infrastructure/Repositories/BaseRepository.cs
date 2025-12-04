using jwt_auth_api.Core;
using jwt_auth_api.Infrastructure.Context;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace jwt_auth_api.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepositoriy<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public Guid Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Delete(Guid id)
        {
            var entity = ReadById(id);

            if (entity == null)
                return;

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }

        public List<T> Read()
        {
            return _dbSet.ToList();
        }

        public T ReadById(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity is null)
                throw new KeyNotFoundException($"Entity com id {id} não encontrada.");
            return entity;
        }

        public void Update(T entity)
        {
            var modelOriginal = ReadById(entity.Id);
            if (modelOriginal == null)
                return;
            _context.Entry(modelOriginal).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
