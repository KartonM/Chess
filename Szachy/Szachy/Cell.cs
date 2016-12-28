using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    [Serializable]
    public class Cell
    {
        public Figure figure = null;

        public Cell()
        {

        }

        public void ChangeFigure(Figure newFigure)
        {
            figure = newFigure;
        }
    }

}
