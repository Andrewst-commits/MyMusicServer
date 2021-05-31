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
    { // добавить XMl
       
        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [Length(MaxLen = 30, MinLen = 1, ErrMes = "Langth must be")]
        public string TitleDto { get; set; }

        [Required]
        [MyRange(MinNum = 0, MaxNum = 36000, ErrMes = "Duration (mc) must be")]
        public long DurationMsDto { get; set; }

        [Required]
        public string ProductionDateDto { get; set; }

        [Required]
        [OnlyLatin(ErrMes = "Only latin letters")]
        [Length(MaxLen = 30, MinLen = 1, ErrMes = "Langth must be")]
        public string PerformerNickNameDto { get; set; }

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
