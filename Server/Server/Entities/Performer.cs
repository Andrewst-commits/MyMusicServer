using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Performer
    {
        public int PerformerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<User> Users { get; set; } 
        public virtual ICollection<Song> Songs { get; set; } 

        public Performer(List<User> users, List<Song> songs)
        {
            Users = new List<User>();
            Songs = new List<Song>();
        }

    }
}
