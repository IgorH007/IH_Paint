using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IH_Paint
{
    public class FillBitmapCommand : ICommand
    {
        private Point _startPoint;
        private Color _replacementColor;
        private Color _targetColor; // Color to be replaced
        private DrawingState _drawingState;

        // For Undo: Store the state of the bitmap before the fill
        // This is memory intensive for large bitmaps!
        private byte[] _bitmapDataBefore;
        private Size _bitmapSize;
        private PixelFormat _pixelFormat;


        public FillBitmapCommand(Point startPoint, Color replacementColor, Color targetColor, DrawingState drawingState)
        {
            _startPoint = startPoint;
            _replacementColor = replacementColor;
            _targetColor = targetColor;
            _drawingState = drawingState;
        }

        public void Execute()
        {

            try
            {
                Bitmap canvasBitmap = _drawingState.GetCanvasBitmapDelegate?.Invoke();
                if (canvasBitmap == null)
                {
                    System.Diagnostics.Debug.WriteLine("FillCommand.Execute: canvasBitmap is null.");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"FillCommand.Execute: Starting fill. StartPoint: {_startPoint}, TargetColor: {_targetColor}, ReplacementColor: {_replacementColor}");

                // Store bitmap state for undo (make sure _pixelFormat is suitable or handle it)
                _bitmapSize = canvasBitmap.Size;
                _pixelFormat = canvasBitmap.PixelFormat;
                if (_pixelFormat == PixelFormat.Indexed || _pixelFormat == PixelFormat.Undefined || (int)_pixelFormat == 0) // (int)0 is sometimes seen for default
                {
                    System.Diagnostics.Debug.WriteLine($"FillCommand.Execute: Potentially problematic pixel format for direct byte copy: {_pixelFormat}. Undo might be unreliable if GetBitmapBytes fails.");
                    // For safety, you might want to create a temporary copy in Format32bppArgb for the fill operation
                    // and then copy it back, but that adds complexity. Let's see if GetBitmapBytes works.
                    try
                    {
                        _bitmapDataBefore = GetBitmapBytes(canvasBitmap);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"FillCommand.Execute: Error in GetBitmapBytes: {ex.Message}. Undo will not work.");
                        _bitmapDataBefore = null;
                    }
                }
                else
                {
                    _bitmapDataBefore = GetBitmapBytes(canvasBitmap);
                }
                System.Diagnostics.Debug.WriteLine($"FillBitmapCommand.Execute: Command execution started.");
                // Call the FloodFill method, passing the _targetColor we received
                FloodFill(canvasBitmap, _startPoint, _targetColor, _replacementColor);

                _drawingState.InvalidateCanvasDelegate?.Invoke();
                System.Diagnostics.Debug.WriteLine("FillCommand.Execute: Fill attempt finished.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FillCommand.Execute CRASH or ERROR: {ex.ToString()}");
                MessageBox.Show($"Fill Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Unexecute()
        {
            Bitmap canvasBitmap = _drawingState.GetCanvasBitmapDelegate?.Invoke();
            if (canvasBitmap == null || _bitmapDataBefore == null) return;

            // Restore bitmap from stored bytes
            SetBitmapBytes(canvasBitmap, _bitmapDataBefore);
            _drawingState.InvalidateCanvasDelegate?.Invoke();
        }
        private void FloodFill(Bitmap bmp, Point startNode, Color targetColor, Color replacementColor)
        {
            if (targetColor.ToArgb() == replacementColor.ToArgb()) 
            {
                return;
            }

            int width = bmp.Width;
            int height = bmp.Height;

            if (startNode.X < 0 || startNode.X >= width || startNode.Y < 0 || startNode.Y >= height)
            {
                return;
            }
            Color actualStartColor = bmp.GetPixel(startNode.X, startNode.Y);
            if (actualStartColor.ToArgb() != targetColor.ToArgb())
            {
                return; 
            }

            Queue<Point> q = new Queue<Point>();
            q.Enqueue(startNode);

            int processedPixels = 0;
            const int maxProcessedPixels = 5_000_000; 

            while (q.Count > 0)
            {
                if (processedPixels++ > maxProcessedPixels)
                {
                    break; 
                }

                Point current = q.Dequeue();
                if (current.X < 0 || current.X >= width || current.Y < 0 || current.Y >= height)
                    continue;

                if (bmp.GetPixel(current.X, current.Y).ToArgb() == targetColor.ToArgb())
                {
                    bmp.SetPixel(current.X, current.Y, replacementColor);

                    Point[] neighbors = new Point[] {
                new Point(current.X + 1, current.Y),
                new Point(current.X - 1, current.Y),
                new Point(current.X, current.Y + 1),
                new Point(current.X, current.Y - 1)
            };

                    foreach (Point neighbor in neighbors)
                    {
                        if (neighbor.X >= 0 && neighbor.X < width &&
                            neighbor.Y >= 0 && neighbor.Y < height &&
                            bmp.GetPixel(neighbor.X, neighbor.Y).ToArgb() == targetColor.ToArgb()) 
                        {
                            q.Enqueue(neighbor);
                        }
                    }
                }
            }
        }

        private byte[] GetBitmapBytes(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);
            bmp.UnlockBits(bmpData);
            return rgbValues;
        }

        private void SetBitmapBytes(Bitmap bmp, byte[] rgbValues)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, bmpData.Scan0, rgbValues.Length);
            bmp.UnlockBits(bmpData);
        }
        
    }
}
