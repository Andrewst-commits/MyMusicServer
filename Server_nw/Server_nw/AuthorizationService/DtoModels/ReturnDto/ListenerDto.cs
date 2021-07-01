using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.DtoModels.ReturnDto
{
    public class ListenerDto
    {
        public ListenerDto(Listener listener)
        {
            NickName = listener.NickName;
            BirthDate = listener.BirthDate;
            RoleId = listener.RoleId;
        }

        public string NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int RoleId { get; set; }

    }
}
