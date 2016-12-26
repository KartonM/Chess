namespace Szachy
{
    partial class Menu
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.startGame = new System.Windows.Forms.Button();
            this.timeMinutes = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.timeSeconds = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.startingColor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(590, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "SZACHY v0.1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(12, 291);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(590, 39);
            this.startGame.TabIndex = 1;
            this.startGame.Text = "ROZPOCZNIJ GRĘ";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // timeMinutes
            // 
            this.timeMinutes.Location = new System.Drawing.Point(12, 222);
            this.timeMinutes.Name = "timeMinutes";
            this.timeMinutes.Size = new System.Drawing.Size(87, 20);
            this.timeMinutes.TabIndex = 2;
            this.timeMinutes.Text = "0";
            this.timeMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox4.Location = new System.Drawing.Point(12, 190);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(206, 26);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "Czas na wykonanie ruchu";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeSeconds
            // 
            this.timeSeconds.Location = new System.Drawing.Point(131, 222);
            this.timeSeconds.Name = "timeSeconds";
            this.timeSeconds.Size = new System.Drawing.Size(87, 20);
            this.timeSeconds.TabIndex = 5;
            this.timeSeconds.Text = "45";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox5.Location = new System.Drawing.Point(105, 222);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(20, 19);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = ":";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(396, 190);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(206, 26);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Rozpoczynająca Strona";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startingColor
            // 
            this.startingColor.AllowDrop = true;
            this.startingColor.FormattingEnabled = true;
            this.startingColor.Items.AddRange(new object[] {
            "Białi",
            "Czarni"});
            this.startingColor.Location = new System.Drawing.Point(396, 220);
            this.startingColor.Name = "startingColor";
            this.startingColor.Size = new System.Drawing.Size(206, 21);
            this.startingColor.TabIndex = 8;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 591);
            this.Controls.Add(this.startingColor);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.timeSeconds);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.timeMinutes);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.TextBox timeMinutes;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox timeSeconds;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox startingColor;
    }
}