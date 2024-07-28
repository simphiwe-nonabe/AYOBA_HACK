using Microsoft.EntityFrameworkCore;
using LotusOrganiser.Entities;

namespace LotusOrganiser.Data
{
    public class LotusOrganiserDbContext : DbContext
    {
        public LotusOrganiserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Business> Businesses { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}