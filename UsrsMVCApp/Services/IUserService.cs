using UsrsMVCApp.DTO;
using UsrsMVCApp.Models;

namespace UsrsMVCApp.Services
{
    public interface IUserService
    {
        Task SignUpUserAsync(UserSignUpDTO userSignUpDTO);
        Task<User?> LoginUserAsync(UserLoginDTO userLoginDTO);
        //Task<User?> UpdateUser(int userId, UserPatchDTO patchDTO);
        Task<User?> GetUserByUsername(string username);
    }
}
