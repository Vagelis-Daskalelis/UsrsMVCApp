using UsrsMVCApp.Models;

namespace UsrsMVCApp.Repositories
{
    public interface IUserRepository
    {
        Task<bool> SignUpUserAsync(User user);
        Task<User> GetUserAync(string username, string password);
        //Task<User> UpdateUserAsync(int userId, UserPatchDTO user);
        Task<User> GetByUsernameAsync(string username);
    }
}
