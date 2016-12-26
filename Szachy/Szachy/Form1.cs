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
        public int timeLeft;
        public int turnTime;
        System.Windows.Forms.Timer turnTimer;

        public Form1()
        {
            InitializeComponent();
            turnTimer = new System.Windows.Forms.Timer();
            turnTimer.Interval = 1000;
            turnTimer.Tick += new EventHandler(TimerTick);
            turnTimer.Start();

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

        public void ResetTime()
        {
            timeLeft = turnTime;
        }

        void TimerTick(Object myObject, EventArgs myEventArgs)
        {
            if(timeLeft<0)
            {

            }
            GUI_Time.Text = "Pozostały Czas:" + Environment.NewLine + timeLeft;
            timeLeft--;

        }

        public void Win(Figure.ColorEnum color)
        {
            if(color==Figure.ColorEnum.White)
            {

            }
        }
    }
}