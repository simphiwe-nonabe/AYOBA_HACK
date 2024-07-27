using LotusOrganiser.Entities;

namespace LotusOrganiser_Repository.Interfaces
{
    public interface IBusinessRepository
    {
        public Task<IEnumerable<Business>> GetAllBusinessesAsync();

        public Task<Business> CreateBusinessAsync(Business business);

        public Task<Business?> GetBusinessByIdAsync(long businessId);

        public Task<Business?> UpdateBusinessAsync(long id, Business updatedBusiness);

        public Task<Business?> DeleteBusinessAsync(long id);
    }
}
