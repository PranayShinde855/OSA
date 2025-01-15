using AutoMapper;
using OSA.Database.Infrastructure;
using OSA.DomainEntities;
using OSA.ServiceEntities;
using OSA.Services.Interfaces;

namespace OSA.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(AddCompanyDto requestDto)
        {
            var company = _mapper.Map<Company>(requestDto);
            await _unitOfWork.CompanyRepository.AddAsync(company);
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(DeleteCompanyDto requestDto)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(requestDto.Id);
            company.IsActive = false;
            _unitOfWork.CompanyRepository.Update(company);
            return true;
        }

        public Task<CompanyDto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyDto> GetByIdAsync(GetByIdCompanyDto requestDto)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(requestDto.Id);
            var result = _mapper.Map<CompanyDto>(company);
            return result;
        }

        public async Task<bool> UpdateAsync(UpdateCompanyDto requestDto)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(requestDto.Id);
            company = _mapper.Map<Company>(requestDto);
            _unitOfWork.CompanyRepository.Update(company);
            return true;
        }
    }
}
