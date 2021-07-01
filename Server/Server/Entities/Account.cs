using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Account
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? RoleId { get; set; }
        public bool IsDeleted { get; set; }

        public LoginModel Login { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Performer> Performers { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public Account()
        {
            Performers = new List<Performer>();
            Songs = new List<Song>();
            IsDeleted = false;
        }


    } 

    
}
