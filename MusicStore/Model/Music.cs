using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    class Music
    {
        public int id { get; set; }
        public string musicName { get; set; }
        public string album { get; set; }
        public string artist { get; set; }
        public bool available { get; set; }
    }
}
