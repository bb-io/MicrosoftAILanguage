using Azure.AI.TextAnalytics;
using Blackbird.Applications.Sdk.Common;

namespace Apps.MicrosoftAILanguage.Model.Response
{
    public class AnalyzeSentimentResponse
    {
        public string Sentiment { get; set; }

        public List<CustomSentenceSentiment> Sentences { get; set; }

        [Display("Confidence score - negative")]
        public double ConfidenceScoreNegative { get; set; }

        [Display("Confidence score - neutral")]
        public double ConfidenceScoreNeutral { get; set; }

        [Display("Confidence score - positive")]
        public double ConfidenceScorePositive { get; set; }
    }

    public class CustomSentenceSentiment
    {
        public CustomSentenceSentiment(SentenceSentiment sentenceSentiment)
        {
            Text = sentenceSentiment.Text;
            Sentiment = sentenceSentiment.Sentiment.ToString();
            Offset = sentenceSentiment.Offset;
            Length = sentenceSentiment.Length;
            ConfidenceScoreNegative = sentenceSentiment.ConfidenceScores.Negative;
            ConfidenceScoreNeutral = sentenceSentiment.ConfidenceScores.Neutral;
            ConfidenceScorePositive = sentenceSentiment.ConfidenceScores.Positive;
        }

        public string Text { get; set; }
        public string Sentiment { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }

        [Display("Confidence score - negative")]
        public double ConfidenceScoreNegative { get; set; }

        [Display("Confidence score - neutral")]
        public double ConfidenceScoreNeutral { get; set; }

        [Display("Confidence score - positive")]
        public double ConfidenceScorePositive { get; set; }
    }
}
