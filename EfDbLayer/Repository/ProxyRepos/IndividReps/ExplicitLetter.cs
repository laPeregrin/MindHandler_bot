using DTOObjects.DataObjects;
using EfDbLayer.EfDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.ProxyRepos.IndividReps
{
    public class ExplicitLetter : GenRep<Letter>
    {
        private readonly EfDbContext _service;

        public ExplicitLetter(EfDbContext service)
        {
            _service = service;
        }
        public ExplicitLetter()
        {
            _service = new EfDbContext();
        }
        public async Task<bool> AddLetter(Letter letter)
        {
            try
            {
                await base.Add(letter);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
        public  async Task<IEnumerable<Letter>> GetAll(string id)
        {
            var coll = await base.GetAll();
            return coll;
        }
    }
}
