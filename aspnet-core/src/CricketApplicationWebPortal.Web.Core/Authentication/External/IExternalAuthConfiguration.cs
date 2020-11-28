using System.Collections.Generic;

namespace CricketApplicationWebPortal.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
