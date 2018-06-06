using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NodeJsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("192.168.1.114", 3000); //Connect to the server on our local host IP address, listening to port 3000

            NetworkStream clientStream = client.GetStream();
            while (clientStream.DataAvailable) //While the network stream say's there is data to be read
            {
                byte[] inMessage = new byte[4096];
                int bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(inMessage, 0, 4096);
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    Console.WriteLine(encoder.GetString(inMessage, 0, bytesRead));
                }
                catch { /*Catch exceptions and handle them here*/ }
            }
            

            client.Close();
            System.Threading.Thread.Sleep(10000); //Sleep for 10 seconds
        }
    }
}
