using DTOObjects.DataObjects;
using EfDbLayer.EfDbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.UserReposes
{
    public class UserRepository : IUserRepository
    {
        private EfDbContext _context;

        public UserRepository(EfDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add<T>(T newEntity) where T : DomainObject
        {
            if (newEntity != null)
            {
                var res = await _context.Set<T>().AnyAsync(x => x.Id == newEntity.Id);
                if (!res)
                {
                    await _context.Set<T>().AddAsync(newEntity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
      
        public IQueryable<User> Get(Expression<Func<User, bool>> expression)
        {
            IQueryable<User> query = _context.Set<User>().Where(expression).AsQueryable();
            return query;
        }
        public async Task<User> GetById(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<User> GetByUserId(long ClientId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.ClientId == ClientId);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Remove<T>(T entity) where T : DomainObject
        {
            if (entity != null)
            {
                if (_context.Set<T>().Any(x => x.Id == entity.Id))
                {
                    _context.Set<T>().Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }
    }
}
