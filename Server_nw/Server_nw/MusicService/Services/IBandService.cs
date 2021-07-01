using System;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public interface IBandService
    {
        Task<bool> AttachAlbum(Guid bandId, Guid albumId);
        Task<bool> AttachMusicSong(Guid bandId, Guid songId);
    }
}