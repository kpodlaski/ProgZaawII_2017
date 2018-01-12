using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetCommunicator {
    class CommunicatorServer {
        List<SocketConnection> connections = new List<SocketConnection> ();
        int port;
        volatile bool continueCommunication = true;
        ServerReceiver console;

        public CommunicatorServer(int port) {
            this.port = port;
            console = new ServerReceiver(this);
        }

        public void Start() {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            try {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (continueCommunication) {
                    Console.WriteLine("Waiting for a connection...");
                     
                    Socket handler = listener.Accept();
                    SocketConnection con = new SocketConnection(handler);
                    con.AddReceiver(console);
                    con.Start();
                    connections.Add(con);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        class ServerReceiver : IReceiver {

            private CommunicatorServer _server;
            public ServerReceiver (CommunicatorServer _server) {
                this._server = _server;
            }

            public void MessageReceived(string m, Object sender = null) {
                String msg;
                Console.WriteLine(sender != null);
                Console.WriteLine(sender is SocketConnection);
                if (sender != null && sender is SocketConnection) {
                    SocketConnection s = (SocketConnection) sender;
                    int senderId = _server.connections.IndexOf(s);
                    if (m.Equals(SocketConnection.END_COMMAND)) {
                        _server.connections.Remove(s);
                    }
                    msg = "[" + senderId + "]: " + m;

                }
                else {
                    msg = sender+ m;
                }
                foreach(SocketConnection sc in _server.connections) {
                    sc.SendMessage(msg);
                }
                Console.WriteLine(msg);
            }
        }
    }
}
