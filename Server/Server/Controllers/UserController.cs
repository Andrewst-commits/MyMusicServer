using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Models;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly ILogger<UserController> _logger;

        public UserController(IUsers users, ILogger<UserController> logger)
        {
            _users = users;
            _logger = logger;
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <response code = "200"> Список получен </response>
        /// <response code = "404"> Данных нет </response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<AccountDto>>> GetAllUsers()
        {
            var users = await _users.GetAllUsers();
            List<AccountDto> usersDto = new List<AccountDto>();

            foreach (var user in users)
            {
                usersDto.Add(new AccountDto(user));
            }

            return Ok(usersDto);
        }



        /// <summary>
        /// Получить пользователя по  id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Пользователь найден </response>
        /// <response code = "404"> Пользователь не найден </response>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AccountDto>> GetUser(Guid id)
        {
            var user = await _users.GetUser(id);

            if (user == null) return NotFound();

            return new AccountDto(user);
        }

        /// <summary>
        /// Зарегистрировать нового пользователя
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <response code = "200"> Пользователь успешно зарегистрирован </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AccountDto>> RegisterUser([FromBody] AccountCreateDto userCreateDto)
        {
            var user = await _users.RegisterUser(userCreateDto);

            return new UserDto(user);
        }


        /// <summary>
        /// Изменить информацию о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userCreateDto"></param>
        /// <response code = "200"> Информация успешно обновлена </response>
        /// <response code = "404"> Пользователь не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUserInf(Guid id, [FromBody] AccountCreateDto userCreateDto)
        {
            var IsUpdated = await _users.UpdateUser(id, userCreateDto);
            return IsUpdated ? Ok() : NotFound();
        }

        /// <summary>
        /// Прикрепить песню к пользователю 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="songId"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AttachMusicSongToUser(Guid userId, Guid songId)
        {
            var isAttached = await _users.AttachMusicSong(userId, songId);
            return isAttached ? Ok() : NotFound();
        }

        /// <summary>
        ///  Удалить пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Пользователь удален </response>
        /// <response code = "404"> Пользователь не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>   
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var isDeleted = await _users.DeleteUser(id);
            return isDeleted ? Ok() : NotFound();
        }

        /// <summary>
        ///  Восстановить пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Пользователь восстановлен </response>
        /// <response code = "404"> Пользователь не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>   
        [HttpPut("isDeleted/{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RestoreUser(Guid id)
        {
            var isRestored = await _users.RestoreUser(id);

            return isRestored ? Ok() : NotFound(new { errorMessage = "Проверьте id" });
        }


        /// <summary>
        /// Получить список удаленных пользователей
        /// </summary>
        /// <response code = "200"> Список получен </response>
        /// <response code = "404"> Данных нет </response>
        /// <returns></returns>
        [HttpGet("isDeleted")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<AccountDto>>> GetAllDeletedUsers()
        {
            var users = await _users.GetAllDeletedUsers();
            List<AccountDto> usersDto = new List<AccountDto>();

            foreach (var user in users)
            {
                usersDto.Add(new UserDto(user));
            }

            return Ok(usersDto);
        }

    }


}






