using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy
{
    public class Cell
    {
        public Figure figure = null;

        public void ChangeFigure(Figure newFigure)
        {
            figure = newFigure;
        }
    }

}
