using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using CricketApplicationWebPortal.Authorization.Roles;

namespace CricketApplicationWebPortal.Roles.Dto
{
    public class CreateTeamDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Zone { get; set; }
        public int? TenantId { get; set; }
    }
}
