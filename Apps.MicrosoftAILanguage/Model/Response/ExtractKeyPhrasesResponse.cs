using Blackbird.Applications.Sdk.Common;

namespace Apps.MicrosoftAILanguage.Model.Response
{
    public class ExtractKeyPhrasesResponse
    {
        [Display("Key phrases")]
        public List<string> KeyPhrases { get; set; }
    }
}
