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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.startingPlayer = new System.Windows.Forms.ComboBox();
            this.timeSeconds = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.timeMinutes = new System.Windows.Forms.NumericUpDown();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.timeHours = new System.Windows.Forms.NumericUpDown();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.namePlayer1 = new System.Windows.Forms.TextBox();
            this.namePlayer2 = new System.Windows.Forms.TextBox();
            this.enableTimers = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.timeSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeHours)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(16, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(786, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "SZACHY v0.1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(16, 571);
            this.startGame.Margin = new System.Windows.Forms.Padding(4);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(787, 48);
            this.startGame.TabIndex = 1;
            this.startGame.Text = "ROZPOCZNIJ GRĘ";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox4.Location = new System.Drawing.Point(16, 234);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(273, 31);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "Czas na wykonanie ruchów";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(528, 234);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(273, 31);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Rozpoczynająca Strona";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startingPlayer
            // 
            this.startingPlayer.AllowDrop = true;
            this.startingPlayer.FormattingEnabled = true;
            this.startingPlayer.Items.AddRange(new object[] {
            "Gracz 1",
            "Gracz 2",
            "Losowo"});
            this.startingPlayer.Location = new System.Drawing.Point(528, 271);
            this.startingPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.startingPlayer.Name = "startingPlayer";
            this.startingPlayer.Size = new System.Drawing.Size(273, 24);
            this.startingPlayer.TabIndex = 8;
            // 
            // timeSeconds
            // 
            this.timeSeconds.Enabled = false;
            this.timeSeconds.Location = new System.Drawing.Point(243, 305);
            this.timeSeconds.Margin = new System.Windows.Forms.Padding(4);
            this.timeSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeSeconds.Name = "timeSeconds";
            this.timeSeconds.Size = new System.Drawing.Size(47, 22);
            this.timeSeconds.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(204, 309);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(32, 15);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "Sek:";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(115, 309);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(29, 15);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "Min:";
            // 
            // timeMinutes
            // 
            this.timeMinutes.Enabled = false;
            this.timeMinutes.Location = new System.Drawing.Point(147, 305);
            this.timeMinutes.Margin = new System.Windows.Forms.Padding(4);
            this.timeMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeMinutes.Name = "timeMinutes";
            this.timeMinutes.Size = new System.Drawing.Size(47, 22);
            this.timeMinutes.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(17, 309);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(40, 15);
            this.textBox6.TabIndex = 16;
            this.textBox6.Text = "Godz:";
            // 
            // timeHours
            // 
            this.timeHours.Enabled = false;
            this.timeHours.Location = new System.Drawing.Point(59, 305);
            this.timeHours.Margin = new System.Windows.Forms.Padding(4);
            this.timeHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.timeHours.Name = "timeHours";
            this.timeHours.Size = new System.Drawing.Size(47, 22);
            this.timeHours.TabIndex = 15;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox7.Location = new System.Drawing.Point(15, 396);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(273, 31);
            this.textBox7.TabIndex = 17;
            this.textBox7.Text = "Nazwa Gracza 1";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox8.Location = new System.Drawing.Point(528, 396);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(273, 31);
            this.textBox8.TabIndex = 18;
            this.textBox8.Text = "Nazwa Gracza 2";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // namePlayer1
            // 
            this.namePlayer1.BackColor = System.Drawing.SystemColors.Window;
            this.namePlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.namePlayer1.Location = new System.Drawing.Point(15, 436);
            this.namePlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.namePlayer1.Name = "namePlayer1";
            this.namePlayer1.Size = new System.Drawing.Size(273, 26);
            this.namePlayer1.TabIndex = 19;
            this.namePlayer1.Text = "Gracz1";
            this.namePlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // namePlayer2
            // 
            this.namePlayer2.BackColor = System.Drawing.SystemColors.Window;
            this.namePlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.namePlayer2.Location = new System.Drawing.Point(528, 436);
            this.namePlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.namePlayer2.Name = "namePlayer2";
            this.namePlayer2.Size = new System.Drawing.Size(273, 26);
            this.namePlayer2.TabIndex = 20;
            this.namePlayer2.Text = "Gracz2";
            this.namePlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enableTimers
            // 
            this.enableTimers.AutoSize = true;
            this.enableTimers.Location = new System.Drawing.Point(17, 274);
            this.enableTimers.Name = "enableTimers";
            this.enableTimers.Size = new System.Drawing.Size(107, 21);
            this.enableTimers.TabIndex = 21;
            this.enableTimers.Text = "Gra na czas";
            this.enableTimers.UseVisualStyleBackColor = true;
            this.enableTimers.CheckStateChanged += new System.EventHandler(this.enableTimersClick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 727);
            this.Controls.Add(this.enableTimers);
            this.Controls.Add(this.namePlayer2);
            this.Controls.Add(this.namePlayer1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.timeHours);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.timeMinutes);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.timeSeconds);
            this.Controls.Add(this.startingPlayer);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.timeSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox startingPlayer;
        private System.Windows.Forms.NumericUpDown timeSeconds;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.NumericUpDown timeMinutes;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.NumericUpDown timeHours;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox namePlayer1;
        private System.Windows.Forms.TextBox namePlayer2;
        private System.Windows.Forms.CheckBox enableTimers;
    }
}