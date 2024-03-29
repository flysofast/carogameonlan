﻿using System;
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
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;

        static ASCIIEncoding encoding = new ASCIIEncoding();
        public FrmServer()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Socket server;
        IPEndPoint ipe;
        string myIP = "";
        public void GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = ip.ToString();
                    break;
                }
            }
            ipe = new IPEndPoint(IPAddress.Parse(myIP), PORT_NUMBER);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }

        Thread clientListening;
        private void FrmServer_Load(object sender, EventArgs e)
        {
            GetLocalIPAddress();
            clientListening = new Thread(new ThreadStart(Listen));
            clientListening.IsBackground = true;
            clientListening.Start();
           
        }
        Dictionary<string, Socket> clientList = new Dictionary<string, Socket>();
        Dictionary<Socket, NetworkStream> streamList = new Dictionary<Socket, NetworkStream>();
        void Listen()
        {
            try
            {
                server.Bind(ipe);
                server.Listen(10);
                AppendText(server.LocalEndPoint + " đang chờ kết nối...\r\n", Color.Green);
                while (true)
                {   
                    Socket clientSoc = server.Accept  ();
                    Thread clientCommunicating = new Thread(clientProcess);
                    clientCommunicating.IsBackground = true;
                    clientCommunicating.Start(clientSoc);
                    AppendText("Đã nhận kết nối từ " + clientSoc.RemoteEndPoint + "\r\n", Color.Green);
                }
            }
            catch (Exception ex)
            {

                AppendText("Listen:\r\n", Color.Red);
                AppendText(ex.Message + "\r\n", Color.Red);
            }
        }


        /// <summary>
        /// Hàm xử lý gửi nhận tin với client đang được kết nối
        /// </summary>
        /// <param name="soc">socket của client đang được kết nối</param>
        void clientProcess(object soc)
        {

            Socket clientSoc = (Socket)soc;
            //var stream = new NetworkStream(clientSoc);
            //var reader = new StreamReader(stream);
            //var writer = new StreamWriter(stream);
            //writer.AutoFlush = true;
            byte[] buff = new byte[BUFFER_SIZE];
            
            //Đã đăng kí alias hay chưa
            bool registered = false;
            try
            {
                while (true)
                {


                    // Nhận dữ liệu từ client
                    int rcv = clientSoc.Receive(buff);
                    string str = encoding.GetString(buff).TrimEnd('\0').TrimEnd('\n').TrimEnd('\r');
                    AppendText(string.Format("{0}: {1}\r\n", clientSoc.RemoteEndPoint, str), Color.Black);

                    //Nếu chưa đăng kí alias
                    if (!registered)
                    {
                        //Cấu trúc yêu cầu đăng kí alias: /:al:/<alias> => đăng kí alias là <alias>
                        //Xác nhận thêm thành công (added): /:AD:/ => đã thêm alias vào danh sách client
                        //Xác nhận trùng alias (conflicted): /:CF:/ => chưa thêm vào danh sách, nhập lại alias khác
                        if (str.Length >= 6 && str.ToUpper().Substring(0, 6) == "/:AL:/")
                        {
                            string alias = str.Substring(6);

                            //Nếu alias này đã có người đăng kí trước
                            if (clientList.ContainsKey(alias))
                            {
                                AppendText(string.Format("Từ chối yêu cầu thêm alias \"{0}\" từ {1} vì đã tồn tại\r\n"
                                    , alias, clientSoc.RemoteEndPoint), Color.Green);

                                //Gửi thông báo trùng alias
                                //writer.WriteLine("/:AD:/");
                                clientSoc.Send(encoding.GetBytes("/:CF:/"));

                                continue;
                            }

                            clientList.Add(alias, clientSoc);

                            AppendText(clientSoc.RemoteEndPoint + " đã được thêm vào danh sách với alias \""
                                + alias + "\"\r\n", Color.Green);

                            UpdateClientsListDisplay();
                            clientSoc.Send(encoding.GetBytes("/:AD:/"));
                            //writer.WriteLine("/:AD:/");
                            registered = true;
                            continue;
                        }
                    }

                    //Nếu đã đăng kí alias
                    else
                    {
                        //Cấu trúc yêu cầu đóng kết nối (disconnect): /:dc:/ => yêu cầu ngắt kết nối
                        //KHÔNG GỬI TRẢ XÁC NHẬN VỀ CLIENT VÌ CLIENT ĐÃ ĐÓNG KẾT NỐI
                        if (str.ToUpper() == "/:DC:/")
                        {
                            AppendText(clientSoc.RemoteEndPoint + " đã ngắt kết nối\r\n", Color.Green);


                            //stream.Close();
                            clientSoc.Close();

                            clientList.Remove(clientList.First(p => p.Value == clientSoc).Key);

                            UpdateClientsListDisplay();
                            break;
                        }


                        //Cấu trúc: /:ms:/<recipient><alias người nhận></recipient><content><nội dung></content> 
                        //  => gửi tin nhắn có nội dung <nội dung> tới <alias người nhận>
                        //Nội dung tin nhắn có thể là tin nhắn chat, các lệnh đánh, xin thua,... được quy định ở client
                        //Xác nhận thành công (succeed): /:SC:/
                        //Xác nhận không tìm thấy alias này trong danh sách client đang kết nối (not found): /:NF:/
                        if (str.Length >= 6 && str.ToUpper().Substring(0, 6) == "/:MS:/")
                        {
                            string clientString = str.Substring(6);
                            string alias = GetElement(clientString, "recipient");
                            string message = GetElement(clientString, "content");


                            if (clientList.Any(p => p.Key == alias))
                            {
                                Socket cs = clientList.Single(p => p.Key == alias).Value;
                                cs.Send(encoding.GetBytes(message));
                                clientSoc.Send(encoding.GetBytes("/:SC:/"));
                             

                                AppendText(string.Format("Đã gửi tin nhắn tới alias \"" + alias + "\"\r\n"), Color.Green);
                            }
                            else
                            {
                                //writer.WriteLine("/:NF:/");
                                clientSoc.Send(encoding.GetBytes("/:NF:/"));
                                AppendText(string.Format("Không tìm thấy alias \"" + alias + "\". Tin nhắn chưa được gửi đi.\r\n"), Color.Green);
                            }


                            continue;

                        }
                    }

                    //Client kết nối tới chưa đăng kí alias gửi tin chùa hoặc không theo đúng cấu trúc
                    //writer.WriteLine("Da nhan duoc tin nhan nhung khong thuc hien thao tac gi! Kiem tra lai cau truc tin nhan gui di!");
                    clientSoc.Send(encoding.GetBytes("Da nhan duoc tin nhan nhung khong thuc hien thao tac gi!\r\nKiem tra lai cau truc tin nhan gui di!"));
                    AppendText("Không thực hiện hành động gì\r\n", Color.Green);
                }

            }
            catch (Exception ex)
            {
                AppendText("clientProcess:\r\n", Color.Red);
                AppendText(ex.Message + "\r\n", Color.Red);

                //Có lỗi xảy ra, gửi thông báo cho client
                //writer.WriteLine("/:ER:/");

            }

        }
        /// <summary>
        /// Lấy nội dung của một tag
        /// </summary>
        /// <param name="s">xâu nhập vào</param>
        /// <param name="tagname">tên tag</param>
        /// <returns>nội dung của tag</returns>
        string GetElement(string s, string tagname)
        {
            int start = s.IndexOf(tagname) + tagname.Length + 1;
            int length = s.IndexOf("/" + tagname) - start - 1;
            return s.Substring(start, length);
        }
        /// <summary>
        /// Hàm cập nhật lại danh sách client được hiển thị trên form
        /// </summary>
        void UpdateClientsListDisplay()
        {
            rtbClients.Clear();
            foreach (var client in clientList)
            {
                rtbClients.AppendText(client.Key + ": " + client.Value.RemoteEndPoint + "\r\n");
            }

        }

        public void AppendText(string text, Color color)
        {
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;

            rtbLog.SelectionColor = color;
            rtbLog.AppendText(text);
            rtbLog.SelectionColor = rtbLog.ForeColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Socket cs = clientList.Single(p => p.Key == "1").Value;
            byte[] data = new byte[1024];

            cs.Send(encoding.GetBytes("Hello "));
            AppendText(string.Format("Đã gửi tin nhắn tới alias \"" + "1" + "\"\r\n"), Color.Green);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Socket cs = clientList.Single(p => p.Key == "2").Value;
            byte[] data = new byte[1024];

            cs.Send(encoding.GetBytes("Hello "));
            AppendText(string.Format("Đã gửi tin nhắn tới alias \"" + "2" + "\"\r\n"), Color.Green);
        }


    }
}
