using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace CricketApplicationWebPortal.Models
{
    public class PlayerRole : FullAuditedEntity<int>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}