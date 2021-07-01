using System;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public interface IListenerService
    {
        Task<bool> AttachAlbum(Guid listenerId, Guid albumId);
        Task<bool> AttachMusicSong(Guid listenerId, Guid songId);
    }
}