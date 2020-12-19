using DTOObjects.DataObjects;
using EfDbLayer.EfDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.ProxyRepos
{
    public class UserRep
    {
        private EfDbContexts.EfDbContext _service;

        public UserRep(EfDbContext service)
        {
            _service = service;
        }
        public UserRep()
        {
            _service = new EfDbContext();
        }
        public async Task<User> Add(User user)
        {

            var IsExist = _service.Users.Any(x => x.TelegramUserId == user.TelegramUserId);
            if (IsExist)
                throw new ArgumentException();
            await _service.Users.AddAsync(user);
            await _service.SaveChangesAsync();
            return user;
        }
    }
}
