﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_Game_2
{
    public partial class Ban_AI : UserControl
    {
        public Graphics g;// đối tượng để vẽ lên
        int cellSize; //kich cỡ 1 ô
        int rows, cols; //số dòng và số cột
        int[,] Data; // mảng 2 chiều lưu giá trị của 1 ô

        /// <summary>
        /// xác đinh lượt đánh 
        /// true là O đánh
        /// false là X đánh
        /// </summary>
        bool flag;
        public Ban_AI(int cellSize, int rows, int cols, bool flag)
        {
            InitializeComponent();// hàm mặc đinh để khỏi tạo một đối tượng control      

            //-- Đưa dữ liệu vào cho các trường
            this.cellSize = cellSize;
            this.rows = rows;
            this.cols = cols;
            this.flag = flag;
            //--

            //--- Khỏi tạo giá trị mặc định cho các ô là 0
            Data = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Data[i, j] = 0;
            //---
        }
        /// <summary>
        /// Hàm sẻ vẽ các đường thẳng và đường ngang khi đối tượng được khỏi tạo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ban_Paint(object sender, PaintEventArgs e)
        {
            Width = cols * cellSize + 1; // tạo chiều rộng cho bàn 
            Height = rows * cellSize + 1;// tạo chiều cao cho bàn;

            g = this.CreateGraphics();
            int i, j;
            Pen p = new Pen(Color.Blue);
            for (i = 0; i <= rows; i++)
                g.DrawLine(p, 0, i * cellSize, rows * cellSize, i * cellSize);

            for (j = 0; j <= cols; j++)
                g.DrawLine(p, j * cellSize, 0, j * cellSize, cols * cellSize);
        }
        /// <summary>
        /// Vẽ X
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Ve_X(int x, int y)
        {
            Pen p = new Pen(Color.Black, 5);
            //Vẽ chéo thuận
            g.DrawLine(p, x * cellSize, y * cellSize, (x + 1) * cellSize, (y + 1) * cellSize);
            // Vẽ chéo nghịch
            g.DrawLine(p, (x + 1) * cellSize, y * cellSize, x * cellSize, (y + 1) * cellSize);
        }
        /// <summary>
        /// Vẽ O
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Ve_O(int x, int y)
        {
            Pen p = new Pen(Color.Blue, 5);
            g.DrawEllipse(p, x * cellSize + 2, y * cellSize + 2, cellSize - 5, cellSize - 5);
        }

        /// <summary>
        /// Làm việc khi nhấn chuột lên các ô của bàn cờ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ban_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / cellSize;// lấy số dòng
            int y = e.Y / cellSize; // lấy số cột
            if(flag)
            {
                if (Data[x, y] == 0) // nếu ô này chưa đc đánh
                {
                    Data[x, y] = 1;// 2 tương đương với chứa O
                    Ve_O(x, y);// vẽ hình O
                    flag = false;

                    //try
                    //{
                    //-- Kiểm tra thắng thua
                    if (KiemTra(x, y) == 1)// kiểm tra xem với O vừa đánh có tạo thành 1 dãy 5 O ko
                    {
                        if (MessageBox.Show("O thang!! Ban co muon tiep tuc?", "Victory", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            panelBan game = Parent as panelBan;
                            game.TaoBan();
                            return;
                        }
                    }
                    if (KiemTra(x, y) == 2)// kiểm tra xem với X vừa đánh có tạo thành 1 dãy 5 X ko
                    {
                        if (MessageBox.Show("X thang!! Ban co muon tiep tuc?", "Victory", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            panelBan game = Parent as panelBan;
                            game.TaoBan();
                            return;
                        }
                    }
                    //---
                    //}
                    //catch(Exception ex) 
                    //{
                    //    MessageBox.Show(x.ToString()+","+y.ToString()+","+ ex.Message);
                    //}


                    AI();
                }
            }
        }
        /// <summary>
        /// Hàm kiểm tra thắng thua
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int KiemTra(int x, int y)
        {
            if (kiemtra_Doc(x, y) >= 5) return Data[x, y]; // kiểm tra doc           
            if (kiemtra_Ngang(x, y) >= 5) return Data[x, y]; // kiểm tra ngang     
            if (kiemtra_CT(x, y) >= 5) return Data[x, y]; // kiểm tra chéo trái  
            if (kiemtra_CP(x, y) >= 5) return Data[x, y]; // kiểm tra chéo phải
            return 0;
        }
        /// <summary>
        /// Hàm kiểm tra ngang
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int kiemtra_Ngang(int x, int y)
        {
            int count = 1;
            int i = 1;
            while (x - i >= 0 && Data[x - i, y] == Data[x, y]) // kiểm tra lên
            {
                i++;
                count++;
            }
            i = 1;
            while (x + i < cols && Data[x + i, y] == Data[x, y]) // kiểm tra xuống
            {
                i++;
                count++;
            }
            return count;
        }
        /// <summary>
        /// Kiểm tra Doc
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int kiemtra_Doc(int x, int y)
        {
            int count = 1;
            int i = 1;
            while (y - i >= 0 && Data[x, y - i] == Data[x, y])
            {
                i++;
                count++;
            }
            i = 1;
            while (y + i <= rows && Data[x, y + i] == Data[x, y])
            {
                i++;
                count++;
            }
            return count;
        }
        /// <summary>
        /// Kiểm tra chéo trái
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int kiemtra_CT(int x, int y)
        {
            int count = 1;
            int i = 1;
            while (x - i >= 0 && y - i >= 0 && Data[x - i, y - i] == Data[x, y])
            {
                i++;
                count++;
            }
            i = 1;
            while (x + i < cols && y + i < rows && Data[x + i, y + i] == Data[x, y])
            {
                i++;
                count++;
            }
            return count;
        }
        /// <summary>
        /// Kiểm tra chéo phải
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int kiemtra_CP(int x, int y)
        {
            int count = 1;
            int i = 1;
            while (x - i >= 0 && y + i < rows && Data[x - i, y + i] == Data[x, y])
            {
                i++;
                count++;
            }
            i = 1;
            while (x + i < cols && y - i >= 0 && Data[x + i, y - i] == Data[x, y])
            {
                i++;
                count++;
            }
            return count;
        }
        public void AI()
        {
            Random r = new Random();
            while (true)
            {              
                int x = r.Next(0, cols);
                int y = r.Next(0, rows);
                if (Data[x, y] == 0) // nếu ô này chưa đc đánh
                {
                    Data[x, y] = 2;// 2 tương đương với chứa O
                    Ve_X(x, y);// vẽ hình O
                    flag = true;
                    break;
                }
            }
        }
    }
}
