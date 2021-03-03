using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using CricketApplicationWebPortal.Authorization.Roles;

namespace CricketApplicationWebPortal.Roles.Dto
{
    public class TeamDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Zone { get; set; }
        public int? TenantId { get; set; }
    }
}