using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_Game_2
{
    public partial class Game : Form
    {
        panelBan pb;
        public string doithu = "tranhuulac";
        public string ten;
        public Game()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        //Ban ban;
        private void Game_Load(object sender, EventArgs e)
        {

            //tạo diện tích cho form Game
            Width = 912;
            Height = 610;

            pb = new panelBan(18, 26, true, 2);
            pb.Parent = this;
            pb.Left = 195;
            pb.Top = 80;
            //Ban ban = new Ban(18, 26, 26, true);
            //ban.Parent = this;
            //ban.Left = 200;
            //ban.Top = 80;

            // mặc định là đánh với computer
            humanVsComputerToolStripMenuItem.Checked = false;
            humanVsHumanToolStripMenuItem.Checked = true;
            //Chay thread nhan du lieu tu server

            timer2.Interval = 100;
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

            Width = map * 30 + 100;
            Height = map * 30 + 150;
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
            //cclient.GuiDuLieu("/:MS:/<recipient>"+/:TD:/" + x.ToString() + "," + y.ToString());
            Caro_Client.GuiToaDo(x, y, doithu);
            pb.Xoasukienclick();
            TimeStart(1);
            lblTimeright.Text = "30s";

        }

        //hàm trả về kết quả thắng
        public void Xylythang(int xo) //Neu O thang thi xo=1, X thang thi xo=2
        {
            rtbWriteChat.Text = xo.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pb.Danh_O(15, 16);
            pb.Themsukienclick();
            TimeStart(2);
            lblTimeleft.Text = "30s";
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
           // Hienthitindi("me", rtbWriteChat.Rtf);
            //Hienthitinden("we", rtbWriteChat.Rtf);
            Caro_Client.GuiTinNhan("tranhuulac","abc");
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
            TimeStart(1);
            TimeStart(2);
        }
        // Hàm nhận các lệnh từ Server
        Thread Nhan;
        public void NhanDL()
        {
            string dl = Caro_Client.NhanDuLieu();
            if (dl == null || dl == "")
                return;
            if(dl.Substring(0,6)=="/:TD:/")
            {
               string[] td= dl.Substring(6).Split(',');
               pb.Danh_O(int.Parse(td[0]),int.Parse(td[1])+1);
               pb.Themsukienclick();
            }
            else if (dl.Substring(0,6)=="/:TN:/")
            {
                string tn = dl.Substring(6);
                //Hienthitinden("tranhuulac",tn);
                txtTimkiem.Text = tn;
                
            }
            else if(dl.Substring(0,6)=="/:LM:/")
            {
                NhanLoiMoi nml = new NhanLoiMoi();
                string noidung = dl.Substring(6);
                nml.ShowDialog();
            }
            else if(dl.Substring(0,6)=="/:XH:/")
            {
                //Xử lý xin hòa
            }
            else
            {
                return;
            }
        }
        //Đóng kết nối tới server;
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Caro_Client.NgatKetNoi();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Nhan = new Thread(new ThreadStart(NhanDL));
            Nhan.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Caro_Client.GuiTinNhan(doithu, rtbWriteChat.Rtf);
            //Caro_Client.GuiTinNhan(doithu, rtbWriteChat.Rtf);
        }
    }
}
