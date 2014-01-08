using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Caro_Game_2
{
    public partial class Game : Form
    {
        panelBan pb;
        public string ten;
        public string doithu;
        public int tysotrai;
        public int tysophai;
        public string[] dsnc;

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //Hiển thị
            lblTentoi.Text = ten;
            lblTendoithu.Text = "<doithu>";
            Thietlaptyso(0, 0);
            AcceptButton = btnGui;

            //tạo diện tích cho form Game
            Width = 912;
            Height = 610;

            pb = new panelBan(18, 26, true, 2);
            pb.Parent = this;
            pb.Left = 195;
            pb.Top = 80;

            // mặc định là đánh với humem
            humanVsComputerToolStripMenuItem.Checked = false;
            humanVsHumanToolStripMenuItem.Checked = true;

            //timer2.Interval = 100;
            //timer2.Enabled = true;
        }
        /// <summary>
        /// Tạo bàn mới
        /// </summary>
        int map = 26;
        public void TaoBan()
        {
            this.Controls.Remove(pb);
            pb = new panelBan(18, map, true, gMode());
            pb.Parent = this;
            pb.Left = 200;
            pb.Top = 80;

            //Width = map * 30 + 100;
            //Height = map * 30 + 150;
        }
        /// <summary>
        /// Chọn kiểu map là nhỏ 10x10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public int gMode()
        {
            if (humanVsComputerToolStripMenuItem.Checked == true) return 1;
            if (humanVsHumanToolStripMenuItem.Checked == true) return 2;
            return 3;
        }

        /// <summary>
        /// Hàm tạo game mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có chắc chắn muốn tạo game mới?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                TaoBan();
            }
        }
        private void humanVsHumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            humanVsComputerToolStripMenuItem.Checked = false;
            humanVsHumanToolStripMenuItem.Checked = true;
        }

        private void humanVsComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            humanVsComputerToolStripMenuItem.Checked = true;
            humanVsHumanToolStripMenuItem.Checked = false;
        }

        //Ham tra ve toa do khi click
        public void NhanToado(int x, int y)
        {
            //txtTimkiem.Text = x.ToString() + " " + y.ToString();
            pb.Xoasukienclick();
            TimeStart(2);
            lblTimeright.Text = "30s";
        }

        //Ham đánh tọa độ
        public void Danhco(int x, int y)
        {
            pb.Danh_O(x, y);
            pb.Themsukienclick();
            TimeStart(1);
            lblTimeleft.Text = "30s";
        }

        //Ham tu danh
        public void Tudanhco()
        {
            int[] td = pb.TuDanhco();
            int x = td[0];
            int y = td[1];
            //code gui toa do danh tu dong:
            txtTimkiem.Text = x + " " + y;
        }

        //hàm trả về kết quả thắng
        public void Xylythang(int xo) //Neu O thang thi xo=1, X thang thi xo=2
        {
            if (xo == 1)
                Thietlaptyso(tysotrai, tysophai + 1);
            else
                Thietlaptyso(tysotrai + 1, tysophai);
            timer1.Enabled = false;
            lblTimeleft.Text = lblTimeright.Text = "30s";
        }

        //Hàm thiết lập tỷ số
        public void Thietlaptyso(int a, int b)
        {
            tysotrai = a;
            tysophai = b;
            lblTysotrai.Text = tysotrai.ToString();
            lblTysophai.Text = tysophai.ToString();
        }

        //Hàm hiển thị danh sách người chơi
        public void Hienthidsnguoichoi(string ds)
        {
            listDsnguoidung.Clear();
            dsnc = ds.Split(';');

            for (int i = 0; i < dsnc.Length; i++)
            {
                listDsnguoidung.Items.Add(dsnc[i]);
            }
        }

        //hàm hiển thị lời mời
        public void Hienthiloimoi(string tendthu, string noidung)
        {
            NhanLoiMoi nlm = new NhanLoiMoi();
            nlm.tendthu = tendthu;
            nlm.noidunglm = noidung;
            nlm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //test danh co:
            string[] arrtd = txtTimkiem.Text.Split(' ');
            int x = int.Parse(arrtd[0]);
            int y = int.Parse(arrtd[1]);
            Danhco(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listDsnguoidung.Items.Add(txtTimkiem.Text, "12");
            pb.Xoasukienclick();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pb.Themsukienclick();
        }

        private void btnFontchat_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            rtbWriteChat.Font = fontDialog1.Font;
            rtbWriteChat.Focus();
        }

        private void btnColorchat_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            rtbWriteChat.ForeColor = colorDialog1.Color;
            rtbWriteChat.Focus();
        }

        //hien thi tin nhan
        public void Hienthitindi(string ten, string noidung)
        {
            string s = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\fnil\\fcharset0 Times New Roman;}}{\\colortbl ;\\red125\\green0\\blue255;}\\viewkind4\\uc1\\pard\\cf1\\b\\f0\\fs20" + ten + "  : }";
            rtbTinnhan.SelectedRtf= s;
            rtbTinnhan.Select(rtbTinnhan.Text.Length, 1);
            rtbTinnhan.SelectedRtf = noidung;
            
            rtbTinnhan.ScrollToCaret();
        }
        public void Hienthitinden(string ten, string noidung)
        {
            string s = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\fnil\\fcharset0 Times New Roman;}}{\\colortbl ;\\red0\\green0\\blue255;}\\viewkind4\\uc1\\pard\\cf1\\b\\f0\\fs20" + ten + "  : }";
            rtbTinnhan.SelectedRtf = s;
            rtbTinnhan.Select(rtbTinnhan.Text.Length, 1);
            rtbTinnhan.SelectedRtf = noidung;

            rtbTinnhan.ScrollToCaret();
        }
        //-------------------

        private void button5_Click(object sender, EventArgs e)
        {
            Hienthitindi("me", rtbWriteChat.Rtf);
            Hienthitinden("we", rtbWriteChat.Rtf);
        }

        //Đếm ngược thời gian chơi:
        int sogiay, aidanh;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aidanh == 1)
            {
                if (sogiay >= 0)
                {
                    lblTimeleft.Text = Math.Abs(sogiay) + "s";
                    sogiay--;
                }
                else
                {
                    rtbTinnhan.Text = "het gio";
                    Tudanhco();
                    //thực hiện gữi tin cho sv đánh random
                    timer1.Enabled = false;
                }
            }
            else
            {
                lblTimeright.Text = Math.Abs(sogiay) + "s";
                sogiay--;
            }
        }
        //Hàm chạy thời gian chơi:
        public void TimeStart(int b_aidanh)
        {
            aidanh = b_aidanh;
            sogiay = 30;
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
        //-----------------
        private void button3_Click(object sender, EventArgs e)
        {
            Hienthidsnguoichoi("a;bac;lac;mam");
        }

        //Xử lý việc đóng form
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listDsnguoidung_DoubleClick(object sender, EventArgs e)
        {
            if (listDsnguoidung.Items.Count <= 0)
                return;
            string tendoithu = listDsnguoidung.SelectedItems[0].Text;
            MoiChoi mc = new MoiChoi();
            mc.tendoithu = tendoithu;
            mc.ShowDialog();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            Hienthitindi(ten, rtbWriteChat.Rtf);
            rtbWriteChat.Text = "";
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if (listDsnguoidung.Items.Count <= 0)
                return;
            listDsnguoidung.Clear();
            for (int i = 0; i < dsnc.Length; i++)
            {
                if(txtTimkiem.Text.Trim()=="")
                    listDsnguoidung.Items.Add(dsnc[i]);
                else
                    if(dsnc[i].Contains(txtTimkiem.Text.Trim()))
                        listDsnguoidung.Items.Add(dsnc[i]);
            }
        }

        //Phần của client:
        public void Laydl()
        {
            Danhco(15, 16);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread td = new Thread(new ThreadStart(Laydl));
            td.Start();
            timer2.Enabled = false;
            timer2.Stop();
        }
    }
}
