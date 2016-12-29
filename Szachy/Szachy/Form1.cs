using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        public double player1_points;
        public double player2_points;

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
        public int whitePlayer;
        public bool endOfGame = false;

        public Label p1_lbl;
        public Label p2_lbl;

        public int fileCounter = 0;
        public string[] saveText;
        public string fileData;

        public Form1()
        {
            saveText = new string[1];

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
            matrix.figures[29].firstMove = false;

            /*matrix.board[4, 4].figure = matrix.figures[17];
            matrix.board[8, 4].figure = matrix.figures[10];
            matrix.board[4, 2].figure = matrix.figures[15];
            matrix.board[2, 2].figure = matrix.figures[29];
            matrix.board[8, 2].figure = matrix.figures[11];
            matrix.figures[13].firstMove = false;
            matrix.figures[17].firstMove = false;
            matrix.figures[15].firstMove = false;
            matrix.figures[29].firstMove = false;
            matrix.figures[11].firstMove = false;

            ResetTime();
            firstMove = true;
            TimerStart();*/

            matrix.DrawFigures();

            boardEncode(null, null);
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
            if(endOfGame)
            {
                rotate_labels();
                if (whitePlayer == 1) whitePlayer = 2;
                else whitePlayer = 1;
                endOfGame = false;
            }

            if (timer1_lbl.Visible)
            {
                Point timer1_lblLocation = timer1_lbl.Location;
                timer1_lbl.Location = timer2_lbl.Location;
                timer2_lbl.Location = timer1_lblLocation;
            }

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

                timer2_lbl.Text = player1_hour.ToString() + ":" + (player1_min <= 9 ? "0" : "") + player1_min.ToString() + ":" +
                    (player1_sec <= 9 ? "0" : "") + player1_sec.ToString() + ":" + player1_dec.ToString();

                firstMove = false;
                if (playerTime == 0 && timer1_lbl.Visible)
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
                                Debug.WriteLine("Znalazłem " + matrix.board[iCol, iRow].figure.type);
                                opponentFigure++;
                                if (matrix.board[iCol, iRow].figure.type == Figure.TypeEnum.Knight)
                                    opponentKnights++;
                            }

                        }
                    Debug.WriteLine(opponentKnights);
                    Debug.WriteLine(opponentFigure);
                    Debug.WriteLine(allyFigure);
                    if (allyFigure && opponentFigure > 0)
                        draw = false;

                    if (!allyFigure && opponentFigure > 1 && opponentFigure - opponentKnights > 0)
                        draw = false;

                    if (!draw)
                    {
                        if (whitePlayer == 1) player1Win();
                        else player2Win();
                        Debug.WriteLine("Koniec czasu, biale wygrywaja");
                        MessageBox.Show("Koniec czasu\nBiale wygrywaja", "Koniec czasu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.draw();
                        Debug.WriteLine("Koniec czasu, remis");
                    }
                }

                playerTime--;
                player1_dec = playerTime % 10;
                player1_sec = ((playerTime - player1_dec) / 10) % 60;
                player1_min = ((playerTime - player1_sec - player1_dec) / 600) % 60;
                player1_hour = (playerTime - player1_min - player1_sec - player1_dec) / 36000;
            }

            if (!firstMove && matrix.currentColor == Figure.ColorEnum.White)
            {
                int playerTime = player2_hour * 36000 + player2_min * 600 + player2_sec * 10 + player2_dec;

                timer1_lbl.Text = player2_hour.ToString() + ":" + (player2_min <= 9 ? "0" : "") + player2_min.ToString() + ":" +
                    (player2_sec <= 9 ? "0" : "") + player2_sec.ToString() + ":" + player2_dec.ToString();

                if (playerTime == 0 && timer1_lbl.Visible)
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

                    if (!allyFigure && opponentFigure > 1 && opponentFigure - opponentKnights > 0)
                        draw = false;

                    if (!draw)
                    {
                        if (whitePlayer == 1) player2Win();
                        else player1Win();
                        Debug.WriteLine("Koniec czasu, czarne wygrywaja");
                        MessageBox.Show("Koniec czasu\nCzarne wygrywaja", "Koniec czasu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.draw();
                        Debug.WriteLine("Koniec czasu, remis");
                    }
                }

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
                Point points1_lblLocation = points1_lbl.Location;

                player1_lbl.Location = player2_lbl.Location;
                timer1_lbl.Location = timer2_lbl.Location;
                player2_lbl.Location = player1_lblLocation;
                timer2_lbl.Location = timer1_lblLocation;
                points1_lbl.Location = points2_lbl.Location;
                points2_lbl.Location = points1_lblLocation;

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

        public void player1Win()
        {
            player1_points++;
            points1_lbl.Text = "Punkty: " + player1_points.ToString();
            endOfGame = true;
        }

        public void player2Win()
        {
            player2_points++;
            points2_lbl.Text = "Punkty: " + player2_points.ToString();
            endOfGame = true;

        }

        public void draw()
        {
            player1_points += 0.5;
            player2_points += 0.5;
            points1_lbl.Text = "Punkty: " + player1_points.ToString();
            points2_lbl.Text = "Punkty: " + player2_points.ToString();
            endOfGame = true;
        }

        public void rotate_labels()
        {
            Point player1_lblLocation = player1_lbl.Location;
            Point timer1_lblLocation = timer1_lbl.Location;
            Point points1_lblLocation = points1_lbl.Location;
            player1_lbl.Location = player2_lbl.Location;
            timer1_lbl.Location = timer2_lbl.Location;
            player2_lbl.Location = player1_lblLocation;
            timer2_lbl.Location = timer1_lblLocation;
            points1_lbl.Location = points2_lbl.Location;
            points2_lbl.Location = points1_lblLocation;

        }

        public void boardEncode(object sender, EventArgs e)
        {
            ///
            ///         STRUKTURA ZAPISU:
            ///         3 LICZBY DLA KAŻEGO CELLA
            ///         
            ///         JEŻELI POLE PUSTE 000
            ///         
            ///         JEŻELI POLE NIEPUSTE
            ///         1 JEZELI FIRSTMOVE = TRUE / 0 JEŻELI = FALSE
            ///         DWIE CYFRY BĘDĄCE NR BIERKI W FIGURES
            ///
            fileCounter++;
            Array.Resize<string>(ref saveText, fileCounter);
            saveText[fileCounter - 1] = "";
            Debug.WriteLine("Encode: " + fileCounter);

                for (int iCol = 1; iCol <= 9; iCol++)
                    for (int iRow = 1; iRow <= 9; iRow++)
                    {
                        if (matrix.board[iCol, iRow].figure == null)
                        {
                        saveText[fileCounter-1] += "000";
                        }
                        else
                        {
                            int indexWr = Array.IndexOf(matrix.figures, matrix.board[iCol, iRow].figure);
                        saveText[fileCounter-1] += (matrix.board[iCol, iRow].figure.firstMove ? "1" : "0") +
                                (indexWr < 10 ? "0" : "") + indexWr.ToString();
                        }
                    }
            //}
        }

        public void boardDecode(object sender, EventArgs e)
        {
            if (fileCounter>1)
            {
                fileCounter--;
                Debug.WriteLine("Decode: " + fileCounter);

                string line = saveText[fileCounter-1];

                if (fileCounter % 2 == 1)
                matrix.currentColor = Figure.ColorEnum.White;
                else
                matrix.currentColor = Figure.ColorEnum.Black;

                for (int iCol = 1; iCol <= 9; iCol++)
                    for (int iRow = 1; iRow <= 9; iRow++)
                    {
                        int index = (iCol - 1) * 9 + iRow - 1;
                        string ss = line.Substring(index * 3, 3);
                        if (ss == "000")
                        {
                            matrix.board[iCol, iRow].figure = null;
                        }
                        else
                        {
                            matrix.board[iCol, iRow].figure = matrix.figures[int.Parse(ss.Substring(1, 2))];
                            if (ss.Substring(0, 1) == "1")
                                matrix.board[iCol, iRow].figure.firstMove = true;
                            else
                                matrix.board[iCol, iRow].figure.firstMove = false;
                        }
                    }
            }
            matrix.DrawFigures();
        }

        private void SaveGame(object sender, EventArgs e)
        {
            SaveFileDialog fdlg = new SaveFileDialog();
            fdlg.Title = "Zapis Gry";
            fdlg.DefaultExt = ".majc";
            fdlg.FileName = "save";
            fdlg.Filter = "Maric And Jan Chess (*.majc)|*.majc";
            if(fdlg.ShowDialog() == DialogResult.OK)
            {
                string[] fileText = saveText;
                Array.Resize<string>(ref fileText, fileText.Length + 1);
                fileText[fileText.Length-1] =
                    //PLAYER 1 NAME
                    player1_lbl.Text+
                    //PLAYER 1 TIME
                    player1_hour.ToString().PadLeft(2, '0')+
                    player1_min.ToString().PadLeft(2, '0')+
                    player1_sec.ToString().PadLeft(2, '0')+
                    player1_dec.ToString()+
                    //PLAYER 2 NAME
                    player2_lbl.Text +
                    //PLAYER 2 TIME
                    player2_hour.ToString().PadLeft(2, '0') +
                    player2_min.ToString().PadLeft(2, '0') +
                    player2_sec.ToString().PadLeft(2, '0') +
                    player2_dec.ToString() +                    
                    //GRA NA CZAS
                    Convert.ToInt16(timer1_lbl.Enabled)+
                    //ZATRZYMYWANIE CZSU DOZWOLONE
                    Convert.ToInt16(toggleTimer.Enabled);
                string saveDirectory = fdlg.FileName;
                Debug.WriteLine(saveDirectory);
                File.Create(saveDirectory).Close();
                File.AppendAllLines(saveDirectory, fileText);
            }
        }
    }
}