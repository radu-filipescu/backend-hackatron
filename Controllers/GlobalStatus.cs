using backend_hackatron.DTOs;
using backend_hackatron.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        
        [HttpPost]
        public async Task<List<String>> InitialiseBlockchain()
        {
            List<string> bigResult = new List<string>();
            List<string> result = new List<string>();
            
            result = await _cmdCommandsService.InitialiseNode1();
            bigResult.AddRange(result);

            result = await _cmdCommandsService.InitialiseNode2();
            bigResult.AddRange(result);

            result = await _cmdCommandsService.InitialiseNode3();
            bigResult.AddRange(result);

            result = await _cmdCommandsService.InitialiseNode4();
            bigResult.AddRange(result);

            result = await _cmdCommandsService.InitialiseNode5();
            bigResult.AddRange(result);

            return result;
        }

        [HttpPut("createUser")]
        public List<string> CreateUserForNode([FromBody]string nodeName)
        {
            List<string> result = _cmdCommandsService.CreateUser(nodeName);

            return result;
        }

        [HttpPut("getFromNode")]
        public List<string> GetAllUsersFromNode([FromBody]string nodeName)
        {
            return _cmdCommandsService.GetAllUsersFromNode(nodeName);
        }

        [HttpPut("setUserToMine")]
        public List<string> SetUserToMine([FromBody] SetUserToMineDTO input)
        {
            return _cmdCommandsService.SetUserToMine(input.NodeName, input.UserIndex);
        }

        [HttpPut("startMining")]
        public bool StartMining([FromBody]string nodeName)
        {
            return _cmdCommandsService.StartMining(nodeName);
        }

        [HttpPut("stopMining")]
        public bool StopMining([FromBody] string nodeName)
        {
            return _cmdCommandsService.StopMining(nodeName);
        }

        [HttpPut("balance")]
        public int GetBalanceFor([FromBody] SetUserToMineDTO input)
        {
            string result = _cmdCommandsService.GetBalance(input.NodeName, input.UserIndex);

            result = result.Remove(result.Length - 1);

            Double bigDouble = Double.Parse(result);
            bigDouble /= 1000000000000000000;

            return (int)bigDouble;
        }

        [HttpPut("transfer")]
        public string TransferAmount([FromBody] TransferDTO input)
        {
            return _cmdCommandsService.TransferAmount(input);
        }

        [HttpPut("checkMining")]
        public bool CheckNodeMining([FromBody] string nodeName)
        {
            string response = _cmdCommandsService.IsNodeMining(nodeName);

            response = response.Remove(response.Length - 1);

            return bool.Parse(response);
        }
    }
}
