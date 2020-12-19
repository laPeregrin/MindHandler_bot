using DTOObjects.DataObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.EfDbContexts
{
    public class EfDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Letter> Letters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=84.38.189.95,30174;Database = telegramData; User ID = 'sa'; Password = 'Ghbdtn010102'; MultipleActiveResultSets = True;");
            options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Database = Contracts_db; Persist Security Info = false; MultipleActiveResultSets = True; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new LetterConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasKey(p => p.TelegramUserId);

            builder.Property(p => p.UserName).IsRequired();
            builder.Property(p => p.ChatId).IsRequired();
        }
    }
    public class LetterConfiguration : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IsPublic).HasDefaultValue(false);
            builder.Property(p => p.Message).IsRequired();

        }
    }
}
