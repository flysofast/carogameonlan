using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class Y2Client
{

    private const int BUFFER_SIZE = 1024;
    private const int PORT_NUMBER = 9999;

    static ASCIIEncoding encoding = new ASCIIEncoding();

    public static void Main()
    {

        try
        {
            TcpClient client = new TcpClient();

            // 1. connect
            client.Connect("192.168.0.102", PORT_NUMBER);
            Stream stream = client.GetStream();

            Console.WriteLine("Connected to Y2Server.");
            Console.Write("Enter your name: ");

            //var reader = new StreamReader(stream);
            //var writer = new StreamWriter(stream);
            //writer.AutoFlush = true;

            // 2. send
            byte[] data = encoding.GetBytes("/:al:/1");

            stream.Write(data, 0, data.Length);

            while (true)
            {
                data = new byte[BUFFER_SIZE];
                stream.Read(data, 0, BUFFER_SIZE);
                string st = encoding.GetString(data).TrimEnd('\0').TrimEnd('\n').TrimEnd('\r');
                Console.WriteLine(st);
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }

        Console.Read();
    }
}