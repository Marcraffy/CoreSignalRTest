using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CoreSignalRTest.Localization
{
    public static class CoreSignalRTestLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CoreSignalRTestConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CoreSignalRTestLocalizationConfigurer).GetAssembly(),
                        "CoreSignalRTest.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
