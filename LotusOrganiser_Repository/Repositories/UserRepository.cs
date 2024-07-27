using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Entities;
using LotusOrganiser.Data;
using LotusOrganiser_Repository.Interfaces;


namespace LotusOrganiser_Repository.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly LotusOrganiserDbContext _context;

        private readonly ILogger<UserRepository> _logger;

        public UserRepository(LotusOrganiserDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add user - {name}", user.Name);
                throw;
            }
        }

        public async Task<User?> DeleteUserAsync(long id)
        {
            try
            {
                User? user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return null;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception exception) 
            {
                _logger.LogError(exception, "Unable to delete user with id - {id}", id);
                throw;
            }

        }

        public async Task<IEnumerable<User>> FindUsersByNameAsync(string name)
        {
            return await _context.Users.Where(user => user.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateUserAsync(long id, User updatedUser)
        {
            try
            {
                User? user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return null;
                }

                user.Name = updatedUser.Name;
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to update user with id - {id}", updatedUser.UserId);
                throw;
            }

        }
    }
}
