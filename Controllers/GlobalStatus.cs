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
        public SingleStringDTO CreateUserForNode([FromBody]SingleStringDTO input)
        {
            string result = _cmdCommandsService.CreateUser(input.Value);

            if(result.Length > 1)
                result = result.Remove(result.Length - 2);

            if(result.Length > 3)
                result = result.Remove(0, 3);

            var tmp = new SingleStringDTO();
            tmp.Value = result;
            return tmp;
        }

        [HttpPut("getFromNode")]
        public List<string> GetAllUsersFromNode([FromBody]SingleStringDTO input)
        {
            string result = _cmdCommandsService.GetAllUsersFromNode(input.Value);

            result = result.Remove(result.Length - 2);
            result = result.Remove(0, 1);

            result = result.Replace(" ", string.Empty);

            List<string> resultSplit = result.Split(",").ToList();

            for(int i = 0; i < resultSplit.Count; i++)
            {
                if(resultSplit[i].Length > 1)
                    resultSplit[i] = resultSplit[i].Remove(resultSplit[i].Length - 2);

                if (resultSplit[i].Length > 1)
                    resultSplit[i] = resultSplit[i].Remove(0, 1);
            }

            return resultSplit;
        }

        [HttpPut("setUserToMine")]
        public List<string> SetUserToMine([FromBody] SetUserToMineDTO input)
        {
            string result = _cmdCommandsService.SetUserToMine(input.NodeName, input.UserIndex);

            return new List<string>();
        }

        [HttpPut("startMining")]
        public bool StartMining([FromBody] SingleStringDTO input)
        {
            return _cmdCommandsService.StartMining(input.Value);
        }

        [HttpPut("stopMining")]
        public bool StopMining([FromBody] SingleStringDTO input)
        {
            return _cmdCommandsService.StopMining(input.Value);
        }

        [HttpPut("balance")]
        public int GetBalanceFor([FromBody] SetUserToMineDTO input)
        {
            string result = _cmdCommandsService.GetBalance(input.NodeName, input.UserIndex);

            result = result.Remove(result.Length - 1);

            Double bigDouble = Double.Parse(result);
            //bigDouble /= 1000000000000000000;

            return (int)bigDouble;
        }

        [HttpPut("transfer")]
        public string TransferAmount([FromBody] TransferDTO input)
        {
            return _cmdCommandsService.TransferAmount(input);
        }

        [HttpPut("checkMining")]
        public bool CheckNodeMining([FromBody] SingleStringDTO input)
        {
            string response = _cmdCommandsService.IsNodeMining(input.Value);
            if (response.Length > 1)
            {
                response = response.Remove(response.Length - 1);
            } 

            return bool.Parse(response);
        }
    }
}
