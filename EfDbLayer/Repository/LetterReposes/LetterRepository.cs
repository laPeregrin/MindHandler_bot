using DTOObjects.DataObjects;
using EfDbLayer.EfDbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.LetterReposes
{
    public class LetterRepository : ILetterRepository
    {
        private EfDbContext _context;

        public LetterRepository(EfDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Letter>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Letter>> GetByUserId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllLetterById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllLetterByUserId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
