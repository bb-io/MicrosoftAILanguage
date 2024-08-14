using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.MicrosoftAILanguage;

public class MSAILanguageApplication : IApplication, ICategoryProvider
{
    public string Name
    {
        get => "Microsoft AI Language";
        set { }
    }

    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.AzureApps, ApplicationCategory.ArtificialIntelligence];
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}