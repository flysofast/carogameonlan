namespace Caro_Game_2
{
    partial class MoiChoi
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
            this.rtbNDLoimoi = new System.Windows.Forms.RichTextBox();
            this.btnGuiloimoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTendoithu = new System.Windows.Forms.Label();
            this.btnHuyloimoi = new System.Windows.Forms.Button();
            this.lblChophanhoi = new System.Windows.Forms.Label();
            this.timerchophanhoi = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rtbNDLoimoi
            // 
            this.rtbNDLoimoi.Location = new System.Drawing.Point(31, 51);
            this.rtbNDLoimoi.Name = "rtbNDLoimoi";
            this.rtbNDLoimoi.Size = new System.Drawing.Size(286, 65);
            this.rtbNDLoimoi.TabIndex = 0;
            this.rtbNDLoimoi.Text = "";
            // 
            // btnGuiloimoi
            // 
            this.btnGuiloimoi.Location = new System.Drawing.Point(136, 133);
            this.btnGuiloimoi.Name = "btnGuiloimoi";
            this.btnGuiloimoi.Size = new System.Drawing.Size(75, 30);
            this.btnGuiloimoi.TabIndex = 1;
            this.btnGuiloimoi.Text = "Gửi Đi";
            this.btnGuiloimoi.UseVisualStyleBackColor = true;
            this.btnGuiloimoi.Click += new System.EventHandler(this.btnGuiloimoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nội dung lời mời: ";
            // 
            // lblTendoithu
            // 
            this.lblTendoithu.AutoSize = true;
            this.lblTendoithu.Location = new System.Drawing.Point(118, 9);
            this.lblTendoithu.Name = "lblTendoithu";
            this.lblTendoithu.Size = new System.Drawing.Size(62, 13);
            this.lblTendoithu.TabIndex = 3;
            this.lblTendoithu.Text = "Tên đối thủ";
            // 
            // btnHuyloimoi
            // 
            this.btnHuyloimoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyloimoi.Location = new System.Drawing.Point(121, 133);
            this.btnHuyloimoi.Name = "btnHuyloimoi";
            this.btnHuyloimoi.Size = new System.Drawing.Size(100, 30);
            this.btnHuyloimoi.TabIndex = 4;
            this.btnHuyloimoi.Text = "Hủy Lời Mời";
            this.btnHuyloimoi.UseVisualStyleBackColor = true;
            this.btnHuyloimoi.Visible = false;
            this.btnHuyloimoi.Click += new System.EventHandler(this.btnHuyloimoi_Click);
            // 
            // lblChophanhoi
            // 
            this.lblChophanhoi.AutoSize = true;
            this.lblChophanhoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChophanhoi.ForeColor = System.Drawing.Color.Blue;
            this.lblChophanhoi.Location = new System.Drawing.Point(118, 32);
            this.lblChophanhoi.Name = "lblChophanhoi";
            this.lblChophanhoi.Size = new System.Drawing.Size(127, 13);
            this.lblChophanhoi.TabIndex = 5;
            this.lblChophanhoi.Text = "Đang chờ phản hồi...";
            this.lblChophanhoi.Visible = false;
            // 
            // timerchophanhoi
            // 
            this.timerchophanhoi.Interval = 1000;
            this.timerchophanhoi.Tick += new System.EventHandler(this.timerchophanhoi_Tick);
            // 
            // MoiChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 175);
            this.Controls.Add(this.lblChophanhoi);
            this.Controls.Add(this.btnHuyloimoi);
            this.Controls.Add(this.lblTendoithu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuiloimoi);
            this.Controls.Add(this.rtbNDLoimoi);
            this.Name = "MoiChoi";
            this.Text = "Mời chơi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoiChoi_FormClosing);
            this.Load += new System.EventHandler(this.MoiChoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNDLoimoi;
        private System.Windows.Forms.Button btnGuiloimoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTendoithu;
        private System.Windows.Forms.Button btnHuyloimoi;
        private System.Windows.Forms.Label lblChophanhoi;
        private System.Windows.Forms.Timer timerchophanhoi;
    }
}