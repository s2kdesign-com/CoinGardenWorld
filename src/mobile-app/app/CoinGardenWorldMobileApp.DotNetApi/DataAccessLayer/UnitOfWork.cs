using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.Models.Entities;

namespace CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private readonly MobileAppDbContext _context;
        private readonly GenericRepository<Account>? _accountRepository;
        private readonly GenericRepository<Post>? _postRepository;
        private readonly GenericRepository<Flower>? _flowerRepository;

        public UnitOfWork(MobileAppDbContext context,
            GenericRepository<Account> accountRepository,
            GenericRepository<Flower> flowerRepository,
                GenericRepository<Post> postRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _postRepository = postRepository;  
            _flowerRepository = flowerRepository;
        }

        public GenericRepository<Account> AccountRepository => _accountRepository;

        public GenericRepository<Post> PostRepository => _postRepository;
        public GenericRepository<Flower> FlowerRepository => _flowerRepository;

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
