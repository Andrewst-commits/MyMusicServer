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
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _users.GetAllUsers();
            List<UserDto> usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                usersDto.Add(new UserDto(user));
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
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await _users.GetUser(id);

            if (user == null) return NotFound();

            return new UserDto(user); 
        }

        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <response code = "200"> Пользователь успешно добавлен </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDto>> AddUser([FromBody] UserCreateDto userCreateDto)
        {
            var user = await _users.AddUser(userCreateDto);

            return new UserDto(user); //Почему не выдало ошибку???!!!!! было Ok(user)
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
        public async Task<ActionResult<bool>> UpdateUserInf(Guid id, [FromBody] UserCreateDto userCreateDto)
        {
            var IsUpdated = await _users.UpdateUser(id, userCreateDto);
            return IsUpdated ? Ok() : NotFound();
        }

        /// <summary>
        /// Прикрепить исполнителя к пользователю 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="performerId"></param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> AttachMusicPerformerToUser(Guid userId, Guid performerId)
        {
            var isAttached = await _users.AttachMusicPerformer(userId, performerId);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            var isDeleted = await _users.DeleteUser(id);
            return isDeleted ? Ok() : NotFound();
        }

    }


}
