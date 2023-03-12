using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_hackatron.DTOs
{
    public class TransferDTO
    {
        public int SenderIdx { get; set; }

        public int ReceiverIdx { get; set; }

        public int TranferAmount { get; set; }

        public string nodeName { get; set; }
    }
}
