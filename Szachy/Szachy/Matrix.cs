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
        public int[] currentSelection = { 1, 1 };
        public bool debug = false;

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
            figures[28].type = Figure.TypeEnum.Queen;
            figures[29].type = Figure.TypeEnum.King;
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
            board[fromColumn, fromRow].figure.firstMove = false;
            board[toColumn,toRow].figure = board[fromColumn,fromRow].figure;

            //WHITE castle king-side *short*
            if (board[fromColumn, fromRow].figure.type == Figure.TypeEnum.King &&
                fromColumn == 5 &&
                toColumn == 7 &&
                fromRow == 1)
                    MoveFigure(8, 1, 6, 1);
            
            //WHITE castle queen-side  *long*
            if (board[fromColumn, fromRow].figure.type == Figure.TypeEnum.King &&
                fromColumn == 5 &&
                toColumn == 3 &&
                fromRow == 1)
                    MoveFigure(1, 1, 4, 1);

            //BLACK castle king-side *short*
            if (board[fromColumn, fromRow].figure.type == Figure.TypeEnum.King &&
                fromColumn == 5 &&
                toColumn == 7 &&
                fromRow == 8)
                    MoveFigure(8, 8, 6, 8);

            //BLACK castle queen-side *long*
            if (board[fromColumn, fromRow].figure.type == Figure.TypeEnum.King &&
                fromColumn == 5 &&
                toColumn == 3 &&
                fromRow == 8)
                MoveFigure(1, 8, 4, 8);

            board[fromColumn,fromRow].figure = null;
        }

        public void BoardSetup()
        {
            for (int iCol = 1; iCol <= 9; iCol++)
                for (int iRow = 1; iRow <= 9; iRow++)
                    board[iCol, iRow].figure = null;

            foreach(Figure figure in figures)
            {
                figure.firstMove = true;
            }
            currentColor = Figure.ColorEnum.White;

            for (int i = 1; i <= 8; i++)
            {
                //Setting up pawns
                board[i, 2].figure = figures[i];
                board[i, 7].figure = figures[i + 16];

                //Setting up other figures
                board[i, 1].figure = figures[i + 8];
                board[i, 8].figure = figures[i + 24];
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
                if (board[selectedCol, selectedRow].figure != null &&
                    board[selectedCol, selectedRow].figure.color == currentColor)
                {
                    GetMoveAbility(selectedCol, selectedRow);
                    DrawMoveAbility();
                    currentSelection[0] = selectedCol;
                    currentSelection[1] = selectedRow;
                }
                else if (moveAbility[selectedCol, selectedRow] == "Yes" ||
                     moveAbility[selectedCol, selectedRow] == "Attack" ||
                     debug)
                {
                    MoveFigure(currentSelection[0], currentSelection[1], selectedCol, selectedRow);
                    DrawFigures();
                    ResetMoveAbility();
                    DrawMoveAbility();
                    if (currentColor == Figure.ColorEnum.White) currentColor = Figure.ColorEnum.Black;
                    else currentColor = Figure.ColorEnum.White;
                }
        }

        public void GetMoveAbility(int selectedCol, int selectedRow)
        {
            ResetMoveAbility();
            moveAbility[selectedCol, selectedRow] = "Current";

            switch(board[selectedCol,selectedRow].figure.type)
            {
                case Figure.TypeEnum.Rook:
                    RooksMoveAbility(selectedCol, selectedRow);
                    break;

                case Figure.TypeEnum.Knight:
                    KnightsMoveAbility(selectedCol, selectedRow);
                    break;

                case Figure.TypeEnum.Bishop:
                    BishopsMoveAbility(selectedCol, selectedRow);
                    break;

                case Figure.TypeEnum.Queen:
                    RooksMoveAbility(selectedCol, selectedRow);
                    BishopsMoveAbility(selectedCol, selectedRow);
                    break;

                case Figure.TypeEnum.Pawn:
                    PawnMoveAbility(selectedCol, selectedRow);
                    break;

                case Figure.TypeEnum.King:
                    KingsMoveAbility(selectedCol, selectedRow);
                    break;

            }
        }

        void RooksMoveAbility(int selectedCol, int selectedRow)
        {
            for (int i = 1; i <= 8; i++)
            {
                //DIRECTION RIGHT
                if(!CheckMoveAbility(selectedCol + i, selectedRow)) break;
            }

            for (int i = 1; i <= 8; i++)
            {
                //Debug.WriteLine("Left: " + i + ", " + CellExists(selectedCol - i, selectedRow));

                //DIRECTION LEFT
                if (!CheckMoveAbility(selectedCol - i, selectedRow)) break;
            }

            for (int i = 1; i <= 8; i++)
            {
                //DIRECTION UP

                if (!CheckMoveAbility(selectedCol, selectedRow+i)) break;
            }

            for (int i = 1; i <= 8; i++)
            {
                //DIRECTION DOWN
                if (!CheckMoveAbility(selectedCol, selectedRow - i)) break;
            }
        }

        void KnightsMoveAbility(int selectedCol, int selectedRow)
        {
            CheckMoveAbility(selectedCol + 2, selectedRow + 1);
            CheckMoveAbility(selectedCol + 1, selectedRow + 2);
            CheckMoveAbility(selectedCol + 2, selectedRow - 1);
            CheckMoveAbility(selectedCol + 1, selectedRow - 2);
            CheckMoveAbility(selectedCol - 2, selectedRow + 1);
            CheckMoveAbility(selectedCol - 1, selectedRow + 2);
            CheckMoveAbility(selectedCol - 2, selectedRow - 1);
            CheckMoveAbility(selectedCol - 1, selectedRow - 2);
        }

        void BishopsMoveAbility(int selectedCol, int selectedRow)
        {
            for (int i = 1; i <= 8; i++)
            {
                //direction upper right
                if (!CheckMoveAbility(selectedCol + i, selectedRow + i)) break;
            }

            for (int i = 1; i <= 8; i++)
            {
                //direction upper left
                if (!CheckMoveAbility(selectedCol - i, selectedRow + i)) break;
            }

            for (int i = 1; i <= 8; i++)
            {
                //direction lower right
                if (!CheckMoveAbility(selectedCol + i, selectedRow - i)) break;
            }

            for (int i = 1; i <= 8; i++)
            {
                //direction lower left
                if (!CheckMoveAbility(selectedCol - i, selectedRow - i)) break;
            }
        }

        void PawnMoveAbility(int selectedCol, int selectedRow)
        {
            if(currentColor==Figure.ColorEnum.White)
            {
                if (CellExists(selectedCol, selectedRow+1) && CellIsEmpty(selectedCol, selectedRow+1))
                    moveAbility[selectedCol, selectedRow+1] = "Yes";
                if (board[selectedCol, selectedRow].figure.firstMove && CellIsEmpty(selectedCol, selectedRow + 2) && CellIsEmpty(selectedCol, selectedRow + 1))
                    moveAbility[selectedCol, selectedRow+2] = "Yes";
                if(CellExists(selectedCol+1, selectedRow+1) && !CellIsEmpty(selectedCol + 1, selectedRow + 1) && board[selectedCol + 1, selectedRow + 1].figure.color!=currentColor)
                    moveAbility[selectedCol+1, selectedRow+1] = "Attack";
                if (CellExists(selectedCol-1, selectedRow+1) && !CellIsEmpty(selectedCol - 1, selectedRow + 1) && board[selectedCol - 1, selectedRow + 1].figure.color != currentColor)
                    moveAbility[selectedCol-1, selectedRow+1] = "Attack";
            }
            else
            {
                if (CellExists(selectedCol, selectedRow - 1) && CellIsEmpty(selectedCol, selectedRow - 1))
                    moveAbility[selectedCol, selectedRow - 1] = "Yes";
                if (board[selectedCol, selectedRow].figure.firstMove && CellIsEmpty(selectedCol, selectedRow - 2) && CellIsEmpty(selectedCol, selectedRow - 1))
                    moveAbility[selectedCol, selectedRow - 2] = "Yes";
                if (CellExists(selectedCol + 1, selectedRow - 1) && !CellIsEmpty(selectedCol + 1, selectedRow - 1) && board[selectedCol + 1, selectedRow - 1].figure.color != currentColor)
                    moveAbility[selectedCol + 1, selectedRow - 1] = "Attack";
                if (CellExists(selectedCol - 1, selectedRow - 1) && !CellIsEmpty(selectedCol - 1, selectedRow - 1) && board[selectedCol - 1, selectedRow - 1].figure.color != currentColor)
                    moveAbility[selectedCol - 1, selectedRow - 1] = "Attack";
            }
        }

        void KingsMoveAbility(int selectedCol, int selectedRow)
        {
            CheckMoveAbility(selectedCol + 1, selectedRow);
            CheckMoveAbility(selectedCol + 1, selectedRow + 1);
            CheckMoveAbility(selectedCol + 1, selectedRow - 1);
            CheckMoveAbility(selectedCol - 1, selectedRow);
            CheckMoveAbility(selectedCol - 1, selectedRow + 1);
            CheckMoveAbility(selectedCol - 1, selectedRow - 1);
            CheckMoveAbility(selectedCol, selectedRow + 1);
            CheckMoveAbility(selectedCol, selectedRow - 1);

            //WHITE castle king-side *short*
            if (board[selectedCol, selectedRow].figure.firstMove &&
               board[selectedCol, selectedRow].figure.color == Figure.ColorEnum.White && 
               figures[16].firstMove &&
               CellIsEmpty(6, 1) &&
               CellIsEmpty(7, 1))
                    moveAbility[7, 1] = "Yes";

            //WHITE castle queen-side *long*
            if (board[selectedCol, selectedRow].figure.firstMove &&
              board[selectedCol, selectedRow].figure.color == Figure.ColorEnum.White &&
              figures[9].firstMove &&
              CellIsEmpty(2, 1) &&
              CellIsEmpty(3, 1) &&
              CellIsEmpty(4, 1))
                    moveAbility[3, 1] = "Yes";

            //BLACK castle king-side *short*
            if (board[selectedCol, selectedRow].figure.firstMove &&
               board[selectedCol, selectedRow].figure.color == Figure.ColorEnum.Black &&
               figures[32].firstMove &&
               CellIsEmpty(6, 8) &&
               CellIsEmpty(7, 8))
                    moveAbility[7, 8] = "Yes";

            //BLACK castle queen-side *long*
            if (board[selectedCol, selectedRow].figure.firstMove &&
              board[selectedCol, selectedRow].figure.color == Figure.ColorEnum.Black &&
              figures[25].firstMove &&
              CellIsEmpty(2, 8) &&
              CellIsEmpty(3, 8) &&
              CellIsEmpty(4, 8))
                moveAbility[3, 8] = "Yes";

        }

        bool CheckMoveAbility(int col, int row)
        {
            if (CellExists(col, row))
            {
                if (CellIsEmpty(col, row))
                {
                    //Cell empty
                    moveAbility[col, row] = "Yes";
                }
                else
                {
                    //Check if friend or foe
                    if (board[col, row].figure.color == currentColor)
                        moveAbility[col, row] = "No";
                    else
                        moveAbility[col, row] = "Attack";

                    return false;
                }
            }
            return true;

        }

        public void ResetMoveAbility()
        {
            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                    moveAbility[iCol, iRow] = "No";
        }
    }    
}