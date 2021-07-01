using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Entities
{
    public class Performer : User
    {
        public List<Song> Songs { get; set; }

        public List<Album> Albums { get; set; }
        public Performer()
        {
            Songs = new List<Song>();
            Albums = new List<Album>();
        }

    }
}
