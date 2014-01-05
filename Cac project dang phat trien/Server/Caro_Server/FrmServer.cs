using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_Server
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
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
        //private void btStart_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    IPAddress address = IPAddress.Parse(LocalIPAddress());

        //    //    TcpListener listener = new TcpListener(address, 65535);

        //    //    // 1. listen
        //    //    listener.Start();


        //    //    lbxLog.Items.Add("Server started on " + listener.LocalEndpoint.ToString());
        //    //    lbxLog.Items.Add("Waiting for a connection...");

        //    //    Socket socket = listener.AcceptSocket();
        //    //    lbxLog.Items.Add("Connection received from " + socket.RemoteEndPoint);

        //    //    var stream = new NetworkStream(socket);
        //    //    var reader = new StreamReader(stream);
        //    //    var writer = new StreamWriter(stream);
        //    //    writer.AutoFlush = true;

        //    //    while (true)
        //    //    {
        //    //        // 2. receive
        //    //        string str = reader.ReadLine();
        //    //        if (str.ToUpper() == "EXIT")
        //    //        {
        //    //            writer.WriteLine("bye");
        //    //            break;
        //    //        }
        //    //        // 3. send
        //    //        writer.WriteLine("Hello " + str);
        //    //    }
        //    //    // 4. close
        //    //    stream.Close();
        //    //    socket.Close();
        //    //    listener.Stop();

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    lbxLog.Items.Add("Error: " + ex);
        //    //}
        //    IPAddress address = IPAddress.Parse(GetLocalIPAddress());
        //    listener = new TcpListener(address, 9999);
        //    clientListening = new Thread(new ThreadStart(Listen));
        //    clientListening.IsBackground = true;
        //    clientListening.Start();
        //    rtbLog.AppendText("Đang chờ kết nối tới " + listener.LocalEndpoint + "...\r\n");
        //    btStart.Enabled = false;
        //}
        TcpListener listener;
        Thread clientListening;
        private void FrmServer_Load(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Parse(GetLocalIPAddress());
            listener = new TcpListener(address, 9999);
            clientListening = new Thread(new ThreadStart(Listen));
            clientListening.IsBackground = true;
            clientListening.Start();
            rtbLog.AppendText(listener.LocalEndpoint + " đang chờ kết nối...\r\n");
        }
        static Dictionary<string, Socket> clientList = new Dictionary<string, Socket>();
        void Listen()
        {
            listener.Start();
            while (true)
            {
                Socket clientSoc = listener.AcceptSocket();
                Thread clientCommunicating = new Thread(clientProcess);
                clientCommunicating.IsBackground = true;
                clientCommunicating.Start(clientSoc);
                rtbLog.AppendText("Đã nhận kết nối từ " + clientSoc.RemoteEndPoint + "\r\n");
            }
        }
        void clientProcess(object soc)
        {

            Socket clientSoc = (Socket)soc;
            var stream = new NetworkStream(clientSoc);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            try
            {
                while (true)
                {

                    // Nhận dữ liệu từ client
                    string str = reader.ReadLine();
                    rtbLog.AppendText(string.Format("{0}: {1}\r\n", clientSoc.RemoteEndPoint, str));
                    if (str.ToUpper() == "/:EX:/")
                    {
                        writer.WriteLine("/:EX:/");


                        rtbLog.AppendText(clientSoc.RemoteEndPoint + " đã ngắt kết nối\r\n");

                        stream.Close();
                        clientSoc.Close();
                        break;
                    }

                    if (str.Length >= 6 && str.ToUpper().Substring(0, 6) == "/:AL:/")
                    {
                        string alias = str.Substring(6);
                        if (clientList.ContainsKey(alias))
                        {
                            rtbLog.AppendText(string.Format("Từ chối yêu cầu thêm alias \"{0}\" từ {1} vì đã tồn tại\r\n"
                                , alias, clientSoc.RemoteEndPoint));
                            writer.WriteLine("/:TR:/");
                            continue;
                        }

                        clientList.Add(alias, clientSoc);

                        rtbLog.AppendText(clientSoc.RemoteEndPoint + " đã được thêm vào danh sách với alias \""
                            + alias + "\"\r\n");
                        rtbClients.AppendText(alias + " : " + clientSoc.RemoteEndPoint + "\r\n");
                        writer.WriteLine("/:OK:/");
                    }

                    writer.WriteLine("RECEIVED!");
                }

            }
            catch (Exception ex)
            {
                rtbLog.AppendText("clientProcess:\r\n");
                rtbLog.AppendText(ex.Message + "\r\n");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        
    }
}
