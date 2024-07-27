using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Subscription
{
    public class SubscriptionCreationModel
    {
        private SubscriptionCreationModel()
        {
            BusinessId = default!;
            UserId = default!;
        }

        [JsonConstructor]
        public SubscriptionCreationModel(long businessId, long userId)
        {
            BusinessId = businessId;
            UserId = userId;
        }


        [Required]
        public long BusinessId { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}