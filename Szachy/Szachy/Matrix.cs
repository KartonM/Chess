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
        public Cell[,] board;
        public string[,] moveAbility; 
        public Figure[] figures;
        public Form form;
        public bool cellSelected = false;

        Figure.ColorEnum currentColor;

        public Matrix()
        {
            currentColor = Figure.ColorEnum.White;

    //BOARD
    //Creating an empty board

            board = new Cell[10,10];

            for (int iCol = 1; iCol <= 9; iCol++)
                for (int iRow = 1; iRow <= 9; iRow++)
                    board[iCol,iRow] = new Cell();

            //MOVE ABILITY

            moveAbility = new string[9, 9];

            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                {
                    moveAbility[iCol, iRow] = "No";
                }

            //FIGURES
            figures = new Figure[33];

            //WHITE

            //Creating a set of figures
            for (int i=0; i<=16; i++)
            {
                figures[i] = new Figure();
                figures[i].color = Figure.ColorEnum.White;
            }

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
            if (row >= 1 && column >= 1 && row <= 8 && column <= 8)
                return true;
            else
                return false;
        }

        public bool CellIsEmpty(int column, int row)
        {
            Debug.WriteLine("col: " + column + "  row: " + row);
            if (board[column, row].figure == null)
                return true;
            else
                return false;
        }

        public void MoveFigure(int fromColumn, int fromRow, int toColumn, int toRow)
        {
            board[toColumn,toRow].figure = board[fromColumn,fromRow].figure;
            board[fromColumn,fromRow].figure = null;
        }

        public void BoardSetup()
        {
            for (int i = 1; i <= 8; i++)
            {
                //Setting up pawns
                board[i,2].figure = figures[i];
                board[i,7].figure = figures[i + 16];

                //Setting up other figures
                board[i,1].figure = figures[i + 8];
                board[i,8].figure = figures[i + 24];
            }
        }

        public void DrawFigures()
        {
            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                {
                    PictureBox pb = (PictureBox)form.Controls.Find("c" + iCol.ToString() + iRow.ToString(), false)[0];
                    pb.SizeMode = PictureBoxSizeMode.StretchImage; //DO USUNIĘCIA

                    if (board[iCol,iRow].figure!=null)
                    {
                        switch (board[iCol,iRow].figure.type)
                        {
                            case Figure.TypeEnum.Pawn:

                                if (board[iCol,iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhitePawn;
                                else
                                    pb.Image = Resources.BlackPawn;
                                break;

                            case Figure.TypeEnum.Rook:
                                if (board[iCol,iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteRook;
                                else
                                    pb.Image = Resources.BlackRook;
                                break;
                            case Figure.TypeEnum.Knight:
                                if (board[iCol,iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteKnight;
                                else
                                    pb.Image = Resources.BlackKnight;
                                break;

                            case Figure.TypeEnum.Bishop:
                                if (board[iCol,iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteBishop;
                                else
                                    pb.Image = Resources.BlackBishop;
                                break;

                            case Figure.TypeEnum.King:
                                if (board[iCol,iRow].figure.color == Figure.ColorEnum.White)
                                    pb.Image = Resources.WhiteKing;
                                else
                                    pb.Image = Resources.BlackKing;
                                break;

                            case Figure.TypeEnum.Queen:
                                if (board[iCol,iRow].figure.color == Figure.ColorEnum.White)
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

        public void DrawMoveAbility()
        {
            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                {
                    PictureBox pb = (PictureBox)form.Controls.Find("c" + iCol.ToString() + iRow.ToString(), false)[0];
                    pb.BackgroundImageLayout = ImageLayout.Stretch; //DO USUNIĘCIA

                    switch (moveAbility[iCol, iRow])
                    {
                        case "No":
                            pb.BackgroundImage = null;
                            break;
                        case "Yes":
                            pb.BackgroundImage = Resources.CellAvailable;
                            break;
                        case "Current":
                            pb.BackgroundImage = Resources.CellCurrent;
                            break;
                        case "Attack":
                            pb.BackgroundImage = Resources.CellEnemy;
                            break;
                    }
                }
        }

        public void SelectCell(int selectedCol, int selectedRow)
        {
            if(cellSelected)
            {

            }
            else
            {
                    GetMoveAbility(selectedCol, selectedRow);
                    DrawMoveAbility();
            }
        }

        public void GetMoveAbility(int selectedCol, int selectedRow)
        {
            ResetMoveAbility();
            moveAbility[selectedCol, selectedRow] = "Current";

            switch(board[selectedCol,selectedRow].figure.type)
            {
                case Figure.TypeEnum.Rook:
                    for(int i=1; i<=8; i++)
                    {
                        //DIRECTION RIGHT
                        if(CellExists(selectedCol + i, selectedRow))
                        {
                            if (CellIsEmpty(selectedCol + i, selectedRow))
                                //Cell empty
                                moveAbility[selectedCol + i, selectedRow] = "Yes";
                            else
                            {
                                //Check if friend or foe
                                if(board[selectedCol + i, selectedRow].figure.color == Figure.ColorEnum.White)
                                    moveAbility[selectedCol + i, selectedRow] = "No";
                                else
                                    moveAbility[selectedCol + i, selectedRow] = "Attack";
                                break;
                            }
                        }
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        Debug.WriteLine("Left: " + i + ", " + CellExists(selectedCol - i, selectedRow));

                        //DIRECTION LEFT
                        if (CellExists(selectedCol - i, selectedRow))
                        {
                            if (CellIsEmpty(selectedCol - i, selectedRow))
                                //Cell empty
                                moveAbility[selectedCol - i, selectedRow] = "Yes";
                            else
                            {
                                //Check if friend or foe
                                if (board[selectedCol - i, selectedRow].figure.color == Figure.ColorEnum.White)
                                    moveAbility[selectedCol - i, selectedRow] = "No";
                                else
                                    moveAbility[selectedCol - i, selectedRow] = "Attack";
                                break;
                            }
                        }
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        //DIRECTION UP
                        if (CellExists(selectedCol, selectedRow + i))
                        {
                            Debug.WriteLine("Up: " + (selectedRow + i) + ", " + CellExists(selectedCol, selectedRow + i));
                            if (CellIsEmpty(selectedCol, selectedRow + i))
                                //Cell empty
                                moveAbility[selectedCol, selectedRow + i] = "Yes";
                            else
                            {
                                //Check if friend or foe
                                if (board[selectedCol, selectedRow + i].figure.color == Figure.ColorEnum.White)
                                    moveAbility[selectedCol, selectedRow + i] = "No";
                                else
                                    moveAbility[selectedCol, selectedRow + i] = "Attack";
                                break;
                            }
                        }
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        //DIRECTION UP
                        if (CellExists(selectedCol, selectedRow - i))
                        {
                            if (CellIsEmpty(selectedCol, selectedRow - i))
                                //Cell empty
                                moveAbility[selectedCol, selectedRow - i] = "Yes";
                                else
                            {
                                //Check if friend or foe
                                if (board[selectedCol, selectedRow - i].figure.color == Figure.ColorEnum.White)
                                    moveAbility[selectedCol, selectedRow - i] = "No";
                                else
                                    moveAbility[selectedCol, selectedRow - i] = "Attack";
                                break;
                            }
                        }
                    }


                    break; 
            }
        }

        void ResetMoveAbility()
        {
            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                    moveAbility[iCol, iRow] = "No";
        }
    }    
}
