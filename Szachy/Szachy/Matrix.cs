using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szachy.Properties;

namespace Szachy
{
    public class Matrix
    {
        public Cell[][] board;
        public Figure[] figures;
        public Form form;

        public Matrix()
        {
            figures = new Figure[40];

            //Creating an empty board

            board = new Cell[9][];
            for (int i = 0; i <= 8; i++)
                board[i] = new Cell[9];

            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                {
                    board[iCol][iRow] = new Cell();
                }

                    //WHITE

                    //Creating a set of figures
                    for (int i=0; i<=16; i++)
            {
                figures[i] = new Figure();
                figures[i].color = Figure.ColorEnum.White;
            }


            figures[0].type = Figure.TypeEnum.Null;

            //Setting figure types
            figures[1].type = Figure.TypeEnum.Pawn;
            figures[2].type = Figure.TypeEnum.Pawn;
            figures[3].type = Figure.TypeEnum.Pawn;
            figures[4].type = Figure.TypeEnum.Pawn;
            figures[5].type = Figure.TypeEnum.Pawn;
            figures[6].type = Figure.TypeEnum.Pawn;
            figures[7].type = Figure.TypeEnum.Pawn;
            figures[8].type = Figure.TypeEnum.Pawn;
            figures[9].type = Figure.TypeEnum.Rook;
            figures[10].type = Figure.TypeEnum.Knight;
            figures[11].type = Figure.TypeEnum.Bishop;
            figures[12].type = Figure.TypeEnum.Queen;
            figures[13].type = Figure.TypeEnum.King;
            figures[14].type = Figure.TypeEnum.Bishop;
            figures[15].type = Figure.TypeEnum.Knight;
            figures[16].type = Figure.TypeEnum.Rook;

        //BLACK

            //Creating a set of figures
            for (int i = 17; i <= 32; i++)
            {
                figures[i] = new Figure();
                figures[i].color = Figure.ColorEnum.Black;
            }

            //Setting figure types
            figures[17].type = Figure.TypeEnum.Pawn;
            figures[18].type = Figure.TypeEnum.Pawn;
            figures[19].type = Figure.TypeEnum.Pawn;
            figures[20].type = Figure.TypeEnum.Pawn;
            figures[21].type = Figure.TypeEnum.Pawn;
            figures[22].type = Figure.TypeEnum.Pawn;
            figures[23].type = Figure.TypeEnum.Pawn;
            figures[24].type = Figure.TypeEnum.Pawn;
            figures[25].type = Figure.TypeEnum.Rook;
            figures[26].type = Figure.TypeEnum.Knight;
            figures[27].type = Figure.TypeEnum.Bishop;
            figures[28].type = Figure.TypeEnum.King;
            figures[29].type = Figure.TypeEnum.Queen;
            figures[30].type = Figure.TypeEnum.Bishop;
            figures[31].type = Figure.TypeEnum.Knight;
            figures[32].type = Figure.TypeEnum.Rook;

        }

        //Check if cell exists
        public bool CellExists(int column, int row)
        {
            if (row >= 1 && column >= 1 && row <= 10 && column <= 10)
                return true;
            else
                return false;
        }

        public bool CellIsEmpty(int column, int row)
        {
            return (board[column][row].figure == null);
        }

        public void MoveFigure(int fromColumn, int fromRow, int toColumn, int toRow)
        {
            board[toColumn][toRow].figure = board[fromColumn][fromRow].figure;
            board[fromColumn][fromRow].figure = null;
        }

        public void BoardSetup()
        {
            for (int i = 1; i <= 8; i++)
            {
                //Setting up pawns
                board[i][2].figure = figures[i];
                board[i][7].figure = figures[i + 16];

                //Setting up other figures
                board[i][1].figure = figures[i + 8];
                board[i][8].figure = figures[i + 24];
            }
        }

        public void DrawFigures()
        {
            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                {
                    PictureBox pb = (PictureBox)form.Controls.Find("C" + iCol.ToString() + iRow.ToString(), false)[0];
                    pb.SizeMode = PictureBoxSizeMode.StretchImage; //DO USUNIĘCIA

                    if (board[iCol][iRow].figure!=null)
                    {
                        switch (board[iCol][iRow].figure.type)
                        {
                            case Figure.TypeEnum.Pawn:

                                if (board[iCol][iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhitePawn;
                                else
                                    pb.Image = Resources.BlackPawn;
                                break;

                            case Figure.TypeEnum.Rook:
                                if (board[iCol][iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteRook;
                                else
                                    pb.Image = Resources.BlackRook;
                                break;
                            case Figure.TypeEnum.Knight:
                                if (board[iCol][iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteKnight;
                                else
                                    pb.Image = Resources.BlackKnight;
                                break;

                            case Figure.TypeEnum.Bishop:
                                if (board[iCol][iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteBishop;
                                else
                                    pb.Image = Resources.BlackBishop;
                                break;

                            case Figure.TypeEnum.King:
                                if (board[iCol][iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteKing;
                                else
                                    pb.Image = Resources.BlackKing;
                                break;

                            case Figure.TypeEnum.Queen:
                                if (board[iCol][iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteQueen;
                                else
                                    pb.Image = Resources.BlackQueen;
                                break;

                        }
                    }
                    else
                    {
                        pb.Image = null;
                    }

            }
        }
    }    
}
