using System.ComponentModel.DataAnnotations.Schema;
using OSA.ServiceEntities;

namespace OSA.DomainEntities.Users
{
    [Table("User")]
    public class User : BaseKey
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
