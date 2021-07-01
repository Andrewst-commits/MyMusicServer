using System;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public interface IPerformerService
    {
        Task<bool> AttachAlbum(Guid performerId, Guid albumId);
        Task<bool> AttachMusicSong(Guid performerId, Guid songId);
    }
}