using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public abstract class BaseTool : ITool
    {
        public abstract string Name { get; }
        public virtual Cursor ToolCursor => Cursors.Default;
        public virtual Image ToolIcon => null; 

        protected bool IsDrawing { get; set; } = false;

        public virtual void Activate(DrawingState state)
        {
        }

        public virtual void Deactivate(DrawingState state)
        {
            IsDrawing = false;
            state.CurrentPreviewShape = null; 
            state.InvalidateCanvasDelegate?.Invoke(); 
        }

        public abstract void OnMouseDown(Point location, MouseButtons button, DrawingState state);
        public abstract void OnMouseMove(Point location, MouseButtons button, DrawingState state);
        public abstract void OnMouseUp(Point location, MouseButtons button, DrawingState state);
        public virtual void PaintPreview(Graphics g, DrawingState state)
        {
            state.CurrentPreviewShape?.Draw(g);
        }
    }
}
