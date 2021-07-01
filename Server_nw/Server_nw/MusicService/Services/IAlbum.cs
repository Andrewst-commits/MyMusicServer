using Server_nw.MusicApplication.Entities;
using Server_nw.MusicService.DtoModels.CreateDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public interface IAlbum
    {
        Task<Album> AddAlbum(AlbumCreateDto albumCreateDto);
        Task<bool> AttachMusicSong(Guid albumId, Guid songId);
        Task<bool> DeleteAlbum(Guid id);
        Task<Album> GetAlbum(Guid id);
        Task<List<Album>> GetAllAlbums();
        Task<List<Album>> GetAllDeletedAlbums();
        Task<bool> RestoreAlbum(Guid id);
        Task<bool> UpdateAlbum(Guid id, AlbumCreateDto albumCreateDto);
    }
}