using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management.Automation;
using System.Threading;

namespace backend_hackatron.Services
{
    public class CMDCommandsService: ICMDCommandsService
    {
        private static PowerShell MasterPS;
        private static PowerShell TemporaryPS;
        
        public async Task<List<string>> Initialise()
        {
            MasterPS = PowerShell.Create();

            string command = "";
            List<string>resultString = new List<string>();

            // create blockchain
            command = "C:/\"Program Files\"/Geth/geth.exe -datadir ./privateChain init ./Configs/genesis.json";
            MasterPS.AddScript(command);

            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            var results = MasterPS.BeginInvoke<PSObject, PSObject>(null, outputCollection);
            results.AsyncWaitHandle.WaitOne();
            var tmp = MasterPS.Streams.Error.ReadAll();
            foreach(var line in tmp)
            {
                resultString.Add(line.Exception.Message);
            }
            MasterPS.Commands.Clear();

            command = "C:/\"Program Files\"/Geth/geth.exe --datadir ./privateChain --nodiscover --networkid 1234 --port 30306 --authrpc.port 8552 --rpc.enabledeprecatedpersonal";
            MasterPS.AddScript(command);

            outputCollection = new PSDataCollection<PSObject>();

            results = MasterPS.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            tmp = MasterPS.Streams.Error.ReadAll();

            return resultString;
        }


        public List<string> PingNode()
        {
            TemporaryPS = PowerShell.Create();

            string command = "C:/\"Program Files\"/Geth/geth.exe --exec eth.accounts attach \\\\.\\pipe\\geth.ipc";
            List<string> resultString = new List<string>();

            TemporaryPS.AddScript(command);

            PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();

            var results = TemporaryPS.BeginInvoke<PSObject, PSObject>(null, outputCollection);
            results.AsyncWaitHandle.WaitOne();

            foreach(var element in outputCollection)
            {
                resultString.Add(element.BaseObject.ToString());
            }

            return resultString;
        }
    }
}
