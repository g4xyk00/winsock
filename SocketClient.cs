using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

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

                    // Send Data to Server
                    String dateTime = DateTime.Now.ToString("h:mm:ss tt");
                    byte[] messageSent = Encoding.ASCII.GetBytes("[Client] Connecting to 127.0.0.1:8099 at " + dateTime);
                    int byteSent = conn.Send(messageSent);
                    byte[] messageReceived = new byte[1024];

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
