using OSA.ServiceEntities;

namespace OSA.DomainEntities
{
    public class Company : AuditProperty
    {
        public string Name { get; set; } = string.Empty;
        public string OldName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CIN { get; set; } = string.Empty;
        public byte[] Logo { get; set; } = new byte[0];
    }
}
