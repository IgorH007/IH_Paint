using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Paint
{
    [Serializable]
    public abstract class Shape
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color DrawColor { get; set; } = Color.Black;
        public float PenWidth { get; set; } = 1f;
        public DashStyle PenDashStyle { get; set; } = DashStyle.Solid;
        public Point Location { get; set; }

        protected Shape(Point start, Point end, Color color, float penWidth, DashStyle dashStyle = DashStyle.Solid)
        {
            StartPoint = start;
            EndPoint = end;
            DrawColor = color;
            PenWidth = penWidth;
            PenDashStyle = dashStyle;
            Location = start; 
        }

        protected Shape(Point location, Color color, float penWidth, DashStyle dashStyle = DashStyle.Solid)
        {
            Location = location;
            StartPoint = location; 
            EndPoint = location;  
            DrawColor = color;
            PenWidth = penWidth;
            PenDashStyle = dashStyle;
        }

        protected Shape() { }


        public abstract void Draw(Graphics g);

        public virtual Rectangle GetBounds()
        {
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);

            return new Rectangle(x, y, Math.Max(1, width), Math.Max(1, height));
        }

        public virtual bool ContainsPoint(Point p)
        {
            return GetBounds().Contains(p);
        }

        public abstract Shape Clone(); // Deep copy
    }
}
