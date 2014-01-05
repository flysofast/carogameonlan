using LTM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Y2Server
{
    const int MAX_CONNECTION = 10;
    const int PORT_NUMBER = 9999;
    static int _connectionsCount = 0;
    static TcpListener listener;
    static ASCIIEncoding encoding = new ASCIIEncoding();
    public static string LocalIPAddress()
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


    class StudentTCPServer
    {

        const int MAX_CONNECTION = 10;
        const int PORT_NUMBER = 9999;
        static int _connectionsCount = 0;
        static TcpListener listener;

        static Dictionary<string, Socket> clientList =
            new Dictionary<string, Socket>();
        static Dictionary<string, Client> clientInfo =
            new Dictionary<string, Client>();

        public static void Main()
        {
            IPAddress address = IPAddress.Parse(LocalIPAddress());

            listener = new TcpListener(address, PORT_NUMBER);
            Console.WriteLine("Waiting for connection...");
            listener.Start();

            while (_connectionsCount < MAX_CONNECTION || MAX_CONNECTION == 0)
            {
                Socket soc = listener.AcceptSocket();

                if (clientList.ContainsKey(soc.RemoteEndPoint.ToString()))
                {

                }
                _connectionsCount++;

                Thread t = new Thread((obj) =>
                                      {
                                          DoWork((Socket)obj);
                                      });
                t.Start(soc);
            }
        }
        void AddClient(Socket soc)
        {
            Client cl = new Client();
            cl.socket = soc;
            if (clientList.ContainsKey(soc.RemoteEndPoint.ToString()))
            {

            }
        }

        static void DoWork(Socket soc)
        {
            Console.WriteLine("Connection received from: {0}",
                              soc.RemoteEndPoint);
            try
            {
                var stream = new NetworkStream(soc);
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                writer.WriteLine("Welcome to Student TCP Server");
                writer.WriteLine("Please enter the student id");

                while (true)
                {
                    //string id = reader.ReadLine();

                    //if (String.IsNullOrEmpty(id))
                    //    break; // disconnect

                    //if (_data.ContainsKey(id))
                    //    writer.WriteLine("Student's name: '{0}'", _data[id]);
                    //else
                    //    writer.WriteLine("Can't find name for student id '{0}'", id);
                    //while (true)
                    //{
                    //    writer.WriteLine("Can't find name for stu");
                    //    Thread.Sleep(500);
                    //}

                    writer.WriteLine("Can't find name for stu");
                    Thread.Sleep(5000);
                }
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

            Console.WriteLine("Client disconnected: {0}",
                              soc.RemoteEndPoint);
            soc.Close();
        }
    }
}