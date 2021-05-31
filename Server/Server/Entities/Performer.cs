using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Performer
    {

        public Guid PerformerId { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; } 
        public virtual ICollection<Song> Songs { get; set; } 

        public Performer()
        {
            Users = new List<User>();
            Songs = new List<Song>();
            IsDeleted = false;
        }

    }
}
