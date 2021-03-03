using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace CricketApplicationWebPortal.Models
{
    public class BattingStyle : FullAuditedEntity<int>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}