using backend_hackatron.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_hackatron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpPost]
        public bool TransferAmount([FromBody] TransferDTO transferDTO)
        {
            return true;
        }

        [HttpGet]
        public IEnumerable<TransferDTO> GetTransfersHistory()
        {
            TransferDTO transferDTO = new TransferDTO();

            transferDTO.SenderId = "a22123wdad";
            transferDTO.ReceiverId = "2312o9jaw9";
            transferDTO.TranferAmount = 1000;
            
            return new TransferDTO[] { transferDTO };
        }
    }
}
