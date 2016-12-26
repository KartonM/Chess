using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szachy
{
    public partial class Endgame : Form
    {

        public string message1;
        public string message2;
        public string message3;

        public Endgame()
        {
            InitializeComponent();
            textMessage1.Text = message1;
            textMessage2.Text = message2;
            textMessage3.Text = message3;
        }
    }
}
