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
    public partial class MoiChoi : Form
    {
        public string tendoithu;
        public string tenminh;
        public MoiChoi()
        {
            InitializeComponent();
        }

        private void MoiChoi_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuiloimoi;
            lblTendoithu.Text = "Mời đối thủ: " + tendoithu;
        }

        private void btnGuiloimoi_Click(object sender, EventArgs e)
        {
            //code gửi lời mời
            //--thêm--
            Caro_Client.GuiLoiMoi(tendoithu, tenminh,rtbNDLoimoi.Text);
            lblChophanhoi.Visible = true;
            btnGuiloimoi.Visible = false;
            btnHuyloimoi.Visible = true;
            timerchophanhoi.Enabled = true;
            rtbNDLoimoi.Enabled = false;
            CloseForm = true;
        }

        //--thêm--
        int sogiay = 25;
        private void timerchophanhoi_Tick(object sender, EventArgs e)
        {
            if (sogiay >= 0)
            {
                btnHuyloimoi.Text = "Hủy Lời Mời (" + sogiay + ")";
                sogiay--;
            }
            else
            {
                //code huy loi moi
                CloseForm = false;
                this.Close();
            }
        }

        private void btnHuyloimoi_Click(object sender, EventArgs e)
        {
            //code huy loi moi
            CloseForm = false;
            this.Close();
        }

        bool CloseForm = false;
        private void MoiChoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CloseForm;
        }
    }
}
