using OSA.DomainEntities.Users;

namespace OSA.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Add(User requestDto);
        Task<List<User>> GetAsync();
    }
}
