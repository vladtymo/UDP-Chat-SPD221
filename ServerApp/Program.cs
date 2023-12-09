using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    internal class Program
    {
        const int port = 3300;
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(port);

            IPEndPoint clientIP = null;

            while (true)
            {
                // wait new request from client
                Console.WriteLine("\t...Waiting new requests...");
                var data = server.Receive(ref clientIP);

                var message = Encoding.UTF8.GetString(data);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Request: {message} at {DateTime.Now} from {clientIP}");
                Console.ResetColor();

                // send response to the client
                server.Send(Encoding.UTF8.GetBytes("Good!"), clientIP);
            }
        }
    }
}