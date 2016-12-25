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
            this.selectQueen.Location = new System.Drawing.Point(317, 13);
            this.selectQueen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectQueen.Name = "selectQueen";
            this.selectQueen.Size = new System.Drawing.Size(93, 86);
            this.selectQueen.TabIndex = 4;
            this.selectQueen.TabStop = false;
            // 
            // selectBishop
            // 
            this.selectBishop.BackgroundImage = global::Szachy.Properties.Resources.WhiteBishop;
            this.selectBishop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectBishop.Location = new System.Drawing.Point(216, 13);
            this.selectBishop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectBishop.Name = "selectBishop";
            this.selectBishop.Size = new System.Drawing.Size(93, 86);
            this.selectBishop.TabIndex = 3;
            this.selectBishop.TabStop = false;
            // 
            // selectKnight
            // 
            this.selectKnight.BackgroundImage = global::Szachy.Properties.Resources.WhiteKnight;
            this.selectKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectKnight.Location = new System.Drawing.Point(115, 13);
            this.selectKnight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectKnight.Name = "selectKnight";
            this.selectKnight.Size = new System.Drawing.Size(93, 86);
            this.selectKnight.TabIndex = 2;
            this.selectKnight.TabStop = false;
            // 
            // selectRook
            // 
            this.selectRook.BackgroundImage = global::Szachy.Properties.Resources.WhiteRook;
            this.selectRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectRook.Location = new System.Drawing.Point(13, 13);
            this.selectRook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectRook.Name = "selectRook";
            this.selectRook.Size = new System.Drawing.Size(93, 86);
            this.selectRook.TabIndex = 1;
            this.selectRook.TabStop = false;
            // 
            // FigureSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 112);
            this.Controls.Add(this.selectQueen);
            this.Controls.Add(this.selectBishop);
            this.Controls.Add(this.selectKnight);
            this.Controls.Add(this.selectRook);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FigureSelect";
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