

using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {


            TcpListener serverSocket = new TcpListener(IPAddress.Any, 7000);
            Console.WriteLine("server started..");
            serverSocket.Start();

            while (true)
            {


                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                NetworkStream stream = clientSocket.GetStream();
                
                byte[] bytes = new byte[256];
                int length = stream.Read(bytes, 0, bytes.Length);
                string request = Encoding.ASCII.GetString(bytes, 0 , length);

                Console.Write("Got request: " + request);

                string message = "Length of your request" + request.Length;
                bytes = Encoding.ASCII.GetBytes(message);
                stream.Read(bytes, 0, bytes.Length);
                stream.Flush();
                Console.WriteLine("Sent message: "+ message);
                clientSocket.Close();
            }
            serverSocket.Stop();
            
            Console.WriteLine("server stopped");
            
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
        Console.ReadLine();
    }
}

