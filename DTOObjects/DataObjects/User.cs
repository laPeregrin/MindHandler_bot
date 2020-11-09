using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOObjects.DataObjects
{
    public class User : DomainObject
    {
        public long ChatId { get; set; }  
        public string UserName { get; set; }
        public IEnumerable<Letter> Letters { get; set; }
    }
}
