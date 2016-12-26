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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            startingPlayer.SelectedIndex = 2;
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            if (startingPlayer.SelectedIndex == 2)
            {
                startingPlayer.SelectedIndex = new Random().Next(0, 2);
            }

            if (startingPlayer.SelectedIndex==0)
            {
                form.p1_lbl.Text = namePlayer1.Text;
                form.p2_lbl.Text = namePlayer2.Text;
            }
            else
            {
                form.p1_lbl.Text = namePlayer2.Text;
                form.p2_lbl.Text = namePlayer1.Text;
            }

            form.matrix.menu = this;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.turnTimeSec = decimal.ToInt16(timeSeconds.Value);
            form.turnTimeMin = decimal.ToInt16(timeMinutes.Value);
            form.turnTimeHour = decimal.ToInt16(timeHours.Value);
            form.ResetTime();
            this.Hide();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
