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
        public Matrix matrix;
        //public int timeLeft;
        public int turnTimeMin;
        public int turnTimeSec;
        public int player1_min;
        public int player1_sec;
        public int player1_dec;
        public int player2_min;
        public int player2_sec;
        public int player2_dec;
        public bool firstMove;

        //System.Windows.Forms.Timer turnTimer;

        public Form1()
        {
            InitializeComponent();
            /*turnTimer = new System.Windows.Forms.Timer();
            turnTimer.Interval = 1000;
            turnTimer.Tick += new EventHandler(TimerTick);
            turnTimer.Start();*/

            matrix = new Matrix();
            matrix.form = this;
            matrix.GUI_Color = GUI_Color;
            matrix.GUI_Count = GUI_Count;
            matrix.BoardSetup();
            /*matrix.board[2, 3].figure = matrix.figures[9];
            matrix.board[1, 7].figure = matrix.figures[29];
            matrix.board[4, 4].figure = matrix.figures[2];
            matrix.board[4, 5].figure = matrix.figures[17];
            matrix.board[5, 4].figure = matrix.figures[25];
            matrix.board[7, 5].figure = matrix.figures[32];
            matrix.board[8, 3].figure = matrix.figures[13];
            matrix.board[8, 2].figure = matrix.figures[4];
            matrix.figures[4].firstMove = false;
            matrix.figures[2].firstMove = false;
            matrix.figures[17].firstMove = false;
            matrix.figures[13].firstMove = false;
            matrix.figures[29].firstMove = false;*/
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
            matrix.DrawFigures();
            matrix.ResetMoveAbility();
            matrix.DrawMoveAbility();
        }

        private void debugClick(object sender, EventArgs e)
        {
            matrix.debug = checkBox1.Checked;
        }

        public void TimerStart()
        {
            timer1.Start();
            timer2.Start();
        }

        public void TimerStop()
        {
            timer1.Stop();
            timer2.Stop();
        }

        public void ResetTime()
        {
            player1_min = turnTimeMin;
            player1_sec = turnTimeSec;
            player1_dec = 0;
            player2_min = turnTimeMin;
            player2_sec = turnTimeSec;
            player2_dec = 0;

            if (player1_sec <= 9 && player1_min <= 9)
            {
                timer1_lbl.Text = "0" + player1_min.ToString() + ":0" + player1_sec.ToString() + "." + player1_dec.ToString();
                timer2_lbl.Text = "0" + player2_min.ToString() + ":0" + player2_sec.ToString() + "." + player2_dec.ToString();
            }
            else if (player1_min <= 9)
            {
                timer1_lbl.Text = "0" + player1_min.ToString() + ":" + player1_sec.ToString() + "." + player1_dec.ToString();
                timer2_lbl.Text = "0" + player2_min.ToString() + ":" + player2_sec.ToString() + "." + player2_dec.ToString();
            }
            else if (player1_sec <= 9)
            {
                timer1_lbl.Text = player1_min.ToString() + ":0" + player1_sec.ToString() + "." + player1_dec.ToString();
                timer2_lbl.Text = player2_min.ToString() + ":0" + player2_sec.ToString() + "." + player2_dec.ToString();
            }
            else
            {
                timer1_lbl.Text = player1_min.ToString() + ":" + player1_sec.ToString() + "." + player1_dec.ToString();
                timer2_lbl.Text = player2_min.ToString() + ":" + player2_sec.ToString() + "." + player2_dec.ToString();
            }
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (matrix.currentColor == Figure.ColorEnum.Black)
            {
                firstMove = false;
                if (player1_min == 0 && player1_sec == 0 && player1_dec == 00)
                {
                    Debug.WriteLine("koniec czasu");
                    timer1.Stop();
                }

                if (player1_dec < 0)
                {
                    player1_dec = 9;
                    player1_sec--;
                }
                if (player1_sec < 0)
                {
                    player1_sec = 59;
                    player1_min--;
                }

                if (player1_sec <= 9 && player1_min <= 9)
                    timer1_lbl.Text = "0" + player1_min.ToString() + ":0" + player1_sec.ToString() + "." + player1_dec.ToString();
                else if (player1_min <= 9)
                    timer1_lbl.Text = "0" + player1_min.ToString() + ":" + player1_sec.ToString() + "." + player1_dec.ToString();
                else if (player1_sec <= 9)
                    timer1_lbl.Text = player1_min.ToString() + ":0" + player1_sec.ToString() + "." + player1_dec.ToString();
                else
                    timer1_lbl.Text = player1_min.ToString() + ":" + player1_sec.ToString() + "." + player1_dec.ToString();

                player1_dec--;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!firstMove && matrix.currentColor == Figure.ColorEnum.White)
            {
                if (player2_min == 0 && player2_sec == 0 && player2_dec == 00)
                {
                    Debug.WriteLine("koniec czasu");
                    timer2.Stop();
                }

                if (player2_dec < 0)
                {
                    player2_dec = 9;
                    player2_sec--;
                }
                if (player2_sec < 0)
                {
                    player2_sec = 59;
                    player2_min--;
                }

                if (player2_sec <= 9 && player2_min <= 9)
                    timer2_lbl.Text = "0" + player2_min.ToString() + ":0" + player2_sec.ToString() + "." + player2_dec.ToString();
                else if (player2_min <= 9)
                    timer2_lbl.Text = "0" + player2_min.ToString() + ":" + player2_sec.ToString() + "." + player2_dec.ToString();
                else if (player2_sec <= 9)
                    timer2_lbl.Text = player2_min.ToString() + ":0" + player2_sec.ToString() + "." + player2_dec.ToString();
                else
                    timer2_lbl.Text = player2_min.ToString() + ":" + player2_sec.ToString() + "." + player2_dec.ToString();

                player2_dec--;
            }
        }

        /*void TimerTick(Object myObject, EventArgs myEventArgs)
        {
            if(timeLeft<0)
            {

            }
            GUI_Time.Text = "Pozostały Czas:" + Environment.NewLine + timeLeft;
            timeLeft--;

        }*/

        /*public void Win(Figure.ColorEnum color)
        {
            if(color==Figure.ColorEnum.White)
            {

            }
        }*/     //------ USUNĄŁBYM TO, PO WYGRANEJ WYSTARCZY TEN MESSAGEBOX, KTÓRY WYSKAKUJE
                //       I WTEDY MOŻNA ALBO WYJŚĆ KRZYŻYKIEM, ALBO USTAWIĆ NA NOWO SZACHOWNICĘ
                //       I GRAĆ DALEJ - DO TEGO ZROBIĆ LICZNIK WYGRANYCH PARTII I TERAZ JEŚLI KTOŚ
                //       CHCE ZAGRAC WIECEJ NIZ JEDEN MECZ NIE MUSI NA NOWO ODPALAC APKI
    }
}