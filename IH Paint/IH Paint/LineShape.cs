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
    public class LineShape : Shape
    {
        public LineShape(Point start, Point end, Color color, float penWidth, DashStyle dashStyle = DashStyle.Solid)
            : base(start, end, color, penWidth, dashStyle) { }
        public LineShape() : base() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(DrawColor, PenWidth))
            {
                pen.DashStyle = PenDashStyle;
                g.DrawLine(pen, StartPoint, EndPoint);
            }
        }

        public override Shape Clone()
        {
            return new LineShape(this.StartPoint, this.EndPoint, this.DrawColor, this.PenWidth, this.PenDashStyle);
        }
    }
}
