using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public interface ITool
    {
        string Name { get; }
        Cursor ToolCursor { get; }
        Image ToolIcon { get; } 
        void OnMouseDown(Point location, MouseButtons button, DrawingState state);
        void OnMouseMove(Point location, MouseButtons button, DrawingState state);
        void OnMouseUp(Point location, MouseButtons button, DrawingState state);

        void Activate(DrawingState state);  
        void Deactivate(DrawingState state); 

        void PaintPreview(Graphics g, DrawingState state);
    }
}
