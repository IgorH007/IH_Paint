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
    public class PencilStroke : Shape
    {
        public List<Point> Points { get; private set; } = new List<Point>();
        public PencilStroke(Point startLocation, Color color, float penWidth, DashStyle dashStyle = DashStyle.Solid)
            : base(startLocation, color, penWidth, dashStyle)
        {
            Points.Add(startLocation);
        }

        public PencilStroke() : base() { } 

        public void AddPoint(Point p)
        {
            Points.Add(p);
            if (Points.Count == 1) StartPoint = p;
            EndPoint = p; // Last point
        }

        public override void Draw(Graphics g)
        {
            if (Points.Count < 2)
            {
                if (Points.Count == 1)
                {
                    using (SolidBrush brush = new SolidBrush(DrawColor))
                    {
                        float dotRadius = PenWidth / 2;
                        g.FillEllipse(brush, Points[0].X - dotRadius, Points[0].Y - dotRadius, PenWidth, PenWidth);
                    }
                }
                return;
            }

            using (Pen pen = new Pen(DrawColor, PenWidth))
            {
                pen.DashStyle = PenDashStyle; 
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round; // smoother joins
                g.DrawLines(pen, Points.ToArray());
            }
        }

        public override Rectangle GetBounds()
        {
            if (Points == null || !Points.Any())
                return new Rectangle(Location.X, Location.Y, (int)PenWidth, (int)PenWidth);

            int minX = Points.Min(p => p.X);
            int minY = Points.Min(p => p.Y);
            int maxX = Points.Max(p => p.X);
            int maxY = Points.Max(p => p.Y);
            int buffer = (int)Math.Ceiling(PenWidth / 2.0);
            return new Rectangle(minX - buffer, minY - buffer, (maxX - minX) + 2 * buffer, (maxY - minY) + 2 * buffer);
        }

        public override Shape Clone()
        {
            var newStroke = new PencilStroke(this.Location, this.DrawColor, this.PenWidth, this.PenDashStyle);
            newStroke.Points = new List<Point>(this.Points); // deep copy
            newStroke.StartPoint = this.StartPoint;
            newStroke.EndPoint = this.EndPoint;
            return newStroke;
        }
    }
}
