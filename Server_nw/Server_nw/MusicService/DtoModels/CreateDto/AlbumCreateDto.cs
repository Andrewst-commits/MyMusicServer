using Server_nw.Attributes;
using Server_nw.MusicApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicService.DtoModels.CreateDto
{
    public class AlbumCreateDto
    {
        /// <summary>
        /// название альбома 
        /// </summary>
        [Required]
        [OnlyLatin]
        [Length(MinLen = 1, MaxLen = 100, ErrMes = "must be in range")]
        public string NameDto { get; set; }

        /// <summary>
        /// дата выпуска
        /// </summary>
        [Required]
        [DateFormat]
        public string ProductionDateDto { get; set; }

        /// <summary>
        /// правообладатель
        /// </summary>
        [Required]
        public Guid UserIdDto { get; set; }
        public Album ToEntity()
        {
            Album album = new Album()
            {
               Name = NameDto,
               ProductionDate = DateTime.Parse(ProductionDateDto),
               UserId = UserIdDto,
            };

            return album;
        }
    }


}