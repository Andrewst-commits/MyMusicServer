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
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Account> Users { get; set; } 
        public virtual ICollection<Song> Songs { get; set; } 

        public Performer()
        {
            Users = new List<Account>();
            Songs = new List<Song>();
            IsDeleted = false;
        }

    }
}
