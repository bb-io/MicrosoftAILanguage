using Azure.AI.TextAnalytics;
using Blackbird.Applications.Sdk.Common;

namespace Apps.MicrosoftAILanguage.Model.Response
{
    public class DetectLanguageResponse
    {
        public DetectLanguageResponse(DetectedLanguage detectedLanguage)
        {
            Language = detectedLanguage.Name;
            LanguageCode = detectedLanguage.Iso6391Name;
            ConfidenceScore = detectedLanguage.ConfidenceScore;
        }

        [Display("Language")]
        public string Language { get; set; }

        [Display("Language code", Description = "ISO 6391")]
        public string LanguageCode { get; set; }

        [Display("Confidence score")]
        public double ConfidenceScore { get; set; }
    }
}
