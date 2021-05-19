using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public float Duration { get; set; }
        public DateTime ProductionDate { get; set; }


        public int PerformerId { get; set; }
        public virtual Performer Performer { get; set; }

       
    }
}
