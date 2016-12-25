using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szachy.Properties;

namespace Szachy
{
    public partial class FigureSelect : Form
    {
        public Matrix matrix;
        public int col;
        public int row;

        public FigureSelect()
        {
            InitializeComponent();
        }

        public void DrawFigures(Figure.ColorEnum color)
        {
            if (color == Figure.ColorEnum.Black)
            {
                selectRook.BackgroundImage = Resources.BlackRook;
                selectKnight.BackgroundImage = Resources.BlackKnight;
                selectBishop.BackgroundImage = Resources.BlackBishop;
                selectQueen.BackgroundImage = Resources.BlackQueen;
            }
        }

        private void selectRook_Click(object sender, EventArgs e)
        {
            matrix.board[col, row].figure.type = Figure.TypeEnum.Rook;
            this.Close();
        }

        private void selectKnight_Click(object sender, EventArgs e)
        {
            matrix.board[col, row].figure.type = Figure.TypeEnum.Knight;
            this.Close();
        }

        private void selectBishop_Click(object sender, EventArgs e)
        {
            matrix.board[col, row].figure.type = Figure.TypeEnum.Bishop;
            this.Close();
        }

        private void selectQueen_Click(object sender, EventArgs e)
        {
            matrix.board[col, row].figure.type = Figure.TypeEnum.Queen;
            this.Close();
        }


        //BLOKOWANIE ZAMKNIĘCIA OKIENKA
        protected override CreateParams CreateParams
        {
            get
            {
                const int CP_NOCLOSE = 0x200;
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE;
                return myCp;
            }
        }
    }
}
