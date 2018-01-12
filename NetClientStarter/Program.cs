using NetCommunicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetClientStarter {
    class Program {
        static void Main(string[] args) {
            CommunicatorClient c = new CommunicatorClient(8000);
            c.Start();
        }
    }
}
