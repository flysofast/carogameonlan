using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_Game_2
{
    public partial class NhanLoiMoi : Form
    {
        public string noidunglm, tendthu,tenminh;
        public NhanLoiMoi()
        {
            InitializeComponent();
        }
        
        private void btnHuybo_Click(object sender, EventArgs e)
        {
            Caro_Client.TuChoi(tendthu,"TuChoi");
            CloseForm = false;
            this.Close();
            //Khi quá thời gian 
            //    Caro_Client.TuChoi(tendthu,"KhongTraLoi");
            //Đóng form nhận lời mời
        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            //code xử lý đồng ý...
            Caro_Client.DongY(tenminh,tendthu);
            //Game gm = Parent as Game;
            //gm.dangchoi = true;
            //gm.doithu = tendthu;
            setVaoChoi(tendthu);
            this.Hide();
            MessageBox.Show("Bắt đầu chơi với " + tendthu);
            CloseForm = false;
            this.Close();
        }
        public delegate void dlgsetVaoChoi(string doithu);
        public dlgsetVaoChoi setVaoChoi;
        private void NhanLoiMoi_Load(object sender, EventArgs e)
        {
            rtbNoidungloimoi.Text = noidunglm;
            lblTendoithu.Text = tendthu;
            AcceptButton = btnDongy;
            timerchophanhoi.Enabled = true;
        }

        int sogiay = 25;
        private void timerchophanhoi_Tick(object sender, EventArgs e)
        {
            if (sogiay >= 0)
            {
                btnHuybo.Text = "Hủy Bỏ (" + sogiay + ")";
                sogiay--;
            }
            else
            {
                //code huy loi moi
                Caro_Client.TuChoi(tendthu, "KhongTraLoi");
                CloseForm = false;
                sogiay = 25;
                this.Close();
            }
        }

        bool CloseForm = true;
        private void NhanLoiMoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CloseForm;
        }
    }
}
