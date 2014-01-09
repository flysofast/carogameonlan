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

        TcpListener listener;
        Thread clientListening;
        private void FrmServer_Load(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Parse(GetLocalIPAddress());
            listener = new TcpListener(address, 9999);
            clientListening = new Thread(new ThreadStart(Listen));
            clientListening.IsBackground = true;
            clientListening.Start();
            AppendText(listener.LocalEndpoint + " đang chờ kết nối...", Color.Green);
        }
        static Dictionary<string, Socket> clientList = new Dictionary<string, Socket>();
        void Listen()
        {
            try
            {
                listener.Start();
                while (true)
                {
                    Socket clientSoc = listener.AcceptSocket();
                    Thread clientCommunicating = new Thread(clientProcess);
                    clientCommunicating.IsBackground = true;
                    clientCommunicating.Start(clientSoc);
                    AppendText("Đã nhận kết nối từ " + clientSoc.RemoteEndPoint + ".", Color.Green);
                }
            }
            catch (Exception ex)
            {

                AppendText("Listen:", Color.Red);
                AppendText(ex.Message, Color.Red);
            }
        }


        /// <summary>
        /// Hàm xử lý gửi nhận tin với client đang được kết nối
        /// </summary>
        /// <param name="soc">socket của client đang được kết nối</param>
        void clientProcess(object soc)
        {
            Socket clientSoc = (Socket)soc;
            var stream = new NetworkStream(clientSoc);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            //Đã đăng kí alias hay chưa
            bool registered = false;
            try
            {
                while (true)
                {


                    // Nhận dữ liệu từ client
                    string str = reader.ReadLine();



                    AppendText(string.Format("{0}: {1}", clientSoc.RemoteEndPoint, str), Color.Black);

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
                                AppendText(string.Format("Từ chối yêu cầu thêm alias \"{0}\" từ {1} vì đã tồn tại."
                                    , alias, clientSoc.RemoteEndPoint), Color.Green);

                                //Gửi thông báo trùng alias
                                writer.WriteLine("/:CF:/");

                                continue;
                            }

                            clientList.Add(alias, clientSoc);

                            AppendText(clientSoc.RemoteEndPoint + " đã được thêm vào danh sách với alias \""
                                + alias + "\".", Color.Green);

                            UpdateClientsListDisplay();
                            writer.WriteLine("/:AD:/");
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
                            AppendText(clientSoc.RemoteEndPoint + " đã ngắt kết nối.", Color.Green);


                            stream.Close();
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
                                var st = new NetworkStream(cs);
                                var wr = new StreamWriter(st);
                                wr.AutoFlush = true;

                                wr.WriteLine(message);
                                writer.WriteLine("/:SC:/");
                                AppendText(string.Format("Đã gửi tin nhắn tới alias \"" + alias + "\"."), Color.Green);
                            }
                            else
                            {
                                writer.WriteLine("/:NF:/");
                                AppendText(string.Format("Không tìm thấy alias \"" + alias + "\". Tin nhắn chưa được gửi đi."), Color.Green);
                            }
                            continue;
                        }
                    }

                    //Client kết nối tới chưa đăng kí alias gửi tin chùa hoặc không theo đúng cấu trúc
                    writer.WriteLine("Da nhan duoc lenh nhung khong thuc hien thao tac gi. Kiem tra lai cau truc tin nhan gui di!");
                    AppendText("Không thực hiện hành động gì.", Color.Green);
                }

            }
            catch (Exception ex)
            {
                AppendText("clientProcess:", Color.Red);
                AppendText(ex.Message, Color.Red);
                stream.Close();
                clientSoc.Close();

                AppendText("Ngắt kết nối đến \"" + clientList.First(p => p.Value == clientSoc).Key + "\".", Color.Green);
                clientList.Remove(clientList.First(p => p.Value == clientSoc).Key);

                UpdateClientsListDisplay();
                //clientSoc.Close();
                //Có lỗi xảy ra, gửi thông báo cho client
                //writer.WriteLine("/:ER:/");

            }

        }

        void BroadcastClientList()
        {
            string cls = "";
            foreach (var client in clientList)
            {
                cls += client.Key + ";";
            }
            foreach (var client in clientList)
            {
                Socket cs = client.Value;
                var st = new NetworkStream(cs);
                var wr = new StreamWriter(st);
                wr.AutoFlush = true;
                wr.WriteLine(string.Format("/:CL:/{0}", cls));
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
            int length = s.LastIndexOf("/" + tagname) - start - 1;
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
            BroadcastClientList();
        }

        public void AppendText(string text, Color color)
        {
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;

            rtbLog.SelectionColor = color;
            rtbLog.AppendText(text + "\r\n");
            rtbLog.SelectionColor = rtbLog.ForeColor;
            rtbLog.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }



    }
}
