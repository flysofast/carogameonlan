namespace Caro_Game_2
{
    partial class NhanLoiMoi
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
            this.btnDongy = new System.Windows.Forms.Button();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.rtbNoidungloimoi = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTendoithu = new System.Windows.Forms.Label();
            this.timerchophanhoi = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnDongy
            // 
            this.btnDongy.Location = new System.Drawing.Point(73, 148);
            this.btnDongy.Name = "btnDongy";
            this.btnDongy.Size = new System.Drawing.Size(89, 30);
            this.btnDongy.TabIndex = 0;
            this.btnDongy.Text = "Đồng ý";
            this.btnDongy.UseVisualStyleBackColor = true;
            this.btnDongy.Click += new System.EventHandler(this.btnDongy_Click);
            // 
            // btnHuybo
            // 
            this.btnHuybo.Location = new System.Drawing.Point(200, 148);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(89, 30);
            this.btnHuybo.TabIndex = 1;
            this.btnHuybo.Text = "Hủy Bỏ";
            this.btnHuybo.UseVisualStyleBackColor = true;
            this.btnHuybo.Click += new System.EventHandler(this.btnHuybo_Click);
            // 
            // rtbNoidungloimoi
            // 
            this.rtbNoidungloimoi.Enabled = false;
            this.rtbNoidungloimoi.Location = new System.Drawing.Point(26, 58);
            this.rtbNoidungloimoi.Name = "rtbNoidungloimoi";
            this.rtbNoidungloimoi.Size = new System.Drawing.Size(312, 71);
            this.rtbNoidungloimoi.TabIndex = 2;
            this.rtbNoidungloimoi.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nội dung lời mời:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bạn nhận được lời mời từ: ";
            // 
            // lblTendoithu
            // 
            this.lblTendoithu.AutoSize = true;
            this.lblTendoithu.Location = new System.Drawing.Point(197, 10);
            this.lblTendoithu.Name = "lblTendoithu";
            this.lblTendoithu.Size = new System.Drawing.Size(47, 13);
            this.lblTendoithu.TabIndex = 5;
            this.lblTendoithu.Text = "Tendthu";
            // 
            // timerchophanhoi
            // 
            this.timerchophanhoi.Interval = 1000;
            this.timerchophanhoi.Tick += new System.EventHandler(this.timerchophanhoi_Tick);
            // 
            // NhanLoiMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 187);
            this.Controls.Add(this.lblTendoithu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbNoidungloimoi);
            this.Controls.Add(this.btnHuybo);
            this.Controls.Add(this.btnDongy);
            this.Name = "NhanLoiMoi";
            this.Text = "Nhận lời mời";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NhanLoiMoi_FormClosing);
            this.Load += new System.EventHandler(this.NhanLoiMoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDongy;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.RichTextBox rtbNoidungloimoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTendoithu;
        private System.Windows.Forms.Timer timerchophanhoi;
    }
}