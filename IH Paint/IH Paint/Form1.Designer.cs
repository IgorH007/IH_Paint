namespace IH_Paint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Panel = new System.Windows.Forms.Panel();
            this.toolMainStrip = new System.Windows.Forms.ToolStrip();
            this.btnPencil = new System.Windows.Forms.ToolStripButton();
            this.btnBrushes = new System.Windows.Forms.ToolStripDropDownButton();
            this.brushNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brushCalligraphyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brushAirbrushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.btnShapes = new System.Windows.Forms.ToolStripDropDownButton();
            this.shapeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapeRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapeEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFill = new System.Windows.Forms.ToolStripButton();
            this.btnTextTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainerMain = new System.Windows.Forms.ToolStripContainer();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblMouseCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCanvasSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentTool = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblZoomLevelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.gbBrushSettings = new System.Windows.Forms.GroupBox();
            this.numThickness = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.gbTextSettings = new System.Windows.Forms.GroupBox();
            this.lblCurrentFont = new System.Windows.Forms.Label();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.gbColors = new System.Windows.Forms.GroupBox();
            this.flpColorPalette = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSecondaryColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrimaryColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualSize100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialogMain = new System.Windows.Forms.ColorDialog();
            this.fontDialogMain = new System.Windows.Forms.FontDialog();
            this.openFileDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.Panel.SuspendLayout();
            this.toolMainStrip.SuspendLayout();
            this.toolStripContainerMain.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.ContentPanel.SuspendLayout();
            this.toolStripContainerMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.gbBrushSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).BeginInit();
            this.gbTextSettings.SuspendLayout();
            this.gbColors.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.AllowDrop = true;
            this.Panel.Controls.Add(this.toolMainStrip);
            this.Panel.Controls.Add(this.toolStripContainerMain);
            this.Panel.Controls.Add(this.menuStrip1);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1014, 564);
            this.Panel.TabIndex = 0;
            // 
            // toolMainStrip
            // 
            this.toolMainStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPencil,
            this.btnBrushes,
            this.btnEraser,
            this.btnShapes,
            this.btnFill,
            this.btnTextTool});
            this.toolMainStrip.Location = new System.Drawing.Point(235, 24);
            this.toolMainStrip.Name = "toolMainStrip";
            this.toolMainStrip.Size = new System.Drawing.Size(358, 25);
            this.toolMainStrip.TabIndex = 0;
            this.toolMainStrip.Text = "toolStrip1";
            // 
            // btnPencil
            // 
            this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
            this.btnPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(59, 22);
            this.btnPencil.Text = "Pencil";
            this.btnPencil.ToolTipText = "Draw freehand lines";
            this.btnPencil.Click += new System.EventHandler(this.btnPencil_Click);
            // 
            // btnBrushes
            // 
            this.btnBrushes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushNormalToolStripMenuItem,
            this.brushCalligraphyToolStripMenuItem,
            this.brushAirbrushToolStripMenuItem});
            this.btnBrushes.Image = ((System.Drawing.Image)(resources.GetObject("btnBrushes.Image")));
            this.btnBrushes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBrushes.Name = "btnBrushes";
            this.btnBrushes.Size = new System.Drawing.Size(66, 22);
            this.btnBrushes.Text = "Brush";
            // 
            // brushNormalToolStripMenuItem
            // 
            this.brushNormalToolStripMenuItem.Name = "brushNormalToolStripMenuItem";
            this.brushNormalToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.brushNormalToolStripMenuItem.Text = "Normal Brush";
            this.brushNormalToolStripMenuItem.Click += new System.EventHandler(this.brushNormalToolStripMenuItem_Click);
            // 
            // brushCalligraphyToolStripMenuItem
            // 
            this.brushCalligraphyToolStripMenuItem.Name = "brushCalligraphyToolStripMenuItem";
            this.brushCalligraphyToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.brushCalligraphyToolStripMenuItem.Text = "Calligraphy";
            this.brushCalligraphyToolStripMenuItem.Click += new System.EventHandler(this.brushCalligraphyToolStripMenuItem_Click);
            // 
            // brushAirbrushToolStripMenuItem
            // 
            this.brushAirbrushToolStripMenuItem.Name = "brushAirbrushToolStripMenuItem";
            this.brushAirbrushToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.brushAirbrushToolStripMenuItem.Text = "Airbrush";
            this.brushAirbrushToolStripMenuItem.Click += new System.EventHandler(this.brushAirbrushToolStripMenuItem_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
            this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(58, 22);
            this.btnEraser.Text = "Eraser";
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnShapes
            // 
            this.btnShapes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shapeLineToolStripMenuItem,
            this.shapeRectangleToolStripMenuItem,
            this.shapeEllipseToolStripMenuItem});
            this.btnShapes.Image = ((System.Drawing.Image)(resources.GetObject("btnShapes.Image")));
            this.btnShapes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShapes.Name = "btnShapes";
            this.btnShapes.Size = new System.Drawing.Size(73, 22);
            this.btnShapes.Text = "Shapes";
            // 
            // shapeLineToolStripMenuItem
            // 
            this.shapeLineToolStripMenuItem.Name = "shapeLineToolStripMenuItem";
            this.shapeLineToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.shapeLineToolStripMenuItem.Text = "Line";
            this.shapeLineToolStripMenuItem.Click += new System.EventHandler(this.shapeLineToolStripMenuItem_Click);
            // 
            // shapeRectangleToolStripMenuItem
            // 
            this.shapeRectangleToolStripMenuItem.Name = "shapeRectangleToolStripMenuItem";
            this.shapeRectangleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.shapeRectangleToolStripMenuItem.Text = "Rectangle";
            this.shapeRectangleToolStripMenuItem.Click += new System.EventHandler(this.shapeRectangleToolStripMenuItem_Click);
            // 
            // shapeEllipseToolStripMenuItem
            // 
            this.shapeEllipseToolStripMenuItem.Name = "shapeEllipseToolStripMenuItem";
            this.shapeEllipseToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.shapeEllipseToolStripMenuItem.Text = "Ellipse";
            this.shapeEllipseToolStripMenuItem.Click += new System.EventHandler(this.shapeEllipseToolStripMenuItem_Click);
            // 
            // btnFill
            // 
            this.btnFill.Image = ((System.Drawing.Image)(resources.GetObject("btnFill.Image")));
            this.btnFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(42, 22);
            this.btnFill.Text = "Fill";
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnTextTool
            // 
            this.btnTextTool.Image = ((System.Drawing.Image)(resources.GetObject("btnTextTool.Image")));
            this.btnTextTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTextTool.Name = "btnTextTool";
            this.btnTextTool.Size = new System.Drawing.Size(48, 22);
            this.btnTextTool.Text = "Text";
            this.btnTextTool.Click += new System.EventHandler(this.btnTextTool_Click);
            // 
            // toolStripContainerMain
            // 
            // 
            // toolStripContainerMain.BottomToolStripPanel
            // 
            this.toolStripContainerMain.BottomToolStripPanel.Controls.Add(this.statusStripMain);
            // 
            // toolStripContainerMain.ContentPanel
            // 
            this.toolStripContainerMain.ContentPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripContainerMain.ContentPanel.Controls.Add(this.drawingPanel);
            this.toolStripContainerMain.ContentPanel.Controls.Add(this.optionsPanel);
            this.toolStripContainerMain.ContentPanel.Size = new System.Drawing.Size(1014, 493);
            this.toolStripContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainerMain.Name = "toolStripContainerMain";
            this.toolStripContainerMain.Size = new System.Drawing.Size(1014, 540);
            this.toolStripContainerMain.TabIndex = 1;
            this.toolStripContainerMain.Text = "toolStripContainer1";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMouseCoords,
            this.lblCanvasSize,
            this.lblCurrentTool,
            this.lblZoomLevelStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 0);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1014, 22);
            this.statusStripMain.TabIndex = 0;
            // 
            // lblMouseCoords
            // 
            this.lblMouseCoords.Name = "lblMouseCoords";
            this.lblMouseCoords.Size = new System.Drawing.Size(51, 17);
            this.lblMouseCoords.Text = "X: 0, Y: 0";
            // 
            // lblCanvasSize
            // 
            this.lblCanvasSize.Name = "lblCanvasSize";
            this.lblCanvasSize.Size = new System.Drawing.Size(54, 17);
            this.lblCanvasSize.Text = "1000x800";
            // 
            // lblCurrentTool
            // 
            this.lblCurrentTool.Name = "lblCurrentTool";
            this.lblCurrentTool.Size = new System.Drawing.Size(65, 17);
            this.lblCurrentTool.Text = "Tool:Pencil";
            // 
            // lblZoomLevelStatus
            // 
            this.lblZoomLevelStatus.Name = "lblZoomLevelStatus";
            this.lblZoomLevelStatus.Size = new System.Drawing.Size(73, 17);
            this.lblZoomLevelStatus.Text = "Zoom: 100%";
            // 
            // drawingPanel
            // 
            this.drawingPanel.AutoScroll = true;
            this.drawingPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingPanel.Location = new System.Drawing.Point(241, 47);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1000, 800);
            this.drawingPanel.TabIndex = 3;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            this.drawingPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseWheel);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.gbBrushSettings);
            this.optionsPanel.Controls.Add(this.gbTextSettings);
            this.optionsPanel.Controls.Add(this.gbColors);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(235, 493);
            this.optionsPanel.TabIndex = 1;
            // 
            // gbBrushSettings
            // 
            this.gbBrushSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBrushSettings.Controls.Add(this.numThickness);
            this.gbBrushSettings.Controls.Add(this.label3);
            this.gbBrushSettings.Location = new System.Drawing.Point(0, 139);
            this.gbBrushSettings.Name = "gbBrushSettings";
            this.gbBrushSettings.Size = new System.Drawing.Size(232, 60);
            this.gbBrushSettings.TabIndex = 1;
            this.gbBrushSettings.TabStop = false;
            this.gbBrushSettings.Text = "Brush/Line";
            // 
            // numThickness
            // 
            this.numThickness.Location = new System.Drawing.Point(6, 32);
            this.numThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThickness.Name = "numThickness";
            this.numThickness.Size = new System.Drawing.Size(120, 20);
            this.numThickness.TabIndex = 1;
            this.numThickness.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numThickness.ValueChanged += new System.EventHandler(this.numThickness_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thickness";
            // 
            // gbTextSettings
            // 
            this.gbTextSettings.Controls.Add(this.lblCurrentFont);
            this.gbTextSettings.Controls.Add(this.btnSelectFont);
            this.gbTextSettings.Location = new System.Drawing.Point(12, 205);
            this.gbTextSettings.Name = "gbTextSettings";
            this.gbTextSettings.Size = new System.Drawing.Size(170, 41);
            this.gbTextSettings.TabIndex = 2;
            this.gbTextSettings.TabStop = false;
            this.gbTextSettings.Text = "Text Tool";
            this.gbTextSettings.Visible = false;
            // 
            // lblCurrentFont
            // 
            this.lblCurrentFont.Location = new System.Drawing.Point(87, 12);
            this.lblCurrentFont.Name = "lblCurrentFont";
            this.lblCurrentFont.Size = new System.Drawing.Size(100, 23);
            this.lblCurrentFont.TabIndex = 1;
            this.lblCurrentFont.Text = "Arial, 12pt";
            // 
            // btnSelectFont
            // 
            this.btnSelectFont.Location = new System.Drawing.Point(6, 12);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFont.TabIndex = 0;
            this.btnSelectFont.Text = "Font...";
            this.btnSelectFont.UseVisualStyleBackColor = true;
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);
            // 
            // gbColors
            // 
            this.gbColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbColors.Controls.Add(this.flpColorPalette);
            this.gbColors.Controls.Add(this.btnSecondaryColor);
            this.gbColors.Controls.Add(this.label2);
            this.gbColors.Controls.Add(this.btnPrimaryColor);
            this.gbColors.Controls.Add(this.label1);
            this.gbColors.Location = new System.Drawing.Point(0, 0);
            this.gbColors.Name = "gbColors";
            this.gbColors.Size = new System.Drawing.Size(235, 136);
            this.gbColors.TabIndex = 0;
            this.gbColors.TabStop = false;
            this.gbColors.Text = "Colors";
            // 
            // flpColorPalette
            // 
            this.flpColorPalette.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpColorPalette.Location = new System.Drawing.Point(68, 16);
            this.flpColorPalette.Name = "flpColorPalette";
            this.flpColorPalette.Size = new System.Drawing.Size(164, 117);
            this.flpColorPalette.TabIndex = 4;
            // 
            // btnSecondaryColor
            // 
            this.btnSecondaryColor.Location = new System.Drawing.Point(9, 81);
            this.btnSecondaryColor.Name = "btnSecondaryColor";
            this.btnSecondaryColor.Size = new System.Drawing.Size(30, 30);
            this.btnSecondaryColor.TabIndex = 3;
            this.btnSecondaryColor.UseVisualStyleBackColor = true;
            this.btnSecondaryColor.Visible = false;
            this.btnSecondaryColor.Click += new System.EventHandler(this.btnSecondaryColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Secondary";
            this.label2.Visible = false;
            // 
            // btnPrimaryColor
            // 
            this.btnPrimaryColor.Location = new System.Drawing.Point(9, 32);
            this.btnPrimaryColor.Name = "btnPrimaryColor";
            this.btnPrimaryColor.Size = new System.Drawing.Size(30, 30);
            this.btnPrimaryColor.TabIndex = 1;
            this.btnPrimaryColor.UseVisualStyleBackColor = true;
            this.btnPrimaryColor.Click += new System.EventHandler(this.btnPrimaryColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1014, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveasToolStripMenuItem.Text = "Save &as...";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.actualSize100ToolStripMenuItem,
            this.canvasSizeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom &In";
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom &Out";
            // 
            // actualSize100ToolStripMenuItem
            // 
            this.actualSize100ToolStripMenuItem.Name = "actualSize100ToolStripMenuItem";
            this.actualSize100ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.actualSize100ToolStripMenuItem.Text = "&Actual Size (100%)";
            this.actualSize100ToolStripMenuItem.Click += new System.EventHandler(this.actualSize100ToolStripMenuItem_Click);
            // 
            // canvasSizeToolStripMenuItem
            // 
            this.canvasSizeToolStripMenuItem.Name = "canvasSizeToolStripMenuItem";
            this.canvasSizeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.canvasSizeToolStripMenuItem.Text = "&Canvas Size...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // openFileDialogMain
            // 
            this.openFileDialogMain.FileName = "openFileDialog1";
            this.openFileDialogMain.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.";
            this.openFileDialogMain.Title = "Open Image";
            // 
            // saveFileDialogMain
            // 
            this.saveFileDialogMain.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.";
            this.saveFileDialogMain.Title = "Save Image As";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 564);
            this.Controls.Add(this.Panel);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Paint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.toolMainStrip.ResumeLayout(false);
            this.toolMainStrip.PerformLayout();
            this.toolStripContainerMain.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.BottomToolStripPanel.PerformLayout();
            this.toolStripContainerMain.ContentPanel.ResumeLayout(false);
            this.toolStripContainerMain.ResumeLayout(false);
            this.toolStripContainerMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.gbBrushSettings.ResumeLayout(false);
            this.gbBrushSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).EndInit();
            this.gbTextSettings.ResumeLayout(false);
            this.gbColors.ResumeLayout(false);
            this.gbColors.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualSize100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainerMain;
        private System.Windows.Forms.ToolStrip toolMainStrip;
        private System.Windows.Forms.ToolStripButton btnPencil;
        private System.Windows.Forms.ToolStripDropDownButton btnBrushes;
        private System.Windows.Forms.ToolStripMenuItem brushNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brushCalligraphyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brushAirbrushToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnEraser;
        private System.Windows.Forms.ToolStripDropDownButton btnShapes;
        private System.Windows.Forms.ToolStripMenuItem shapeLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapeRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapeEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnFill;
        private System.Windows.Forms.ToolStripButton btnTextTool;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.GroupBox gbColors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbBrushSettings;
        private System.Windows.Forms.NumericUpDown numThickness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpColorPalette;
        private System.Windows.Forms.Button btnSecondaryColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrimaryColor;
        private System.Windows.Forms.GroupBox gbTextSettings;
        private System.Windows.Forms.Label lblCurrentFont;
        private System.Windows.Forms.Button btnSelectFont;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblMouseCoords;
        private System.Windows.Forms.ToolStripStatusLabel lblCanvasSize;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTool;
        private System.Windows.Forms.ToolStripStatusLabel lblZoomLevelStatus;
        private System.Windows.Forms.ColorDialog colorDialogMain;
        private System.Windows.Forms.FontDialog fontDialogMain;
        private System.Windows.Forms.OpenFileDialog openFileDialogMain;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMain;
        private System.Windows.Forms.ToolStripMenuItem canvasSizeToolStripMenuItem;
    }
}

