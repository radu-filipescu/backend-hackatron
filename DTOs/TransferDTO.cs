﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_hackatron.DTOs
{
    public class TransferDTO
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public int TranferAmount { get; set; }
    }
}
