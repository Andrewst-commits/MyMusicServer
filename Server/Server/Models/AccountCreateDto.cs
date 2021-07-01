
using Server.Attributes;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class AccountCreateDto
    {
        /// <summary>
        /// имя
        /// </summary>
        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 30, MinLen = 1, ErrMes = "Langth must be")]
        public string NameDto { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 70, MinLen = 1, ErrMes = "Langth must be")]
        public string SurnameDto { get; set; }

        /// <summary>
        /// отчество
        /// </summary>
        [OnlyLatin(ErrMes = "Only latin letters")]
        [LengthAttribute(MaxLen = 70, MinLen = 1, ErrMes = "Langth must be")]
        public string LastNameDto { get; set; }


        /// <summary>
        /// дата рождения
        /// </summary>
        [Required]
        public string BirthDateDto { get; set; }

        public async Task<Account> ToEntity()
        {
            await Task.CompletedTask;
            var account = new Account()
            {
                Name = NameDto,
                Surname = SurnameDto,
                LastName = LastNameDto,
                BirthDate = DateTime.Parse(BirthDateDto),
            };

            return account;
        }

    }
}



