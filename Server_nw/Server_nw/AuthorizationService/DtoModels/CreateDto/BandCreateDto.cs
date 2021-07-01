using Server_nw.Attributes;
using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationService.DtoModels.CreateDto
{
    public class BandCreateDto
    {
        /// <summary>
        /// название группы
        /// </summary>
        [Required]
        [Length(MinLen = 1, MaxLen = 100, ErrMes = "must be in range")]
        public string NickNameDto { get; set; }

        /// <summary>
        /// количество участников
        /// </summary>
        [Required]
        [MyRange(MinNum = 2, MaxNum = 100, ErrorMessage = "must be in range ")]
        public int MemberNumDto { get; set; }

        /// <summary>
        /// дата регистрации
        /// </summary>
        [Required]
        [DateFormat]
        public string RegistrationDateDto { get; set; }

        /// <summary>
        /// роль
        /// </summary>
        [Required]
        public int RoleIdDto { get; set; }

        public Band ToEntity()
        {
            Band band = new Band()
            {
                NickName = NickNameDto,
                MemberNum = MemberNumDto,
                RegistrationDate = DateTime.Parse(RegistrationDateDto),
                RoleId = RoleIdDto,
            };

            return band;
        }
    }
}
