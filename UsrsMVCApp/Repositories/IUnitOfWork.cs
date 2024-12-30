namespace UsrsMVCApp.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        //public IStudentRepository StudentRepository { get; }

        Task<bool> SaveAsync();
    }
}
