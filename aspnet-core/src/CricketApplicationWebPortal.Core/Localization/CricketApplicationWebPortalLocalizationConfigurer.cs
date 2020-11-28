using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CricketApplicationWebPortal.Localization
{
    public static class CricketApplicationWebPortalLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CricketApplicationWebPortalConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CricketApplicationWebPortalLocalizationConfigurer).GetAssembly(),
                        "CricketApplicationWebPortal.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
