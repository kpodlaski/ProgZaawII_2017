using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCommunicator {
    public class CommunicatorClient {
        int port;
        ConsoleReceiver console = new ConsoleReceiver();
        SocketConnection con;

        public CommunicatorClient(int port) {
            this.port = port;
        }

        public void Start() {
            try {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                // Connect the socket to the remote endpoint. Catch any errors.  
                try {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());
                    con = new SocketConnection(sender);
                    con.AddReceiver(console);
                    con.Start();
                    Thread t = new Thread(keyboardListener);
                    t.Start();
                }
                catch (ArgumentNullException ane) {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se) {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e) {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void Send(String msg) {
            con.SendMessage(msg);
        }

        public void keyboardListener() {
            while (con.continueCommunication) {
                String msg = Console.ReadLine();
                Send(msg);
            }
        }

    }
}
