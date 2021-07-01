using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Entities
{
    public class Band : User
    {
        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }

        public Band()
        {
            Songs = new List<Song>();
            Albums = new List<Album>();
        }
    }
}
