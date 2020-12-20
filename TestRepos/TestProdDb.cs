using DTOObjects.DataObjects;
using EfDbLayer.EfDbContexts;
using EfDbLayer.Repository.ProxyRepos;
using EfDbLayer.Repository.ProxyRepos.IndividReps;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestRepos
{
    public class Tests
    {
        private ExplicitUser _userService;
        private ExplicitLetter _letterService;
        private EfDbContext _service;
        private string tesUserId = "1488";
        [SetUp]
        public void Setup()
        {
            _service = new EfDbContext();
            _letterService = new ExplicitLetter();
            _userService = new ExplicitUser();
        }

        [Test]
        public void AddUser_InputUser_returnFalse()
        {
            //b86c0587-5fd7-4df0-9713-1fc213beaad2
            //arrange
            bool succes = true;
            var user = new User()
            {
                UserId = tesUserId,
                Username = "Glad Valakas",
                FirstName = "Valera",
                LastName = "Borow"
            };
            //act
            try
            {
                _service.Add(user);
                _service.SaveChanges();
            }
            catch (Exception e)
            {
                succes = false;
                Assert.IsFalse(succes, $"{e.Message}");
            }

            //assert
            Assert.IsFalse(succes, "not valid user");
        }
        [Test]
        public async Task AddUser_InputUser_returnTrue()
        {
            //arrange
            Random random = new Random();

            bool succes = true;
            var user = new User()
            {
                UserId = "testId",
                Username = "Glad Valakas",
                FirstName = "Valera",
                LastName = "Borow"

            };
            //act
            try
            {
                await _userService.RegisterUser(user);
            }
            catch (Exception e)
            {
                succes = false;
                Assert.IsTrue(succes, $"{e.Message}");
            }

            //assert
            Assert.IsTrue(succes, "not valid user");
        }
        [Test]
        public void AddLetter_UserId_returnTrue()
        {
            //Arrange
            var letter = new Letter()
            {
                UserId = tesUserId,
                Message = "пока вы бегали по верхним этажам"
            };
            //Act
            var res = _letterService.AddLetter(letter).Result;

            //Assert
            Assert.IsTrue(res, "didnt add the letter");
        }

        [Test]
        public void GetLetterList_UserId_returnColl()
        {
            //action
            var col = (List<Letter>)_letterService.GetAll(tesUserId).Result;
            //Assert
            Assert.IsTrue(col.Count > 0);
        }

    }
}