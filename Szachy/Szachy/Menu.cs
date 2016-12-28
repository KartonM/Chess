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
        public bool enableTime;
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
                form.whitePlayer = 1;
                form.p1_lbl.Text = namePlayer1.Text;
                form.p2_lbl.Text = namePlayer2.Text;
            }
            else
            {
                form.whitePlayer = 2;

                Point points1_lblLocation = form.points1_lbl.Location;
                form.points1_lbl.Location = form.points2_lbl.Location;
                form.points2_lbl.Location = points1_lblLocation;

                form.p1_lbl.Text = namePlayer2.Text;
                form.p2_lbl.Text = namePlayer1.Text;
            }

            Debug.WriteLine("Gracz grający białymi: " + form.whitePlayer);
            form.matrix.menu = this;
            //form.StartPosition = FormStartPosition.Manual;

            form.timer1_lbl.Enabled = enableTimers.Checked;
            form.timer1_lbl.Visible = enableTimers.Checked;

            form.timer2_lbl.Enabled = enableTimers.Checked;
            form.timer2_lbl.Visible = enableTimers.Checked;

            form.toggleTimer.Enabled = enablePause.Checked;
            form.toggleTimer.Visible = enablePause.Checked;

            form.turnTimeSec = decimal.ToInt16(timeSeconds.Value);
            form.turnTimeMin = decimal.ToInt16(timeMinutes.Value);
            form.turnTimeHour = decimal.ToInt16(timeHours.Value);
            form.ResetTime();

            this.Hide();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }


        private void enableTimersClick(object sender, EventArgs e)
        {
            if(enableTimers.Checked)
            {
                enablePause.Enabled = true;
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox3.Enabled = true;
                timeHours.Enabled = true;
                timeMinutes.Enabled = true;
                timeSeconds.Enabled = true;
            }
            else
            {
                enablePause.Enabled = false;
                textBox6.Enabled = false;
                textBox5.Enabled = false;
                textBox3.Enabled = false;
                timeHours.Enabled = false;
                timeMinutes.Enabled = false;
                timeSeconds.Enabled = false;
            }
        }
    }
}
