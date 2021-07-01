using Server_nw.MusicApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.DtoModels.ReturnDto
{
    public class AlbumDto
    {
        public AlbumDto(Album album)
        {
            Name = album.Name;
            ProductionDate = album.ProductionDate;
            UserId = album.UserId;
        }
        public string Name { get; set; }
        public DateTime ProductionDate { get; set; }
        public Guid UserId { get; set; }
    }
}
