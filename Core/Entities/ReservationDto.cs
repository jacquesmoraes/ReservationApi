﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ReservationDto
    {
        public string TableName { get; set; }
        public int Capacity { get; set; }

        public int TableId { get; set; }
    }
}
