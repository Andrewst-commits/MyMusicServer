using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Song
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public long DurationMs { get; set; }
        public DateTime ProductionDate { get; set; }
        public string PerformerNickName { get; set; }
        public bool IsDeleted { get; set; }


        public Guid PerformerId { get; set; }
        public virtual Performer Performer { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Song()
        {
            Users = new List<User>();
            IsDeleted = false;
        }

    }
}
