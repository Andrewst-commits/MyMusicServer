using Server.Attributes;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class SongCreateDto
    { 
       
        /// <summary>
        /// название
        /// </summary>
        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [Length(MaxLen = 30, MinLen = 1, ErrMes = "Langth must be")]
        public string TitleDto { get; set; }

        /// <summary>
        /// длительность
        /// </summary>
        [Required]
        [MyRange(MinNum = 0, MaxNum = 36000, ErrMes = "Duration (mc) must be")]
        public long DurationMsDto { get; set; }


        /// <summary>
        /// дата выпуска
        /// </summary>
        [Required]
        public string ProductionDateDto { get; set; }

        /// <summary>
        /// id исполнителя
        /// </summary>
        [Required]
        public Guid PerformerIdDto  { get; set; }

        public async Task<Song> ToEntity()
        {
            await Task.CompletedTask;

            var song = new Song()
            {
                Title = TitleDto,
                DurationMs = DurationMsDto,
                ProductionDate = DateTime.Parse(ProductionDateDto), // аттрибут валидации на songCreateDto
                PerformerId = PerformerIdDto
            };

            return song;
        }
    }
}
