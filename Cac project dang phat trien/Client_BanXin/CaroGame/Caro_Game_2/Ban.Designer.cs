﻿namespace Caro_Game_2
{
    partial class Ban
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Ban";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Ban_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ban_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ban_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
