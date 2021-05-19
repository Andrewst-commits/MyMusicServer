using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface ISongs
    {
        Task<SongDto> GetSongAsync(int id);
        Task<SongDto> AddSongAsync(string title, int duration,
             DateTime productionDate, int performerId);
        Task<bool> PutSongAsync(int id, string newTitle, int newDuration,
             DateTime newProductionDate, int newPerformerId);
        Task<bool> DeleteSongAsync(int id);
    }
}
