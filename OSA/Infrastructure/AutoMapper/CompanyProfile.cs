using AutoMapper;
using OSA.API.Requests;
using OSA.DomainEntities;
using OSA.ServiceEntities;

namespace OSA.API.Infrastructure.AutoMapper
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyRequest, CompanyDto>();   
            CreateMap<Company, CompanyDto>().ReverseMap();   
            CreateMap<AddCompanyRequest, AddCompanyDto>();   
            CreateMap<UpdateCompanyRequest, UpdateCompanyDto>();   
            CreateMap<DeleteCompanyRequest, DeleteCompanyDto>();   
            CreateMap<GetByIdCompanyRequest, GetByIdCompanyDto>();   
        }
    }
}
