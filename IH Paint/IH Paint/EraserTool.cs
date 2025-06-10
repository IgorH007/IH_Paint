using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public class EraserTool : BaseTool
    {
        public override string Name => "Eraser";
        public override Cursor ToolCursor => Cursors.Cross; 

        private PencilStroke _currentEraseStroke;

        public override void OnMouseDown(Point location, MouseButtons button, DrawingState state)
        {
            if (button == MouseButtons.Left) 
            {
                IsDrawing = true;
                Point worldLocation = state.ScreenToWorld(location);
                _currentEraseStroke = new PencilStroke(worldLocation, state.SecondaryColor, state.PenWidth);

                state.CurrentPreviewShape = _currentEraseStroke;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseMove(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing)
            {
                _currentEraseStroke.AddPoint(state.ScreenToWorld(location));
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseUp(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing && button == MouseButtons.Left)
            {
                IsDrawing = false;
                if (_currentEraseStroke != null && _currentEraseStroke.Points.Count > 1)
                {
                    var command = new DrawShapeCommand(
                        _currentEraseStroke,
                        state.AddShapeToDocumentDelegate,
                        state.RemoveShapeFromDocumentDelegate
                    );
                    state.ExecuteCommandDelegate?.Invoke(command);
                }
                state.CurrentPreviewShape = null;
                _currentEraseStroke = null;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }
    }
}
