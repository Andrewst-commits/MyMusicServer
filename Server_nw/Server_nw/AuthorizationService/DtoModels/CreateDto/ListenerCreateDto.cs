using Server_nw.Attributes;
using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationService.DtoModels.CreateDto
{
    public class ListenerCreateDto
    {
        /// <summary>
        /// псевдоним
        /// </summary>
        [Required]
        [Length(MinLen = 1, MaxLen = 20, ErrMes = "must be in range")]
        public string NickNameDto { get; set; }

        /// <summary>
        /// дата рождения
        /// </summary>
        [DateFormat]
        public string BirthDateDto { get; set; }

        /// <summary>
        /// роль
        /// </summary>
        [Required]
        public int RoleIdDto { get; set; }

        public Listener ToEntity()
        {
            Listener listener = new Listener()
            {
                NickName = NickNameDto,
                BirthDate = DateTime.Parse(BirthDateDto),
                RoleId = RoleIdDto,
            };

            return listener;
        }
    }
}
