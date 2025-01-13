namespace OSA.ServiceEntities
{
    public class CompanyDto
    {
        public string Name { get; set; } = string.Empty;
        public string OldName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CIN { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }

    public class AddCompanyDto
    {
        public string Name { get; set; } = string.Empty;
        public string OldName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CIN { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }
    
    public class UpdateCompanyDto : BaseIdKey
    {
        public string Name { get; set; } = string.Empty;
        public string OldName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CIN { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }

    public class CompanyGetByIdDto : BaseIdKey
    {
    }

    public class DeleteCompanyDto : BaseIdKey
    {
    }
}
