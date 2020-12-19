using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOObjects.DataObjects
{
    public class User
    {
        public Guid Id { get; set; }
        public int TelegramUserId { get; set; }
        public int ChatId { get; set; }
        public string UserName { get; set; }
       // public ICollection<Letter> Letters { get; set; }
    }
}
