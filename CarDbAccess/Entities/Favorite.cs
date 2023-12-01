using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
