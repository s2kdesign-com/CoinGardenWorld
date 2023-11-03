using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.Models.Entities;

namespace CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer
{
    public class UnitOfWork<TEntity> : IDisposable where TEntity : BaseEntity
    {
        private readonly MobileAppDbContext _context;
        private readonly GenericRepository<TEntity> _repository;

        public UnitOfWork(MobileAppDbContext context,
            GenericRepository<TEntity> repository)
        {
            _context = context;
            _repository = repository;
        }

        public GenericRepository<TEntity> Repository => _repository;


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
