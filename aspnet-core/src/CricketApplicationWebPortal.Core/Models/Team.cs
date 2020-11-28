using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace CricketApplicationWebPortal.Models
{
    public class Team : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Zone { get; set; }
        public int? TenantId { get; set; }
    }
}
