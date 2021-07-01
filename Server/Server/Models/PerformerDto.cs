using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Server.Models
{
    public class PerformerDto
    { 
       public PerformerDto(Performer performer)
       {
            NickName = performer.NickName;
            RegistrationDate = performer.RegistrationDate;
            Songs = performer.Songs
                .Select(c => new SongDto(c))
                .ToList();
       }
       
        public string NickName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual List<SongDto> Songs { get; set; }
    }
}
