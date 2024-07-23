using Azure.AI.TextAnalytics;
using Blackbird.Applications.Sdk.Common;

namespace Apps.MicrosoftAILanguage.Model.Response
{
    public class IndentifyPiiInformationResponse
    {
        [Display("Personally identifiable information")]
        public List<PiiInformation> PiiInformation { get; set; }
    }

    public class PiiInformation
    {
        public PiiInformation(PiiEntity piiEntity)
        {
            Text = piiEntity.Text;
            Length = piiEntity.Length;
            Offset = piiEntity.Offset;
            Category = piiEntity.Category.ToString();
            SubCategory = piiEntity.SubCategory;
            ConfidenceScore = piiEntity.ConfidenceScore;
        }
        public string Text { get; set; }
        public int Length { get; set; }
        public int Offset { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public double ConfidenceScore { get; set; }
    }
}
