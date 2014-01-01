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
        public panelBan(int s,int rc, bool t,int l)
        {
            InitializeComponent();

            switch (l)
            {
                case 1:
                    {
                        Ban_AI ban = new Ban_AI(s, rc, rc, true);
                        ban.Parent = this;
                        break;
                    }
                case 2:
                    {
                        Ban ban = new Ban(s, rc, rc, true);
                        ban.Parent = this;
                        break;
                    }
                default: break;
            }
            Width = rc * s + 1;
            Height = rc * s + 1;
        }
        public void TaoBan()
        {
            Game game = Parent as Game;
            game.TaoBan();
        }
    }
}
