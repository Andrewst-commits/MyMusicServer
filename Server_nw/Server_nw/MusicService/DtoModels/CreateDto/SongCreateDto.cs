using Server_nw.Attributes;
using Server_nw.MusicApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicService.DtoModels.CreateDto
{
    public class SongCreateDto
    {
        /// <summary>
        /// название
        /// </summary>
        [Required]
        [Length(MinLen = 1, MaxLen = 20, ErrMes = "must be in range")]
        public string TitleDto { get; set; }

        /// <summary>
        /// длительность (мс)
        /// </summary>
        [Required]
        [MyRange(MinNum = 0, MaxNum = int.MaxValue, ErrorMessage = "must be in range")]
        public int DurationMsDto { get; set; }

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
        public Song ToEntity()
        {
            Song song = new Song()
            {
                Title = TitleDto,
                DurationMs = DurationMsDto,
                ProductionDate = DateTime.Parse(ProductionDateDto),
                UserId = UserIdDto,
            };

            return song;
        }
    }
}
