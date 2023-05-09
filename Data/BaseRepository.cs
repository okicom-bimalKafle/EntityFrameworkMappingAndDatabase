using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMappingAndDatabase.Data
{
    public class BaseRepository<T> where T : class
    {
        private readonly MyDbContext _dbContext;

        public BaseRepository(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task Delete(T entity)
        {
            await Task.Run(() => _dbContext.Set<T>().Remove(entity)).ConfigureAwait(false);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<T?> GetById(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbContext.Set<T>();
        }

        public async Task Insert(T entity)
        {
            await _dbContext.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task Update(T entity)
        {
            EntityEntry entry = _dbContext.Entry<T>(entity);
            entry.State = EntityState.Modified;
            
        }
    }
}
