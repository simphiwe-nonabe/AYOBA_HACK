using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.User
{
    public class UserViewModel
    {
        private UserViewModel()
        { 
            Name = default!;
        }

        [JsonConstructor]
        public UserViewModel(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}