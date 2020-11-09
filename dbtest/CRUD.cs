using DTOObjects.DataObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbtest
{
    public class CRUD
    {
        private EfRepository _context;

        public CRUD(EfRepository context)
        {
            _context = context;
        }

        public async Task<Guid> Add<T>(T newEntity) where T : DomainObject
        {
            var entity = await _context.Set<T>().AddAsync(newEntity);
            await Task.Run(()=>SaveChangesAsync());
            return entity.Entity.Id;
        }

        public Task AddRange<T>(IEnumerable<T> newEntities) where T : DomainObject, ILetter
        {
            throw new NotImplementedException();
        }

        public async Task Delete<T>(Guid entity) where T : DomainObject
        {
            var activeEntity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == entity);
            _context.Set<T>().Remove(activeEntity);
            await Task.Run(() => SaveChangesAsync());
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : DomainObject
        {
            return _context.Set<T>().Where(selector).Where(x => x.Id != null).AsQueryable();
        }

        public IQueryable<T> Get<T>() where T : DomainObject
        {
            return _context.Set<T>().Where(x => x.Id != null).AsQueryable();
        }

        public IQueryable<T> GetAll<T>() where T : DomainObject, ILetter
        {
            return _context.Set<T>().AsQueryable();
        }

        public Task Remove<T>(T entity) where T : DomainObject
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : DomainObject
        {
            await Task.Run(() => _context.Update(entity));
        }
    }
}
