using Server_nw.Attributes;
using Server_nw.AuthorizationApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationService.DtoModels.CreateDto
{
    public class MemberCreateDto
    {
        /// <summary>
        /// псевдоним
        /// </summary>
        [Required]
        [OnlyLatin]
        [Length(MinLen = 1, MaxLen = 30, ErrMes = "must be in range")]
        public string NickNameDto { get; set; }

        /// <summary>
        /// имя
        /// </summary>
        [OnlyLatin]
        [Length(MinLen = 1, MaxLen = 30, ErrMes = "must be in range")]
        public string NameDto { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        [OnlyLatin]
        [Length(MinLen = 1, MaxLen = 50, ErrMes = "must be in range")]
        public string SurnameDto { get; set; }
        
        /// <summary>
        /// отчество
        /// </summary>
        [OnlyLatin]
        [Length(MinLen = 1, MaxLen = 50, ErrMes = "must be in range")]
        public string LastNameDto { get; set; }

        /// <summary>
        /// дата рождения
        /// </summary>
        [DateFormat]
        public string BirthDateDto { get; set; }

        public Member ToEntity()
        {
            Member member = new Member()
            {
                NickName = NickNameDto,
                Name = NameDto,
                Surname = SurnameDto,
                LastName = LastNameDto,
                BirthDate = DateTime.Parse(BirthDateDto)
            };

            return member;
        }
    }
}
