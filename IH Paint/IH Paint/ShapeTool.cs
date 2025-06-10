using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public class ShapeTool<T> : BaseTool where T : Shape, new() 
    {
        private T _shapeInProgress;
        public override string Name => typeof(T).Name.Replace("Shape", ""); 

        public override Cursor ToolCursor => Cursors.Cross;

        public override void OnMouseDown(Point location, MouseButtons button, DrawingState state)
        {
            if (button == MouseButtons.Left)
            {
                IsDrawing = true;
                state.MouseDownStartPoint = state.ScreenToWorld(location); 

                _shapeInProgress = new T
                {
                    StartPoint = state.MouseDownStartPoint,
                    EndPoint = state.MouseDownStartPoint,
                    DrawColor = state.PrimaryColor,
                    PenWidth = state.PenWidth,
                    PenDashStyle = state.CurrentDashStyle
                };
                state.CurrentPreviewShape = _shapeInProgress;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseMove(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing)
            {
                _shapeInProgress.EndPoint = state.ScreenToWorld(location);
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }

        public override void OnMouseUp(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing && button == MouseButtons.Left)
            {
                IsDrawing = false;
                _shapeInProgress.EndPoint = state.ScreenToWorld(location);

                if (_shapeInProgress.GetBounds().Width > 0 || _shapeInProgress.GetBounds().Height > 0)
                {
                    var command = new DrawShapeCommand(
                        _shapeInProgress,
                        state.AddShapeToDocumentDelegate,    //execute
                        state.RemoveShapeFromDocumentDelegate //unexecute
                    );
                    state.ExecuteCommandDelegate?.Invoke(command);
                }

                state.CurrentPreviewShape = null;
                _shapeInProgress = null;
                state.InvalidateCanvasDelegate?.Invoke();
            }
        }
    }
}
