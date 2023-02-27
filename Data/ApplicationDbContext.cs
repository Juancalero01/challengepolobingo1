using Bingoapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Bingoapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<BallHistory> BallHistories { get; set; }
        public DbSet<CardboardHistory> CardboardHistories { get; set; }

    }
}