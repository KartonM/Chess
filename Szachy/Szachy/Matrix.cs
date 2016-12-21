using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    public class Matrix
    {
        public Cell[][] board;
        public Figure[] figures;

        public Matrix()
        {
            //Creating a empty board
            board = new Cell[9][];
            for (int i = 0; i <= 8; i++)
                board[i] = new Cell[8];

            //Creating a set of figures
            for (int i = 1; i <= 20; i++)
                figures[i] = new Figure();

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



        }

        //Check if cell exists
        public bool CellExists(int row, int column)
        {
            if (row >= 1 && column >= 1 && row <= 10 && column <= 10)
                return true;
            else
                return false;
        }

        public bool CellIsEmpty(int row, int column)
        {
            return (board[row][column].figure == null);
        }

        private void MoveFigure(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            board[toRow][toColumn].figure = board[fromRow][fromColumn].figure;
            board[fromRow][fromColumn].figure = null;
        }
    }
}
