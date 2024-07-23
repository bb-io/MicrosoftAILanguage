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
            [ActionParameter] DetectLanguageRequest detectLanguageRequest)
        {
            var result = await Client.DetectLanguageAsync(detectLanguageRequest.TextToDetect);
            return new(result.Value);
        }
    }
}
