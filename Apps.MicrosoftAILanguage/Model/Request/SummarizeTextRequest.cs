using Apps.MicrosoftAILanguage.DataSourceHandlers.Enums;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.MicrosoftAILanguage.Model.Request
{
    public class SummarizeTextRequest
    {
        [Display("Summarize type")]
        [StaticDataSource(typeof(SummarizeTypeDataHandler))]
        public string SummarizeType { get; set; }
    }
}
