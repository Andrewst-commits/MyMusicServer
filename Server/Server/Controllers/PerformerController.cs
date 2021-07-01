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
    public class PerformerController : ControllerBase
    {
        IPerformers _performers;
        ILogger<PerformerController> _logger;

        public PerformerController(IPerformers performers, ILogger<PerformerController> logger)
        {
            _performers = performers;
            _logger = logger;
        }

        /// <summary>
        /// Получить всех исполнителей 
        /// </summary>
        /// <response code = "200"> Список получен </response>
        /// <response code = "404"> Данных нет </response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PerformerDto>>> GetAllPerformers()
        {
            var performers = await _performers.GetAllPerformers();
            List<PerformerDto> performersDto = new List<PerformerDto>();

            foreach(var performer in performers)
            {
                performersDto.Add(new PerformerDto(performer));
            }

            return Ok(performersDto);
        }

        /// <summary>
        ///  Получить исполнителя по псевдониму
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Исполнитель найден </response>
        /// <response code = "404"> Исполнитель не найден </response>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PerformerDto>> GetPerformer(Guid id)
        {
            var performer = await _performers.GetPerformer(id);

            if (performer == null) return NotFound();

            return new PerformerDto(performer);
        }




        /// <summary>
        /// Добавить нового исполнителя
        /// </summary>
        /// <param name="perfomerCreateDto"></param>
        /// <response code = "200"> Исполнитель успешно добавлен </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PerformerDto>> AddPerformer([FromBody]PerfomerCreateDto perfomerCreateDto)
        {
            //нельзя принимать perfomerCreateDto с арибутами валидации нужно делать новые без зависимостей 
            var performer = await _performers.AddPerformer(perfomerCreateDto); 
               
            return new PerformerDto(performer);
        }

        /// <summary>
        /// Изменить информацию об исполнителе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="perfomerCreateDto"></param>
        /// <response code = "200"> Информация успешно обновлена </response>
        /// <response code = "404"> Исполнитель не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdatePerformer(Guid id, [FromBody]PerfomerCreateDto perfomerCreateDto)
        {
            var isUpdated = await _performers.UpdatePerformer(id, perfomerCreateDto);
            return isUpdated ? Ok() : NotFound();
        }

        /// <summary>
        /// Удалить исполнителя по псевдониму
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Исполнитель удален </response>
        /// <response code = "404"> Исполнитель не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var isDeleted = await _performers.DeletePerformer(id);

            return isDeleted ? Ok() : NotFound();
        }
    }
}

