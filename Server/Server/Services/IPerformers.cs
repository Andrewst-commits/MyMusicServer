using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{ 
    public interface IPerformers
    {
        Task<Performer> GetPerformerAsync(int id);
        Task<Performer> AddPerformerAsync(string name, string surname,
            string lastName, DateTime birthDate);
        Task<bool> PutPerformerAsync(int id, string newName, string newSurname,
            string newLastName, DateTime newBirthDate);
        Task<bool> DeletePerformerAsync(int id);
    }
}
