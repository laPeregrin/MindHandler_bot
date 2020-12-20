using DTOObjects.DataObjects;
using EfDbLayer.EfDbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.ProxyRepos
{
    public class GenRep<T> where T : DomainObject
    {
        private EfDbContext _service;

        public GenRep(EfDbContext service)
        {
            _service = service;
        }
        public GenRep()
        {
            _service = new EfDbContext();
        }
        public async Task<T> Add(T domainObject)
        {
            if (_service.Set<T>().Any(x => x.UserId == domainObject.UserId)) throw new Exception("User already exist");
            await _service.Set<T>().AddAsync(domainObject);
            await _service.SaveChangesAsync();
            return domainObject;

        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var coll = await _service.Set<T>().AsNoTracking().ToListAsync();
            return coll;
        }
        public async Task<T> GetByUserId(string id)
        {
            var item = await _service.Set<T>().FirstOrDefaultAsync(x => x.UserId == id);
            return item;
        }
    }
}
