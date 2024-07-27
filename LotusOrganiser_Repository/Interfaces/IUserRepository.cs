using LotusOrganiser.Entities;


namespace LotusOrganiser_Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddUserAsync(User user);

        public Task<IEnumerable<User>> GetAllUsersAsync();

        public Task<User?> GetUserByIdAsync(long id);

        public Task<IEnumerable<User>> FindUsersByNameAsync(string name);

        public Task<User?> UpdateUserAsync(long id, User user);

        public Task<User?> DeleteUserAsync(long id);

    }
}
