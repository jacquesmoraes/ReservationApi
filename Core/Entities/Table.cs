﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Table : BaseEntity
    {
        
        public string TableName { get; set; }

        public int Capacity { get; set; }

        public List<Reservation> reservations { get; set; } = new();

    }
}
