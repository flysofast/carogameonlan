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
    public static string GetLocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
    public static void Main()
    {

        try
        {
            TcpClient client = new TcpClient();

            // 1. connect
            client.Connect(GetLocalIPAddress(), PORT_NUMBER);
            Stream stream = client.GetStream();
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            writer.WriteLine("/:al:/2");
            Console.WriteLine("Connected to Y2Server.");
            while (true)
            {
                Console.Write("Enter your name: ");

                string str = Console.ReadLine();
                
                writer.WriteLine("/:ms:/<recipient>1</recipient><content>"+str+"</content>");
                // 2. send

                // 3. receive
                //str = reader.ReadLine();
                //Console.WriteLine(str);
                if (str.ToUpper() == "/:EX:/")
                    break;
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