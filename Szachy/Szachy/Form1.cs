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
            
        public Form()
        {
            InitializeComponent();

            Matrix matrix = new Matrix();
            matrix.form = this;
            matrix.BoardSetup();
            matrix.DrawFigures();
            
        }

        private void CellClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Debug.WriteLine(pb.Name);
        }
    }
}