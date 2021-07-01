using Server_nw.Attributes;
using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationService.DtoModels.CreateDto
{
    public class RoleCreateDto
    {
        /// <summary>
        /// название роли
        /// </summary>
        [Required]
        [Length(MinLen = 4, MaxLen = 100, ErrMes = "must be in range")]
        public string NameDto { get; set; }


        public Role ToEntity()
        {
            Role role = new Role()
            {
                Name = NameDto
            };

            return role;
        }
    }
}
