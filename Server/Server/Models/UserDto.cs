using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            LastName = user.LastName;
            BirthDate = user.BirthDate;
            Performers = user.Performers
                .Select(c => new PerformerDto(c)) 
                .ToList();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<PerformerDto> Performers { get; set; }
    }
}
