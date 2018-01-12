using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCommunicator {
    class ConsoleReceiver : IReceiver {
        public void MessageReceived(String msg, Object sender=null) {
            Console.WriteLine(msg);
        }
    }
}
