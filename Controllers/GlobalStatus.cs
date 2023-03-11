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
        public async Task<List<String>> InitialiseBlockchain()
        {
            List<string> result = await _cmdCommandsService.Initialise();

            return result;
        }

        [HttpPut]
        public List<string> PingNode()
        {
            List<string> result = _cmdCommandsService.PingNode();

            return result;
        }

    }
}
