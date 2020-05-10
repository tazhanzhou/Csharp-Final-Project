using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    class Order
    {
        public int Id { get; set; }
        public virtual Music Music { get; set; }
        public virtual User User { get; set; }
    }
}
