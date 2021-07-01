using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.DtoModels.ReturnDto
{
    public class BandDto
    {
        public BandDto(Band band)
        {
            NickName = band.NickName;
            MemberNum = band.MemberNum;
            RegistrationDate = band.RegistrationDate;
            RoleId = band.RoleId;
        }

        public string NickName { get; set; }
        public int MemberNum { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RoleId { get; set; }
    }
}
