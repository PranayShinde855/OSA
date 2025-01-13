using OSA.Database.Infrastructure;
using OSA.ServiceEntities;
using OSA.Services.Interfaces;

namespace OSA.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> AddAsync(AddCompanyDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(DeleteCompanyDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDto> GetByIdAsync(CompanyGetByIdDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(UpdateCompanyDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
