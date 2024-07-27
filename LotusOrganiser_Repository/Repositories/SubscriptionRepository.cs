using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Data;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;

namespace LotusOrganiser_Repository.Repositories
{
    public sealed class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly LotusOrganiserDbContext _context;

        private readonly ILogger<SubscriptionRepository> _logger;

        private readonly IUserRepository _userRepository;

        private readonly IBusinessRepository _businessRepository;

        public SubscriptionRepository(LotusOrganiserDbContext context, ILogger<SubscriptionRepository> logger, IUserRepository userRepository, IBusinessRepository businessRepository)
        {
            _context = context;
            _logger = logger;
            _userRepository = userRepository;
            _businessRepository = businessRepository;
        }

        public async Task<Subscription> AddSubscriptionAsync(Subscription subscription)
        {
            try
            {
                User? user = await
                    _userRepository.GetUserByIdAsync(subscription.UserId);

                if (user == null)
                {
                    throw new Exception($"User with id - {subscription.UserId} does not exist. Please add user first");
                }

                subscription.User = user;

                Business? business = await
                    _businessRepository.GetBusinessByIdAsync(subscription.BusinessId);

                if (business == null)
                {
                    throw new Exception($"Business with id - {subscription.BusinessId} does not exist. Please create business first");
                }

                subscription.Business = business;

                await _context.Subscriptions.AddAsync(subscription);
                await _context.SaveChangesAsync();
                return subscription;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add Subscription");
                throw;
            }
        }

        public async Task<Subscription?> DeleteSubscriptionAsync(long id)
        {
            try
            {
                Subscription? subscription = await _context.Subscriptions.FindAsync(id);

                if (subscription == null)
                {
                    return null;
                }

                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
                return subscription;

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to delete Subscription with id - {id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Subscription>> FindBusinessesMemberBelongsToByNameAsync(string name)
        {
            return await _context.Subscriptions
                .Include(user => user.User)
                .Include(subscription => subscription.Business)
                .Where(subscription => subscription.User.Name.StartsWith(name)).ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions
                .Include(subscription => subscription.User)
                .Include(subscription => subscription.Business)
                .ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> FindSubscriptionsByUserAsync(string name)
        {
            return await _context.Subscriptions
                .Include(subscription => subscription.User)
                .Include(subscription => subscription.Business)
                .Where(subscription => subscription.User.Name == name).ToListAsync();
        }

        public async Task<Subscription?> UpdateSubscriptionAsync(long id, Subscription updatedSubscription)
        {
            try
            {
                Subscription? business = await _context.Subscriptions.FindAsync(id);

                if (business == null)
                {
                    return null;
                }

                User? user = await
                    _userRepository.GetUserByIdAsync(updatedSubscription.UserId);
                if (user == null)
                {
                    throw new Exception($"Subscription type with id - {updatedSubscription.UserId} does not exist.");
                }

                Subscription? subscription = await _context.Subscriptions.FindAsync(updatedSubscription.SubscriptionId);

                if (subscription == null)
                {
                    return null;
                }

                subscription.User.Name = updatedSubscription.User.Name;
                subscription.User = user;
                _context.Update(subscription);
                await _context.SaveChangesAsync();
                return subscription;

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to update Subscription with id - {id}", updatedSubscription.SubscriptionId);
                throw;
            }
        }

        public async Task<IEnumerable<Subscription>> FindSubscriptionsByBusinessNameAsync(string name)
        {
            return await _context.Subscriptions
                .Include(subscription => subscription.User)
                .Include(subscription => subscription.Business)
                .Where(subscription => subscription.Business.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByBusinessIdAsync(long id)
        {
            return await _context.Subscriptions
                .Include(subscription => subscription.User)
                .Include(subscription => subscription.Business)
                .Where(subscription => subscription.BusinessId == id).ToListAsync();
        }

    }
}
