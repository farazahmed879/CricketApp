using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CricketApplicationWebPortal.Models
{
    public class Team : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Zone { get; set; }
        public bool IsRegistered { get; set; }
        public string FileName { get; set; }
        public List<Player> Players { get; set; }
        public string Contact { get; set; }
        public int? OwnerId { get; set; }
        public int? TenantId { get; set; }
        
    }
}

