using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_hackatron.Services
{
    public interface ICMDCommandsService
    {
        public Task<List<string>> Initialise();

        public List<string> PingNode();
    }
}
