using OSA.Database.Interfaces;

namespace OSA.Database.Infrastructure
{
    public interface IUnitOfWork/* : IDisposable*/
    {
        Task<int> SaveChanges();
        IUserRepository UserRepository { get; }
        ICompanyRepository CompanyRepository { get; }
    }
}
