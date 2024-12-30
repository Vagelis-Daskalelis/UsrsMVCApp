using AutoMapper;
using UsrsMVCApp.DTO;
using UsrsMVCApp.Models;
using UsrsMVCApp.Repositories;

namespace UsrsMVCApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;

        public UserService(IUnitOfWork? unitOfWork, IMapper? mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var user = await _unitOfWork!.UserRepository!.GetByUsernameAsync(username!);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _unitOfWork!.UserRepository!.GetUserAync(userLoginDTO!.Username!, userLoginDTO!.Password!);
            if (user is null) 
            {
                return null;
            }
            return user;
        }

        public async Task SignUpUserAsync(UserSignUpDTO userSignUpDTO)
        {
            var user = _mapper!.Map<User>(userSignUpDTO);
            bool isUserExists = await _unitOfWork!.UserRepository.SignUpUserAsync(user);
            if (!isUserExists) 
            {
                throw new ApplicationException("User already exists");
            }
            await _unitOfWork!.SaveAsync();
        }
    }
}
