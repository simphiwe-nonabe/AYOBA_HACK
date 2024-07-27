using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Data;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;

namespace LotusOrganiser_Repository.Repositories
{
    public sealed class BusinessRepository : IBusinessRepository
    {
        private readonly LotusOrganiserDbContext _context;
        private readonly ILogger<BusinessRepository> _logger;

        public BusinessRepository(LotusOrganiserDbContext context, ILogger<BusinessRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Business>> GetAllBusinessesAsync()
        {
            return await _context.Businesses.ToListAsync();
        }

        public async Task<Business> CreateBusinessAsync(Business business)
        {
            try
            {
                await _context.Businesses.AddAsync(business);
                await _context.SaveChangesAsync();
                return business;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add Business - {name}", business.Name);
                throw;
            }
        }

        public async Task<Business?> GetBusinessByIdAsync(long businessId)
        {
            return await _context.Businesses.FindAsync(businessId);
        }

        public async Task<Business?> UpdateBusinessAsync(long id, Business updatedBusiness)
        {
            try
            {
                Business? business = await _context.Businesses.FindAsync(id);

                if (business == null)
                {
                    return null;
                }

                business.Name = updatedBusiness.Name;
                await _context.SaveChangesAsync();
                return business;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to update business with id - {id}", updatedBusiness.BusinessId);
                throw;
            }
        }

        public async Task<Business?> DeleteBusinessAsync(long id)
        {
            try
            {
                Business? business = await _context.Businesses.FindAsync(id);

                if (business == null)
                {
                    return null;
                }

                _context.Businesses.Remove(business);
                await _context.SaveChangesAsync();
                return business;
            }
            catch (Exception exception) 
            {
                _logger.LogError(exception, "Unable to delete business with id - {id}", id);
                throw;
            }
        }
    }
}
