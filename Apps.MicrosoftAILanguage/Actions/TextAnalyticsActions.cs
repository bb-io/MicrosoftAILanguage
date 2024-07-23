using Apps.MicrosoftAILanguage.Invocables;
using Apps.MicrosoftAILanguage.Model.Request;
using Apps.MicrosoftAILanguage.Model.Response;
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

        [Action("Summarize text", Description = "Summarize text")]
        public async Task SummarizeText(
            [ActionParameter] TextContentRequest textAnalyticsRequest,
            [ActionParameter] SummarizeTextRequest summarizeTextRequest)
        {
            //if(summarizeTextRequest.SummarizeType == "abstractive")
            //{
            //}
            //else
            //{
            //    var result = await Client.ExtractiveSummarizeAsync(Azure.WaitUntil.Completed, new List<string>() { textAnalyticsRequest.Text });
            //    return result.GetValues()..Select(x => x.)
            //}
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
    }
}
