using Microsoft.EntityFrameworkCore;
using UsrsMVCApp.Models;
using UsrsMVCApp.Security;

namespace UsrsMVCApp.Repositories
{
    public class UserRepository : BaseReposiroty<User>, IUserRepository
    {
        public UserRepository(Stdnts5DbContext context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context!.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserAync(string username, string password)
        {
           var user = await _context!.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is null) 
            {
                return null;
            }
            if (!EncryptitionUtil.IsValidPassword(password, user.Password)) 
            {
                return null;
            }

            return user;
        }

        public Task<bool> SignUpUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
