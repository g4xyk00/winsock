using System.Net;
using System.Net.Sockets;
using System;

namespace TestSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8099);
                Socket conn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    // Connect to Server
                    conn.Connect(server);

                    // Send File Content to Server
                    string filePath = "C:\\temp\\sample.txt";
                    conn.SendFile(filePath);

                    // Close TCP Connection
                    conn.Shutdown(SocketShutdown.Both);
                    conn.Close();
                }
                catch (Exception e)
                {
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
