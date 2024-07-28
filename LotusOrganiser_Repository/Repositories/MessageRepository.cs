using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Data;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;
using System;

namespace LotusOrganiser_Repository.Repositories
{
    public sealed class MessageRepository : IMessageRepository
    {
        private readonly LotusOrganiserDbContext _context;

        private readonly ILogger<MessageRepository> _logger;

        private readonly IBusinessRepository _businessRepository;

        public MessageRepository(LotusOrganiserDbContext context, ILogger<MessageRepository> logger, IBusinessRepository businessRepository)
        {
            _context = context;
            _logger = logger;
            _businessRepository = businessRepository;
        }
        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await _context.Messages
                .Include(message => message.Business)
                .Include(message => message.User)
                .ToListAsync();
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            try
            {
                Business? business = await
                    _businessRepository.GetBusinessByIdAsync(message.BusinessId);

                if (business == null)
                {
                    throw new Exception($"ToDo list message can not be created without assignee business. Please create business first");
                }

                message.Business = business;

                User? user = await _context.Users.FindAsync(message.UserId);

                if (user == null)
                {
                    throw new Exception($"ToDo list message can not be created without assignee user. Please create user first");
                }

                message.User = user;

                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return message;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add Message - {name}", message.id);
                throw;
            }
        }

        public async Task<Message?> GetMessageByIdAsync(string messageId)
        {
            return await _context.Messages
                .Include(message => message.Business)
                .Include(message => message.User)
                .FirstOrDefaultAsync(message => message.id == messageId) ?? null;
        }


        public async Task<Message?> DeleteMessageAsync(string id)
        {
            try
            {
                Message? message = await _context.Messages
                    .Include(message => message.Business).
                    FirstOrDefaultAsync(message => message.id == id) ?? null;

                if (message == null)
                {
                    return null;
                }

                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
                return message;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to delete message with id - {id}", id);
                throw;
            }
        }
    }
}
