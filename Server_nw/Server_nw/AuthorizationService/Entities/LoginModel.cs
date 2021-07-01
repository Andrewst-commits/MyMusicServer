using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.Entities
{
    public class LoginModel
    {
        [Key]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public User User { get; set; }
    }
}
