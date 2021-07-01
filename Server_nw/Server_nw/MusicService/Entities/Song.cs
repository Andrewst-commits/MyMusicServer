using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Entities
{
    public class Song
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public int DurationMs { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsDeleted { get; set; }

        public Guid UserId { get; set; }
        public Guid? AlbumId { get; set; }

        public Album Album { get; set; }
        public Band Band { get; set; }
        public Performer Performer { get; set; }
        public List<Listener> Listeners { get; set; }

        public Song()
        {
            Listeners = new List<Listener>();
            IsDeleted = false; 
        }
    }
}
