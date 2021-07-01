using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class AccountDto
    {
        public AccountDto(Account user)
        {
            Name = user.Name;
            Surname = user.Surname;
            LastName = user.LastName;
            BirthDate = user.BirthDate;
            RoleId = user.RoleId;
            Songs = user.Songs
                .Select(c => new SongDto(c)) 
                .ToList();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? RoleId { get; set; }
        public virtual List<SongDto> Songs { get; set; }
    }
}
