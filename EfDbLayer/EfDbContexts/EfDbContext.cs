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
            options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Database = Tel_Store_Test; Persist Security Info = false; MultipleActiveResultSets = True; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.ApplyConfiguration(new UserConfiguration());
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => new { p.UserId });

            builder.HasMany(x => x.Letters).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasIndex(u => u.UserId).IsUnique();
        }
    }
}
