namespace Szachy
{
    partial class FigureSelect
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
            this.selectQueen = new System.Windows.Forms.PictureBox();
            this.selectBishop = new System.Windows.Forms.PictureBox();
            this.selectKnight = new System.Windows.Forms.PictureBox();
            this.selectRook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectRook)).BeginInit();
            this.SuspendLayout();
            // 
            // selectQueen
            // 
            this.selectQueen.BackgroundImage = global::Szachy.Properties.Resources.WhiteQueen;
            this.selectQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectQueen.Location = new System.Drawing.Point(238, 11);
            this.selectQueen.Name = "selectQueen";
            this.selectQueen.Size = new System.Drawing.Size(70, 70);
            this.selectQueen.TabIndex = 4;
            this.selectQueen.TabStop = false;
            this.selectQueen.Click += new System.EventHandler(this.selectQueen_Click);
            // 
            // selectBishop
            // 
            this.selectBishop.BackgroundImage = global::Szachy.Properties.Resources.WhiteBishop;
            this.selectBishop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectBishop.Location = new System.Drawing.Point(162, 11);
            this.selectBishop.Name = "selectBishop";
            this.selectBishop.Size = new System.Drawing.Size(70, 70);
            this.selectBishop.TabIndex = 3;
            this.selectBishop.TabStop = false;
            this.selectBishop.Click += new System.EventHandler(this.selectBishop_Click);
            // 
            // selectKnight
            // 
            this.selectKnight.BackgroundImage = global::Szachy.Properties.Resources.WhiteKnight;
            this.selectKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectKnight.Location = new System.Drawing.Point(86, 11);
            this.selectKnight.Name = "selectKnight";
            this.selectKnight.Size = new System.Drawing.Size(70, 70);
            this.selectKnight.TabIndex = 2;
            this.selectKnight.TabStop = false;
            this.selectKnight.Click += new System.EventHandler(this.selectKnight_Click);
            // 
            // selectRook
            // 
            this.selectRook.BackgroundImage = global::Szachy.Properties.Resources.WhiteRook;
            this.selectRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectRook.Location = new System.Drawing.Point(10, 11);
            this.selectRook.Name = "selectRook";
            this.selectRook.Size = new System.Drawing.Size(70, 70);
            this.selectRook.TabIndex = 1;
            this.selectRook.TabStop = false;
            this.selectRook.Click += new System.EventHandler(this.selectRook_Click);
            // 
            // FigureSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(318, 91);
            this.Controls.Add(this.selectQueen);
            this.Controls.Add(this.selectBishop);
            this.Controls.Add(this.selectKnight);
            this.Controls.Add(this.selectRook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FigureSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FigureSelect";
            ((System.ComponentModel.ISupportInitialize)(this.selectQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectRook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox selectRook;
        private System.Windows.Forms.PictureBox selectKnight;
        private System.Windows.Forms.PictureBox selectBishop;
        private System.Windows.Forms.PictureBox selectQueen;
    }
}