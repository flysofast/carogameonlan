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
        public string noidunglm, tendthu;
        public NhanLoiMoi()
        {
            InitializeComponent();
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            //code xử lý đồng ý...
            this.Close();
        }

        private void NhanLoiMoi_Load(object sender, EventArgs e)
        {
            rtbNoidungloimoi.Text = noidunglm;
            lblTendoithu.Text = tendthu;
            AcceptButton = btnDongy;
        }
    }
}
