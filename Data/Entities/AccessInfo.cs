using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class AccessInfo
    {
        [Key]
        public int Id { get; set; }             
        public int? AccessLevel { get; set; }
        public int? NotificationLevel { get; set; }        
    }
}
