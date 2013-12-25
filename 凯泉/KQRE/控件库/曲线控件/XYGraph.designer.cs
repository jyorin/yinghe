namespace 控件库.曲线控件
{
    partial class XYGraph
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelItemShuoMing = new System.Windows.Forms.Label();
            this.panelBigXY = new System.Windows.Forms.Panel();
            this.buttonBigXYBig = new System.Windows.Forms.Button();
            this.buttonBigXYQuit = new System.Windows.Forms.Button();
            this.pictureBoxBigXY = new System.Windows.Forms.PictureBox();
            this.MenuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBoxX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.网格显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大选取框功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标自动调整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认坐标范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slide = new NationalInstruments.UI.WindowsForms.Slide();
            this.panel_itemsIN = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_切换Y轴 = new System.Windows.Forms.Button();
            this.BTN_停止显示 = new System.Windows.Forms.Button();
            this.buttonReXY = new System.Windows.Forms.Button();
            this.buttonModeXY = new System.Windows.Forms.Button();
            this.buttonBigModeXY = new System.Windows.Forms.Button();
            this.buttonLinesShowXY = new System.Windows.Forms.Button();
            this.btn_调整坐标轴 = new System.Windows.Forms.Button();
            this.legend1 = new NationalInstruments.UI.WindowsForms.Legend();
            this.xAxis_Looking = new NationalInstruments.UI.XAxis();
            this.Graph_View = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.xyCursorB = new NationalInstruments.UI.XYCursor();
            this.scatterPlot2 = new NationalInstruments.UI.ScatterPlot();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.xyCursorE = new NationalInstruments.UI.XYCursor();
            this.panel_text = new System.Windows.Forms.Panel();
            this.panelBigXY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigXY)).BeginInit();
            this.MenuRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slide)).BeginInit();
            this.panel_itemsIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legend1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xyCursorB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xyCursorE)).BeginInit();
            this.SuspendLayout();
            // 
            // labelItemShuoMing
            // 
            this.labelItemShuoMing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemShuoMing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.labelItemShuoMing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelItemShuoMing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelItemShuoMing.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelItemShuoMing.ForeColor = System.Drawing.Color.White;
            this.labelItemShuoMing.Location = new System.Drawing.Point(868, 518);
            this.labelItemShuoMing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemShuoMing.Name = "labelItemShuoMing";
            this.labelItemShuoMing.Size = new System.Drawing.Size(149, 47);
            this.labelItemShuoMing.TabIndex = 10;
            this.labelItemShuoMing.Text = "说明";
            this.labelItemShuoMing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelItemShuoMing.Visible = false;
            // 
            // panelBigXY
            // 
            this.panelBigXY.BackColor = System.Drawing.Color.Transparent;
            this.panelBigXY.Controls.Add(this.buttonBigXYBig);
            this.panelBigXY.Controls.Add(this.buttonBigXYQuit);
            this.panelBigXY.Location = new System.Drawing.Point(650, 327);
            this.panelBigXY.Margin = new System.Windows.Forms.Padding(4);
            this.panelBigXY.Name = "panelBigXY";
            this.panelBigXY.Size = new System.Drawing.Size(171, 48);
            this.panelBigXY.TabIndex = 16;
            this.panelBigXY.Visible = false;
            // 
            // buttonBigXYBig
            // 
            this.buttonBigXYBig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigXYBig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonBigXYBig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBigXYBig.ForeColor = System.Drawing.Color.Black;
            this.buttonBigXYBig.Location = new System.Drawing.Point(32, 14);
            this.buttonBigXYBig.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBigXYBig.Name = "buttonBigXYBig";
            this.buttonBigXYBig.Size = new System.Drawing.Size(70, 34);
            this.buttonBigXYBig.TabIndex = 13;
            this.buttonBigXYBig.TabStop = false;
            this.buttonBigXYBig.Text = "放大";
            this.buttonBigXYBig.UseVisualStyleBackColor = false;
            this.buttonBigXYBig.Click += new System.EventHandler(this.buttonBigXYBig_Click);
            // 
            // buttonBigXYQuit
            // 
            this.buttonBigXYQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigXYQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonBigXYQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBigXYQuit.ForeColor = System.Drawing.Color.Black;
            this.buttonBigXYQuit.Location = new System.Drawing.Point(104, 14);
            this.buttonBigXYQuit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBigXYQuit.Name = "buttonBigXYQuit";
            this.buttonBigXYQuit.Size = new System.Drawing.Size(66, 34);
            this.buttonBigXYQuit.TabIndex = 12;
            this.buttonBigXYQuit.TabStop = false;
            this.buttonBigXYQuit.Text = "取消";
            this.buttonBigXYQuit.UseVisualStyleBackColor = false;
            this.buttonBigXYQuit.Click += new System.EventHandler(this.buttonBigXYQuit_Click);
            // 
            // pictureBoxBigXY
            // 
            this.pictureBoxBigXY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBoxBigXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBigXY.ErrorImage = null;
            this.pictureBoxBigXY.InitialImage = null;
            this.pictureBoxBigXY.Location = new System.Drawing.Point(650, 327);
            this.pictureBoxBigXY.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxBigXY.Name = "pictureBoxBigXY";
            this.pictureBoxBigXY.Size = new System.Drawing.Size(170, 47);
            this.pictureBoxBigXY.TabIndex = 15;
            this.pictureBoxBigXY.TabStop = false;
            this.pictureBoxBigXY.Visible = false;
            // 
            // MenuRightClick
            // 
            this.MenuRightClick.BackColor = System.Drawing.Color.White;
            this.MenuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxX,
            this.toolStripTextBoxY,
            this.toolStripSeparator1,
            this.网格显示ToolStripMenuItem,
            this.放大选取框功能ToolStripMenuItem,
            this.坐标自动调整ToolStripMenuItem,
            this.默认坐标范围ToolStripMenuItem});
            this.MenuRightClick.Name = "MenuRightClick";
            this.MenuRightClick.Size = new System.Drawing.Size(207, 174);
            // 
            // toolStripTextBoxX
            // 
            this.toolStripTextBoxX.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.toolStripTextBoxX.Name = "toolStripTextBoxX";
            this.toolStripTextBoxX.ReadOnly = true;
            this.toolStripTextBoxX.Size = new System.Drawing.Size(100, 24);
            this.toolStripTextBoxX.Text = "0";
            // 
            // toolStripTextBoxY
            // 
            this.toolStripTextBoxY.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBoxY.ForeColor = System.Drawing.Color.Black;
            this.toolStripTextBoxY.Name = "toolStripTextBoxY";
            this.toolStripTextBoxY.ReadOnly = true;
            this.toolStripTextBoxY.Size = new System.Drawing.Size(100, 24);
            this.toolStripTextBoxY.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // 网格显示ToolStripMenuItem
            // 
            this.网格显示ToolStripMenuItem.Checked = true;
            this.网格显示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.网格显示ToolStripMenuItem.Name = "网格显示ToolStripMenuItem";
            this.网格显示ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.网格显示ToolStripMenuItem.Text = "网格显示";
            // 
            // 放大选取框功能ToolStripMenuItem
            // 
            this.放大选取框功能ToolStripMenuItem.Name = "放大选取框功能ToolStripMenuItem";
            this.放大选取框功能ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.放大选取框功能ToolStripMenuItem.Text = "放大选取框功能";
            // 
            // 坐标自动调整ToolStripMenuItem
            // 
            this.坐标自动调整ToolStripMenuItem.Checked = true;
            this.坐标自动调整ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.坐标自动调整ToolStripMenuItem.Name = "坐标自动调整ToolStripMenuItem";
            this.坐标自动调整ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.坐标自动调整ToolStripMenuItem.Text = "坐标自动调整";
            // 
            // 默认坐标范围ToolStripMenuItem
            // 
            this.默认坐标范围ToolStripMenuItem.Name = "默认坐标范围ToolStripMenuItem";
            this.默认坐标范围ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.默认坐标范围ToolStripMenuItem.Text = "默认坐标范围";
            // 
            // slide
            // 
            this.slide.Border = NationalInstruments.UI.Border.Etched;
            this.slide.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.slide.FillStyle = NationalInstruments.UI.FillStyle.HorizontalGradient;
            this.slide.Location = new System.Drawing.Point(0, 568);
            this.slide.Margin = new System.Windows.Forms.Padding(4);
            this.slide.Name = "slide";
            this.slide.Range = new NationalInstruments.UI.Range(0D, 100D);
            this.slide.ScalePosition = NationalInstruments.UI.NumericScalePosition.Bottom;
            this.slide.Size = new System.Drawing.Size(1082, 54);
            this.slide.SlideStyle = NationalInstruments.UI.SlideStyle.SunkenWithGrip;
            this.slide.TabIndex = 22;
            this.slide.Value = 100D;
            // 
            // panel_itemsIN
            // 
            this.panel_itemsIN.BackColor = System.Drawing.Color.Transparent;
            this.panel_itemsIN.Controls.Add(this.BTN_切换Y轴);
            this.panel_itemsIN.Controls.Add(this.BTN_停止显示);
            this.panel_itemsIN.Controls.Add(this.buttonReXY);
            this.panel_itemsIN.Controls.Add(this.buttonModeXY);
            this.panel_itemsIN.Controls.Add(this.buttonBigModeXY);
            this.panel_itemsIN.Controls.Add(this.buttonLinesShowXY);
            this.panel_itemsIN.Controls.Add(this.btn_调整坐标轴);
            this.panel_itemsIN.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_itemsIN.Location = new System.Drawing.Point(1028, 33);
            this.panel_itemsIN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panel_itemsIN.Name = "panel_itemsIN";
            this.panel_itemsIN.Size = new System.Drawing.Size(54, 535);
            this.panel_itemsIN.TabIndex = 1;
            // 
            // BTN_切换Y轴
            // 
            this.BTN_切换Y轴.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_切换Y轴.BackColor = System.Drawing.Color.Transparent;
            this.BTN_切换Y轴.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_切换Y轴.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTN_切换Y轴.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_切换Y轴.Image = global::控件库.Properties.Resources.AutoCorrect_Icon;
            this.BTN_切换Y轴.Location = new System.Drawing.Point(2, 0);
            this.BTN_切换Y轴.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.BTN_切换Y轴.Name = "BTN_切换Y轴";
            this.BTN_切换Y轴.Size = new System.Drawing.Size(48, 48);
            this.BTN_切换Y轴.TabIndex = 13;
            this.BTN_切换Y轴.TabStop = false;
            this.BTN_切换Y轴.UseVisualStyleBackColor = false;
            this.BTN_切换Y轴.Click += new System.EventHandler(this.BTN_切换Y轴_Click);
            this.BTN_切换Y轴.MouseEnter += new System.EventHandler(this.BTN_切换Y轴_MouseEnter);
            this.BTN_切换Y轴.MouseLeave += new System.EventHandler(this.BTN_切换Y轴_MouseLeave);
            // 
            // BTN_停止显示
            // 
            this.BTN_停止显示.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_停止显示.BackColor = System.Drawing.Color.Transparent;
            this.BTN_停止显示.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_停止显示.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTN_停止显示.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_停止显示.Image = global::控件库.Properties.Resources.Action_Exit_32x32;
            this.BTN_停止显示.Location = new System.Drawing.Point(2, 48);
            this.BTN_停止显示.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.BTN_停止显示.Name = "BTN_停止显示";
            this.BTN_停止显示.Size = new System.Drawing.Size(48, 48);
            this.BTN_停止显示.TabIndex = 13;
            this.BTN_停止显示.TabStop = false;
            this.BTN_停止显示.UseVisualStyleBackColor = false;
            this.BTN_停止显示.Click += new System.EventHandler(this.BTN_停止显示_Click);
            this.BTN_停止显示.MouseEnter += new System.EventHandler(this.BTN_停止显示_MouseEnter);
            this.BTN_停止显示.MouseLeave += new System.EventHandler(this.BTN_停止显示_MouseLeave);
            // 
            // buttonReXY
            // 
            this.buttonReXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReXY.BackColor = System.Drawing.Color.Transparent;
            this.buttonReXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReXY.ForeColor = System.Drawing.Color.Transparent;
            this.buttonReXY.Image = global::控件库.Properties.Resources.reflash;
            this.buttonReXY.Location = new System.Drawing.Point(2, 96);
            this.buttonReXY.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.buttonReXY.Name = "buttonReXY";
            this.buttonReXY.Size = new System.Drawing.Size(48, 48);
            this.buttonReXY.TabIndex = 13;
            this.buttonReXY.TabStop = false;
            this.buttonReXY.UseVisualStyleBackColor = false;
            this.buttonReXY.Click += new System.EventHandler(this.buttonReXY_Click);
            this.buttonReXY.MouseEnter += new System.EventHandler(this.buttonReXY_MouseEnter);
            this.buttonReXY.MouseLeave += new System.EventHandler(this.buttonReXY_MouseLeave);
            // 
            // buttonModeXY
            // 
            this.buttonModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModeXY.BackColor = System.Drawing.Color.Transparent;
            this.buttonModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonModeXY.ForeColor = System.Drawing.Color.Transparent;
            this.buttonModeXY.Image = global::控件库.Properties.Resources.CrosshairCursorControl_Icon;
            this.buttonModeXY.Location = new System.Drawing.Point(2, 144);
            this.buttonModeXY.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.buttonModeXY.Name = "buttonModeXY";
            this.buttonModeXY.Size = new System.Drawing.Size(48, 48);
            this.buttonModeXY.TabIndex = 12;
            this.buttonModeXY.TabStop = false;
            this.buttonModeXY.UseVisualStyleBackColor = false;
            this.buttonModeXY.Click += new System.EventHandler(this.buttonModeXY_Click);
            this.buttonModeXY.MouseEnter += new System.EventHandler(this.buttonModeXY_MouseEnter);
            this.buttonModeXY.MouseLeave += new System.EventHandler(this.buttonModeXY_MouseLeave);
            // 
            // buttonBigModeXY
            // 
            this.buttonBigModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigModeXY.BackColor = System.Drawing.Color.Transparent;
            this.buttonBigModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBigModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBigModeXY.ForeColor = System.Drawing.Color.Transparent;
            this.buttonBigModeXY.Image = global::控件库.Properties.Resources.ChartDemoScrollingAndZooming_Icon;
            this.buttonBigModeXY.Location = new System.Drawing.Point(2, 192);
            this.buttonBigModeXY.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.buttonBigModeXY.Name = "buttonBigModeXY";
            this.buttonBigModeXY.Size = new System.Drawing.Size(48, 48);
            this.buttonBigModeXY.TabIndex = 11;
            this.buttonBigModeXY.TabStop = false;
            this.buttonBigModeXY.UseVisualStyleBackColor = false;
            this.buttonBigModeXY.Click += new System.EventHandler(this.buttonBigModeXY_Click);
            this.buttonBigModeXY.MouseEnter += new System.EventHandler(this.buttonBigModeXY_MouseEnter);
            this.buttonBigModeXY.MouseLeave += new System.EventHandler(this.buttonBigModeXY_MouseLeave);
            // 
            // buttonLinesShowXY
            // 
            this.buttonLinesShowXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLinesShowXY.BackColor = System.Drawing.Color.Transparent;
            this.buttonLinesShowXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLinesShowXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.buttonLinesShowXY.ForeColor = System.Drawing.Color.Transparent;
            this.buttonLinesShowXY.Image = global::控件库.Properties.Resources.ChartDemoDateTimeGridAlignment_Icon;
            this.buttonLinesShowXY.Location = new System.Drawing.Point(2, 240);
            this.buttonLinesShowXY.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.buttonLinesShowXY.Name = "buttonLinesShowXY";
            this.buttonLinesShowXY.Size = new System.Drawing.Size(48, 48);
            this.buttonLinesShowXY.TabIndex = 0;
            this.buttonLinesShowXY.TabStop = false;
            this.buttonLinesShowXY.UseVisualStyleBackColor = false;
            this.buttonLinesShowXY.Click += new System.EventHandler(this.buttonLinesShowXY_Click);
            this.buttonLinesShowXY.MouseEnter += new System.EventHandler(this.buttonLinesShowXY_MouseEnter);
            this.buttonLinesShowXY.MouseLeave += new System.EventHandler(this.buttonLinesShowXY_MouseLeave);
            // 
            // btn_调整坐标轴
            // 
            this.btn_调整坐标轴.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_调整坐标轴.BackColor = System.Drawing.Color.Transparent;
            this.btn_调整坐标轴.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_调整坐标轴.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.btn_调整坐标轴.ForeColor = System.Drawing.Color.Transparent;
            this.btn_调整坐标轴.Image = global::控件库.Properties.Resources.ChartDemoDateTimeScaleMode_Icon;
            this.btn_调整坐标轴.Location = new System.Drawing.Point(2, 288);
            this.btn_调整坐标轴.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btn_调整坐标轴.Name = "btn_调整坐标轴";
            this.btn_调整坐标轴.Size = new System.Drawing.Size(48, 48);
            this.btn_调整坐标轴.TabIndex = 0;
            this.btn_调整坐标轴.TabStop = false;
            this.btn_调整坐标轴.UseVisualStyleBackColor = false;
            this.btn_调整坐标轴.Click += new System.EventHandler(this.btn_调整坐标轴_Click);
            this.btn_调整坐标轴.MouseEnter += new System.EventHandler(this.btn_调整坐标轴_MouseEnter);
            this.btn_调整坐标轴.MouseLeave += new System.EventHandler(this.btn_调整坐标轴_MouseLeave);
            // 
            // legend1
            // 
            this.legend1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.legend1.ItemSize = new System.Drawing.Size(30, 15);
            this.legend1.Location = new System.Drawing.Point(0, 530);
            this.legend1.Margin = new System.Windows.Forms.Padding(4);
            this.legend1.Name = "legend1";
            this.legend1.Padding = new System.Windows.Forms.Padding(2, 0, 4, 0);
            this.legend1.Size = new System.Drawing.Size(1028, 38);
            this.legend1.TabIndex = 24;
            // 
            // xAxis_Looking
            // 
            this.xAxis_Looking.BaseLineVisible = true;
            this.xAxis_Looking.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.DateTime, "dd HH:mm:ss");
            this.xAxis_Looking.Mode = NationalInstruments.UI.AxisMode.AutoScaleExact;
            this.xAxis_Looking.Range = new NationalInstruments.UI.Range(0D, 10.5D);
            // 
            // Graph_View
            // 
            this.Graph_View.Border = NationalInstruments.UI.Border.None;
            this.Graph_View.Cursors.AddRange(new NationalInstruments.UI.XYCursor[] {
            this.xyCursorB,
            this.xyCursorE});
            this.Graph_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph_View.Location = new System.Drawing.Point(0, 33);
            this.Graph_View.Margin = new System.Windows.Forms.Padding(4);
            this.Graph_View.Name = "Graph_View";
            this.Graph_View.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.Graph_View.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot2});
            this.Graph_View.Size = new System.Drawing.Size(1028, 497);
            this.Graph_View.TabIndex = 25;
            this.Graph_View.UseColorGenerator = true;
            this.Graph_View.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis_Looking});
            this.Graph_View.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            this.Graph_View.AfterDrawPlot += new NationalInstruments.UI.AfterDrawXYPlotEventHandler(this.Graph_View_AfterDrawPlot);
            this.Graph_View.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Graph_View_MouseDown);
            this.Graph_View.MouseLeave += new System.EventHandler(this.Graph_View_MouseLeave);
            this.Graph_View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Graph_View_MouseMove);
            this.Graph_View.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Graph_View_MouseUp);
            // 
            // xyCursorB
            // 
            this.xyCursorB.Color = System.Drawing.Color.Gold;
            this.xyCursorB.Plot = this.scatterPlot2;
            this.xyCursorB.SnapMode = NationalInstruments.UI.CursorSnapMode.NearestPoint;
            this.xyCursorB.Visible = false;
            // 
            // scatterPlot2
            // 
            this.scatterPlot2.Visible = false;
            this.scatterPlot2.XAxis = this.xAxis_Looking;
            this.scatterPlot2.YAxis = this.yAxis1;
            // 
            // yAxis1
            // 
            this.yAxis1.BaseLineColor = System.Drawing.SystemColors.ControlText;
            this.yAxis1.Caption = "111";
            this.yAxis1.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F1");
            // 
            // xyCursorE
            // 
            this.xyCursorE.Color = System.Drawing.Color.Gold;
            this.xyCursorE.Plot = this.scatterPlot2;
            this.xyCursorE.SnapMode = NationalInstruments.UI.CursorSnapMode.NearestPoint;
            this.xyCursorE.Visible = false;
            // 
            // panel_text
            // 
            this.panel_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_text.Location = new System.Drawing.Point(0, 0);
            this.panel_text.Margin = new System.Windows.Forms.Padding(4);
            this.panel_text.Name = "panel_text";
            this.panel_text.Size = new System.Drawing.Size(1082, 33);
            this.panel_text.TabIndex = 26;
            this.panel_text.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_text_Paint);
            // 
            // XYGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Graph_View);
            this.Controls.Add(this.legend1);
            this.Controls.Add(this.panel_itemsIN);
            this.Controls.Add(this.panel_text);
            this.Controls.Add(this.panelBigXY);
            this.Controls.Add(this.labelItemShuoMing);
            this.Controls.Add(this.pictureBoxBigXY);
            this.Controls.Add(this.slide);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XYGraph";
            this.Size = new System.Drawing.Size(1082, 622);
            this.panelBigXY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigXY)).EndInit();
            this.MenuRightClick.ResumeLayout(false);
            this.MenuRightClick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slide)).EndInit();
            this.panel_itemsIN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.legend1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xyCursorB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xyCursorE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBigXY;
        private System.Windows.Forms.Button buttonBigXYBig;
        private System.Windows.Forms.Button buttonBigXYQuit;
        private System.Windows.Forms.PictureBox pictureBoxBigXY;
        private System.Windows.Forms.ContextMenuStrip MenuRightClick;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxX;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 网格显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大选取框功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坐标自动调整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认坐标范围ToolStripMenuItem;
        private NationalInstruments.UI.WindowsForms.Slide slide;
        public System.Windows.Forms.Label labelItemShuoMing;
        private NationalInstruments.UI.WindowsForms.Legend legend1;
        private NationalInstruments.UI.WindowsForms.ScatterGraph Graph_View;
        private NationalInstruments.UI.XAxis xAxis_Looking;
        private NationalInstruments.UI.XYCursor xyCursorB;
        private NationalInstruments.UI.XYCursor xyCursorE;
        private NationalInstruments.UI.ScatterPlot scatterPlot2;
        private NationalInstruments.UI.YAxis yAxis1;
        private System.Windows.Forms.Panel panel_text;
        private System.Windows.Forms.FlowLayoutPanel panel_itemsIN;
        private System.Windows.Forms.Button BTN_切换Y轴;
        private System.Windows.Forms.Button BTN_停止显示;
        private System.Windows.Forms.Button buttonReXY;
        private System.Windows.Forms.Button buttonModeXY;
        private System.Windows.Forms.Button buttonBigModeXY;
        private System.Windows.Forms.Button buttonLinesShowXY;
        private System.Windows.Forms.Button btn_调整坐标轴;
    }
}
