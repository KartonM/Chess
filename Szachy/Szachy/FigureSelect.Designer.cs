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
            this.selectPawn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectPawn)).BeginInit();
            this.SuspendLayout();
            // 
            // selectQueen
            // 
            this.selectQueen.BackgroundImage = global::Szachy.Properties.Resources.WhiteQueen;
            this.selectQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectQueen.Location = new System.Drawing.Point(316, 12);
            this.selectQueen.Name = "selectQueen";
            this.selectQueen.Size = new System.Drawing.Size(70, 70);
            this.selectQueen.TabIndex = 4;
            this.selectQueen.TabStop = false;
            // 
            // selectBishop
            // 
            this.selectBishop.BackgroundImage = global::Szachy.Properties.Resources.WhiteBishop;
            this.selectBishop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectBishop.Location = new System.Drawing.Point(240, 12);
            this.selectBishop.Name = "selectBishop";
            this.selectBishop.Size = new System.Drawing.Size(70, 70);
            this.selectBishop.TabIndex = 3;
            this.selectBishop.TabStop = false;
            // 
            // selectKnight
            // 
            this.selectKnight.BackgroundImage = global::Szachy.Properties.Resources.WhiteKnight;
            this.selectKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectKnight.Location = new System.Drawing.Point(164, 12);
            this.selectKnight.Name = "selectKnight";
            this.selectKnight.Size = new System.Drawing.Size(70, 70);
            this.selectKnight.TabIndex = 2;
            this.selectKnight.TabStop = false;
            // 
            // selectRook
            // 
            this.selectRook.BackgroundImage = global::Szachy.Properties.Resources.WhiteRook;
            this.selectRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectRook.Location = new System.Drawing.Point(88, 12);
            this.selectRook.Name = "selectRook";
            this.selectRook.Size = new System.Drawing.Size(70, 70);
            this.selectRook.TabIndex = 1;
            this.selectRook.TabStop = false;
            // 
            // selectPawn
            // 
            this.selectPawn.BackgroundImage = global::Szachy.Properties.Resources.WhitePawn;
            this.selectPawn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectPawn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectPawn.Location = new System.Drawing.Point(12, 12);
            this.selectPawn.Name = "selectPawn";
            this.selectPawn.Size = new System.Drawing.Size(70, 70);
            this.selectPawn.TabIndex = 0;
            this.selectPawn.TabStop = false;
            // 
            // FigureSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 100);
            this.Controls.Add(this.selectQueen);
            this.Controls.Add(this.selectBishop);
            this.Controls.Add(this.selectKnight);
            this.Controls.Add(this.selectRook);
            this.Controls.Add(this.selectPawn);
            this.Name = "FigureSelect";
            this.Text = "FigureSelect";
            ((System.ComponentModel.ISupportInitialize)(this.selectQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectPawn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox selectPawn;
        private System.Windows.Forms.PictureBox selectRook;
        private System.Windows.Forms.PictureBox selectKnight;
        private System.Windows.Forms.PictureBox selectBishop;
        private System.Windows.Forms.PictureBox selectQueen;
    }
}