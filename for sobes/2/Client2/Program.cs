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
            TcpClient client = new TcpClient("127.0.0.1",7000);
            Console.WriteLine("Client  connected");
            NetworkStream stream= client.GetStream();

            string request = "I have an question";
            byte[] bytesWrite = Encoding.ASCII.GetBytes(request);
            stream.Write(bytesWrite, 0, bytesWrite.Length);
            stream.Flush();
            Console.WriteLine("Client sent request"+ bytesWrite.Length);

            byte[] bytesRead = new byte[256];
            int lenght = stream.Read(bytesWrite, 0, bytesWrite.Length);
            string answer = Encoding.ASCII.GetString(bytesRead, 0, lenght);
            Console.WriteLine(answer);

            client.Close();
            Console.WriteLine("Client closed");
        }
        catch(Exception e) 
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadLine();
    }
}
