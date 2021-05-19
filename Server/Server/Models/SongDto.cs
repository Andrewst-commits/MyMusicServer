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
            Duration = song.Duration;
            ProductionDate = song.ProductionDate;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public float Duration { get; set; }
        public DateTime ProductionDate { get; set; }
        public int PerformerId { get; set; }
    }
}
