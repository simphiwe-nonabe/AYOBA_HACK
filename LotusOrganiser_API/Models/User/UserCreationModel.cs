using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.User
{
    public class UserCreationModel
    {
        private UserCreationModel()
        {
            Name = default!;
        }

        [JsonConstructor]
        public UserCreationModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}