using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface ISongs
    {
        Task<bool> AddSong(SongCreateDto songCreateDto);
        Task<bool> DeleteSong(Guid id);
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSong(Guid id);
        Task<bool> UpdateSong(Guid id, SongCreateDto songCreateDto);
    }
}