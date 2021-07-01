using Server_nw.MusicApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.DtoModels.ReturnDto
{
    public class SongDto
    {
        public SongDto(Song song)
        {
            Title = song.Title;
            DurationMs = song.DurationMs;
            ProductionDate = song.ProductionDate;
            UserId = song.UserId;
            AlbumId = song.AlbumId;
        }
        public string Title { get; set; }
        public long DurationMs { get; set; }
        public DateTime ProductionDate { get; set; }
        public TimeSpan Duration => TimeSpan.FromMilliseconds(DurationMs);
        public Guid? AlbumId { get; set; }
        public Guid UserId { get; set; }

    }
}
