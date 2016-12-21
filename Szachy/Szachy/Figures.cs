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

        public enum TypeEnum
        {
            Pawn, Rook, Knight, Bishop, Queen, King
        };
    }
}
