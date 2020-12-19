using DTOObjects.DataObjects;
using EfDbLayer.EfDbContexts;
using EfDbLayer.Repository.ProxyRepos;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TestRepos
{
    public class Tests
    {
        private UserRep _service;
        [SetUp]
        public void Setup()
        {
            _service = new UserRep();
        }

        [Test]
        public void AddUser_InputUser_returnFalse()
        {
            //b86c0587-5fd7-4df0-9713-1fc213beaad2
            //arrange
            bool succes = true;
            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "Gadza",
                TelegramUserId = 123456,
                ChatId = 0,
            };
            //act
            try
            {
                _service.Add(user);
            }
            catch(Exception e)
            {
                succes = false;
                Assert.IsTrue(succes, "not valid user");
            }

            //assert
            Assert.IsTrue(succes, "not valid user");
        }
    }
}