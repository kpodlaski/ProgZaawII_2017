using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCommunicator {
    class SocketConnection {
        List<IReceiver> receivers = new List<IReceiver>();
        private Socket socket;
        private ListeningThread listener;
        public const String END_COMMAND = "<END>";
        public volatile bool continueCommunication = true;
        public volatile bool closingCommunication = false;

        public SocketConnection(Socket s) {
            socket = s;
        }

        public void Start() {
            listener = new ListeningThread(this);
            listener.Start();
        }

        public void Close() {
            if (closingCommunication) {
                socket.Shutdown(SocketShutdown.Both);
                closingCommunication = false;
            }
            socket.Close();
        }

        public void AddReceiver(IReceiver rec) {
            receivers.Add(rec);
        }

        public void SendMessage(String text) {
            if (text.Equals(END_COMMAND)) {
                closingCommunication = true;
                continueCommunication = false;
            }
            byte[] msg = Encoding.ASCII.GetBytes(text);
            socket.Send(msg);
            if (text.Equals(END_COMMAND)) {
                Console.WriteLine("Press Key to Close Window");
                Console.ReadKey();
                Close();
            }
        }

        class ListeningThread {
            SocketConnection _con;
            
            public ListeningThread(SocketConnection sc) {
                _con = sc;
                _con.continueCommunication = true;
            }

            public void Start() {
                Thread t = new Thread(Run);
                t.Start();
            }

            public void Run() {
                byte[] buffer = new byte[1024];
                int readedBytes;
                while (_con.continueCommunication) {
                    readedBytes = _con.socket.Receive(buffer);
                    String text = Encoding.ASCII.GetString(buffer, 0, readedBytes);
                    if (text.Equals(END_COMMAND)) {
                        Console.WriteLine("Closing Communication");
                        _con.continueCommunication = false;
                    }
                    else {
                        foreach(IReceiver rec in _con.receivers)
                            rec.MessageReceived(text, _con);
                    }
                }
                _con.Close();
            }

            public void Close() {
                _con.continueCommunication = false;
                _con.Close();
            }
        }
    }
}
