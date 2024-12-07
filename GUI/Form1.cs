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
        private Circle circle;
        private Square square;
        private Rhomb rhomb;
        private Button moveButton;

        public Form1()
        {
            InitializeComponent();
            circle = new Circle(300, 100, 50);
            square = new Square(200, 200, 100);
            rhomb = new Rhomb(100, 300, 50, 50);
            moveButton = new Button
            {
                Text = "Move Right",
                Location = new Point(10, 10),
                Size = new Size(100, 30)
            };
            moveButton.Click += MoveButton_Click;
            Controls.Add(moveButton);

        }
        private void MoveButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => circle.MoveRight(this, 50));
            Task.Run(() => square.MoveRight(this, 50));
            Task.Run(() => rhomb.MoveRight(this, 50));
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
    public class Rhomb : Figure
    {
        private int horDiagLen;
        private int vertDiagLen;

        public Rhomb(int x, int y, int horDiagLen, int vertDiagLen) : base(x, y)
        {
            this.horDiagLen = horDiagLen;
            this.vertDiagLen = vertDiagLen;
        }
        public override void DrawBlack(Graphics g)
        {
            Point[] points = new Point[]
            {
                new Point(x, y - vertDiagLen / 2),
                new Point(x + horDiagLen / 2, y),
                new Point(x, y + vertDiagLen / 2),
                new Point(x - horDiagLen / 2, y)
            };
            g.DrawPolygon(Pens.Black, points);
        }
        public override void HideDrawingBackGround(Graphics g)
        {
            Point[] points = {
                new Point(x, y - vertDiagLen / 2),
                new Point(x + horDiagLen / 2, y),
                new Point(x, y + vertDiagLen / 2),
                new Point(x - horDiagLen / 2, y)
            };
            g.DrawPolygon(new Pen(Color.White), points);
        }
    }
}
