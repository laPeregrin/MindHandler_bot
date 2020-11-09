using DTOObjects.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDbLayer.Repository.LetterReposes
{
    public interface ILetterRepository
    {
        public Task<bool> AddById(Guid id);

        public Task<bool> RemoveAllLetterById(Guid id);

        public Task<bool> RemoveAllLetterByUserId(Guid id);

        public Task<IEnumerable<Letter>> GetById(Guid id);

        public Task<IEnumerable<Letter>> GetByUserId(long id);
    }
}
