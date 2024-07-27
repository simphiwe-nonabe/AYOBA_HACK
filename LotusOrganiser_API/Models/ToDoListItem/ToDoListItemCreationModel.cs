using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.ToDoListItem
{
    public class ToDoListItemCreationModel
    {
        private ToDoListItemCreationModel()
        {
            Name = default!;
            Completed = false;
            BusinessId = default!;
        }

        [JsonConstructor]
        public ToDoListItemCreationModel(string name, bool completed , long businessId)
        {
            Name = name;
            Completed = completed;
            BusinessId = businessId!;
        }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public long BusinessId { get; set; }
    }
}