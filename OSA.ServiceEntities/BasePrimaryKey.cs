using System.ComponentModel.DataAnnotations;

namespace OSA.ServiceEntities
{
    public class BaseKey
    {
        [Key]
        public int Id { get; set; }
    }

    public class ServiceProperties: BaseKey
    {
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
