
using UsrsMVCApp.Models;

namespace UsrsMVCApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Stdnts5DbContext? _context;

        public IUserRepository UserRepository => new UserRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context!.SaveChangesAsync() > 0; // αυτόματα rollback
        }
    }
}
