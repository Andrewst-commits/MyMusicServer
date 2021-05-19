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

        public virtual List<User> Users { get; set; } = new List<User>();
        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}
