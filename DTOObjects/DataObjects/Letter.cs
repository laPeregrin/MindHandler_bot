using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOObjects.DataObjects
{
    public class Letter : DomainObject, ILetter
{
        public string Message { get; set; }
        public bool IsPublic { get ; set; }
    }
}
