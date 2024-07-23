namespace Apps.MicrosoftAILanguage.Model.Response
{
    public class ExtractiveSummarizeResponse
    {
        public List<CustomExtractiveSummary> Summaries { get; set; }
    }

    public class CustomExtractiveSummary
    {
        public string Sentence { get; set; }
        public double RankScore { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }
}
