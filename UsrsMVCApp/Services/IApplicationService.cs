namespace UsrsMVCApp.Services
{
    public interface IApplicationService
    {
        public IUserService? UserService {  get; }
        //public IStudentService? StudentService {  get; }
    }
}
