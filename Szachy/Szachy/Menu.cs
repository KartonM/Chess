using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szachy
{
    public partial class Menu : Form
    {
        public bool enableTime;
        string fileData;
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

        private void loadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "save.majc";
            dialog.DefaultExt = ".majc";
            //dialog.InitialDirectory
            dialog.Filter = "Marcin And Jan Chess (*.majc)|*.majc";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Form1 form = new Form1();
                form.matrix.menu = this;
                form.saveText = File.ReadAllLines(dialog.FileName);
                fileData = form.saveText[form.saveText.Length-1];
                Array.Resize<string>(ref form.saveText, form.saveText.Length - 1);
                form.fileCounter = form.saveText.Length + 1;
                foreach(string s in form.saveText)
                {
                    Debug.WriteLine(s);
                }

                bool b;
                b = fileData[0] == '1';
                Debug.WriteLine(b);
                form.timer1_lbl.Enabled = b;
                form.timer1_lbl.Visible = b;

                form.timer2_lbl.Enabled = b;
                form.timer2_lbl.Visible = b;

                b = fileData[1] == '1';
                Debug.WriteLine(b);

                form.toggleTimer.Enabled = b;
                form.toggleTimer.Visible = b;

                form.player1_hour = int.Parse(fileData.Substring(2, 2));
                form.player1_min = int.Parse(fileData.Substring(4, 2));
                form.player1_sec = int.Parse(fileData.Substring(6, 2));
                form.player1_dec = int.Parse(fileData[8].ToString());

                form.player2_hour = int.Parse(fileData.Substring(9, 2));
                form.player2_min = int.Parse(fileData.Substring(11, 2));
                form.player2_sec = int.Parse(fileData.Substring(13, 2));
                form.player2_dec = int.Parse(fileData[15].ToString());

                form.timer1_lbl.Text = form.player1_hour.ToString() + ":" + (form.player1_min <= 9 ? "0" : "") + form.player1_min.ToString() + ":" +
                (form.player1_sec <= 9 ? "0" : "") + form.player1_sec.ToString() + ":" + form.player1_dec.ToString();


                form.timer2_lbl.Text = form.player2_hour.ToString() + ":" + (form.player2_min <= 9 ? "0" : "") + form.player2_min.ToString() + ":" +
                (form.player2_sec <= 9 ? "0" : "") + form.player2_sec.ToString() + ":" + form.player2_dec.ToString();

                form.boardDecode(null, null);
                this.Hide();
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
        }
    }
}
