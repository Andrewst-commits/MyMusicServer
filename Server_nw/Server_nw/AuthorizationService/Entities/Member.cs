using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.Entities
{
    public class Member
    {
        public Guid MemberId { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsDeleted { get; set; }

        public Guid UserId { get; set; }
        public Band Band { get; set; }

        public Member()
        {
            IsDeleted = false;
        }
    }
}
