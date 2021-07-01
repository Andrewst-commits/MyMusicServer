using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server_nw.MusicApplication.DtoModels.ReturnDto;
using Server_nw.MusicApplication.Services;
using Server_nw.MusicService.DtoModels.CreateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISong _songs;
        private readonly ILogger<SongController> _logger;

        public SongController(ISong songs, ILogger<SongController> logger)
        {
            _songs = songs;
            _logger = logger;
        }


        /// <summary>
        /// Получить список песен
        /// </summary>
        /// <response code = "200"> Список получен </response>
        /// <response code = "404"> Данных нет </response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<SongDto>>> GetAllSongs()
        {
            var songs = await _songs.GetAllSongs();
            List<SongDto> songsDto = new List<SongDto>();

            foreach (var song in songs)
            {
                songsDto.Add(new SongDto(song));
            }

            return Ok(songsDto);
        }


        /// <summary>
        /// Получить песню по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Песня найдена </response>
        /// <response code = "404"> Песня не найдена </response>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SongDto>> GetSong(Guid id)
        {
            var song = await _songs.GetSong(id);

            if (song == null) return NotFound();

            return new SongDto(song);
        }

        /// <summary>
        /// Добавить новую песню
        /// </summary>
        /// <param name="songCreateDto"></param>
        /// /// <response code = "200"> песня успешно добавлена </response>
        /// <response code = "500"> ошибка сервера </response>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SongDto>> AddSong([FromBody] SongCreateDto songCreateDto)
        {
            var song = await _songs.AddSong(songCreateDto);
            return new SongDto(song);
            
        }

        /// <summary>
        /// Изменить информацию о песне
        /// </summary>
        /// <param name="id"></param>
        /// <param name="songCreateDto"></param>
        /// <response code = "200"> Информация успешно обновлена </response>
        /// <response code = "404"> Песня не найдена </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSongInf(Guid id, [FromBody] SongCreateDto songCreateDto)
        {
            var IsUpdated = await _songs.UpdateSong(id, songCreateDto);
            return IsUpdated ? Ok() : NotFound();
        }

        /// <summary>
        /// Удалить песню по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Песня удалена </response>
        /// <response code = "404"> Песня не найдена </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSong(Guid id)
        {
            var isDeleted = await _songs.DeleteSong(id);
            return isDeleted ? Ok() : NotFound();
        }

        /// <summary>
        ///  Восстановить песню по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Песня восстановлен </response>
        /// <response code = "404"> Песня не найдена </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>   
        [HttpPut("isDeleted/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RestoreSong(Guid id)
        {
            var isRestored = await _songs.RestoreSong(id);

            return isRestored ? Ok() : NotFound(new { errorMessage = "Проверьте id" });
        }


        /// <summary>
        /// Получить список удаленных песен
        /// </summary>
        /// <response code = "200"> Список получен </response>
        /// <response code = "404"> Данных нет </response>
        /// <returns></returns>
        [HttpGet("isDeleted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<SongDto>>> GetAllDeletedSongs()
        {
            var songs = await _songs.GetAllDeletedSongs();
            List<SongDto> songsDto = new List<SongDto>();

            foreach (var song in songs)
            {
                songsDto.Add(new SongDto(song));
            }

            return Ok(songsDto);
        }
    }

}
