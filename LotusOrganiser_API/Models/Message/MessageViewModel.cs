using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Message
{
    public class MessageViewModel
    {
        private MessageViewModel()
        {
            Name = default!;
            Completed = false;
            BusinessName = default!;
        }

        [JsonConstructor]
        public MessageViewModel(string name, bool completed, string businessName)
        {
            Name = name;
            Completed = completed;
            BusinessName = businessName!;
        }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public string BusinessName { get; set; }
    }
}
