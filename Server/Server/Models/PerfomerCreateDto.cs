using Server.Attributes;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PerfomerCreateDto
    { 
        /// <summary>
        /// псевдоним
        /// </summary>
        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 30, MinLen = 1, ErrMes = "Langth must be")]
        public string NickNameDto { get; set; }


        /// <summary>
        /// дата регистрации псевдонима
        /// </summary>
        [Required]
        public string RegistrationDateDto { get; set; }

        public async Task<Performer> ToEntity()
        {
            await Task.CompletedTask;

            var performer = new Performer()
            {
                NickName = NickNameDto,
                RegistrationDate = DateTime.Parse(RegistrationDateDto)
            };

            return performer;
        }
        
    }
}
