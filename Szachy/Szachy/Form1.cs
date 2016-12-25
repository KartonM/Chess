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
    public partial class Form1 : System.Windows.Forms.Form
    {
        Matrix matrix;

        public Form1()
        {
            InitializeComponent();

            matrix = new Matrix();
            matrix.form = this;
            matrix.GUI_Color = GUI_Color;
            matrix.GUI_Count = GUI_Count;
            matrix.BoardSetup();

            matrix.DrawFigures();

        }

        private void CellClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            matrix.SelectCell(int.Parse(pb.Name[1].ToString()), int.Parse(pb.Name[2].ToString()));
        }

        private void boardSetup(object sender, EventArgs e)
        {
            matrix.BoardSetup();
            matrix.ResetMoveAbility();
            matrix.DrawMoveAbility();
        }

        private void debugClick(object sender, EventArgs e)
        {
            matrix.debug = checkBox1.Checked;
        }

        private void OpenDialog(object sender, EventArgs e)
        {

        }
    }
}