using LotusOrganiser.Entities;

namespace LotusOrganiser_Repository.Interfaces
{
    public interface ISubscriptionRepository
    {
        public Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync();

        public Task<IEnumerable<Subscription>> GetSubscriptionsByBusinessIdAsync(long id);

        public Task<IEnumerable<Subscription>> FindBusinessesMemberBelongsToByNameAsync(string name);

        public Task<Subscription> AddSubscriptionAsync(Subscription subscription);

        public Task<Subscription?> UpdateSubscriptionAsync(long id, Subscription updatedSubscription);

        public Task<Subscription?> DeleteSubscriptionAsync(long id);

        public Task<IEnumerable<Subscription>> FindSubscriptionsByBusinessNameAsync(string name);

    }
}
