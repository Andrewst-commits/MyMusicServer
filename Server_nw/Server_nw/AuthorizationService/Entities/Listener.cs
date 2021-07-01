using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.Entities
{
    [Table("Listener")]
    public class Listener : User
    {
        public DateTime? BirthDate { get; set; }
    }
}
