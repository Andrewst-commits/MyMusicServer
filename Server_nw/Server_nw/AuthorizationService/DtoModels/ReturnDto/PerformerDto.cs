using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.DtoModels.ReturnDto
{
    public class PerformerDto
    {
        public PerformerDto(Performer performer)
        {
            NickName = performer.NickName;
            BirthDate = performer.BirthDate;
            RoleId = performer.RoleId;
        }

        public string NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int RoleId { get; set; }
    }
}
