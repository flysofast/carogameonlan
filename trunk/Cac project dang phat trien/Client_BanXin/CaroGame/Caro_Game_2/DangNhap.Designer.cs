namespace Caro_Game_2
{
    partial class DangNhap
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMyIP = new System.Windows.Forms.Label();
            this.txtIpsv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblThongbao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(123, 149);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 32);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtTendangnhap
            // 
            this.txtTendangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTendangnhap.Location = new System.Drawing.Point(123, 102);
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.Size = new System.Drawing.Size(171, 21);
            this.txtTendangnhap.TabIndex = 1;
            this.txtTendangnhap.Text = "a";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập tên của bạn:";
            // 
            // lblMyIP
            // 
            this.lblMyIP.AutoSize = true;
            this.lblMyIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyIP.Location = new System.Drawing.Point(144, 9);
            this.lblMyIP.Name = "lblMyIP";
            this.lblMyIP.Size = new System.Drawing.Size(37, 15);
            this.lblMyIP.TabIndex = 3;
            this.lblMyIP.Text = "My IP";
            // 
            // txtIpsv
            // 
            this.txtIpsv.Location = new System.Drawing.Point(123, 62);
            this.txtIpsv.Name = "txtIpsv";
            this.txtIpsv.Size = new System.Drawing.Size(171, 20);
            this.txtIpsv.TabIndex = 0;
            this.txtIpsv.Text = "192.168.1.104";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP Server: ";
            // 
            // lblThongbao
            // 
            this.lblThongbao.AutoSize = true;
            this.lblThongbao.ForeColor = System.Drawing.Color.Red;
            this.lblThongbao.Location = new System.Drawing.Point(123, 128);
            this.lblThongbao.Name = "lblThongbao";
            this.lblThongbao.Size = new System.Drawing.Size(0, 13);
            this.lblThongbao.TabIndex = 6;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 190);
            this.Controls.Add(this.lblThongbao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIpsv);
            this.Controls.Add(this.lblMyIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTendangnhap);
            this.Controls.Add(this.btnStart);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtTendangnhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMyIP;
        private System.Windows.Forms.TextBox txtIpsv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblThongbao;
    }
}