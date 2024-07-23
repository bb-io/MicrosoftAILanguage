using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.MicrosoftAILanguage.DataSourceHandlers.Enums
{
    public class SummarizeTypeDataHandler : IStaticDataSourceHandler
    {
        public Dictionary<string, string> GetData()
        {
            return new()
            {
                {"abstractive", "Abstractive" },
                {"extractive", "Extractive" }
            };
        }
    }
}
