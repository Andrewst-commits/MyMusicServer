using Server.Attributes;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class LoginModelCreateDto
    {
        /// <summary>
        /// почта
        /// </summary>
        [Required]
        [Length(MaxLen = 30, MinLen = 1, ErrMes = "Langth must be")]
        public string EmailCreateDto { get; set; }


        /// <summary>
        /// пароль
        /// </summary>
        [Required]
        [Length(MaxLen = 256, MinLen = 8, ErrMes = "Langth must be")]
        public string PasswordCreateDto { get; set; }

     
    }
}
