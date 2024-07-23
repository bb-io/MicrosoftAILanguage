using Blackbird.Applications.Sdk.Common;

namespace Apps.MicrosoftAILanguage.Model.Request
{
    public class DetectLanguageRequest
    {
        [Display("Text for detection")]
        public string TextToDetect { get; set; }
    }
}
