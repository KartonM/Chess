using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szachy.Properties;

namespace Szachy
{
    [Serializable]
    public class Matrix
    {
        public Cell[,] board;
        public Cell[,] boardCopy;

        public Menu menu;
        public string[,] moveAbility; 
        public Figure[] figures;
        public Form1 form;
        public TextBox GUI_Count;
        public TextBox GUI_Color;
        int moveCount = 0;
        public bool cellSelected = false;
        public int[] currentSelection = { 1, 1 };
        public int[] BlackKingPosition = { 5, 8 };
        public int[] WhiteKingPosition = { 5, 1 };
        //public int[] WhiteKingPosition = { 8, 3 }; //do testowania
        //public int[] BlackKingPosition = { 1, 7 };
        public bool debug = false;
        public bool checkingMate = false;
        public int[] checkingMateFrom = { 1, 1 };
        public bool whiteDownside;

        public Figure.ColorEnum currentColor;

        public Matrix()
        {
            whiteDownside = true;     
    //BOARD
    //Creating an empty board

            board = new Cell[10,10];
            boardCopy = new Cell[10, 10];

            for (int iCol = 1; iCol <= 9; iCol++)
                for (int iRow = 1; iRow <= 9; iRow++)
                {
                    board[iCol, iRow] = new Cell();
                    boardCopy[iCol, iRow] = new Cell();
                }

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


        protected Matrix(SerializationInfo info, StreamingContext context)
        {
            board = (Cell[,])info.GetValue("Board", typeof(Cell[,]));
        }

        //Check if cell exists
        public bool CellExists(int column, int row) //Checks if cell (column, row) exists
        {
            if (row >= 1 && column >= 1 && row <= 8 && column <= 8)
                return true;
            else
                return false;
        }

        public bool CellIsEmpty(int column, int row) //Checks if there is no figure on cell (column, row) 
        {
            //Debug.WriteLine("col: " + column + "  row: " + row);
            if (board[column, row].figure == null)
                return true;
            else
                return false;
        }

        public void MoveFigure(int fromColumn, int fromRow, int toColumn, int toRow) //Moves figure from cell (fromColumn, fromRow) to cell (toColumn, toRow)
        {        
            if (fromColumn == WhiteKingPosition[0] && fromRow == WhiteKingPosition[1])
            {
                WhiteKingPosition[0] = toColumn;
                WhiteKingPosition[1] = toRow;
            }

            if (fromColumn == BlackKingPosition[0] && fromRow == BlackKingPosition[1])
            {
                BlackKingPosition[0] = toColumn;
                BlackKingPosition[1] = toRow;
            }

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

            if ((board[toColumn, toRow].figure.type == Figure.TypeEnum.Pawn && toRow == 8 && board[toColumn, toRow].figure.color == Figure.ColorEnum.White) ||
            (board[toColumn, toRow].figure.type == Figure.TypeEnum.Pawn && toRow == 1 && board[toColumn, toRow].figure.color == Figure.ColorEnum.Black))
            {
                DrawFigures();
                FigureSelect figureSelectForm = new FigureSelect();
                figureSelectForm.matrix = this;
                figureSelectForm.col = toColumn;
                figureSelectForm.row = toRow;
                figureSelectForm.DrawFigures(currentColor);
                figureSelectForm.ShowDialog(form);

            }
            Debug.WriteLine(WhiteKingPosition[0] + " " + WhiteKingPosition[1] + "   " + BlackKingPosition[0] + " " + BlackKingPosition[1]);
        }

        public void BoardSetup() //Sets the board up
        {
            form.ResetTime();
            form.firstMove = true;
            form.TimerStart();

            BlackKingPosition[0] = 5;
            BlackKingPosition[1] = 8;
            WhiteKingPosition[0] = 5;
            WhiteKingPosition[1] = 1;

            moveCount = 0;
            GUI_Count.Text = "Liczba ruchów:" + Environment.NewLine + moveCount;

            for (int iCol = 1; iCol <= 9; iCol++)
                for (int iRow = 1; iRow <= 9; iRow++)
                {
                    board[iCol, iRow].figure = null;
                    boardCopy[iCol, iRow].figure = null;
                }

            foreach (Figure figure in figures)
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

        public void DrawFigures() //Displays figures
        {
            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                {
                    PictureBox pb = (PictureBox)form.Controls.Find("c" + iCol.ToString() + iRow.ToString(), false)[0];
                    pb.SizeMode = PictureBoxSizeMode.StretchImage; //DO USUNIĘCIA
                    //Debug.WriteLine("Drawing figures");

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

        public void DrawMoveAbility() //Displays move abilities based on moveAbility[,] array
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

        public void SelectCell(int selectedCol, int selectedRow) //Called after clicking on a pictureBox of (selectedCol, selectedRow) cell
        {
                if (board[selectedCol, selectedRow].figure != null &&
                    board[selectedCol, selectedRow].figure.color == currentColor) //checks move ability
                {                                                                 //if there is an alllied figure on a clicked cell
                currentSelection[0] = selectedCol;
                currentSelection[1] = selectedRow;
                GetMoveAbility(selectedCol, selectedRow);
                DrawMoveAbility();
                }
                else if (moveAbility[selectedCol, selectedRow] == "Yes" ||
                     moveAbility[selectedCol, selectedRow] == "Attack")           //check if move on a clicked cell is avalible
                {                                                                 //and move the figure
                    MoveFigure(currentSelection[0], currentSelection[1], selectedCol, selectedRow);
                    DrawFigures();
                    ResetMoveAbility();

                bool stalemate = true;

                if (currentColor == Figure.ColorEnum.White)
                {
                    currentColor = Figure.ColorEnum.Black;
                    GUI_Color.Text = "Ruch:" + Environment.NewLine + "Czarnych";

                    whiteDownside = false;
                    form.RotateBoard(null, null);

                    checkingMate = true;

                    for (int iCol = 1; iCol <= 8; iCol++) //checking if there are any possible moves
                    {
                        for (int iRow = 1; iRow <= 8; iRow++)
                        {
                            if (!CellIsEmpty(iCol, iRow)// && board[iCol, iRow].figure != null
                               && board[iCol, iRow].figure.color == Figure.ColorEnum.Black)
                            {
                                checkingMateFrom[0] = iCol;
                                checkingMateFrom[1] = iRow;

                                Debug.WriteLine("Czarnego " + board[iCol, iRow].figure.type + " na polu " + iCol + " " + iRow);
                                GetMoveAbility(iCol, iRow);
                                moveAbility[WhiteKingPosition[0], WhiteKingPosition[1]] = "No";

                                for (int jCol = 1; jCol <= 8; jCol++)
                                {
                                    for (int jRow = 1; jRow <= 8; jRow++)
                                    {
                                        if (moveAbility[jCol, jRow] == "Yes" || moveAbility[jCol, jRow] == "Attack")
                                        {
                                            Debug.WriteLine("Czarny " + board[iCol, iRow].figure.type + " moze sie ruszyc na " + jCol + " " + jRow + " " + moveAbility[jCol, jRow]);
                                            stalemate = false;
                                            break;
                                        }
                                    }
                                    if (!stalemate) break;
                                }
                            }
                            if (!stalemate) break;
                        }
                        if (!stalemate) break;
                    }
                    if (stalemate) Debug.WriteLine("Pat lub mat");
                    checkingMate = false;

                    ResetMoveAbility();
                    DrawMoveAbility();
                }
                else
                {
                    currentColor = Figure.ColorEnum.White;
                    GUI_Color.Text = "Ruch:" + Environment.NewLine + "Białych";

                    whiteDownside = true;
                    form.RotateBoard(null, null);

                    checkingMate = true;

                    for (int iCol = 1; iCol <= 8; iCol++) //checking if there are any possible moves
                    {
                        for (int iRow = 1; iRow <= 8; iRow++)
                        {
                            if (!CellIsEmpty(iCol, iRow) && board[iCol, iRow].figure != null &&
                               board[iCol, iRow].figure.color == Figure.ColorEnum.White)
                            {
                                checkingMateFrom[0] = iCol;
                                checkingMateFrom[1] = iRow;

                                Debug.WriteLine("Sprawdzam bialego " + board[iCol, iRow].figure.type + " na polu " + iCol + " " + iRow);
                                GetMoveAbility(iCol, iRow);
                                moveAbility[WhiteKingPosition[0], WhiteKingPosition[1]] = "No";

                                for (int jCol = 1; jCol <= 8; jCol++)
                                {
                                    for (int jRow = 1; jRow <= 8; jRow++)
                                    {
                                        if (moveAbility[jCol, jRow] == "Yes" || moveAbility[jCol, jRow] == "Attack")
                                        {
                                            Debug.WriteLine("Bialy " + board[iCol, iRow].figure.type + " moze sie ruszyc na " + jCol + " " + jRow + " " + moveAbility[jCol, jRow]);
                                            stalemate = false;
                                            break;
                                        }
                                    }
                                    if (!stalemate) break;
                                }
                            }
                            if (!stalemate) break;
                        }
                        if (!stalemate) break;
                    }
                    if (stalemate) Debug.WriteLine("Pat lub mat");
                    checkingMate = false;

                    ResetMoveAbility();
                    DrawMoveAbility();
                }

                if(currentColor == Figure.ColorEnum.Black) moveCount++;
                GUI_Count.Text = "Liczba Ruchów:" + Environment.NewLine + moveCount;

                

                if (CellIsAttacked(WhiteKingPosition[0], WhiteKingPosition[1], Figure.ColorEnum.White)) //checks if the white king is checked
                {
                    PictureBox pb = (PictureBox)form.Controls.Find("c" + WhiteKingPosition[0].ToString() + WhiteKingPosition[1].ToString(), false)[0];
                    pb.BackgroundImage = Resources.CellEnemy; //marking checked king
                    Debug.WriteLine("White Check!!!");


                    if (stalemate) //checking if it's a check mate
                    {
                        form.TimerStop();
                        if (form.whitePlayer == 1)
                        {
                            Debug.WriteLine("Gracz 2 zwyciezyl czarnymi");
                            form.player2Win();
                        }
                        else
                        {
                            Debug.WriteLine("Gracz 1 zwyciezyl czarnymi");
                            form.player1Win();
                        }
                        Debug.WriteLine("Szach mat, czarne wygrywaja");
                        MessageBox.Show("Szach i mat\nCzarne wygrywaja w " + moveCount + " ruchach", "Szach mat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stalemate = false;
                    }
                }

                if (CellIsAttacked(BlackKingPosition[0], BlackKingPosition[1], Figure.ColorEnum.Black)) //checks if the black king is checked
                {
                    PictureBox pb = (PictureBox)form.Controls.Find("c" + BlackKingPosition[0].ToString() + BlackKingPosition[1].ToString(), false)[0];
                    pb.BackgroundImage = Resources.CellEnemy; //marking checked king
                    Debug.WriteLine("Black Check!!!");

                    if (stalemate)  //checking if it's a check mate
                    {
                        form.TimerStop();
                        if (form.whitePlayer == 1)
                        {
                            Debug.WriteLine("Gracz 1 zwyciezyl bialymi");
                            form.player1Win();
                        }
                        else
                        {
                            Debug.WriteLine("Gracz 2 zwyciezyl białymi");
                            form.player2Win();
                        }
                        Debug.WriteLine("Szach mat, białe wygrywaja");
                        MessageBox.Show("Szach i mat\nBiałe wygrywaja w " + moveCount + " ruchach", "Szach mat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stalemate = false;
                    }
                }

                if (stalemate && currentColor == Figure.ColorEnum.White)
                {
                    form.TimerStop();
                    form.draw();
                    Debug.WriteLine("PAT");
                    MessageBox.Show("Pat\nBiałe nie mają możliwości ruchu", "Pat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else if(stalemate)
                {
                    form.TimerStop();
                    form.draw();
                    Debug.WriteLine("PAT");
                    MessageBox.Show("Pat\nCzarne nie mają możliwości ruchu", "Pat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
    
        }

        public void GetMoveAbility(int selectedCol, int selectedRow) //Sets move ability for a figure on cell(selectedCol, selectedRow)
        {
            ResetMoveAbility();

            if(debug) //ables to move anywhere if debug mode is turned on
            {
                for (int iCol = 1; iCol <= 8; iCol++)
                    for (int iRow = 1; iRow <= 8; iRow++)
                    {
                        if (CellIsEmpty(iCol, iRow))
                            moveAbility[iCol, iRow] = "Yes";
                        else if (board[iCol, iRow].figure.color == currentColor)
                            moveAbility[iCol, iRow] = "No";
                        else
                            moveAbility[iCol, iRow] = "Attack";
                    }
            }

            moveAbility[selectedCol, selectedRow] = "Current";

            if (!debug)
            {
                switch (board[selectedCol, selectedRow].figure.type)
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
                CheckMoveAbility(selectedCol, selectedRow + 1);
                if (CellExists(selectedCol, selectedRow + 2) && board[selectedCol, selectedRow].figure.firstMove)
                {
                    CheckMoveAbility(selectedCol, selectedRow + 2);
                    if (CellExists(selectedCol, selectedRow + 2) && moveAbility[selectedCol, selectedRow + 2] == "Attack")
                        moveAbility[selectedCol, selectedRow + 2] = "No";
                }

                if (CellExists(selectedCol, selectedRow + 1) && moveAbility[selectedCol, selectedRow + 1] == "Attack")
                    moveAbility[selectedCol, selectedRow + 1] = "No";

                CheckMoveAbility(selectedCol + 1, selectedRow + 1);
                if (CellExists(selectedCol + 1, selectedRow + 1) && moveAbility[selectedCol + 1, selectedRow + 1] == "Yes")
                    moveAbility[selectedCol + 1, selectedRow + 1] = "No";

                CheckMoveAbility(selectedCol - 1, selectedRow + 1);
                if (CellExists(selectedCol - 1, selectedRow + 1) && moveAbility[selectedCol - 1, selectedRow + 1] == "Yes")
                    moveAbility[selectedCol - 1, selectedRow + 1] = "No";

            }
            else
            {
                CheckMoveAbility(selectedCol, selectedRow - 1);
                if (CellExists(selectedCol, selectedRow - 2) && board[selectedCol, selectedRow].figure.firstMove)
                {
                    CheckMoveAbility(selectedCol, selectedRow - 2);
                    if (CellExists(selectedCol, selectedRow - 2) && moveAbility[selectedCol, selectedRow - 2] == "Attack")
                        moveAbility[selectedCol, selectedRow - 2] = "No";
                }

                CheckMoveAbility(selectedCol + 1, selectedRow - 1);
                if (CellExists(selectedCol + 1, selectedRow - 1) && moveAbility[selectedCol + 1, selectedRow - 1] == "Yes")
                    moveAbility[selectedCol + 1, selectedRow - 1] = "No";

                CheckMoveAbility(selectedCol - 1, selectedRow - 1);
                if (CellExists(selectedCol - 1, selectedRow - 1) && moveAbility[selectedCol - 1, selectedRow - 1] == "Yes")
                    moveAbility[selectedCol - 1, selectedRow - 1] = "No";
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
               CellIsEmpty(7, 1) &&
               !CellIsAttacked(5, 1, Figure.ColorEnum.White) &&
               !CellIsAttacked(6, 1, Figure.ColorEnum.White) &&
               !CellIsAttacked(7, 1, Figure.ColorEnum.White))
                    moveAbility[7, 1] = "Yes";

            //WHITE castle queen-side *long*
            if (board[selectedCol, selectedRow].figure.firstMove &&
              board[selectedCol, selectedRow].figure.color == Figure.ColorEnum.White &&
              figures[9].firstMove &&
              CellIsEmpty(2, 1) &&
              CellIsEmpty(3, 1) &&
              CellIsEmpty(4, 1) &&
              !CellIsAttacked(5, 1, Figure.ColorEnum.White) &&
              !CellIsAttacked(4, 1, Figure.ColorEnum.White) &&
              !CellIsAttacked(3, 1, Figure.ColorEnum.White))
                    moveAbility[3, 1] = "Yes";

            //BLACK castle king-side *short*
            if (board[selectedCol, selectedRow].figure.firstMove &&
               board[selectedCol, selectedRow].figure.color == Figure.ColorEnum.Black &&
               figures[32].firstMove &&
               CellIsEmpty(6, 8) &&
               CellIsEmpty(7, 8) &&
               !CellIsAttacked(5, 8, Figure.ColorEnum.Black) &&
               !CellIsAttacked(6, 8, Figure.ColorEnum.Black) &&
               !CellIsAttacked(7, 8, Figure.ColorEnum.Black))
                    moveAbility[7, 8] = "Yes";

            //BLACK castle queen-side *long*
            if (board[selectedCol, selectedRow].figure.firstMove &&
              board[selectedCol, selectedRow].figure.color == Figure.ColorEnum.Black &&
              figures[25].firstMove &&
              CellIsEmpty(2, 8) &&
              CellIsEmpty(3, 8) &&
              CellIsEmpty(4, 8) &&
              !CellIsAttacked(5, 8, Figure.ColorEnum.Black) &&
              !CellIsAttacked(4, 8, Figure.ColorEnum.Black) &&
              !CellIsAttacked(3, 8, Figure.ColorEnum.Black))
                    moveAbility[3, 8] = "Yes";

        }

        bool CheckMoveAbility(int col, int row)
        {
            bool ret = true;
            int[] WhiteKingPositionCopy = { 1, 1 };
            int[] BlackKingPositionCopy = { 1, 1 };
            int[] current = { 1, 1 };
            if(checkingMate)
            {
                current[0] = checkingMateFrom[0];
                current[1] = checkingMateFrom[1];
            }
            else
            {
                current[0] = currentSelection[0];
                current[1] = currentSelection[1];
            }

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

                    ret = false;
                }

                for (int iCol = 1; iCol <= 9; iCol++)
                    for (int iRow = 1; iRow <= 9; iRow++)
                        boardCopy[iCol, iRow].figure = board[iCol, iRow].figure; //copies board to boardCopy
                WhiteKingPositionCopy[0] = WhiteKingPosition[0]; //copies kings positions 
                WhiteKingPositionCopy[1] = WhiteKingPosition[1];
                BlackKingPositionCopy[0] = BlackKingPosition[0];
                BlackKingPositionCopy[1] = BlackKingPosition[1];

                if (current[0] == WhiteKingPosition[0] && current[1] == WhiteKingPosition[1]) //changes king's position
                {                                                                                               //if it's going to be moved
                    WhiteKingPosition[0] = col;
                    WhiteKingPosition[1] = row;
                }

                if (current[0] == BlackKingPosition[0] && current[1] == BlackKingPosition[1])
                {
                    BlackKingPosition[0] = col;
                    BlackKingPosition[1] = row;
                }

                //Debug.WriteLine(currentSelection[0] + " x " + currentSelection[1] + "    " + col + " x " + row);
                board[col, row].figure = board[current[0], current[1]].figure; //simulates the move that is going to be done
                board[current[0], current[1]].figure = null;
                if(currentColor == Figure.ColorEnum.White)
                {
                    if(CellIsAttacked(WhiteKingPosition[0], WhiteKingPosition[1], Figure.ColorEnum.White)) //checks if the move is going to cause a check
                    {
                        moveAbility[col, row] = "No";
                    }
                }
                else
                {
                    if(CellIsAttacked(BlackKingPosition[0], BlackKingPosition[1], Figure.ColorEnum.Black)) //checks if the move is going to cause a check
                    {
                        moveAbility[col, row] = "No";
                    }
                }

                for (int iCol = 1; iCol <= 9; iCol++)
                    for (int iRow = 1; iRow <= 9; iRow++)
                        board[iCol, iRow].figure = boardCopy[iCol, iRow].figure; //gives board its previous values
                WhiteKingPosition[0] = WhiteKingPositionCopy[0]; //gives kings positions their previous values
                WhiteKingPosition[1] = WhiteKingPositionCopy[1];
                BlackKingPosition[0] = BlackKingPositionCopy[0];
                BlackKingPosition[1] = BlackKingPositionCopy[1];
            }

            return ret;

        }

        public void ResetMoveAbility() //sets all move abilities to "No"
        {
            for (int iCol = 1; iCol <= 8; iCol++)
                for (int iRow = 1; iRow <= 8; iRow++)
                    moveAbility[iCol, iRow] = "No";
        }

        public bool CellIsAttacked(int col, int row, Figure.ColorEnum color) //checks if a figure of color(color) is or will be attacked on cell(col, row)
        {
            if (color == Figure.ColorEnum.White) color = Figure.ColorEnum.Black;
            else color = Figure.ColorEnum.White;

            if(CellExists(col, row))
            {
                //Checking if opponents pawn checks
                if(color == Figure.ColorEnum.White)
                {
                    if (FigureIsOnCell(Figure.TypeEnum.Pawn, color, col + 1, row - 1)) return true;
                    if (FigureIsOnCell(Figure.TypeEnum.Pawn, color, col - 1, row - 1)) return true;
                }
                else
                {
                    if (FigureIsOnCell(Figure.TypeEnum.Pawn, color, col + 1, row + 1)) return true;
                    if (FigureIsOnCell(Figure.TypeEnum.Pawn, color, col - 1, row + 1)) return true;
                }

                //Checking if opponents knight ckecks
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col + 2, row + 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col + 2, row - 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col + 1, row + 2)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col + 1, row - 2)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col - 1, row + 2)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col - 1, row - 2)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col - 2, row + 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.Knight, color, col - 2, row - 1)) return true;

                //Checking if opponents bishop or queen checks
                for (int i = 1; i <= 8; i++)
                {
                    if(CellExists(col + i, row + i) && !CellIsEmpty(col + i, row + i))
                        if (FigureIsOnCell(Figure.TypeEnum.Bishop, color, col + i, row + i))
                        {
                            return true;
                        }
                        else
                            break;
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (CellExists(col - i, row + i) && !CellIsEmpty(col - i, row + i))
                        if (FigureIsOnCell(Figure.TypeEnum.Bishop, color, col - i, row + i))
                        {
                            return true;
                        }
                        else
                            break;
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (CellExists(col + i, row - i) && !CellIsEmpty(col + i, row - i))
                        if (FigureIsOnCell(Figure.TypeEnum.Bishop, color, col + i, row - i))
                        {
                            return true;
                        }
                        else
                            break;
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (CellExists(col - i, row - i) && !CellIsEmpty(col - i, row - i))
                        if (FigureIsOnCell(Figure.TypeEnum.Bishop, color, col - i, row - i))
                        {
                            return true;
                        }
                        else
                            break;
                }

                //Checking if opponents rook or queen checks
                for (int i = 1; i <= 8; i++)
                {
                    if (CellExists(col + i, row) && !CellIsEmpty(col + i, row))
                        if (FigureIsOnCell(Figure.TypeEnum.Rook, color, col + i, row))
                        {
                            return true;
                        }
                        else
                    break;
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (CellExists(col, row + i) && !CellIsEmpty(col, row + i))
                        if (FigureIsOnCell(Figure.TypeEnum.Rook, color, col, row + i))
                        {
                            return true;
                        }
                        else
                            break;
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (CellExists(col - i, row) && !CellIsEmpty(col - i, row))
                        if (FigureIsOnCell(Figure.TypeEnum.Rook, color, col - i, row))
                        {
                            return true;
                        }
                        else
                            break;
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (CellExists(col, row - i) && !CellIsEmpty(col, row - i))
                        if (FigureIsOnCell(Figure.TypeEnum.Rook, color, col, row - i))
                        {
                            return true;
                        }
                        else
                            break;
                }

                //Checking if opponents king checks
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col + 1, row + 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col + 1, row - 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col + 1, row)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col - 1, row + 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col - 1, row - 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col - 1, row)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col, row + 1)) return true;
                if (FigureIsOnCell(Figure.TypeEnum.King, color, col, row - 1)) return true;

            }
            return false;
        }

        public bool FigureIsOnCell(Figure.TypeEnum type, Figure.ColorEnum color, int col, int row) //checks if there is a figure(figure, color) on cell(col, row)
        {
            if (type == Figure.TypeEnum.Rook || type == Figure.TypeEnum.Bishop)
            {
                if (CellExists(col, row) &&
                       board[col, row].figure != null &&
                       (board[col, row].figure.type == type || board[col, row].figure.type == Figure.TypeEnum.Queen) &&
                       board[col, row].figure.color == color)
                    return true;
            }
            else if (CellExists(col, row) &&
                    board[col, row].figure != null &&
                    board[col, row].figure.type == type &&
                    board[col, row].figure.color == color)
                return true;
            return false;
        }
    }    
}