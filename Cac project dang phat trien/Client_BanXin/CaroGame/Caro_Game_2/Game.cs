﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
        MoiChoi mc;

        public Game()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Thread thrNhan;
        public static Label lbtd = new Label();
        private void Game_Load(object sender, EventArgs e)
        {
            //Hiển thị
            lblTentoi.Text = ten;
            lblTendoithu.Text = "<doithu>";
            Thietlaptyso(0, 0);
            AcceptButton = btnGui;

            //tạo diện tích cho form Game
            Width = 995;
            Height = 611;

            pb = new panelBan(18, 26, true, 2);
            pb.Parent = this;
            pb.Left = 195;
            pb.Top = 80;

            // mặc định là đánh với humem
            humanVsComputerToolStripMenuItem.Checked = false;
            humanVsHumanToolStripMenuItem.Checked = true;
            rtbTinnhan.Enabled = false;
            pb.Xoasukienclick(); //--sua--

            thrNhan = new Thread(NhanDuLieu);
            thrNhan.IsBackground = true;
            thrNhan.Start();

            DangChoi();
            dathang = 0;
            timer2.Enabled = true;
            lbtd.Parent = this.panel1;
            lbtd.Location = new Point(50, 1);
            lbtd.Size = new Size(100, 13);
            chodanh = 0;
            sogiay = 30;
            demnguoc = 0;
            timerdemnguoc.Enabled = true;
        }

        //public delegate void SetBien();
        //public SetBien setDangChoi;
        public void DangChoi()
        {
            listDsnguoidung.Enabled = !dangchoi;
            rtbWriteChat.Enabled = dangchoi;
            btnGui.Enabled = dangchoi;//Và các nút khác tương tự
            //pb.Enabled = dangchoi;
            //if (!dangchoi)
            //    pb.Themsukienclick();
            ////else
            //    pb.Xoasukienclick();
            rtbTinnhan.Clear();
            btnBocuoc.Enabled = dangchoi;
            btnRoibanchoi.Enabled = dangchoi;
            btnXinhoa.Enabled = dangchoi;
            groupBox1.Visible = dangchoi;
            //Và nhiều nút khác
        }
        public bool dangchoi = false;
        void NhanDuLieu()
        {
            var reader = new StreamReader(Caro_Client.stream);
            try
            {
                while (true)
                {

                    string str = reader.ReadLine();
                    string cmdCode = str.Substring(0, 6);

                    if (cmdCode == "/:TD:/")
                    {
                        string[] td = str.Substring(6).Split(',');
                        int x = int.Parse(td[0]);
                        int y = int.Parse(td[1]);
                        Danhco(x, y);
                        continue;
                    }

                    if (cmdCode == "/:TN:/")
                    {
                        string tn = str.Substring(6);
                        Hienthitinden(doithu, Caro_Client.GiaiMa(tn));
                        continue;
                    }
                    if (cmdCode == "/:LM:/")
                    {
                        string[] td = str.Substring(6).Split(',');
                        string nguoimoi = td[0].ToString();
                        string noidung = td[1].ToString();
                        if (dangchoi)
                        {
                            Caro_Client.TuChoi(nguoimoi, "DangChoi");
                            continue;
                        }
                        Hienthiloimoi(nguoimoi, noidung);
                        continue;
                    }

                    if (cmdCode == "/:DY:/")
                    {
                        doithu = str.Substring(6);
                        dangchoi = true;
                        DangChoi();
                        pb.Themsukienclick();
                        lblTendoithu.Text = doithu;
                        mc.Close();
                        MessageBox.Show("Bắt đầu chơi với " + doithu);
                        continue;
                    }

                    if (cmdCode == "/:TC:/")
                    {
                        mc.Close();
                        if (str.Substring(6) == "TuChoi")
                            MessageBox.Show("Đối thủ từ chối lời mời");
                        if (str.Substring(6) == "DangChoi")
                            MessageBox.Show("Đối thủ đang bận chơi");
                        if (str.Substring(6) == "KhongTraLoi")
                            MessageBox.Show("Đối thủ không trả lời");
                        listDsnguoidung.Enabled = true;
                        continue;
                    }

                    if (cmdCode == "/:XH:/")
                    {
                        //Xử lý xin hòa
                        DialogResult lkResult = MessageBox.Show("Đối thủ " + doithu + " muốn xin hòa", "Cầu hòa", MessageBoxButtons.YesNo);
                        if (lkResult == DialogResult.Yes)
                        {
                            Caro_Client.ChapNhanHoa(doithu);
                            //xu ly hoa
                            dathang = 1;
                            chodanh = 1;
                            demnguoc = 0;
                            lblTimeleft.Text = lblTimeright.Text = "30s";
                            sogiay = 30;
                        }
                        else
                        {
                            Caro_Client.KoChapNhanHoa(doithu);
                        }
                        continue;
                    }
                    if (cmdCode == "/:CN:/")
                    {
                        MessageBox.Show("Đối thủ " + doithu + " đã chấp nhận hòa");
                        //Chấp nhận xin hòa
                        dathang = 1;
                        demnguoc = 0;
                        lblTimeleft.Text = lblTimeright.Text = "30s";
                        sogiay = 30;
                        continue;
                    }

                    if (cmdCode== "/:KK:/")
                    {
                        MessageBox.Show("Đối thủ " + doithu + " không đồng ý hòa");
                        continue;
                    }

                    if (cmdCode == "/:BC:/")
                    {
                        MessageBox.Show("Đối thủ đã bỏ cuộc - Bạn là người chiến thắng");
                        Thietlaptyso(tysotrai + 1, tysophai);
                        dathang = 1;
                        //pb.Themsukienclick();
                        chodanh = 1;

                        demnguoc = 0;
                        lblTimeleft.Text = lblTimeright.Text = "30s";
                        sogiay = 30;
                        //Mình là người thắng
                    }

                    if (cmdCode == "/:CL:/")
                    {
                        Hienthidsnguoichoi(str.Substring(6));
                        continue;
                    }
                    if (str.Substring(0, 6) == "/:RB:/")
                    {
                        MessageBox.Show("Đối thủ " + doithu + " đã thoát khỏi bàn");
                        dangchoi = false;
                        DangChoi();
                        doithu = "";
                        Thietlaptyso(0, 0);
                        dathang = 1;
                        demnguoc = 0;
                        lblTimeleft.Text = lblTimeright.Text = "30s";
                        sogiay = 30;
                        continue;
                    }

                    if (cmdCode == "/:NF:/")
                    {
                        MessageBox.Show("Đối thủ " + doithu + " đã thoát khỏi hệ thống");
                        dangchoi = false;
                        dathang = 1;
                        chodanh = 2;
                        DangChoi();
                        continue;
                    }

                    if (cmdCode == "/:DC:/")
                    {
                        Caro_Client.stream.Close();
                        Caro_Client.client.Close();
                        MessageBox.Show("Server đã ngắt kết nối. Vui lòng kết nối lại sau!");
                       
                        Application.Exit();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            pb.Left = 195;
            pb.Top = 80;
            //pb.Xoasukienclick();

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

        public void Hienthitindi(string ten, string noidung)
        {
            string s = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\fnil\\fcharset0 Times New Roman;}}{\\colortbl ;\\red0\\green0\\blue255;}\\viewkind4\\uc1\\pard\\cf1\\b\\f0\\fs20" + ten + " : }";
            rtbTinnhan.SelectedRtf = s;
            rtbTinnhan.Select(rtbTinnhan.Text.Length, 1);
            rtbTinnhan.SelectedRtf = noidung;

            rtbTinnhan.ScrollToCaret();

        }
        public void Hienthitinden(string ten, string noidung)
        {
            string s = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\fnil\\fcharset0 Times New Roman;}}{\\colortbl ;\\red255\\green0\\blue0;}\\viewkind4\\uc1\\pard\\cf1\\b\\f0\\fs20" + ten + " : }";
            rtbTinnhan.SelectedRtf = s;
            rtbTinnhan.Select(rtbTinnhan.Text.Length, 1);
            rtbTinnhan.SelectedRtf = noidung;

            rtbTinnhan.ScrollToCaret();


        }

        //Ham tra ve toa do khi click
        public void NhanToado(int x, int y)
        {
            Caro_Client.GuiToaDo(x, y, doithu);
            //txtTimkiem.Text = x.ToString() + " " + y.ToString();
            pb.Xoasukienclick();
            lblTimeleft.Text = lblTimeright.Text = "30s";
            sogiay = 30;
            TimeStart(2);
        }

        //Ham đánh tọa độ
        public void Danhco(int x, int y)
        {
            pb.Danh_O(x, y);
            pb.Themsukienclick();
            //--có sửa--
            lblTimeleft.Text = lblTimeright.Text = "30s";
            sogiay = 30;
            TimeStart(1);
        }

        //Ham tu danh
        public void Tudanhco()
        {
            int[] td = pb.TuDanhco();
            int x = td[0];
            int y = td[1];
            //code gui toa do danh tu dong:
            Caro_Client.GuiToaDo(x, y, doithu);
            //--có sửa--
            pb.Xoasukienclick();
            lblTimeleft.Text = lblTimeright.Text = "30s";
            sogiay = 30;
            aidanh = 2;
        }

        //hàm trả về kết quả thắng
        public void Xylythang(int xo) //Neu O thang thi xo=1, X thang thi xo=2
        {
            //--thêm,sửa--
            if (xo == 1)
            {
                dathang = 1;
                Thietlaptyso(tysotrai, tysophai + 1);
                //pb.Xoasukienclick();
                chodanh = 2;
            }
            else
            {
                Thietlaptyso(tysotrai + 1, tysophai);
                TaoBan();
                pb.Themsukienclick();
            }
            //timerdemnguoc.Enabled = false;
            demnguoc = 0;
            lblTimeleft.Text = lblTimeright.Text = "30s";
            sogiay = 30;
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

            for (int i = 0; i < dsnc.Length - 1; i++)
            {
                if (dsnc[i] != ten)//--sửa--
                    listDsnguoidung.Items.Add(dsnc[i]);
            }
        }

        public void setDoiThu(string dt)
        {
            doithu = dt;
            dangchoi = true;
            DangChoi();
            lblTendoithu.Text = doithu;
        }
        //hàm hiển thị lời mời
        public void Hienthiloimoi(string tendthu, string noidung)
        {
            NhanLoiMoi nlm = new NhanLoiMoi();
            nlm.tendthu = tendthu;
            nlm.noidunglm = noidung;
            nlm.tenminh = ten;
            nlm.setVaoChoi = new NhanLoiMoi.dlgsetVaoChoi(setDoiThu);
            nlm.ShowDialog();

        }

        //--Thêm--
        //Hàm xử lý xin hòa, bỏ cuộc
        public void XinHoa()
        {
            if (MessageBox.Show("Đối thủ xin hòa. Bạn có đồ ý không?", "Xin Hòa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //code gửi phản hồi xin hòa 
                TaoBan();
            }
        }
        public void DongYXinHoa()
        {
            MessageBox.Show("Đối thủ đã đồng ý hòa ván này. Bàn chơi được tạo lại!!!", "Xin Hòa");
            TaoBan();
        }
        public void DongYBoCuoc()
        {
            MessageBox.Show("Đối thủ đã bỏ cuộc ván này. Bàn chơi được tạo lại!!!", "Bỏ Cuộc");
            TaoBan();
        }
        //----------------

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
        //-------------------

        //Đếm ngược thời gian chơi:
        int sogiay, aidanh;

        //Hàm chạy thời gian chơi:
        public void TimeStart(int b_aidanh)
        {
            aidanh = b_aidanh;
            sogiay = 30;
            //timerdemnguoc.Enabled = true;
            demnguoc = 1;
        }
        //-----------------

        private void listDsnguoidung_DoubleClick(object sender, EventArgs e)
        {
            if (listDsnguoidung.Items.Count <= 0)
                return;
            if (listDsnguoidung.SelectedItems.Count==0 || string.IsNullOrEmpty(listDsnguoidung.SelectedItems[0].Text)) //--them--
                return;
            string tendoithu = listDsnguoidung.SelectedItems[0].Text;
            mc = new MoiChoi();
            mc.tendoithu = tendoithu;
            mc.tenminh = ten;
            mc.ShowDialog();
            listDsnguoidung.Enabled = false;
        }

        private void btnGui_Click(object sender, EventArgs e)
        {

            Caro_Client.GuiTinNhan(doithu, Caro_Client.MaHoa(rtbWriteChat.Rtf));
            Hienthitindi(ten, rtbWriteChat.Rtf);
            rtbWriteChat.Clear();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if (dsnc.Length <= 0)
                return;
            listDsnguoidung.Clear();
            for (int i = 0; i < dsnc.Length; i++)
            {
                if (dsnc[i] != ten)
                {
                    if (txtTimkiem.Text.Trim() == "")
                        listDsnguoidung.Items.Add(dsnc[i]);
                    else
                        if (dsnc[i].Contains(txtTimkiem.Text.Trim()))
                            listDsnguoidung.Items.Add(dsnc[i]);
                }
            }
        }

        //Phần của client:
        public void Laydl()
        {
            Danhco(15, 16);
        }

        private void btnThoatgame_Click(object sender, EventArgs e)
        {
            Caro_Client.NgatKetNoi();
            Application.Exit();
        }

        private void btnXinhoa_Click(object sender, EventArgs e)
        {
            Caro_Client.XinHoa(doithu);
        }

        private void btnBocuoc_Click(object sender, EventArgs e)
        {
            Caro_Client.BoCuoc(doithu);
            TaoBan();
            Thietlaptyso(tysotrai, tysophai + 1);
            pb.Xoasukienclick();
            demnguoc = 0;
            lblTimeleft.Text = lblTimeright.Text = "30s";
            sogiay = 30;
        }

        private void btnRoibanchoi_Click(object sender, EventArgs e)
        {
            //code gửi tin nhan roi ban choi
            Caro_Client.RoiBanChoi(doithu);
            dangchoi = false;
            doithu = "";
            DangChoi();
            dathang = 1;
            Thietlaptyso(0, 0);
            demnguoc = 0;
            lblTimeleft.Text = lblTimeright.Text = "30s";
            sogiay = 30;
        }

        public int dathang = 0;
        public int chodanh = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dathang == 1)
            {
                TaoBan();
                dathang = 0;
            }
            if (chodanh == 1)
            {
                pb.Themsukienclick();
                chodanh = 0;
            }
            if (chodanh == 2)
            {
                pb.Xoasukienclick();
                chodanh = 0;
            }
        }

        
        public static void GhiToaDo(int x,int y)
        {
            lbtd.Text = x.ToString() + " , " + y.ToString();
        }

        int demnguoc = 0;
        private void timerdemnguoc_Tick(object sender, EventArgs e)
        {
            if (demnguoc == 1)
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
                        Tudanhco();
                    }
                }
                else
                {
                    lblTimeright.Text = Math.Abs(sogiay) + "s";
                    sogiay--;
                }
            }
        }

    }
}
