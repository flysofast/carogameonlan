﻿using System;
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
        public MoiChoi()
        {
            InitializeComponent();
        }

        private void MoiChoi_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuiloimoi;
            lblTendoithu.Text = "Mời đối thủ: " + tendoithu;
        }
    }
}
