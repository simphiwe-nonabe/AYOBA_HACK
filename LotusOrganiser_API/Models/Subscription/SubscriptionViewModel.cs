using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LotusOrganiser.Entities;

namespace LotusOrganiser_API.Models.Subscription
{
    public class SubscriptionViewModel
    {
        private SubscriptionViewModel()
        {
            SubscriptionId = default!;
            BusinessName = default!;
            UserName = default!;
        }

        [JsonConstructor]
        public SubscriptionViewModel(long subscriptionId, string businessName, string userName)
        {
            SubscriptionId = subscriptionId;
            BusinessName = businessName;
            UserName = userName;
        }

        public long SubscriptionId { get; set; }
        public string BusinessName { get; set; }
        public string UserName { get; set; }
    }
}