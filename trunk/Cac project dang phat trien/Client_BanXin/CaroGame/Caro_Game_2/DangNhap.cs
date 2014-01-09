using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Caro_Game_2
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public string myip;

        public string GetIP()
        {
            string ip = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress diachi in host.AddressList)
            {
                if (diachi.AddressFamily.ToString() == "InterNetwork")
                {
                    ip = diachi.ToString();
                }
            }
            return ip;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            lblMyIP.Text = GetIP();
            txtTendangnhap.Focus();
            AcceptButton = btnStart;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtTendangnhap.Text.Trim() == "" || txtIpsv.Text.Trim() == "")
            {
                lblThongbao.Text = "Bạn nhập thiếu thông tin!!!";
                return;
            }
            if (txtTendangnhap.Text[0] >= 48 && txtTendangnhap.Text[0] <= 57)
            {
                lblThongbao.Text = "Tên đăng nhập có ký tự số đầu!!";
                return;
            }
            string tendn = txtTendangnhap.Text;
            try
            {
                Caro_Client.KetNoiServer(txtIpsv.Text, 1);
                Caro_Client.GuiAlias(tendn);
                var reader = new StreamReader(Caro_Client.stream);
                string str = reader.ReadLine();
                if (str.Substring(0, 6) == "/:AD:/")
                {
                    Game fg = new Game();
                    fg.ten = tendn;
                    fg.Show();
                    this.Hide();
                }
                if (str.Substring(0, 6) == "/:CF:/")
                    MessageBox.Show("Trùng tên - Vui lòng nhập tên khác");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối máy chủ thất bại : " + ex.Message);
            }
            //code xu ly dang nhap...
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
