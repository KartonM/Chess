using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    public class Figure
    {
        public TypeEnum type;
        public ColorEnum color;
        public bool firstMove = true;

        public Figure()
        {
            type = Figure.TypeEnum.Null;
            color = Figure.ColorEnum.White;
            firstMove = true;
        }

        public enum TypeEnum
        {
            Pawn, Rook, Knight, Bishop, Queen, King, Null
        };

        public enum ColorEnum
        {
            White, Black
        };
    }
}
