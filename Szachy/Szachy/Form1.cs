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
        Menu menu;
        public Matrix matrix;
        //public int timeLeft;
        public int turnTimeMin;
        public int turnTimeSec;
        public int turnTimeHour;

        public int player1_hour;
        public int player1_min;
        public int player1_sec;
        public int player1_dec;
        public int player2_hour;
        public int player2_min;
        public int player2_sec;
        public int player2_dec;
        public bool firstMove;
        public bool whiteDownside;
        public bool enableTimers;
        bool timerIsRunning = true;

        public Label p1_lbl;
        public Label p2_lbl;

        public Form1()
        {
            InitializeComponent();
            p1_lbl = player1_lbl;
            p2_lbl = player2_lbl;
            whiteDownside = true;

            matrix = new Matrix();
            matrix.form = this;
            matrix.GUI_Color = GUI_Color;
            matrix.GUI_Count = GUI_Count;
            matrix.BoardSetup();
            /*matrix.board[2, 3].figure = matrix.figures[9];   //do testowania pata
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
        }

        public void TimerStop()
        {
            timer1.Stop();
        }

        public void ResetTime()
        {
            player1_hour = turnTimeHour;
            player1_min = turnTimeMin;
            player1_sec = turnTimeSec;
            player1_dec = 0;
            player2_hour = turnTimeHour;
            player2_min = turnTimeMin;
            player2_sec = turnTimeSec;
            player2_dec = 0;

            timer1_lbl.Text = player1_hour.ToString() + ":" + (player1_min <= 9 ? "0" : "") + player1_min.ToString() + ":" +
                (player1_sec <= 9 ? "0" : "") + player1_sec.ToString() + ":" + player1_dec.ToString();


            timer2_lbl.Text = player2_hour.ToString() + ":" + (player2_min <= 9 ? "0" : "") + player2_min.ToString() + ":" +
                (player2_sec <= 9 ? "0" : "") + player2_sec.ToString() + ":" + player2_dec.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (matrix.currentColor == Figure.ColorEnum.Black)
            {
                int playerTime = player1_hour * 36000 + player1_min * 600 + player1_sec * 10 + player1_dec;

                firstMove = false;
                if (playerTime == 0)
                {
                    bool draw = true;
                    bool allyFigure = false;
                    int opponentFigure = 0;
                    int opponentKnights = 0;
                    Debug.WriteLine("koniec czasu");
                    timer1.Stop();

                    for (int iCol = 1; iCol <= 8; iCol++)
                        for (int iRow = 1; iRow <= 8; iRow++)
                        {
                            if (!matrix.CellIsEmpty(iCol, iRow) &&
                                matrix.board[iCol, iRow].figure.color == Figure.ColorEnum.White &&
                                matrix.board[iCol, iRow].figure.type == Figure.TypeEnum.Pawn)
                                draw = false;

                            if (!matrix.CellIsEmpty(iCol, iRow) &&
                                matrix.board[iCol, iRow].figure.color == Figure.ColorEnum.Black &&
                                matrix.board[iCol, iRow].figure.type != Figure.TypeEnum.King)
                                allyFigure = true;

                            if (!matrix.CellIsEmpty(iCol, iRow) &&
                               matrix.board[iCol, iRow].figure.color == Figure.ColorEnum.White &&
                               matrix.board[iCol, iRow].figure.type != Figure.TypeEnum.King &&
                               matrix.board[iCol, iRow].figure.type != Figure.TypeEnum.Pawn)
                            {
                                opponentFigure++;
                                if (matrix.board[iCol, iRow].figure.type == Figure.TypeEnum.Knight)
                                    opponentKnights++;
                            }

                        }

                    if (allyFigure && opponentFigure > 0)
                        draw = false;

                    if (!allyFigure && opponentFigure > 0 && opponentFigure - opponentKnights > 0)
                        draw = false;

                    if (!draw)
                    {
                        Debug.WriteLine("Koniec czasu, biale wygrywaja");
                    }
                    else
                    {
                        Debug.WriteLine("Koniec czasu, remis");
                    }
                }

                timer2_lbl.Text = player1_hour.ToString() + ":" + (player1_min <= 9 ? "0" : "") + player1_min.ToString() + ":" +
                    (player1_sec <= 9 ? "0" : "") + player1_sec.ToString() + ":" + player1_dec.ToString();

                playerTime--;
                player1_dec = playerTime % 10;
                player1_sec = ((playerTime - player1_dec) / 10) % 60;
                player1_min = ((playerTime - player1_sec - player1_dec) / 600) % 60;
                player1_hour = (playerTime - player1_min - player1_sec - player1_dec) / 36000;
            }

            if (!firstMove && matrix.currentColor == Figure.ColorEnum.White)
            {
                int playerTime = player2_hour * 36000 + player2_min * 600 + player2_sec * 10 + player2_dec;

                if (playerTime == 0)
                {
                    bool draw = true;
                    bool allyFigure = false;
                    int opponentFigure = 0;
                    int opponentKnights = 0;

                    timer1.Stop();

                    for (int iCol = 1; iCol <= 8; iCol++)
                        for (int iRow = 1; iRow <= 8; iRow++)
                        {
                            if (!matrix.CellIsEmpty(iCol, iRow) &&
                                matrix.board[iCol, iRow].figure.color == Figure.ColorEnum.Black &&
                                matrix.board[iCol, iRow].figure.type == Figure.TypeEnum.Pawn)
                                draw = false;

                            if (!matrix.CellIsEmpty(iCol, iRow) &&
                                matrix.board[iCol, iRow].figure.color == Figure.ColorEnum.White &&
                                matrix.board[iCol, iRow].figure.type != Figure.TypeEnum.King)
                                allyFigure = true;

                            if (!matrix.CellIsEmpty(iCol, iRow) &&
                               matrix.board[iCol, iRow].figure.color == Figure.ColorEnum.Black &&
                               matrix.board[iCol, iRow].figure.type != Figure.TypeEnum.King &&
                               matrix.board[iCol, iRow].figure.type != Figure.TypeEnum.Pawn)
                            {
                                opponentFigure++;
                                if (matrix.board[iCol, iRow].figure.type == Figure.TypeEnum.Knight)
                                    opponentKnights++;
                            }

                        }

                    if (allyFigure && opponentFigure > 0)
                        draw = false;

                    if (!allyFigure && opponentFigure > 0 && opponentFigure - opponentKnights > 0)
                        draw = false;

                    if (!draw)
                    {
                        Debug.WriteLine("Koniec czasu, czarne wygrywaja");
                    }
                    else
                    {
                        Debug.WriteLine("Koniec czasu, remis");
                    }
                }

                timer1_lbl.Text = player2_hour.ToString() + ":" + (player2_min <= 9 ? "0" : "") + player2_min.ToString() + ":" +
                    (player2_sec <= 9 ? "0" : "") + player2_sec.ToString() + ":" + player2_dec.ToString();


                playerTime--;
                player2_dec = playerTime % 10;
                player2_sec = ((playerTime - player2_dec) / 10) % 60;
                player2_min = ((playerTime - player2_sec - player2_dec) / 600) % 60;
                player2_hour = (playerTime - player2_min - player2_sec - player2_dec) / 36000;
            }


        }

        public void RotateBoard(object sender, EventArgs e)
        {
            if((autoRotate.Checked && matrix.whiteDownside!=whiteDownside)  || sender!=null)
            {
                Point[,] pbarrayCopy = new Point[9, 9];
                Point player1_lblLocation = player1_lbl.Location; 
                Point timer1_lblLocation = timer1_lbl.Location;

                player1_lbl.Location = player2_lbl.Location;
                timer1_lbl.Location = timer2_lbl.Location;
                player2_lbl.Location = player1_lblLocation;
                timer2_lbl.Location = timer1_lblLocation;

                for (int iCol = 1; iCol <= 8; iCol++)
                    for (int iRow = 1; iRow <= 8; iRow++)
                    {
                        Debug.WriteLine("c" + iCol + iRow);
                        pbarrayCopy[iCol, iRow] = (Point)Controls.Find("c" + iCol.ToString() + iRow.ToString(), false)[0].Location;
                    }

                for (int iCol = 1; iCol <= 8; iCol++)
                    for (int iRow = 1; iRow <= 8; iRow++)
                    {
                        PictureBox pb = (PictureBox)Controls.Find("c" + (iCol).ToString() + (iRow).ToString(), false)[0];
                        pb.Location = pbarrayCopy[9 - iCol, 9 - iRow];
                    }
                whiteDownside = !whiteDownside;
            }

        }

        private void OpenMenu(object sender, EventArgs e)
        {
            if (!firstMove)
            {
                DialogResult result = MessageBox.Show("Jesteś pewien, że chcesz wrócić do menu głównego?\nSpowoduje to utratę postepów gry.",
                                                      "Powrót do menu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(result == DialogResult.Yes)
                {
                    menu = new Szachy.Menu();
                    this.Hide();
                    menu.Closed += (s, args) => this.Close();
                    menu.Show();
                }
            }
            else
            {
                menu = new Szachy.Menu();
                this.Hide();
                menu.Closed += (s, args) => this.Close();
                menu.Show();
            }
        }

        private void autorotateClick(object sender, EventArgs e)
        {
            RotateBoard(null, null);
        }

        private void toggleTimer_Click(object sender, EventArgs e)
        {
            timerIsRunning = !timerIsRunning;
            toggleTimer.Text = (timerIsRunning ? "Zatrzymaj Zegar":"Wznów Zegar");
            timer1.Enabled = timerIsRunning;
        }
    }
}