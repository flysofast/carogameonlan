namespace Caro_Game_2
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanVsHumanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanVsComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listDsnguoidung = new System.Windows.Forms.ListView();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.rtbWriteChat = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTysophai = new System.Windows.Forms.Label();
            this.lblTysotrai = new System.Windows.Forms.Label();
            this.lblTendoithu = new System.Windows.Forms.Label();
            this.lblTimeright = new System.Windows.Forms.Label();
            this.lblTentoi = new System.Windows.Forms.Label();
            this.lblTimeleft = new System.Windows.Forms.Label();
            this.btnFontchat = new System.Windows.Forms.Button();
            this.btnColorchat = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnGui = new System.Windows.Forms.Button();
            this.rtbTinnhan = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnXinhoa = new System.Windows.Forms.Button();
            this.btnThoatgame = new System.Windows.Forms.Button();
            this.btnBocuoc = new System.Windows.Forms.Button();
            this.btnRoibanchoi = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Turquoise;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.gamesToolStripMenuItem.Text = "Games";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.humanVsHumanToolStripMenuItem,
            this.humanVsComputerToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // humanVsHumanToolStripMenuItem
            // 
            this.humanVsHumanToolStripMenuItem.Name = "humanVsHumanToolStripMenuItem";
            this.humanVsHumanToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.humanVsHumanToolStripMenuItem.Text = "Human vs Human";
            this.humanVsHumanToolStripMenuItem.Click += new System.EventHandler(this.humanVsHumanToolStripMenuItem_Click);
            // 
            // humanVsComputerToolStripMenuItem
            // 
            this.humanVsComputerToolStripMenuItem.Name = "humanVsComputerToolStripMenuItem";
            this.humanVsComputerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.humanVsComputerToolStripMenuItem.Text = "Human vs Computer";
            this.humanVsComputerToolStripMenuItem.Click += new System.EventHandler(this.humanVsComputerToolStripMenuItem_Click);
            // 
            // listDsnguoidung
            // 
            this.listDsnguoidung.BackColor = System.Drawing.Color.AliceBlue;
            this.listDsnguoidung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listDsnguoidung.FullRowSelect = true;
            this.listDsnguoidung.Location = new System.Drawing.Point(11, 64);
            this.listDsnguoidung.Name = "listDsnguoidung";
            this.listDsnguoidung.Size = new System.Drawing.Size(150, 487);
            this.listDsnguoidung.TabIndex = 1;
            this.listDsnguoidung.UseCompatibleStateImageBehavior = false;
            this.listDsnguoidung.View = System.Windows.Forms.View.List;
            this.listDsnguoidung.DoubleClick += new System.EventHandler(this.listDsnguoidung_DoubleClick);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTimkiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimkiem.Location = new System.Drawing.Point(11, 38);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(150, 20);
            this.txtTimkiem.TabIndex = 2;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // rtbWriteChat
            // 
            this.rtbWriteChat.BackColor = System.Drawing.Color.AliceBlue;
            this.rtbWriteChat.Location = new System.Drawing.Point(695, 381);
            this.rtbWriteChat.Name = "rtbWriteChat";
            this.rtbWriteChat.Size = new System.Drawing.Size(190, 30);
            this.rtbWriteChat.TabIndex = 10;
            this.rtbWriteChat.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblTysophai);
            this.groupBox1.Controls.Add(this.lblTysotrai);
            this.groupBox1.Controls.Add(this.lblTendoithu);
            this.groupBox1.Controls.Add(this.lblTimeright);
            this.groupBox1.Controls.Add(this.lblTentoi);
            this.groupBox1.Controls.Add(this.lblTimeleft);
            this.groupBox1.Location = new System.Drawing.Point(194, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 38);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bàn chơi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(225, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = ":";
            // 
            // lblTysophai
            // 
            this.lblTysophai.AutoSize = true;
            this.lblTysophai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTysophai.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTysophai.Location = new System.Drawing.Point(246, 16);
            this.lblTysophai.Name = "lblTysophai";
            this.lblTysophai.Size = new System.Drawing.Size(17, 17);
            this.lblTysophai.TabIndex = 5;
            this.lblTysophai.Text = "0";
            // 
            // lblTysotrai
            // 
            this.lblTysotrai.AutoSize = true;
            this.lblTysotrai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTysotrai.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTysotrai.Location = new System.Drawing.Point(201, 16);
            this.lblTysotrai.Name = "lblTysotrai";
            this.lblTysotrai.Size = new System.Drawing.Size(17, 17);
            this.lblTysotrai.TabIndex = 4;
            this.lblTysotrai.Text = "0";
            // 
            // lblTendoithu
            // 
            this.lblTendoithu.AutoSize = true;
            this.lblTendoithu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTendoithu.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTendoithu.Location = new System.Drawing.Point(312, 16);
            this.lblTendoithu.Name = "lblTendoithu";
            this.lblTendoithu.Size = new System.Drawing.Size(71, 17);
            this.lblTendoithu.TabIndex = 3;
            this.lblTendoithu.Text = "<doithu>";
            // 
            // lblTimeright
            // 
            this.lblTimeright.AutoSize = true;
            this.lblTimeright.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeright.ForeColor = System.Drawing.Color.Red;
            this.lblTimeright.Location = new System.Drawing.Point(429, 15);
            this.lblTimeright.Name = "lblTimeright";
            this.lblTimeright.Size = new System.Drawing.Size(34, 17);
            this.lblTimeright.TabIndex = 2;
            this.lblTimeright.Text = "30s";
            // 
            // lblTentoi
            // 
            this.lblTentoi.AutoSize = true;
            this.lblTentoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTentoi.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTentoi.Location = new System.Drawing.Point(110, 15);
            this.lblTentoi.Name = "lblTentoi";
            this.lblTentoi.Size = new System.Drawing.Size(31, 17);
            this.lblTentoi.TabIndex = 1;
            this.lblTentoi.Text = "Toi";
            // 
            // lblTimeleft
            // 
            this.lblTimeleft.AutoSize = true;
            this.lblTimeleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeleft.ForeColor = System.Drawing.Color.Red;
            this.lblTimeleft.Location = new System.Drawing.Point(6, 16);
            this.lblTimeleft.Name = "lblTimeleft";
            this.lblTimeleft.Size = new System.Drawing.Size(34, 17);
            this.lblTimeleft.TabIndex = 0;
            this.lblTimeleft.Text = "30s";
            // 
            // btnFontchat
            // 
            this.btnFontchat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFontchat.Image = ((System.Drawing.Image)(resources.GetObject("btnFontchat.Image")));
            this.btnFontchat.Location = new System.Drawing.Point(695, 354);
            this.btnFontchat.Name = "btnFontchat";
            this.btnFontchat.Size = new System.Drawing.Size(21, 21);
            this.btnFontchat.TabIndex = 12;
            this.btnFontchat.UseVisualStyleBackColor = true;
            this.btnFontchat.Click += new System.EventHandler(this.btnFontchat_Click);
            // 
            // btnColorchat
            // 
            this.btnColorchat.Image = global::Caro_Game_2.Properties.Resources.colorgchat;
            this.btnColorchat.Location = new System.Drawing.Point(722, 354);
            this.btnColorchat.Name = "btnColorchat";
            this.btnColorchat.Size = new System.Drawing.Size(21, 21);
            this.btnColorchat.TabIndex = 13;
            this.btnColorchat.UseVisualStyleBackColor = true;
            this.btnColorchat.Click += new System.EventHandler(this.btnColorchat_Click);
            // 
            // btnGui
            // 
            this.btnGui.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGui.ForeColor = System.Drawing.Color.Azure;
            this.btnGui.Location = new System.Drawing.Point(890, 379);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(78, 32);
            this.btnGui.TabIndex = 14;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = false;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // rtbTinnhan
            // 
            this.rtbTinnhan.BackColor = System.Drawing.Color.AliceBlue;
            this.rtbTinnhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbTinnhan.Location = new System.Drawing.Point(695, 39);
            this.rtbTinnhan.Name = "rtbTinnhan";
            this.rtbTinnhan.Size = new System.Drawing.Size(273, 309);
            this.rtbTinnhan.TabIndex = 15;
            this.rtbTinnhan.Text = "";
            // 
            // btnXinhoa
            // 
            this.btnXinhoa.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnXinhoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnXinhoa.FlatAppearance.BorderSize = 0;
            this.btnXinhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXinhoa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnXinhoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXinhoa.Location = new System.Drawing.Point(694, 438);
            this.btnXinhoa.Name = "btnXinhoa";
            this.btnXinhoa.Size = new System.Drawing.Size(135, 55);
            this.btnXinhoa.TabIndex = 16;
            this.btnXinhoa.Text = "XIN HÒA";
            this.btnXinhoa.UseVisualStyleBackColor = false;
            this.btnXinhoa.Click += new System.EventHandler(this.btnXinhoa_Click);
            // 
            // btnThoatgame
            // 
            this.btnThoatgame.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThoatgame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThoatgame.FlatAppearance.BorderSize = 0;
            this.btnThoatgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoatgame.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnThoatgame.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoatgame.Location = new System.Drawing.Point(830, 494);
            this.btnThoatgame.Name = "btnThoatgame";
            this.btnThoatgame.Size = new System.Drawing.Size(138, 54);
            this.btnThoatgame.TabIndex = 17;
            this.btnThoatgame.Text = "THOÁT";
            this.btnThoatgame.UseVisualStyleBackColor = false;
            this.btnThoatgame.Click += new System.EventHandler(this.btnThoatgame_Click);
            // 
            // btnBocuoc
            // 
            this.btnBocuoc.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBocuoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBocuoc.FlatAppearance.BorderSize = 0;
            this.btnBocuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBocuoc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnBocuoc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBocuoc.Location = new System.Drawing.Point(830, 438);
            this.btnBocuoc.Name = "btnBocuoc";
            this.btnBocuoc.Size = new System.Drawing.Size(138, 55);
            this.btnBocuoc.TabIndex = 18;
            this.btnBocuoc.Text = "BỎ CUỘC";
            this.btnBocuoc.UseVisualStyleBackColor = false;
            this.btnBocuoc.Click += new System.EventHandler(this.btnBocuoc_Click);
            // 
            // btnRoibanchoi
            // 
            this.btnRoibanchoi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRoibanchoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRoibanchoi.FlatAppearance.BorderSize = 0;
            this.btnRoibanchoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoibanchoi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnRoibanchoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRoibanchoi.Location = new System.Drawing.Point(694, 494);
            this.btnRoibanchoi.Name = "btnRoibanchoi";
            this.btnRoibanchoi.Size = new System.Drawing.Size(135, 54);
            this.btnRoibanchoi.TabIndex = 19;
            this.btnRoibanchoi.Text = "RỜI BÀN CHƠI";
            this.btnRoibanchoi.UseVisualStyleBackColor = false;
            this.btnRoibanchoi.Click += new System.EventHandler(this.btnRoibanchoi_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 400;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(979, 565);
            this.ControlBox = false;
            this.Controls.Add(this.btnRoibanchoi);
            this.Controls.Add(this.btnBocuoc);
            this.Controls.Add(this.btnThoatgame);
            this.Controls.Add(this.btnXinhoa);
            this.Controls.Add(this.rtbTinnhan);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.btnColorchat);
            this.Controls.Add(this.btnFontchat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbWriteChat);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.listDsnguoidung);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanVsHumanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanVsComputerToolStripMenuItem;
        private System.Windows.Forms.ListView listDsnguoidung;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.RichTextBox rtbWriteChat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTysophai;
        private System.Windows.Forms.Label lblTysotrai;
        private System.Windows.Forms.Label lblTendoithu;
        private System.Windows.Forms.Label lblTimeright;
        private System.Windows.Forms.Label lblTentoi;
        private System.Windows.Forms.Label lblTimeleft;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFontchat;
        private System.Windows.Forms.Button btnColorchat;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.RichTextBox rtbTinnhan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnXinhoa;
        private System.Windows.Forms.Button btnThoatgame;
        private System.Windows.Forms.Button btnBocuoc;
        private System.Windows.Forms.Button btnRoibanchoi;
        private System.Windows.Forms.Timer timer2;
    }
}