using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.Entities
{
    [Table("Band")]
    public class Band : User
    {
        public int MemberNum { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Member> Members { get; set; }
        public Band()
        { 
            Members = new List<Member>();
        }
    }
}
