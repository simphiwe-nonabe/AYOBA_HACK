using LotusOrganiser.Entities;

namespace LotusOrganiser_Repository.Interfaces
{
    public interface IMessageRepository
    {
        public Task<IEnumerable<Message>> GetAllMessagesAsync();

        public Task<Message> CreateMessageAsync(Message message);

        public Task<Message?> GetMessageByIdAsync(string messageId);

        public Task<Message?> DeleteMessageAsync(string id);
    }
}
