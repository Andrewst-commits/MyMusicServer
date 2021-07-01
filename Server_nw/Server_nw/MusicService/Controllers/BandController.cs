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

    public class BandController : Controller
    {
        private readonly IBandService _bands;
        private readonly ILogger<BandController> _logger;

        public BandController(IBandService bands, ILogger<BandController> logger)
        {
            _bands = bands;
            _logger = logger;
        }


        /// <summary>
        /// Прикрепить песню к группе 
        /// </summary>
        /// <param name="bandId"></param>
        /// <param name="songId"></param>
        /// <returns></returns>
        [HttpPut("{bandId}/{songId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AttachMusicSongToBand(Guid bandId, Guid songId)
        {
            var isAttached = await _bands.AttachMusicSong(bandId, songId);
            return isAttached ? Ok() : NotFound();
        }

        /// <summary>
        /// Прикрепить альбом к группе 
        /// </summary>
        /// <param name="bandId"></param>
        /// <param name="albumId"></param>
        /// <returns></returns>
        [HttpPut("{bandId}/{albumId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AttachAlbumToBand(Guid bandId, Guid albumId)
        {
            var isAttached = await _bands.AttachAlbum(bandId, albumId);
            return isAttached ? Ok() : NotFound();
        }

    }
}
