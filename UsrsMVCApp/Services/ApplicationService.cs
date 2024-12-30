using AutoMapper;
using UsrsMVCApp.Repositories;

namespace UsrsMVCApp.Services
{
    public class ApplicationService : IApplicationService
    {

        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;

        public ApplicationService(IUnitOfWork? unitOfWork, IMapper? mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public IUserService userService { get; }

        public IUserService? UserService => new UserService(_unitOfWork, _mapper);
        //public IStudentService studentService => new StudentService(_unitOfWork, _mapper);
    }
}
