using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

namespace TestSocketServer{
    class Program{
        static void Main(string[] args){
            IPEndPoint server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8099);
            Socket conn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try{
                // Started as Server
                conn.Bind(server);
                conn.Listen(10);
                Console.WriteLine("[Server] Listening to TCP port 8099");

                while (true){
                    Socket client = conn.Accept();

                    //Receive data from Client
                    byte[] bytes = new Byte[1024];
                    string data = null;
                    while (true){
                        data += Encoding.ASCII.GetString(bytes, 0, client.Receive(bytes));
                        break;
                    }

                    Console.WriteLine("{0} ", data);
                }
            }
            catch (Exception e){
            }
        }
    }
}
