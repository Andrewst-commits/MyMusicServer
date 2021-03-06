using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class SongDto
    {

        public SongDto(Song song)
        {
            Title = song.Title;
            DurationMs = song.DurationMs;
            ProductionDate = song.ProductionDate;
            PerformerId = song.PerformerId;

        }
        public string Title { get; set; }
        public long DurationMs { get; set; }
        public DateTime ProductionDate { get; set; }
        public TimeSpan Duration => TimeSpan.FromMilliseconds(DurationMs);
        public Guid PerformerId {get; set;}
    }
}
