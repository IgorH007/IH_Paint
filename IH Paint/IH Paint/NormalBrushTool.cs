using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public class NormalBrushTool : BaseTool 
    {
        public override string Name => "Normal Brush";
        public override Cursor ToolCursor => Cursors.Cross; 

        private PencilStroke _currentStroke;

        public override void OnMouseDown(Point location, MouseButtons button, DrawingState state)
        {
            if (button == MouseButtons.Left)
            {
                IsDrawing = true;
                Point worldLocation = state.ScreenToWorld(location);
                _currentStroke = new PencilStroke(worldLocation, state.PrimaryColor, state.PenWidth, state.CurrentDashStyle);
                state.CurrentPreviewShape = _currentStroke;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseMove(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing)
            {
                _currentStroke?.AddPoint(state.ScreenToWorld(location));
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseUp(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing && button == MouseButtons.Left)
            {
                IsDrawing = false;
                if (_currentStroke != null && _currentStroke.Points.Count > 1)
                {
                    var command = new DrawShapeCommand(
                        _currentStroke,
                        state.AddShapeToDocumentDelegate,
                        state.RemoveShapeFromDocumentDelegate
                    );
                    state.ExecuteCommandDelegate?.Invoke(command);
                }
                state.CurrentPreviewShape = null;
                _currentStroke = null;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }
    }
}
