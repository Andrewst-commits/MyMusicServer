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
    public class AlbumController : Controller
    {
        private readonly IAlbum _albums;
        private readonly ILogger<AlbumController> _logger;

        public AlbumController(IAlbum albums, ILogger<AlbumController> logger)
        {
            _albums = albums;
            _logger = logger;
        }


        /// <summary>
        /// Получить список альбомов
        /// </summary>
        /// <response code = "200"> Список получен </response>
        /// <response code = "404"> Данных нет </response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<AlbumDto>>> GetAllAlbums()
        {
            var albums = await _albums.GetAllAlbums();
            List<AlbumDto> albumsDto = new List<AlbumDto>();

            foreach (var album in albums)
            {
                albumsDto.Add(new AlbumDto(album));
            }

            return Ok(albumsDto);
        }


        /// <summary>
        /// Получить альбом по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Альбом найден </response>
        /// <response code = "404"> Альбом не найден </response>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlbumDto>> GetAlbum(Guid id)
        {
            var album = await _albums.GetAlbum(id);

            if (album == null) return NotFound();

            return new AlbumDto(album);
        }

        /// <summary>
        /// Добавить новый альбом
        /// </summary>
        /// <param name="albumCreateDto"></param>
        /// /// <response code = "200"> альбом успешно добавлен </response>
        /// <response code = "500"> ошибка сервера </response>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AlbumDto>> AddAlbum([FromBody] AlbumCreateDto albumCreateDto)
        {
            var album = await _albums.AddAlbum(albumCreateDto);
            return new AlbumDto(album);

        }

        /// <summary>
        /// Изменить информацию об альбоме
        /// </summary>
        /// <param name="id"></param>
        /// <param name="albumCreateDto"></param>
        /// <response code = "200"> Информация успешно обновлена </response>
        /// <response code = "404"> Альбом не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAlbumInf(Guid id, [FromBody] AlbumCreateDto albumCreateDto)
        {
            var IsUpdated = await _albums.UpdateAlbum(id, albumCreateDto);
            return IsUpdated ? Ok() : NotFound();
        }

        /// <summary>
        /// Удалить альбом по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Альбом удален </response>
        /// <response code = "404"> Альбои не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAlbum(Guid id)
        {
            var isDeleted = await _albums.DeleteAlbum(id);
            return isDeleted ? Ok() : NotFound();
        }

        /// <summary>
        ///  Восстановить албом по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Альбом восстановлен </response>
        /// <response code = "404"> Альбом не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>   
        [HttpPut("isDeleted/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RestoreAlbum(Guid id)
        {
            var isRestored = await _albums.RestoreAlbum(id);

            return isRestored ? Ok() : NotFound(new { errorMessage = "Проверьте id" });
        }


        /// <summary>
        /// Получить список удаленных альбомов
        /// </summary>
        /// <response code = "200"> Список получен </response>
        /// <response code = "404"> Данных нет </response>
        /// <returns></returns>
        [HttpGet("isDeleted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<AlbumDto>>> GetAllDeletedAlbums()
        {
            var albums = await _albums.GetAllDeletedAlbums();
            List<AlbumDto> albumsDto = new List<AlbumDto>();

            foreach (var album in albums)
            {
                albumsDto.Add(new AlbumDto(album));
            }

            return Ok(albumsDto);
        }
    }
}
