using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Paint
{
    public class DrawingState
    {
        public Color PrimaryColor { get; set; } = Color.Black;
        public Color SecondaryColor { get; set; } = Color.White; 
        public float PenWidth { get; set; } = 1f;
        public Font CurrentFont { get; set; } = new Font("Arial", 12);
        public System.Drawing.Drawing2D.DashStyle CurrentDashStyle { get; set; } = System.Drawing.Drawing2D.DashStyle.Solid;


        public Action<Shape> AddShapeToDocumentDelegate { get; set; }
        public Action<Shape> RemoveShapeFromDocumentDelegate { get; set; }
        public Action<Shape> AddShapeToCanvasDelegate { get; set; } 
        public Action<ICommand> ExecuteCommandDelegate { get; set; } 
        public Func<Point, Color> GetPixelColorDelegate { get; set; } //color picker & fill tool
        public Action InvalidateCanvasDelegate { get; set; } //  request redraw of drawingPanel
        public Func<List<Shape>> GetCurrentShapesDelegate { get; set; } // get all current shapes 
        public Action<List<Shape>> SetAllShapesDelegate { get; set; } // replace all shapes 
        public Func<Bitmap> GetCanvasBitmapDelegate { get; set; }
        public Action<bool> ShowTextOptionsDelegate { get; set; }

        public Point MouseDownStartPoint { get; set; }
        public Shape CurrentPreviewShape { get; set; }

        public Size CanvasSize { get; set; } 
        public float ZoomFactor { get; set; } = 1.0f;
        public PointF PanOffset { get; set; } = PointF.Empty;

        public Point ScreenToWorld(Point screenPoint)
        {
            /*float worldX = (screenPoint.X / ZoomFactor) + PanOffset.X;
            float worldY = (screenPoint.Y / ZoomFactor) + PanOffset.Y;
            return new Point((int)Math.Round(worldX), (int)Math.Round(worldY));*/
            return screenPoint;
        }
    }
}
