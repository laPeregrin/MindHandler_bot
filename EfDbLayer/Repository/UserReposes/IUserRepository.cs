using DTOObjects.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.UserReposes
{
    public interface IUserRepository
    {
        public Task<User> GetById(Guid id);
        public Task<User> GetByUserId(long Clientid);
        public IQueryable<User> Get(Expression<Func<User, bool>> expression);

        public Task<bool> Add<T>(T newEntity) where T : DomainObject;

        public Task<bool> Remove<T>(T entity) where T : DomainObject;

    }
}
