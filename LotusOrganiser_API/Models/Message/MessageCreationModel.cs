using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Message
{
    public class MessageCreationModel
    {
        private MessageCreationModel()
        {
            Name = default!;
            Completed = false;
            BusinessId = default!;
            UserId = default!;
        }

        [JsonConstructor]
        public MessageCreationModel(string name, bool completed , long businessId, long userId)
        {
            Name = name;
            Completed = completed;
            BusinessId = businessId!;
            UserId = userId!;
        }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public long BusinessId { get; set; }

        public long UserId { get; set; }
    }
}