using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public class FillTool : BaseTool
    {
        public override string Name => "Fill Bucket";
        public override Cursor ToolCursor => Cursors.Hand; 

        public override void OnMouseDown(Point location, MouseButtons button, DrawingState state)
        {
            if (button == MouseButtons.Left)
            {
                if (IsDrawing) 
                {
                    System.Diagnostics.Debug.WriteLine("FillTool.OnMouseDown: IsDrawing is already true. Ignoring likely duplicate event.");
                    return;
                }
                IsDrawing = true; 

                Point worldClickPoint = state.ScreenToWorld(location);
                System.Diagnostics.Debug.WriteLine($"FillTool.OnMouseDown: (Attempt 1) Screen Click at ({location.X},{location.Y}), World Click at ({worldClickPoint.X},{worldClickPoint.Y})");

                if (worldClickPoint.X < 0 || worldClickPoint.X >= state.CanvasSize.Width ||
                    worldClickPoint.Y < 0 || worldClickPoint.Y >= state.CanvasSize.Height)
                {
                    System.Diagnostics.Debug.WriteLine("FillTool.OnMouseDown: Clicked outside canvas bounds.");
                    IsDrawing = false;
                    return;
                }

                Color targetColor = state.GetPixelColorDelegate(worldClickPoint);
                Color replacementColor = state.PrimaryColor;
                System.Diagnostics.Debug.WriteLine($"FillTool.OnMouseDown: TargetColor: {targetColor}, ReplacementColor: {replacementColor}");

                if (targetColor.ToArgb() == replacementColor.ToArgb())
                {
                    System.Diagnostics.Debug.WriteLine("FillTool.OnMouseDown: Target and replacement colors are the same. No fill needed.");
                    IsDrawing = false; 
                    return;
                }

                var command = new FillBitmapCommand(worldClickPoint, replacementColor, targetColor, state);
                state.ExecuteCommandDelegate?.Invoke(command);
            }
        }

        public override void OnMouseMove(Point location, MouseButtons button, DrawingState state) { }
        public override void OnMouseUp(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing)
            {
                IsDrawing = false;
                System.Diagnostics.Debug.WriteLine("FillTool.OnMouseUp: Reset IsDrawing flag.");
            }
        }
        public override void PaintPreview(Graphics g, DrawingState state) {  }
    }
}
