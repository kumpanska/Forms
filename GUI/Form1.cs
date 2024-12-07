using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    public abstract class Figure
    {
        protected int x;
        protected int y;

        public Figure(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
