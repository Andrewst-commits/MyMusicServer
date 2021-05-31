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
    { // добавить XMl

        [Required]
       // [UniquePerformerNickName(ErrMes = "Such nickname exists")]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 30, MinLen = 1, ErrMes = "Langth must be")]
        public string NickNameDto { get; set; }

        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 50, MinLen = 1, ErrMes = "Langth must be")]
        public string NameDto { get; set; }

        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 70, MinLen = 1, ErrMes = "Langth must be")]
        public string SurnameDto { get; set; }

        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 70, MinLen = 1, ErrMes = "Langth must be")]
        public string LastNameDto { get; set; }

        [Required]
        public string BirthDateDto { get; set; }

        public async Task<Performer> ToEntity()
        {
            await Task.CompletedTask;

            var performer = new Performer()
            {
                NickName = NickNameDto,
                Name = NameDto,
                Surname = SurnameDto,
                LastName = LastNameDto,
                BirthDate = DateTime.Parse(BirthDateDto)
            };

            return performer;
        }
        
    }
}
