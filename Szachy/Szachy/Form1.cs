using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szachy
{
    public partial class Form : System.Windows.Forms.Form
    {
        Matrix matrix;

        public Form()
        {
            InitializeComponent();

            matrix = new Matrix();
            matrix.form = this;
            matrix.BoardSetup();

            //matrix.MoveFigure(1, 1, 4, 5);
            // matrix.MoveFigure(1, 7, 7, 5);
            // matrix.MoveFigure(2, 1, 6, 5);
            matrix.MoveFigure(2, 1, 5, 5);

            matrix.DrawFigures();
            
        }

        private void CellClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            matrix.SelectCell(int.Parse(pb.Name[1].ToString()), int.Parse(pb.Name[2].ToString()));
        }
    }
}