﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual List<Song> Songs { get; set; } = new List<Song>();
        public virtual List<Performer> Performers { get; set; } = new List<Performer>();

    }
}
