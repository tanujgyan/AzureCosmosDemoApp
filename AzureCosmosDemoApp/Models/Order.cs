using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureCosmosDemoApp.Models
{
    public class Order
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "orderstatusid")]
        public long OrderStatusId { get; set; }
        [JsonProperty(PropertyName = "billingstatusid")]
        public long? BillingStatusId { get; set; }
        [JsonProperty(PropertyName = "lobid")]
        public long? LobId { get; set; }
        [JsonProperty(PropertyName = "regionid")]
        public long? RegionId { get; set; }
        [JsonProperty(PropertyName = "orderingtransitid")]
        public long? OrderingTransitId { get; set; }
        [JsonProperty(PropertyName = "securedpartytransitid")]
        public long? SecuredPartyTransitId { get; set; }
        [JsonProperty(PropertyName = "responsibilitytransitid")]
        public long? ResponsibilityTransitId { get; set; }
        [JsonProperty(PropertyName = "costcenterid")]
        public long? CostCenterId { get; set; }
        [JsonProperty(PropertyName = "contractid")]
        public long? ContractId { get; set; }
        [JsonProperty(PropertyName = "corporationid")]
        public long CorporationId { get; set; }
        [JsonProperty(PropertyName = "ordertypeid")]
        public long OrderTypeId { get; set; }
        [JsonProperty(PropertyName = "wizardstepindex")]
        public long? WizardStepIndex { get; set; }
        [JsonProperty(PropertyName = "isdeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty(PropertyName = "submittedby")]
        public long? SubmittedBy { get; set; }
        [JsonProperty(PropertyName = "lvsstatusid")]
        public int? LVSStatusId { get; set; }
        [JsonProperty(PropertyName = "contracttype2id")]
        public long? ContractType2Id { get; set; }
        [JsonProperty(PropertyName = "SubmissionDate")]
        public DateTime SubmissionDate { get; set; }
    }
}
