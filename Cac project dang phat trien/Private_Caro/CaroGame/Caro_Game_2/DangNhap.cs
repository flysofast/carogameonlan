﻿using System;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Caro_Client.KetNoiServer("127.0.0.1", 9999);
            Caro_Client.GuiAlias(textBox1.Text);
            Game game=new Game();
            game.Show();

        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Caro_Client.NgatKetNoi();
        }
    }
}
