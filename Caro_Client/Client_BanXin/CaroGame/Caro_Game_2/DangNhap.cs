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

            Caro_Client.KetNoiServer(txtIpsv.Text, 9999);
            Caro_Client.GuiAlias(tendn);
            Game fg = new Game();
            fg.ten = tendn;
            fg.Show();
            this.Hide();
            //code xu ly dang nhap...
        }
    }
}
