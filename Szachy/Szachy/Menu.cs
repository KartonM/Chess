using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szachy
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            startingColor.SelectedIndex = 0;
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            if(startingColor.SelectedIndex==0)
            {
                form.matrix.currentColor = Figure.ColorEnum.White;
                form.matrix.GUI_Color.Text = "Ruch:" + Environment.NewLine + "Białych";
            }
            else
            {
                form.matrix.currentColor = Figure.ColorEnum.Black;
                form.matrix.GUI_Color.Text = "Ruch:" + Environment.NewLine + "Czarnych";
            }

            form.matrix.menu = this;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.turnTime = int.Parse(timeSeconds.Text) + int.Parse(timeMinutes.Text) * 60;
            form.ResetTime();
            this.Hide();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
