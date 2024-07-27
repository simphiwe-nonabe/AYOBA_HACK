﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Data;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;
using System;

namespace LotusOrganiser_Repository.Repositories
{
    public sealed class ToDoListItemRepository : IToDoListItemRepository
    {
        private readonly LotusOrganiserDbContext _context;

        private readonly ILogger<ToDoListItemRepository> _logger;

        private readonly IBusinessRepository _businessRepository;

        public ToDoListItemRepository(LotusOrganiserDbContext context, ILogger<ToDoListItemRepository> logger, IBusinessRepository businessRepository)
        {
            _context = context;
            _logger = logger;
            _businessRepository = businessRepository;
        }
        public async Task<IEnumerable<ToDoListItem>> GetAllToDoListItemsAsync()
        {
            return await _context.ToDoListItems
                .Include(item => item.Business)
                .ToListAsync();
        }

        public async Task<ToDoListItem> CreateToDoListItemAsync(ToDoListItem item)
        {
            try
            {
                Business? business = await
                    _businessRepository.GetBusinessByIdAsync(item.BusinessId);

                if (business == null)
                {
                    throw new Exception($"ToDo list item can not be created without assignee business. Please create business first");
                }

                item.Business = business;

                User? user = await _context.Users.FindAsync(item.UserId);

                if (user == null)
                {
                    throw new Exception($"ToDo list item can not be created without assignee user. Please create user first");
                }

                item.User = user;

                await _context.ToDoListItems.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add ToDoListItem - {name}", item.id);
                throw;
            }
        }

        public async Task<ToDoListItem?> GetToDoListItemByIdAsync(string itemId)
        {
            return await _context.ToDoListItems
                .Include(item => item.Business)
                .FirstOrDefaultAsync(item => item.id == itemId) ?? null;
        }


        public async Task<ToDoListItem?> DeleteToDoListItemAsync(string id)
        {
            try
            {
                ToDoListItem? item = await _context.ToDoListItems
                    .Include(item => item.Business).
                    FirstOrDefaultAsync(item => item.id == id) ?? null;

                if (item == null)
                {
                    return null;
                }

                _context.ToDoListItems.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to delete item with id - {id}", id);
                throw;
            }
        }
    }
}
