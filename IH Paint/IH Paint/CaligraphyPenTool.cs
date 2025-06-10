using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public class CalligraphyPenTool : BaseTool
    {
        public override string Name => "Calligraphy Pen";
        public override Cursor ToolCursor => Cursors.Cross;

        private CalligraphyPenShape _currentShape;
        public float NibAngle { get; set; } = 45f; // Could be a UI setting

        public override void OnMouseDown(Point location, MouseButtons button, DrawingState state)
        {
            if (button == MouseButtons.Left)
            {
                IsDrawing = true;
                PointF worldLocation = state.ScreenToWorld(location); // Use PointF
                _currentShape = new CalligraphyPenShape(worldLocation, state.PrimaryColor, state.PenWidth, NibAngle);
                state.CurrentPreviewShape = _currentShape;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseMove(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing)
            {
                _currentShape?.AddPoint(state.ScreenToWorld(location)); // Use PointF
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseUp(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing && button == MouseButtons.Left)
            {
                IsDrawing = false;
                if (_currentShape != null && _currentShape.PathPoints.Count > 1)
                {
                    var command = new DrawShapeCommand(
                        _currentShape,
                        state.AddShapeToDocumentDelegate,
                        state.RemoveShapeFromDocumentDelegate
                    );
                    state.ExecuteCommandDelegate?.Invoke(command);
                }
                state.CurrentPreviewShape = null;
                _currentShape = null;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }
    }
}
