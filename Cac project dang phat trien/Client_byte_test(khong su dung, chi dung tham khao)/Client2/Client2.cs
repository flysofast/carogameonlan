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
            //Console.Write("Enter your name: ");
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            writer.WriteLine("/:al:/2");
            //string str = Console.ReadLine();
            while (true)
            {
                Console.Write("Enter your name: ");

                string str = Console.ReadLine();
                
                writer.WriteLine("/:ms:/<recipient>1</recipient><content>"+str+"</content>");
                // 2. send

                // 3. receive
                //str = reader.ReadLine();
                //if (str.ToUpper() == "/:EX:/")
                //    break;
                
            }
            // 4. close
            stream.Close();
            client.Close();
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }

        Console.Read();
    }
}