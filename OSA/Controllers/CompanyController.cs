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

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("AddAsync")]
        public async Task<bool> AddAsync(UserRequest request)
        {
            var d = await _companyService.AddAsync(new AddCompanyDto());
            return true;
        }
    }
}
