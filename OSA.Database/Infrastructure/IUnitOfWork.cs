using OSA.Database.Interfaces;

namespace OSA.Database.Infrastructure
{
    public interface IUnitOfWork/* : IDisposable*/
    {
        IUserRepository UserRepository { get; }
        Task<int> SaveChanges();
    }
}
