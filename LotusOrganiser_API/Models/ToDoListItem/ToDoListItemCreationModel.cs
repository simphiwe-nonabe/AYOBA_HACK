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
            UserId = default!;
        }

        [JsonConstructor]
        public ToDoListItemCreationModel(string name, bool completed , long businessId, long userId)
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