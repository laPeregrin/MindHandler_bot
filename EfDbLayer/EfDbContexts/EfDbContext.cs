using DTOObjects.DataObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.EfDbContexts
{
    public class EfDbContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Letter> Letters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=84.38.189.95,30174;Database = telegramData; User ID = 'sa'; Password = 'Ghbdtn010102'; MultipleActiveResultSets = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => new { u.ClientId, u.Id });
        }

    }
}
