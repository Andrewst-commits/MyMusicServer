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
            Name = performer.Name;
            Surname = performer.Surname;
            LastName = performer.LastName;
            BirthDate = performer.BirthDate;
            Songs = performer.Songs
                .Select(c => new SongDto(c))
                .ToList();
       }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<SongDto> Songs { get; set; }
    }
}
