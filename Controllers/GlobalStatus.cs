using backend_hackatron.Services;
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
    public class GlobalStatus : ControllerBase
    {
        private ICMDCommandsService _cmdCommandsService;
        public GlobalStatus(ICMDCommandsService cmdCommandService)
        {
            _cmdCommandsService = cmdCommandService;
        }
        
        [HttpGet]
        public bool InitialiseBlockchain()
        {
            string result = _cmdCommandsService.RunCMDCommand("geth");

            return true;
        }

    }
}
