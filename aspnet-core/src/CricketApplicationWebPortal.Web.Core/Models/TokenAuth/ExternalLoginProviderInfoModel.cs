using Abp.AutoMapper;
using CricketApplicationWebPortal.Authentication.External;

namespace CricketApplicationWebPortal.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
