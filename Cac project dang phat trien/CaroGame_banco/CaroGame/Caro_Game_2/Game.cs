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
            textBox1.Text = x.ToString() + " " + y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arrtd = textBox1.Text.Split(' ');
            int x = int.Parse(arrtd[0]);
            int y = int.Parse(arrtd[1]);
            pb.Danh_X(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(textBox1.Text, "12");
            button1.Click -= button1_Click;
            pb.Xoasukienclick();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pb.Themsukienclick();
        }
    }
}
