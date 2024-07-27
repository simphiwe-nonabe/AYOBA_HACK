using LotusOrganiser.Entities;

namespace LotusOrganiser_Repository.Interfaces
{
    public interface IToDoListItemRepository
    {
        public Task<IEnumerable<ToDoListItem>> GetAllToDoListItemsAsync();

        public Task<ToDoListItem> CreateToDoListItemAsync(ToDoListItem item);

        public Task<ToDoListItem?> GetToDoListItemByIdAsync(string itemId);

        public Task<ToDoListItem?> DeleteToDoListItemAsync(string id);
    }
}
