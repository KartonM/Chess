namespace Szachy
{
    partial class Endgame
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
            this.textMessage1 = new System.Windows.Forms.TextBox();
            this.textMessage2 = new System.Windows.Forms.TextBox();
            this.textMessage3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textMessage1
            // 
            this.textMessage1.Location = new System.Drawing.Point(3, 12);
            this.textMessage1.Name = "textMessage1";
            this.textMessage1.Size = new System.Drawing.Size(269, 20);
            this.textMessage1.TabIndex = 0;
            this.textMessage1.Text = "Biali Wygrali";
            this.textMessage1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textMessage2
            // 
            this.textMessage2.Location = new System.Drawing.Point(3, 38);
            this.textMessage2.Name = "textMessage2";
            this.textMessage2.Size = new System.Drawing.Size(269, 20);
            this.textMessage2.TabIndex = 1;
            this.textMessage2.Text = "W xx ruchach";
            this.textMessage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textMessage3
            // 
            this.textMessage3.Location = new System.Drawing.Point(3, 64);
            this.textMessage3.Name = "textMessage3";
            this.textMessage3.Size = new System.Drawing.Size(269, 20);
            this.textMessage3.TabIndex = 2;
            this.textMessage3.Text = "W xx sekund";
            this.textMessage3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Endgame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textMessage3);
            this.Controls.Add(this.textMessage2);
            this.Controls.Add(this.textMessage1);
            this.Name = "Endgame";
            this.Text = "Endgame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textMessage1;
        private System.Windows.Forms.TextBox textMessage2;
        private System.Windows.Forms.TextBox textMessage3;
    }
}