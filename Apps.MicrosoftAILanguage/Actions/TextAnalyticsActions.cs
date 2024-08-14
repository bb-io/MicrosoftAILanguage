using Apps.MicrosoftAILanguage.Invocables;
using Apps.MicrosoftAILanguage.Model.Request;
using Apps.MicrosoftAILanguage.Model.Response;
using Azure.AI.TextAnalytics;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.MicrosoftAILanguage.Actions
{
    [ActionList]
    public class TextAnalyticsActions : AILanguageInvocable
    {
        public TextAnalyticsActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Detect language", Description = "Detect language")]
        public async Task<DetectLanguageResponse> DetectLanguage(
            [ActionParameter] TextContentRequest detectLanguageRequest)
        {
            var result = await Client.DetectLanguageAsync(detectLanguageRequest.Text);
            return new(result.Value);
        }

        [Action("Summarize text (abstractive)", Description = "Summarize text (abstractive)")]
        public async Task<AbstractiveSummarizeResponse> SummarizeTextAbstractive(
            [ActionParameter] TextContentRequest textAnalyticsRequest)
        {
            var result = new AbstractiveSummarizeResponse();
            var operation = Client.AbstractiveSummarize(Azure.WaitUntil.Completed, new List<string>() { textAnalyticsRequest.Text });
            await foreach (var documentsInPage in operation.Value)
            {
                foreach (var documentResult in documentsInPage)
                {
                    foreach (var summary in documentResult.Summaries)
                    {
                        var abstractiveSummary = new CustomAbstractiveSummary();
                        abstractiveSummary.Text = summary.Text.Replace("\n", " ");
                        foreach (var context in summary.Contexts)
                        {
                            abstractiveSummary.Contexts.Add(new() { Offset = context.Offset, Length = context.Length });
                        }
                        result.Summaries.Add(abstractiveSummary);
                    }
                }
            }
            return result;
        }

        [Action("Summarize text (extractive)", Description = "Summarize text (extractive)")]
        public async Task<ExtractiveSummarizeResponse> SummarizeTextExtractive(
            [ActionParameter] TextContentRequest textAnalyticsRequest)
        {
            var result = new ExtractiveSummarizeResponse();
            var operation = Client.ExtractiveSummarize(Azure.WaitUntil.Completed, new List<string>() { textAnalyticsRequest.Text });
            await foreach (var documentsInPage in operation.Value)
            {
                foreach (var documentResult in documentsInPage)
                {
                    foreach (var sentence in documentResult.Sentences)
                    {
                        result.Summaries.Add(new()
                        {
                            Sentence = sentence.Text,
                            RankScore = sentence.RankScore,
                            Offset = sentence.Offset,
                            Length = sentence.Length
                        });
                    }
                }
            }
            return result;
        }

        [Action("Extract key phrases", Description = "Extract key phrases")]
        public async Task<ExtractKeyPhrasesResponse> ExtractKeyPhrases(
            [ActionParameter] TextContentRequest extractKeyPhrasesRequest)
        {
            var result = await Client.ExtractKeyPhrasesAsync(extractKeyPhrasesRequest.Text);
            return new()
            {
                KeyPhrases = result.Value.ToList()
            };
        }

        [Action("Find linked entities", Description = "Find linked entities")]
        public async Task<FindLinkedEntitiesResponse> FindLinkedEntities(
            [ActionParameter] TextContentRequest extractKeyPhrasesRequest)
        {
            var result = await Client.RecognizeLinkedEntitiesAsync(extractKeyPhrasesRequest.Text);
            return new()
            {
                LinkedEntities = result.Value.Select(x => new CustomLinkedEntity(x)).ToList()
            };
        }

        [Action("Identify personally identifiable information", Description = "Identify personally identifiable information")]
        public async Task<IndentifyPiiInformationResponse> IndentifyPiiInformation(
            [ActionParameter] TextContentRequest indentifyPerInformationRequest)
        {
            var result = await Client.RecognizePiiEntitiesAsync(indentifyPerInformationRequest.Text);
            return new()
            {
                PiiInformation = result.Value.Select(x => new PiiInformation(x)).ToList()
            };
        }

        //[Action("Recognize custom named entity", Description = "Recognize custom named entity")]
        //public async Task<IndentifyPiiInformationResponse> RecognizeCustomNamedEntity(
        //    [ActionParameter] TextContentRequest indentifyPerInformationRequest)
        //{
        //    var result = await Client.RecognizeCustomEntitiesAsync(indentifyPerInformationRequest.Text);
        //    return new()
        //    {
        //        PiiInformation = result.Value.Select(x => new PiiInformation(x)).ToList()
        //    };
        //}

        [Action("Analyze sentiment", Description = "Analyze sentiment")]
        public async Task<AnalyzeSentimentResponse> AnalyzeSentiment(
            [ActionParameter] TextContentRequest indentifyPerInformationRequest)
        {
            var result = await Client.AnalyzeSentimentAsync(indentifyPerInformationRequest.Text);
            return new()
            {
                Sentiment = result.Value.Sentiment.ToString(),
                Sentences = result.Value.Sentences.Select(x => new CustomSentenceSentiment(x)).ToList(),
                ConfidenceScoreNegative = result.Value.ConfidenceScores.Negative,
                ConfidenceScoreNeutral = result.Value.ConfidenceScores.Neutral,
                ConfidenceScorePositive = result.Value.ConfidenceScores.Positive
            };
        }

        //[Action("Custom classify text", Description = "Custom classify text")]
        //public async Task<AnalyzeSentimentResponse> CustomClassifyText(
        //    [ActionParameter] TextContentRequest indentifyPerInformationRequest)
        //{
        //    var result = await Client.Si(indentifyPerInformationRequest.Text);
        //    return new()
        //    {
        //        Sentiment = result.Value.Sentiment.ToString(),
        //        Sentences = result.Value.Sentences.Select(x => new CustomSentenceSentiment(x)).ToList(),
        //        ConfidenceScoreNegative = result.Value.ConfidenceScores.Negative,
        //        ConfidenceScoreNeutral = result.Value.ConfidenceScores.Neutral,
        //        ConfidenceScorePositive = result.Value.ConfidenceScores.Positive
        //    };
        //}
    }
}
