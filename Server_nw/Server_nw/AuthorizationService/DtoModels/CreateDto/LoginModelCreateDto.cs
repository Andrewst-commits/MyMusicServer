using Server_nw.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationService.DtoModels.CreateDto
{
    public class LoginModelCreateDto
    {
        /// <summary>
        /// логин
        /// </summary>
        [Required]
        public string LoginDto { get; set; }

        /// <summary>
        /// пароль
        /// </summary>
        [Required]
        public string PasswordDto { get; set; }

    }
}
