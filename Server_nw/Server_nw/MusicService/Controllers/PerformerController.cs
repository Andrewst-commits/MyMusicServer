using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server_nw.MusicApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerController : Controller
    {
        private readonly IPerformerService _performers;
        private readonly ILogger<PerformerController> _logger;

        public PerformerController(IPerformerService performers, ILogger<PerformerController> logger)
        {
            _performers = performers;
            _logger = logger;
        }


        /// <summary>
        /// Прикрепить песню к исполнителю
        /// </summary>
        /// <param name="performerId"></param>
        /// <param name="songId"></param>
        /// <returns></returns>
        [HttpPut("{performerId}/{songId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AttachMusicSongToPerformer(Guid performerId, Guid songId)
        {
            var isAttached = await _performers.AttachMusicSong(performerId, songId);
            return isAttached ? Ok() : NotFound();
        }

        /// <summary>
        /// Прикрепить альбом к исполнителю
        /// </summary>
        /// <param name="performerId"></param>
        /// <param name="albumId"></param>
        /// <returns></returns>
        [HttpPut("{performerId}/{albumId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AttachAlbumToPerformer(Guid performerId, Guid albumId)
        {
            var isAttached = await _performers.AttachAlbum(performerId, albumId);
            return isAttached ? Ok() : NotFound();
        }

    }
}
