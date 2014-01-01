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
    public partial class Game : Form
    {
        panelBan pb;
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //tạo diện tích cho form Game
            Width = 550;
            Height = 600;

            pb = new panelBan(30,15,true,1);
            pb.Parent = this;
            pb.Left = 40;
            pb.Top = 50;  

            // mặc định size map là medium
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;

            // mặc định là đánh với computer
            humanVsComputerToolStripMenuItem.Checked = true;
            humanVsHumanToolStripMenuItem.Checked = false;
            
        }
        /// <summary>
        /// Tạo bàn mới
        /// </summary>
        public void TaoBan()
        {
            this.Controls.Remove(pb);
            pb = new panelBan(30,gMap(),true,gMode());
            pb.Parent = this;
            pb.Left = 40;
            pb.Top = 50;      
    
            Width = gMap() * 30 + 100;
            Height = gMap() * 30 + 150;
        }
        /// <summary>
        /// Chọn kiểu map là nhỏ 10x10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
        }
        /// <summary>
        /// Chọn kiểu map là vừa 15x15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
        }
        /// <summary>
        /// Chọn kiểu map là lớn 20x20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = true;
        }
        /// <summary>
        /// Lấy giá trị của map hiện tại
        /// </summary>
        /// <returns></returns>
        public int gMap()
        {
            if (smallToolStripMenuItem.Checked == true) return 10;
            if (mediumToolStripMenuItem.Checked == true) return 15;
            return 20;
        }

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
    }
}
