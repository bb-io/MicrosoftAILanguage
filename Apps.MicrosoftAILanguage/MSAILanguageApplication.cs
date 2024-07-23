using Blackbird.Applications.Sdk.Common;

namespace Apps.MicrosoftAILanguage;

public class MSAILanguageApplication : IApplication
{
    public string Name
    {
        get => "Azure Text Translator";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}