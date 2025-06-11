using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IH_Paint
{
    public partial class MainForm : Form
    {
        private List<Shape> _shapes = new List<Shape>();
        private ITool _currentTool;
        private DrawingState _drawingState = new DrawingState();
        private HistoryManager _historyManager = new HistoryManager();
        private string _currentFilePath = null;
        private Bitmap _canvasBitmap; 
        private Button _activeColorButtonForDialog;
        public MainForm()
        {
            InitializeComponent();
            InitializePaintApp();
        }
        private void InitializePaintApp()
        {
            ResizeCanvas(new Size(800, 600)); 
            this.DoubleBuffered = true; 
            typeof(Panel).InvokeMember("DoubleBuffered", 
               System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
               null, drawingPanel, new object[] { true });
            _activeColorButtonForDialog = btnPrimaryColor;
            //drawingPanel events
            drawingPanel.Paint += drawingPanel_Paint;
            drawingPanel.MouseDown += drawingPanel_MouseDown;
            drawingPanel.MouseMove += drawingPanel_MouseMove;
            drawingPanel.MouseUp += drawingPanel_MouseUp;
            /*drawingPanel.MouseWheel += drawingPanel_MouseWheel; //Zoom*/

            _gbTextSettingsVisibleBacked = gbTextSettings.Visible;
            _drawingState.CurrentFont = new Font("Arial", 12);
            lblCurrentFont.Text = $"{_drawingState.CurrentFont.Name}, {_drawingState.CurrentFont.SizeInPoints}pt";

            // initialize DrawingState delegates
            _drawingState.ExecuteCommandDelegate = _historyManager.ExecuteCommand;
            _drawingState.ExecuteCommandDelegate = _historyManager.ExecuteCommand;
            _drawingState.InvalidateCanvasDelegate = () => drawingPanel.Invalidate();
            _drawingState.GetCurrentShapesDelegate = () => new List<Shape>(_shapes); 
            _drawingState.SetAllShapesDelegate = SetAllShapesInDocument;
            _drawingState.GetPixelColorDelegate = GetPixelFromCanvas;
            _drawingState.CanvasSize = _canvasBitmap.Size;
            _drawingState.ZoomFactor = 1.0f;
            _drawingState.PanOffset = Point.Empty;
            _drawingState.AddShapeToDocumentDelegate = this.AddShapeToDocument;         
            _drawingState.RemoveShapeFromDocumentDelegate = this.RemoveShapeFromDocument;

            _drawingState.ExecuteCommandDelegate = _historyManager.ExecuteCommand;
            _drawingState.InvalidateCanvasDelegate = () => drawingPanel.Invalidate();
            _drawingState.GetCurrentShapesDelegate = () => new List<Shape>(_shapes);
            _drawingState.GetCanvasBitmapDelegate = () => this._canvasBitmap;
            _drawingState.SetAllShapesDelegate = SetAllShapesInDocument;
            _drawingState.GetPixelColorDelegate = GetPixelFromCanvas;
            _drawingState.CanvasSize = _canvasBitmap.Size;
            _drawingState.ZoomFactor = 1.0f;
            _drawingState.PanOffset = Point.Empty;

                btnPrimaryColor.BackColor = Color.Black;
            btnSecondaryColor.BackColor = Color.White;
            UpdateDrawingStateFromUI();
            SetTool(new PencilTool()); 
            _historyManager.HistoryChanged += UpdateUndoRedoButtons;
            UpdateUndoRedoButtons();
            PopulateColorPalette();

            CenterDrawingPanelIfNecessary();
            drawingPanel.Resize += (s, e) => CenterDrawingPanelIfNecessary(); 
            UpdateDrawingStateFromUI();
        }
        private void ResizeCanvas(Size newSize)
        {
            Bitmap newBitmap = new Bitmap(newSize.Width, newSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); // Ensure Alpha for transparency
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.Clear(Color.White);
                if (_canvasBitmap != null)
                {
                    _canvasBitmap.Dispose();
                }
            }
            _canvasBitmap = newBitmap;
            drawingPanel.Size = _canvasBitmap.Size; 

            if (_drawingState != null) _drawingState.CanvasSize = _canvasBitmap.Size;
            lblCanvasSize.Text = $"Size: {newSize.Width}x{newSize.Height}"; // update status bar
            drawingPanel.Invalidate();
        }
        
        private void RemoveShapeFromDocument(Shape shape)
        {
            _shapes.Remove(shape);
        }
        private void AddShapeToDocument(Shape shape)
        {
            _shapes.Add(shape);
        }
        private void SetAllShapesInDocument(List<Shape> newShapesList)
        {
            _shapes = new List<Shape>(newShapesList); 
            drawingPanel.Invalidate();
        }

        private Color GetPixelFromCanvas(Point canvasLocation)
        {
            if (_canvasBitmap != null)
            {
                if (canvasLocation.X >= 0 && canvasLocation.X < _canvasBitmap.Width &&
                    canvasLocation.Y >= 0 && canvasLocation.Y < _canvasBitmap.Height)
                {
                    Color pixel = _canvasBitmap.GetPixel(canvasLocation.X, canvasLocation.Y);
                    System.Diagnostics.Debug.WriteLine($"GetPixelFromCanvas: At ({canvasLocation.X},{canvasLocation.Y}), got color {pixel} from _canvasBitmap.");
                    return pixel;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"GetPixelFromCanvas: Location ({canvasLocation.X},{canvasLocation.Y}) is OUTSIDE _canvasBitmap bounds ({_canvasBitmap.Width}x{_canvasBitmap.Height}). Returning Transparent.");
                    return Color.Transparent;
                }
            }
            System.Diagnostics.Debug.WriteLine("GetPixelFromCanvas: _canvasBitmap is null. Returning Transparent.");
            return Color.Transparent; 
        }
        private void PopulateColorPalette()
        {
            Color[] commonColors = { Color.Black, Color.Gray, Color.Maroon, Color.Red, Color.Green, Color.Lime,
                                     Color.Navy, Color.Blue, Color.Purple, Color.Fuchsia, Color.Teal, Color.Aqua,
                                     Color.Olive, Color.Yellow, Color.White, Color.Silver };

            flpColorPalette.Controls.Clear();
            foreach (Color color in commonColors)
            {
                Panel colorPanel = new Panel
                {
                    Size = new Size(20, 20),
                    BackColor = color,
                    Margin = new Padding(2),
                    BorderStyle = BorderStyle.FixedSingle
                };
                colorPanel.MouseClick += (s, ev) =>
                {
                    Panel clickedPalettePanel = s as Panel;
                    if (ev.Button == MouseButtons.Left)
                    {
                        btnPrimaryColor.BackColor = clickedPalettePanel.BackColor;
                    }
                    else if (ev.Button == MouseButtons.Right)
                    {
                        btnSecondaryColor.BackColor = clickedPalettePanel.BackColor;
                    }
                    UpdateDrawingStateFromUI();
                };
                flpColorPalette.Controls.Add(colorPanel); 
            }
        }
        private bool _gbTextSettingsVisibleBacked;
        private bool GbTextSettingsVisible_WithLogging
        {
            get { return _gbTextSettingsVisibleBacked; }
            set
            {
                if (_gbTextSettingsVisibleBacked != value)
                {
                    Debug.WriteLine($"Changing gbTextSettings.Visible from {_gbTextSettingsVisibleBacked} to {value}. StackTrace: {Environment.StackTrace}");
                    _gbTextSettingsVisibleBacked = value;
                    gbTextSettings.Visible = _gbTextSettingsVisibleBacked; 
                }
            }
        }
        private void SetTool(ITool newTool)
        {
            _currentTool?.Deactivate(_drawingState);
            _currentTool = newTool;
            _currentTool.Activate(_drawingState); 
            UpdateUIToReflectTool();
            drawingPanel.Cursor = _currentTool.ToolCursor;
            lblCurrentTool.Text = $"Tool: {_currentTool.Name}";
        }
        private void UpdateUIToReflectTool()
        {
            if (_currentTool is TextTool)
            {
                GbTextSettingsVisible_WithLogging = true;
            }
            else
            {
                GbTextSettingsVisible_WithLogging = false;
            }
        }
        private void UpdateUndoRedoButtons()
        {
            undoToolStripMenuItem.Enabled = _historyManager.CanUndo;
            redoToolStripMenuItem.Enabled = _historyManager.CanRedo;
        }
        private void CenterDrawingPanelIfNecessary()
        {
            if (drawingPanel.Parent != null &&
                (drawingPanel.Width < drawingPanel.Parent.ClientSize.Width ||
                 drawingPanel.Height < drawingPanel.Parent.ClientSize.Height))
            {
                int x = (drawingPanel.Parent.ClientSize.Width - drawingPanel.Width) / 2;
                int y = (drawingPanel.Parent.ClientSize.Height - drawingPanel.Height) / 2;
                drawingPanel.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }
            else if (drawingPanel.Parent != null && (drawingPanel.Location.X < 0 || drawingPanel.Location.Y < 0))
            {
                drawingPanel.Location = new Point(Math.Max(0, drawingPanel.Location.X), Math.Max(0, drawingPanel.Location.Y));
            }
        }
        private void CenterDrawingPanel()
        {
            if (drawingPanel == null || toolStripContainerMain == null) return;

            int x = (toolStripContainerMain.ContentPanel.Width - drawingPanel.Width) / 2;
            int y = (toolStripContainerMain.ContentPanel.Height - drawingPanel.Height) / 2;
            drawingPanel.Location = new Point(Math.Max(0, x), Math.Max(0, y));
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterDrawingPanel();
            btnPrimaryColor.BackColor = Color.Black;
            btnSecondaryColor.BackColor = Color.White;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (drawingPanel.Width < toolStripContainerMain.ContentPanel.Width ||
                drawingPanel.Height < toolStripContainerMain.ContentPanel.Height)
            {
                CenterDrawingPanel();
            }
        }

        private void btnPencil_Click(object sender, EventArgs e)
        {
            SetTool(new PencilTool());
        }
        private void shapeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTool(new ShapeTool<LineShape>());
        }
        private void shapeRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTool(new ShapeTool<RectangleShape>());
        }
        private void UpdateDrawingStateFromUI()
        {
            if (_drawingState == null) _drawingState = new DrawingState();
            _drawingState.PrimaryColor = btnPrimaryColor.BackColor;
            _drawingState.SecondaryColor = btnSecondaryColor.BackColor;
            _drawingState.PenWidth = (float)numThickness.Value;
            _drawingState.CurrentFont = fontDialogMain.Font;
        }
        private void btnPrimaryColor_Click(object sender, EventArgs e)
        {
            colorDialogMain.Color = btnPrimaryColor.BackColor;
            if (colorDialogMain.ShowDialog() == DialogResult.OK)
            {
                btnPrimaryColor.BackColor = colorDialogMain.Color; 
                UpdateDrawingStateFromUI();
            }
        }
        
        private void btnSecondaryColor_Click(object sender, EventArgs e)
        {
            colorDialogMain.Color = btnSecondaryColor.BackColor;
            if (colorDialogMain.ShowDialog() == DialogResult.OK)
            {
                btnSecondaryColor.BackColor = colorDialogMain.Color; 
                UpdateDrawingStateFromUI();
            }
        }

        private void numThickness_ValueChanged(object sender, EventArgs e)
        {
            UpdateDrawingStateFromUI();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapes.Clear();
            _historyManager.ClearHistory(); 
            _currentFilePath = null; 
            this.Text = "Untitled"; 
            
            Size defaultCanvasSize = new Size(800, 600);
            ResizeCanvas(defaultCanvasSize); 

            _drawingState.ZoomFactor = 1.0f;
            _drawingState.PanOffset = Point.Empty;
            /*lblZoomLevelStatus.Text = $"Zoom: {(_drawingState.ZoomFactor * 100):F0}%";*/

            drawingPanel.Invalidate();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _historyManager.Undo();
            drawingPanel.Invalidate(); 
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _historyManager.Redo();
            drawingPanel.Invalidate(); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_canvasBitmap != null && _shapes != null)
            {
                using (Graphics canvasGraphics = Graphics.FromImage(_canvasBitmap))
                {
                    canvasGraphics.Clear(Color.White); 
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias; 
                    foreach (Shape shape in _shapes)
                    {
                        shape.Draw(canvasGraphics);
                    }
                }
            }
            e.Graphics.Clear(drawingPanel.BackColor);
            e.Graphics.ResetTransform();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            e.Graphics.TranslateTransform(-_drawingState.PanOffset.X, -_drawingState.PanOffset.Y); 
            e.Graphics.ScaleTransform(_drawingState.ZoomFactor, _drawingState.ZoomFactor);    

            if (_canvasBitmap != null)
            {
                e.Graphics.DrawImageUnscaled(_canvasBitmap, 0, 0);
            }

            _currentTool?.PaintPreview(e.Graphics, _drawingState); // Preview will also be on unzoomed graphics
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentTool != null)
            {
                _currentTool.OnMouseDown(e.Location, e.Button, _drawingState);
                drawingPanel.Focus(); //focus for keyboard events if any
            }
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Point worldMousePos = _drawingState.ScreenToWorld(e.Location);
            lblMouseCoords.Text = $"X: {worldMousePos.X}, Y: {worldMousePos.Y}";

            if (_currentTool != null)
            {
                _currentTool.OnMouseMove(e.Location, e.Button, _drawingState);
            }
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentTool != null)
            {
                _currentTool.OnMouseUp(e.Location, e.Button, _drawingState);
            }
        }
        private void drawingPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            /*PointF screenMouseAtZoom = e.Location;
            float oldZoom = _drawingState.ZoomFactor;
            float newZoom = oldZoom * ((e.Delta > 0) ? 1.1f : (1.0f / 1.1f));
            newZoom = Math.Max(0.1f, Math.Min(newZoom, 10.0f));
            PointF oldPan = _drawingState.PanOffset;
            float newPanX = oldPan.X + (screenMouseAtZoom.X / oldZoom) - (screenMouseAtZoom.X / newZoom);
            float newPanY = oldPan.Y + (screenMouseAtZoom.Y / oldZoom) - (screenMouseAtZoom.Y / newZoom);
            _drawingState.ZoomFactor = newZoom;
            _drawingState.PanOffset = new PointF(newPanX, newPanY);
            System.Diagnostics.Debug.WriteLine($"MouseWheel: ZF={_drawingState.ZoomFactor:F4}, NewPO=({_drawingState.PanOffset.X:F2},{_drawingState.PanOffset.Y:F2}) | ScreenMouse=({screenMouseAtZoom.X},{screenMouseAtZoom.Y})");
            lblZoomLevelStatus.Text = $"Zoom: {(_drawingState.ZoomFactor * 100):F0}%";
            drawingPanel.Invalidate();*/
        }

        private void btnEraser_Click(object sender, EventArgs e) 
        {
            SetTool(new EraserTool());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                // If no current path, behave like "Save As"
                saveasToolStripMenuItem_Click(sender, e);
            }
            else
            {
                try
                {
                    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                    string ext = System.IO.Path.GetExtension(_currentFilePath).ToLower();
                    if (ext == ".jpg" || ext == ".jpeg") format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    else if (ext == ".bmp") format = System.Drawing.Imaging.ImageFormat.Bmp;
                    else if (ext == ".gif") format = System.Drawing.Imaging.ImageFormat.Gif;

                    _canvasBitmap.Save(_currentFilePath, format);
                    this.Text = $"Untitled - {System.IO.Path.GetFileName(_currentFilePath)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogMain.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif";
            saveFileDialogMain.Title = "Save an Image File";
            saveFileDialogMain.DefaultExt = "png";
            saveFileDialogMain.FileName = string.IsNullOrEmpty(_currentFilePath) ? "Untitled" : System.IO.Path.GetFileName(_currentFilePath);


            if (saveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(saveFileDialogMain.FileName))
                {
                    _currentFilePath = saveFileDialogMain.FileName;
                    saveToolStripMenuItem_Click(sender, e); 
                }
            }
        }

        private void shapeEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTool(new ShapeTool<EllipseShape>());
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            SetTool(new FillTool());
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            fontDialogMain.Font = _drawingState.CurrentFont;
            if (fontDialogMain.ShowDialog() == DialogResult.OK)
            {
                _drawingState.CurrentFont = fontDialogMain.Font;
                lblCurrentFont.Text = $"{_drawingState.CurrentFont.Name}, {_drawingState.CurrentFont.SizeInPoints}pt"; // update UI
                UpdateDrawingStateFromUI(); 
            }
        }
        
        private void btnTextTool_Click(object sender, EventArgs e)
        {
            SetTool(new TextTool());
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogMain.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            openFileDialogMain.Title = "Open Image";
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialogMain.FileName;
                    Bitmap loadedBitmap = new Bitmap(filePath);

                    //  common format 32bppArgb.
                    if (loadedBitmap.PixelFormat == PixelFormat.Format8bppIndexed ||
                        loadedBitmap.PixelFormat == PixelFormat.Format4bppIndexed ||
                        loadedBitmap.PixelFormat == PixelFormat.Format1bppIndexed)
                    {
                        Bitmap tempBitmap = new Bitmap(loadedBitmap.Width, loadedBitmap.Height, PixelFormat.Format32bppArgb);
                        using (Graphics g = Graphics.FromImage(tempBitmap))
                        {
                            g.DrawImage(loadedBitmap, 0, 0);
                        }
                        loadedBitmap.Dispose(); 
                        loadedBitmap = tempBitmap; 
                    }


                    _shapes.Clear(); 
                    _historyManager.ClearHistory();
                    _currentFilePath = filePath; // new path
                    this.Text = $"Untitled - {System.IO.Path.GetFileName(filePath)}";

                    
                    _canvasBitmap?.Dispose();
                    _canvasBitmap = loadedBitmap;

                    
                    drawingPanel.Size = _canvasBitmap.Size;
                    _drawingState.CanvasSize = _canvasBitmap.Size;
                    lblCanvasSize.Text = $"Size: {_canvasBitmap.Width}x{_canvasBitmap.Height}";

                    // reset zoom and pan
                    _drawingState.ZoomFactor = 1.0f;
                    _drawingState.PanOffset = Point.Empty;
                    actualSize100ToolStripMenuItem_Click(this, EventArgs.Empty); // to apply 100% and centering

                    drawingPanel.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening image: {ex.Message}", "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void brushNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTool(new NormalBrushTool());
        }

        private void brushCalligraphyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTool(new CalligraphyPenTool() { NibAngle = 45f });
        }

        private void brushAirbrushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTool(new AirbrushTool() { Density = 15, SpreadRadius = (int)_drawingState.PenWidth * 2 });
        }
    }
}
