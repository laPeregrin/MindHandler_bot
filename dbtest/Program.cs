using DTOObjects.DataObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace dbtest
{
    class Program
    {
        static EfRepository efRepository = new EfRepository();
        static CRUD service = new CRUD(efRepository);
        static void Main(string[] args)
        {

            var id = new Guid();

            Letter letter = new Letter()
            {
                Id = new Guid(),
                IsPublic = false,
                Message = "TestMessageHere",
               // ClientId = lo
            };


            var collection = new List<Letter>();
            collection.Add(letter);

            User user = new User()
            {
                ChatId = 01,
                ClientId = 02,
                Id = id,
                UserName = "TestName",
                Letters = new List<Letter>() { }
            };
            TestAdd(user);


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        public static async void TestAdd(User user)
        {
            await service.Add(user);
        }

    }
    public class EfRepository : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Letter> Letters { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = ConfigurationManager.
            ConnectionStrings["freeaspconnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
