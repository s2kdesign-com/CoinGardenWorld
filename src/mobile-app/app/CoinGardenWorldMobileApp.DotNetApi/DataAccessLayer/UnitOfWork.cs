using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.Models.Entities;

namespace CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private MobileAppDbContext context = new MobileAppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<MobileAppDbContext>());
        private GenericRepository<Account>? _accountRepository;
        private GenericRepository<Post>? _postRepository;

        public GenericRepository<Account> AccountRepository
        {
            get
            {

                if (this._accountRepository == null)
                {
                    this._accountRepository = new GenericRepository<Account>(context);
                }
                return _accountRepository;
            }
        }

        public GenericRepository<Post> PostRepository
        {
            get
            {

                if (this._postRepository == null)
                {
                    this._postRepository = new GenericRepository<Post>(context);
                }
                return _postRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
