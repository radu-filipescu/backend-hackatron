using backend_hackatron.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_hackatron.Services
{
    public interface ICMDCommandsService
    {
        public Task<List<string>> InitialiseNode1();
        public Task<List<string>> InitialiseNode2();
        public Task<List<string>> InitialiseNode3();
        public Task<List<string>> InitialiseNode4();
        public Task<List<string>> InitialiseNode5();

        public List<string> CreateUser(string nodeName);

        public List<string> GetAllUsersFromNode(string nodeName);

        public List<string> SetUserToMine(string nodeName, int userIndex);

        public bool StartMining(string nodeName);
        public bool StopMining(string nodeName);

        public string GetBalance(string nodeName, int userIndex);

        public string TransferAmount(TransferDTO input);

        public string IsNodeMining(string nodeName);
    }
}
