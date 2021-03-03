using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricketApplicationWebPortal.Models
{
    public class Player : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string PlayerName { get; set; }
        public string Contact { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public int? BattingStyleId { get; set; }
        [ForeignKey("BattingStyleId")]
        public BattingStyle BattingStyle { get; set; }
        public int? BowlingStyleId { get; set; }
        [ForeignKey("BowlingStyleId")]
        public BowlingStyle BowlingStyle { get; set; }
        public long TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public DateTime? DOB  { get; set; }
        public int? PlayerRoleId { get; set; }
        [ForeignKey("PlayerRoleId")]
        public PlayerRole PlayerRole { get; set; }
        public string IsGuestorRegistered { get; set; }
        public bool IsDeactivated { get; set; }
        public int? TenantId { get; set; }
        public string Description { get; set; }

    }

}