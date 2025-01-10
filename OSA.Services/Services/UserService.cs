using OSA.Database.Infrastructure;
using OSA.DomainEntities.Users;
using OSA.Services.Interfaces;

namespace OSA.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uniOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<User> Add(User requestDto)
        {
            try
            {
                var data = _uniOfWork.UserRepository.Add(requestDto);
                await _uniOfWork.SaveChanges();
                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<User>> GetAsync()
        {
            return _uniOfWork.UserRepository.GetAll();
        }
    }
}