using System;
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
    public partial class panelBan : UserControl
    {
        Ban ban;
        Ban_AI ban2;
        public panelBan(int s,int rc, bool t,int l)
        {
            InitializeComponent();

            switch (l)
            {
                case 1:
                    {
                        ban2 = new Ban_AI(s, rc, rc, true);
                        ban2.Parent = this;
                        break;
                    }
                case 2:
                    {
                        ban = new Ban(s, rc, rc, true);
                        ban.Parent = this;
                        break;
                    }
                default: break;
            }
            Width = rc * s + 1;
            Height = rc * s + 1;
        }

        //cac ham truyen trung gian
        public void Xoasukienclick()
        {
            ban.Xoaskmd();
        }

        public void Themsukienclick()
        {
            ban.Taoskmd();
        }

        public void Danh_X(int x, int y)
        {
            ban.Ve_X(x, y);
        }
        public void Danh_O(int x, int y)
        {
            ban.Ve_O(x, y);
        }
        public void Tratoado(int x, int y)
        {
            Game ttd = Parent as Game;
            ttd.NhanToado(x, y);
        }
        public void TaoBan()
        {
            Game game = Parent as Game;
            game.TaoBan();
        }
    }
}
