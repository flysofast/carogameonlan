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
            this.rtbNDLoimoi = new System.Windows.Forms.RichTextBox();
            this.btnGuiloimoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbNDLoimoi
            // 
            this.rtbNDLoimoi.Location = new System.Drawing.Point(31, 40);
            this.rtbNDLoimoi.Name = "rtbNDLoimoi";
            this.rtbNDLoimoi.Size = new System.Drawing.Size(286, 65);
            this.rtbNDLoimoi.TabIndex = 0;
            this.rtbNDLoimoi.Text = "";
            // 
            // btnGuiloimoi
            // 
            this.btnGuiloimoi.Location = new System.Drawing.Point(132, 124);
            this.btnGuiloimoi.Name = "btnGuiloimoi";
            this.btnGuiloimoi.Size = new System.Drawing.Size(75, 30);
            this.btnGuiloimoi.TabIndex = 1;
            this.btnGuiloimoi.Text = "Gửi Đi";
            this.btnGuiloimoi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nội dung lời mời: ";
            // 
            // MoiChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 175);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuiloimoi);
            this.Controls.Add(this.rtbNDLoimoi);
            this.Name = "MoiChoi";
            this.Text = "Mời chơi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNDLoimoi;
        private System.Windows.Forms.Button btnGuiloimoi;
        private System.Windows.Forms.Label label1;
    }
}