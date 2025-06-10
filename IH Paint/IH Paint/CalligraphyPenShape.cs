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
    public class CalligraphyPenShape : Shape
    {
        public List<PointF> PathPoints { get; private set; } = new List<PointF>();
        public float NibAngleDegrees { get; set; } = 45f; // angle of nib

        public CalligraphyPenShape(PointF startLocation, Color color, float nibWidth, float nibAngle = 45f)
            : base(Point.Truncate(startLocation), color, nibWidth) // Base PenWidth is nibWidth
        {
            PathPoints.Add(startLocation);
            NibAngleDegrees = nibAngle;
        }
        public CalligraphyPenShape() : base() { }

        public void AddPoint(PointF p)
        {
            if (PathPoints.Any() && p == PathPoints.Last()) return; // Avoid duplicate points
            PathPoints.Add(p);
        }

        public override void Draw(Graphics g)
        {
            if (PathPoints.Count < 1) return;

            if (PathPoints.Count == 1)
            {
                DrawNibMark(g, PathPoints[0], PenWidth, NibAngleDegrees, DrawColor);
                return;
            }

            using (GraphicsPath strokePath = new GraphicsPath())
            {
                strokePath.FillMode = FillMode.Winding;
                for (int i = 0; i < PathPoints.Count - 1; i++)
                {
                    PointF p1 = PathPoints[i];
                    PointF p2 = PathPoints[i + 1];

                    if (p1.Equals(p2)) continue; 
                    float halfNibVisualWidth = PenWidth / 2f;
                    float segmentAngleRad = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
                    float nibAngleRad = NibAngleDegrees * (float)Math.PI / 180f;

                    PointF nibVector = new PointF(
                        (float)Math.Cos(nibAngleRad) * halfNibVisualWidth,
                        (float)Math.Sin(nibAngleRad) * halfNibVisualWidth
                    );

                    //4 corners
                    PointF[] quadPoints = new PointF[4];
                    quadPoints[0] = new PointF(p1.X + nibVector.X, p1.Y + nibVector.Y); // top-right of nib at p1
                    quadPoints[1] = new PointF(p1.X - nibVector.X, p1.Y - nibVector.Y); // bottom-left of nib at p1
                    quadPoints[2] = new PointF(p2.X - nibVector.X, p2.Y - nibVector.Y); // bottom-left of nib at p2
                    quadPoints[3] = new PointF(p2.X + nibVector.X, p2.Y + nibVector.Y); // top-right of nib at p2

                    strokePath.AddPolygon(quadPoints);
                }

                if (strokePath.PointCount > 0) 
                {
                    using (SolidBrush brush = new SolidBrush(DrawColor))
                    {
                        g.FillPath(brush, strokePath);
                    }
                }
                else if (PathPoints.Count > 0) 
                {
                    DrawNibMark(g, PathPoints[0], PenWidth, NibAngleDegrees, DrawColor);
                }
                if (PathPoints.Count > 0)
                {
                    DrawNibMark(g, PathPoints.First(), PenWidth, NibAngleDegrees, DrawColor);
                    if (PathPoints.Count > 1 && !PathPoints.First().Equals(PathPoints.Last()))
                    {
                        DrawNibMark(g, PathPoints.Last(), PenWidth, NibAngleDegrees, DrawColor);
                    }
                }
            }
        }

        private void DrawNibMark(Graphics g, PointF center, float width, float angleDegrees, Color color)
        {
            float angleRad = angleDegrees * (float)Math.PI / 180f;
            float halfW = width / 2f; 
            PointF p1 = new PointF(center.X + halfW * (float)Math.Cos(angleRad),
                                   center.Y + halfW * (float)Math.Sin(angleRad));
            PointF p2 = new PointF(center.X - halfW * (float)Math.Cos(angleRad),
                                   center.Y - halfW * (float)Math.Sin(angleRad));

            using (Pen markPen = new Pen(color, 2f)) 
            {
                markPen.StartCap = LineCap.Flat;
                markPen.EndCap = LineCap.Flat;
                g.DrawLine(markPen, p1, p2);
            }
        }


        public override Rectangle GetBounds() 
        {
            if (!PathPoints.Any()) return base.GetBounds();
            float minX = PathPoints.Min(p => p.X);
            float minY = PathPoints.Min(p => p.Y);
            float maxX = PathPoints.Max(p => p.X);
            float maxY = PathPoints.Max(p => p.Y);
            int buffer = (int)Math.Ceiling(PenWidth / 2.0) + 2;
            return new Rectangle((int)(minX - buffer), (int)(minY - buffer), (int)((maxX - minX) + 2 * buffer), (int)((maxY - minY) + 2 * buffer));
        }
        public override Shape Clone()
        {
            var newShape = new CalligraphyPenShape(PointF.Empty, this.DrawColor, this.PenWidth, this.NibAngleDegrees);
            if (this.PathPoints.Any()) newShape.PathPoints = new List<PointF>(this.PathPoints); // deep copy
            if (newShape.PathPoints.Any()) newShape.Location = Point.Truncate(newShape.PathPoints.First());
            return newShape;
        }
    }
}
