using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    [Serializable]
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
            Pawn=1, Rook=2, Knight=3, Bishop=4, Queen=5, King=6, Null=7
        };

        public enum ColorEnum
        {
            White=0, Black=1
        };
    }
}
