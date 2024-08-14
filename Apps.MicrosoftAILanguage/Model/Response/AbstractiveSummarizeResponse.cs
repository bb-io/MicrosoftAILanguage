namespace Apps.MicrosoftAILanguage.Model.Response
{
    public class AbstractiveSummarizeResponse
    {
        public AbstractiveSummarizeResponse()
        {
            Summaries = new();
        }

        public List<CustomAbstractiveSummary> Summaries { get; set; }
    }

    public class CustomAbstractiveSummary
    {
        public CustomAbstractiveSummary()
        {
            Contexts = new();
        }

        public string Text { get; set; }

        public List<AbstractiveSummaryContext> Contexts { get; set; }
    }

    public class AbstractiveSummaryContext
    {
        public int Length { get; set; }
        public int Offset { get; set; }
    }
}
