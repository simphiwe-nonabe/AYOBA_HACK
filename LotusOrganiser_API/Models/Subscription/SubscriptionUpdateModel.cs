using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Subscription
{
    public class SubscriptionUpdateModel
    {
        private SubscriptionUpdateModel()
        {
            SubscriptionId = default!;
            Name = default!;
            Code = default!;
            UserId = default!;
        }

        [JsonConstructor]
        public SubscriptionUpdateModel(long subscriptionId, string name, string business, long userId)
        {
            SubscriptionId = subscriptionId;
            Name = name;
            Code = business;
            UserId = userId;
        }

        [Required]
        public long SubscriptionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}