using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public class AirbrushTool : BaseTool, IDisposable
    {
        public override string Name => "Airbrush";
        public override Cursor ToolCursor => Cursors.Cross; //custom cursor

        private System.Windows.Forms.Timer _sprayTimer;
        private Point _currentMouseWorldLocation;
        private DrawingState _activeDrawingState; 
        private Random _random = new Random();

        public int Density { get; set; } = 10; // particles per tick
        public int SpreadRadius { get; set; } = 15; // Max radius

        public AirbrushTool()
        {
            _sprayTimer = new System.Windows.Forms.Timer();
            _sprayTimer.Interval = 50; //ms
            _sprayTimer.Tick += SprayTimer_Tick;
        }

        public override void OnMouseDown(Point location, MouseButtons button, DrawingState state)
        {
            if (button == MouseButtons.Left)
            {
                IsDrawing = true;
                _activeDrawingState = state; // Store state for timer
                _currentMouseWorldLocation = state.ScreenToWorld(location);
                _sprayTimer.Start();
                SprayTimer_Tick(null, EventArgs.Empty); // Spray immediately on click
            }
        }

        public override void OnMouseMove(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing)
            {
                _currentMouseWorldLocation = state.ScreenToWorld(location);
                System.Diagnostics.Debug.WriteLine($"Airbrush MouseMove: WorldLoc=({_currentMouseWorldLocation.X},{_currentMouseWorldLocation.Y})");
            }
        }

        public override void OnMouseUp(Point location, MouseButtons button, DrawingState state)
        {
            if (IsDrawing && button == MouseButtons.Left)
            {
                IsDrawing = false;
                _sprayTimer.Stop();
                _activeDrawingState = null;
            }
        }

        private void SprayTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!IsDrawing || _activeDrawingState == null) { return; }
                Bitmap canvasBitmap = _activeDrawingState.GetCanvasBitmapDelegate?.Invoke();
                if (canvasBitmap == null) {  return; }

                using (Graphics g = Graphics.FromImage(canvasBitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None; 
                    Color particleColor = Color.Fuchsia; 
                    using (SolidBrush brush = new SolidBrush(particleColor))
                    {
                        float particleDiameter = 20f; 
                        Point drawLocation = _currentMouseWorldLocation;

                        System.Diagnostics.Debug.WriteLine($"Airbrush Tick DEBUG: Drawing at World ({drawLocation.X},{drawLocation.Y}) with ZF={_activeDrawingState.ZoomFactor}, PO=({_activeDrawingState.PanOffset.X},{_activeDrawingState.PanOffset.Y})");

                        g.FillEllipse(brush, drawLocation.X - particleDiameter / 2,
                                             drawLocation.Y - particleDiameter / 2,
                                             particleDiameter, particleDiameter);
                    }
                }
                _activeDrawingState.InvalidateCanvasDelegate?.Invoke();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Airbrush Tick ERROR: {ex.ToString()}");
                _sprayTimer.Stop();
                IsDrawing = false;
                _activeDrawingState = null;
            }
        }

        public void Dispose()
        {
            _sprayTimer?.Stop();
            _sprayTimer?.Dispose();
        }
    }
}
