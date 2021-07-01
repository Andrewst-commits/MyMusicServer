using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.DtoModels.ReturnDto
{
    public class RoleDto
    {
        public RoleDto(Role role)
        {
            Name = role.Name;
        }

        public string Name { get; set; }
    }
}
