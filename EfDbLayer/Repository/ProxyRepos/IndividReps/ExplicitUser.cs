using DTOObjects.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.ProxyRepos.IndividReps
{
    public class ExplicitUser : GenRep<User>
    {
        private EfDbContexts.EfDbContext _service;
        public ExplicitUser()
        {
            _service = new EfDbContexts.EfDbContext();
        }

        public async Task<User> RegisterUser(User user)
        {
            User _user = null;
            try
            {
               _user = await Add(user);
                return _user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<User> GetUserById(string id)
        {
            var res = await base.GetByUserId(id);
            return res;
        }
    }
}
