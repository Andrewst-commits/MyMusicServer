using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.DtoModels.ReturnDto
{
    public class MemberDto
    {
        public MemberDto(Member member)
        {
            NickName = member.NickName;
            Name = member.Name;
            Surname = member.Surname;
            LastName = member.LastName;
            BirthDate = member.BirthDate;
            UserId = member.UserId;
        }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid UserId { get; set; }
    }
}
