using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; } 
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Performer> Performers { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public User()
        {
            Performers = new List<Performer>();
            Songs = new List<Song>();
            IsDeleted = false;
        }


    }
}
