using Server_nw.MusicApplication.Entities;
using Server_nw.MusicService.DtoModels.CreateDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public interface ISong
    {
        Task<Song> AddSong(SongCreateDto songCreateDto);
        Task<bool> DeleteSong(Guid id);
        Task<List<Song>> GetAllDeletedSongs();
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSong(Guid id);
        Task<bool> RestoreSong(Guid id);
        Task<bool> UpdateSong(Guid id, SongCreateDto songCreateDto);
    }
}