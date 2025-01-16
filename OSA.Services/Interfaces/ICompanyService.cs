using OSA.ServiceEntities;

namespace OSA.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllAsync();
        Task<bool> AddAsync(AddCompanyDto requestDto);
        Task<bool> UpdateAsync(UpdateCompanyDto requestDto);
        Task<CompanyDto> GetByIdAsync(GetByIdCompanyDto requestDto);
        Task<bool> DeleteAsync(DeleteCompanyDto requestDto);
    }
}
