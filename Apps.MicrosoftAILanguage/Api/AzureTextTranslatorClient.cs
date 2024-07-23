using Apps.MicrosoftAILanguage.Constants;
using Azure;
using Azure.AI.TextAnalytics;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.MicrosoftAILanguage.Api;

public class AzureTextTranslatorClient : TextAnalyticsClient
{
    public AzureTextTranslatorClient(AuthenticationCredentialsProvider[] creds) : base(GetUriEndpoint(creds), GetApiKey(creds))
    {
    }

    private static Uri GetUriEndpoint(AuthenticationCredentialsProvider[] creds)
        => new Uri(creds.Get(CredsNames.Endpoint).Value);

    private static AzureKeyCredential GetApiKey(AuthenticationCredentialsProvider[] creds)
        => new(creds.Get(CredsNames.ApiKey).Value);
}