using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Business
{
    public class BusinessCreationModel
    {
        private BusinessCreationModel()
        {
            Name = default!;
        }

        [JsonConstructor]
        public BusinessCreationModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}