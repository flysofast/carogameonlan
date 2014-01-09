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
            this.Close();
        }
        public delegate void dlgsetVaoChoi(string doithu);
        public dlgsetVaoChoi setVaoChoi;
        private void NhanLoiMoi_Load(object sender, EventArgs e)
        {
            rtbNoidungloimoi.Text = noidunglm;
            lblTendoithu.Text = tendthu;
            AcceptButton = btnDongy;
        }
    }
}
