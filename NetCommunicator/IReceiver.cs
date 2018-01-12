using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCommunicator {
    interface IReceiver {
        void MessageReceived(String m, Object sender=null);
        
    }
}
