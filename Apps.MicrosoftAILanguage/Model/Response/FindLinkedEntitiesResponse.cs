using Azure.AI.TextAnalytics;
using Blackbird.Applications.Sdk.Common;

namespace Apps.MicrosoftAILanguage.Model.Response
{
    public class FindLinkedEntitiesResponse
    {
        [Display("Linked entities")]
        public List<CustomLinkedEntity> LinkedEntities { get; set; }
    }

    public class CustomLinkedEntity
    {
        public CustomLinkedEntity(LinkedEntity linkedEntity)
        {
            Name = linkedEntity.Name;
            Url = linkedEntity.Url.ToString();
            Language = linkedEntity.Language;
            DataSource = linkedEntity.DataSource;
            DataSourceEntityId = linkedEntity.DataSourceEntityId;
            BindEntitySearchApiId = linkedEntity.BindEntitySearchApiId;
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }

        [Display("Data source")]
        public string DataSource { get; set; }

        [Display("Data source entity ID")]
        public string DataSourceEntityId { get; set; }

        [Display("Bind entity search API ID")]
        public string BindEntitySearchApiId { get; set; }
    }
}
