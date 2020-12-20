using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOObjects.DataObjects
{
    public class Letter : DomainObject
    {
        public Guid Id { get; set; }
        public bool IsPublic { get; set; } = false;
        public string Message { get; set; }

        public User User { get; set; }
    }
}
