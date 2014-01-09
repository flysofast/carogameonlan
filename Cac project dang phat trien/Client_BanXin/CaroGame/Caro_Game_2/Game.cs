using System;
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
        public string doithu="a";
        public int tysotrai;
        public int tysophai;
        public string[] dsnc;

        public Game()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Thread thrNhan;
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

            pb.Xoasukienclick(); //--sua--

            thrNhan = new Thread(NhanDuLieu);
            thrNhan.IsBackground = true;
            thrNhan.Start();
        }

        //public delegate void SetBien();
        //public SetBien setDangChoi;

       public bool dangchoi = false;
        void NhanDuLieu()
        {
            var reader = new StreamReader(Caro_Client.stream);
            try
            {
                while (true)
                {
                    
                    string str = reader.ReadLine();

                    if (str.Substring(0, 6) == "/:TD:/")
                    {
                        string[] td = str.Substring(6).Split(',');
                        int x = int.Parse(td[0]);
                        int y = int.Parse(td[1]);
                        Danhco(x, y);
                        continue;
                    }

                    if (str.Substring(0, 6) == "/:TN:/")
                    {
                        string tn = str.Substring(6);
                        Hienthitinden(doithu,Caro_Client.GiaiMa(tn));
                        continue;
                    }
                    if (str.Substring(0, 6) == "/:LM:/")
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

                    if (str.Substring(0, 6) == "/:DY:/")
                    {
                        doithu = str.Substring(6);
                        dangchoi = true;
                        lblTendoithu.Text = doithu;
                        MessageBox.Show("Bắt đầu chơi với " + doithu);
                        continue;
                    }

                    if (str.Substring(0, 6) == "/:TC:/")
                    {
                        if (str.Substring(6) == "TuChoi")
                            MessageBox.Show("Đối thủ từ chối lời mời");
                        if (str.Substring(6) == "DangChoi")
                            MessageBox.Show("Đối thủ đang bận chơi");

                        continue;
                    }

                    if (str.Substring(0, 6) == "/:XH:/")
                    {
                        //Xử lý xin hòa
                        DialogResult lkResult = MessageBox.Show("Đối thủ "+doithu+" muốn xin hòa","Cầu hòa", MessageBoxButtons.YesNo);
                        if (lkResult == DialogResult.Yes)
                        {
                            Caro_Client.ChapNhanHoa(doithu);
                            //Xử lý hòa trên form
                        }
                        else
                        {
                            Caro_Client.KoChapNhanHoa(doithu);
                        }
                        continue;
                    }
                    if (str.Substring(0, 6) == "/:CN:/")
                    {
                        MessageBox.Show("Đối thủ " + doithu + " đã chấp nhận hòa");
                        //Xử lý trên form khi chấp nhận hòa
                        continue;
                    }

                    if (str.Substring(0, 6) == "/:KK:/")
                    {
                        MessageBox.Show("Đối thủ " + doithu + " không đồng ý hòa");
                        continue;
                    }

                    if (str.Substring(0, 6) == "/:BC:/")
                    {
                        MessageBox.Show("Đối thủ đã bỏ cuộc");
                        //Xử lý form khi bỏ cuộc
                    }

                    if (str.Substring(0, 6) == "/:CL:/")
                    {
                        Hienthidsnguoichoi(str.Substring(6));
                        continue;
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
            string s = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\fnil\\fcharset0 Times New Roman;}}{\\colortbl ;\\red125\\green0\\blue255;}\\viewkind4\\uc1\\pard\\cf1\\b\\f0\\fs20" + ten + "  : }";
            rtbTinnhan.SelectedRtf = s;
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
            TimeStart(1);
            sogiay = 30;
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
            TaoBan();
            pb.Enabled = false;
            //--thêm,sửa--
            if (xo == 1)
                Thietlaptyso(tysotrai, tysophai + 1);
            else
            {
                Thietlaptyso(tysotrai + 1, tysophai);
                pb.Enabled = true;
            }
            timer1.Enabled = false;
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

            for (int i = 0; i < dsnc.Length; i++)
            {
                if (dsnc[i] != ten)//--sửa--
                    listDsnguoidung.Items.Add(dsnc[i]);
            }
        }

        public void setDoiThu(string dt)
        {
            doithu = dt;
            dangchoi = true;
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
            Hienthiloimoi(doithu, ten);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
            txtTimkiem.Text = Caro_Client.GiaiMa(Caro_Client.MaHoa(rtbWriteChat.Rtf));
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
        //-------------------

        private void button5_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text =Caro_Client.MaHoa(rtbWriteChat.Rtf);
        }

        //Đếm ngược thời gian chơi:
        int sogiay, aidanh;
        private void timer1_Tick(object sender, EventArgs e) //--có thay đổi--
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

        //Hàm chạy thời gian chơi:
        public void TimeStart(int b_aidanh)
        {
            aidanh = b_aidanh;
            sogiay = 30;
        }
        //-----------------
        private void button3_Click(object sender, EventArgs e)
        {
            Hienthidsnguoichoi("a;bac;lac;mam");
        }

        //Xử lý việc đóng form
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Caro_Client.NgatKetNoi();
            Application.Exit();
        }

        private void listDsnguoidung_DoubleClick(object sender, EventArgs e)
        {
            if (listDsnguoidung.Items.Count <= 0)
                return;
            if (listDsnguoidung.SelectedItems[0].Text == null) //--them--
                return;
            string tendoithu = listDsnguoidung.SelectedItems[0].Text;
            MoiChoi mc = new MoiChoi();
            mc.tendoithu = tendoithu;
            mc.tenminh = ten;
            mc.ShowDialog();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            
            Caro_Client.GuiTinNhan(doithu,Caro_Client.MaHoa(rtbWriteChat.Rtf));
            Hienthitindi(ten, rtbWriteChat.Rtf);
            rtbWriteChat.Clear();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if (listDsnguoidung.Items.Count <= 0)
                return;
            listDsnguoidung.Clear();
            for (int i = 0; i < dsnc.Length; i++)
            {
                if (txtTimkiem.Text.Trim() == "")
                    listDsnguoidung.Items.Add(dsnc[i]);
                else
                    if (dsnc[i].Contains(txtTimkiem.Text.Trim()))
                        listDsnguoidung.Items.Add(dsnc[i]);
            }
        }

        //Phần của client:
        public void Laydl()
        {
            Danhco(15, 16);
        }

      
    }
}
