using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public class TextTool : BaseTool
    {
        public override string Name => "Text";
        public override Cursor ToolCursor => Cursors.IBeam;
        public Action<bool> ShowTextOptionsDelegate { get; set; }
        public override void Activate(DrawingState state) { base.Activate(state); }
        public override void Deactivate(DrawingState state) { base.Deactivate(state); }


        public override void OnMouseDown(Point location, MouseButtons button, DrawingState state)
        {
            if (button == MouseButtons.Left)
            {
                Point worldClickPoint = state.ScreenToWorld(location);

                string inputText = Microsoft.VisualBasic.Interaction.InputBox("Enter text:", "Add Text");

                if (!string.IsNullOrEmpty(inputText))
                {
                    var textShape = new TextShape(worldClickPoint, inputText, state.CurrentFont, state.PrimaryColor);
                    var command = new DrawShapeCommand(textShape, state.AddShapeToDocumentDelegate, state.RemoveShapeFromDocumentDelegate);
                    state.ExecuteCommandDelegate?.Invoke(command);
                    state.InvalidateCanvasDelegate?.Invoke();
                }
            }
        }

        public override void OnMouseMove(Point location, MouseButtons button, DrawingState state) {  }
        public override void OnMouseUp(Point location, MouseButtons button, DrawingState state) { /* No drag */ }
        public override void PaintPreview(Graphics g, DrawingState state) {  }
    }
}
