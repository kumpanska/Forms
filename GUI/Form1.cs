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
        public abstract void DrawBlack(Graphics g);
        public abstract void HideDrawingBackGround(Graphics g);
        public void MoveRight(Form form, int step)
        {
            using (Graphics g = form.CreateGraphics())
            {
                for (int i = 0; i < step; i++)
                {
                    DrawBlack(g);
                    System.Threading.Thread.Sleep(100);
                    HideDrawingBackGround(g);
                    x++;
                }
            }
        }
    }
    public class Circle : Figure
    {
        private int radius;

        public Circle(int x, int y, int radius) : base(x, y)
        {
            this.radius = radius;
        }
        public override void DrawBlack(Graphics g)
        {
            g.DrawEllipse(Pens.Black, x - radius, y - radius, 2 * radius, 2 * radius);
        }
        public override void HideDrawingBackGround(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.White), x - radius, y - radius, 2 * radius, 2 * radius);
        }
    }
    public class Square : Figure
    {
        private int sideLength;

        public Square(int x, int y, int sideLength) : base(x, y)
        {
            this.sideLength = sideLength;
        }
        public override void DrawBlack(Graphics g)
        {
            g.DrawRectangle(Pens.Black, x - sideLength / 2, y - sideLength / 2, sideLength, sideLength);
        }
        public override void HideDrawingBackGround(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.White), x - sideLength / 2, y - sideLength / 2, sideLength, sideLength);
        }
    }
}
