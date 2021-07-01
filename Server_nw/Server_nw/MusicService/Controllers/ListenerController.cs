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
    public class ListenerController : Controller
    {
        private readonly IListenerService _listeners;
        private readonly ILogger<ListenerController> _logger;

        public ListenerController(IListenerService listeners, ILogger<ListenerController> logger)
        {
            _listeners = listeners;
            _logger = logger;
        }


        /// <summary>
        /// Прикрепить песню к слушателю 
        /// </summary>
        /// <param name="listenerId"></param>
        /// <param name="songId"></param>
        /// <returns></returns>
        [HttpPut("{listenerId}/{songId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AttachMusicSongToListener(Guid listenerId, Guid songId)
        {
            var isAttached = await _listeners.AttachMusicSong(listenerId, songId);
            return isAttached ? Ok() : NotFound();
        }

        /// <summary>
        /// Прикрепить альбом к слушателю
        /// </summary>
        /// <param name="listenerId"></param>
        /// <param name="albumId"></param>
        /// <returns></returns>
        [HttpPut("{listenerId}/{albumId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AttachAlbumToListener(Guid listenerId, Guid albumId)
        {
            var isAttached = await _listeners.AttachAlbum(listenerId, albumId);
            return isAttached ? Ok() : NotFound();
        }

    }
}
