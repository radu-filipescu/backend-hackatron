using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management.Automation;
using System.Threading;
using backend_hackatron.DTOs;
using System.IO;

namespace backend_hackatron.Services
{
    public class CMDCommandsService: ICMDCommandsService
    {
        private static PowerShell MasterPS1;
        private static PowerShell MasterPS2;
        private static PowerShell MasterPS3;
        private static PowerShell MasterPS4;
        private static PowerShell MasterPS5;
        
        public async Task<List<string>> InitialiseNode1()
        {
            if (Directory.Exists("privateChain1"))
                return new List<string>();
            
            MasterPS1 = PowerShell.Create();

            string command = "";
            List<string>resultString = new List<string>();

            // create blockchain
            command = "C:/\"Program Files\"/Geth/geth.exe -datadir ./privateChain1 init ./Configs/genesis.json";
            MasterPS1.AddScript(command);

            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            var results = MasterPS1.BeginInvoke<PSObject, PSObject>(null, outputCollection);
            results.AsyncWaitHandle.WaitOne();
            var tmp = MasterPS1.Streams.Error.ReadAll();
            foreach(var line in tmp)
            {
                resultString.Add(line.Exception.Message);
            }
            MasterPS1.Commands.Clear();
                                                         
            command = "C:/\"Program Files\"/Geth/geth.exe --datadir ./privateChain1 --nodiscover --networkid 1234 --port 30301 --authrpc.port 8551 --rpc.enabledeprecatedpersonal --ipcpath ./privateChain1";
            MasterPS1.AddScript(command);

            outputCollection = new PSDataCollection<PSObject>();

            results = MasterPS1.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            tmp = MasterPS1.Streams.Error.ReadAll();

            return resultString;
        }

        public async Task<List<string>> InitialiseNode2()
        {
            if (Directory.Exists("privateChain2"))
                return new List<string>();

            MasterPS2 = PowerShell.Create();

            string command = "";
            List<string> resultString = new List<string>();

            // create blockchain
            command = "C:/\"Program Files\"/Geth/geth.exe -datadir ./privateChain2 init ./Configs/genesis.json";
            MasterPS2.AddScript(command);

            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            var results = MasterPS2.BeginInvoke<PSObject, PSObject>(null, outputCollection);
            results.AsyncWaitHandle.WaitOne();
            var tmp = MasterPS2.Streams.Error.ReadAll();
            foreach (var line in tmp)
            {
                resultString.Add(line.Exception.Message);
            }
            MasterPS2.Commands.Clear();

            command = "C:/\"Program Files\"/Geth/geth.exe --datadir ./privateChain2 --nodiscover --networkid 1234 --port 30302 --authrpc.port 8552 --rpc.enabledeprecatedpersonal --ipcpath ./privateChain2";
            MasterPS2.AddScript(command);

            outputCollection = new PSDataCollection<PSObject>();

            results = MasterPS2.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            tmp = MasterPS2.Streams.Error.ReadAll();

            return resultString;
        }

        public async Task<List<string>> InitialiseNode3()
        {
            if (Directory.Exists("privateChain3"))
                return new List<string>();

            MasterPS3 = PowerShell.Create();

            string command = "";
            List<string> resultString = new List<string>();

            // create blockchain
            command = "C:/\"Program Files\"/Geth/geth.exe -datadir ./privateChain3 init ./Configs/genesis.json";
            MasterPS3.AddScript(command);

            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            var results = MasterPS3.BeginInvoke<PSObject, PSObject>(null, outputCollection);
            results.AsyncWaitHandle.WaitOne();
            var tmp = MasterPS3.Streams.Error.ReadAll();
            foreach (var line in tmp)
            {
                resultString.Add(line.Exception.Message);
            }
            MasterPS3.Commands.Clear();

            command = "C:/\"Program Files\"/Geth/geth.exe --datadir ./privateChain3 --nodiscover --networkid 1234 --port 30303 --authrpc.port 8553 --rpc.enabledeprecatedpersonal --ipcpath ./privateChain3";
            MasterPS3.AddScript(command);

            outputCollection = new PSDataCollection<PSObject>();

            results = MasterPS3.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            tmp = MasterPS3.Streams.Error.ReadAll();

            return resultString;
        }

        public async Task<List<string>> InitialiseNode4()
        {
            if (Directory.Exists("privateChain4"))
                return new List<string>();

            MasterPS4 = PowerShell.Create();

            string command = "";
            List<string> resultString = new List<string>();

            // create blockchain
            command = "C:/\"Program Files\"/Geth/geth.exe -datadir ./privateChain4 init ./Configs/genesis.json";
            MasterPS4.AddScript(command);

            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            var results = MasterPS4.BeginInvoke<PSObject, PSObject>(null, outputCollection);
            results.AsyncWaitHandle.WaitOne();
            var tmp = MasterPS4.Streams.Error.ReadAll();
            foreach (var line in tmp)
            {
                resultString.Add(line.Exception.Message);
            }
            MasterPS4.Commands.Clear();

            command = "C:/\"Program Files\"/Geth/geth.exe --datadir ./privateChain4 --nodiscover --networkid 1234 --port 30304 --authrpc.port 8554 --rpc.enabledeprecatedpersonal --ipcpath ./privateChain4";
            MasterPS4.AddScript(command);

            outputCollection = new PSDataCollection<PSObject>();

            results = MasterPS4.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            tmp = MasterPS4.Streams.Error.ReadAll();

            return resultString;
        }

        public async Task<List<string>> InitialiseNode5()
        {
            if (Directory.Exists("privateChain5"))
                return new List<string>();

            MasterPS5 = PowerShell.Create();

            string command = "";
            List<string> resultString = new List<string>();

            // create blockchain
            command = "C:/\"Program Files\"/Geth/geth.exe -datadir ./privateChain5 init ./Configs/genesis.json";
            MasterPS5.AddScript(command);

            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            var results = MasterPS5.BeginInvoke<PSObject, PSObject>(null, outputCollection);
            results.AsyncWaitHandle.WaitOne();
            var tmp = MasterPS5.Streams.Error.ReadAll();
            foreach (var line in tmp)
            {
                resultString.Add(line.Exception.Message);
            }
            MasterPS5.Commands.Clear();

            command = "C:/\"Program Files\"/Geth/geth.exe --datadir ./privateChain5 --nodiscover --networkid 1234 --port 30305 --authrpc.port 8555 --rpc.enabledeprecatedpersonal --ipcpath ./privateChain5";
            MasterPS5.AddScript(command);

            outputCollection = new PSDataCollection<PSObject>();

            results = MasterPS5.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            tmp = MasterPS5.Streams.Error.ReadAll();

            AfterInitialization();

            return resultString;
        }

        private void AfterInitialization()
        {
            CreateUser("privateChain1");
            CreateUser("privateChain1");
            SetUserToMine("privateChain1", 0);
            CreateUser("privateChain2");
            CreateUser("privateChain2");
            SetUserToMine("privateChain2", 0);
            CreateUser("privateChain3");
            CreateUser("privateChain3");
            CreateUser("privateChain3");
            SetUserToMine("privateChain3", 0);
            CreateUser("privateChain4");
            CreateUser("privateChain4");
            SetUserToMine("privateChain4", 0);
            CreateUser("privateChain5");
            SetUserToMine("privateChain5", 0);
        }

        public string CreateUser(string nodeName)
        {
            if (!Directory.Exists("privateChain1"))
                return string.Empty;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec web3.personal.newAccount(\"1234567890\") attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.Kill();

            return result;
        }

        public string GetAllUsersFromNode(string nodeName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec eth.accounts attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.Kill();

            return result;
        }

        public string SetUserToMine(string nodeName, int userIndex)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec miner.setEtherbase(eth.accounts[" + userIndex.ToString()+"]) attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.Kill();

            return result;
        }

        public bool StartMining(string nodeName)
        {
            if (!Directory.Exists("privateChain1"))
                return false;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec miner.start() attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            List<string> resultList = new List<string>();
            resultList.Add(result);

            process.Kill();

            return true;
        }

        public bool StopMining(string nodeName)
        {
            if (!Directory.Exists("privateChain1"))
                return false;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec miner.stop() attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            List<string> resultList = new List<string>();
            resultList.Add(result);

            process.Kill();

            return true;
        }

        public string GetBalance(string nodeName, int userIndex)
        {
            if (!Directory.Exists("privateChain1"))
                return string.Empty;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            // string command = "C:/\"Program Files\"/Geth/geth.exe --exec eth.getBalance(eth.accounts[" + userIndex.ToString() + "]) attach \\\\.\\pipe\\" + nodeName;
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec web3.fromWei(eth.getBalance(eth.accounts[" + userIndex.ToString() + "]),'ether') attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            List<string> resultList = new List<string>();
            resultList.Add(result);

            process.Kill();

            return result;
        }

        public string TransferAmount(TransferDTO input)
        {
            if (!Directory.Exists("privateChain1"))
                return string.Empty;

            if (input.TransferAmount == 0)
                return string.Empty;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec web3.personal.sendTransaction({from:eth.accounts[" + input.SenderIdx.ToString() + "],to:eth.accounts[" + input.ReceiverIdx.ToString() + "],value:web3.toWei('" + input.TransferAmount.ToString() + "','ether')},'1234567890') attach \\\\.\\pipe\\" + input.nodeName;
            //string command = "C:/\"Program Files\"/Geth/geth.exe --exec web3.personal.sendTransaction({from:eth.accounts[" + input.SenderIdx.ToString() + "],to:eth.accounts[" + input.ReceiverIdx.ToString() + "],value:web3.toWei('" + input.TranferAmount.ToString() + "','ether') },'1234567890') attach \\\\.\\pipe\\" + input.nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.Kill();

            return result;
        }

        public string IsNodeMining(string nodeName)
        {
            if (!Directory.Exists("privateChain1"))
                return string.Empty;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec eth.mining attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.Kill();

            return result;
        }

        public string GetBlocksForNode(string nodeName)
        {
            if (!Directory.Exists("privateChain1"))
                return "0";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec eth.blockNumber attach \\\\.\\pipe\\" + nodeName;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.Kill();


            return result;
        }

        public string ConnectNodes(ConnectionDTO input)
        {
            if (!Directory.Exists("privateChain1"))
                return "0";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";

            string command = "C:/\"Program Files\"/Geth/geth.exe --exec admin.nodeInfo.enode attach \\\\.\\pipe\\" + input.Node1;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            if(result.Length > 3)
                result = result.Remove(result.Length - 2);

            if (result.Length > 1)
                result = result.Remove(0, 1);

            string result2 = secondPart(result, input.Node2);

            process.Kill();

            return result2;
        }

        private string secondPart(string input, string node2Name)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            string command = "C:/\"Program Files\"/Geth/geth.exe --exec admin.addPeer('" + input +"') attach //./pipe/" + node2Name;
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;

            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();

            process.Kill();

            return result;
        }
    }
}
