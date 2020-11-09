using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOObjects.DataObjects
{
    public interface ILetter
    {
        public bool IsPublic { get; set; }
    }

    public class DomainObject
    {
        public Guid Id { get; set; }
        public long ClientId { get; set; }
    }
}
