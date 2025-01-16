using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSA.API.Requests;
using OSA.DomainEntities.Users;
using OSA.ServiceEntities;
using OSA.Services.Interfaces;

namespace OSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService
            , IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost("GetAllAsync")]
        public async Task<List<CompanyDto>> GetAllAsync()
        {
            return await _companyService.GetAllAsync();
        }

        [HttpPost("GetByIdAsync")]
        public async Task<CompanyDto> GetByIdAsync(GetByIdCompanyDto request)
        {
            var requestDto = _mapper.Map<GetByIdCompanyDto>(request);
            return await _companyService.GetByIdAsync(requestDto);
        }

        [HttpPost("AddAsync")]
        public async Task<bool> AddAsync(AddCompanyRequest request)
        {
            var requestDto = _mapper.Map<AddCompanyDto>(request);
            var d = await _companyService.AddAsync(requestDto);
            return true;
        }

        [HttpPost("UpdateAsync")]
        public async Task<bool> UpdateAsync(UpdateCompanyRequest request)
        {
            var requestDto = _mapper.Map<UpdateCompanyDto>(request);
            var d = await _companyService.UpdateAsync(requestDto);
            return true;
        }

        [HttpPost("DeleteAsync")]
        public async Task<bool> DeleteAsync(DeleteCompanyRequest request)
        {
            var requestDto = _mapper.Map<DeleteCompanyDto>(request);
            var d = await _companyService.DeleteAsync(requestDto);
            return true;
        }
    }
}
