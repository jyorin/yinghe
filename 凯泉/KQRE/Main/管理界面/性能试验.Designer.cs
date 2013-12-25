namespace Main.管理界面
{
    partial class 性能试验
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl_泵效率 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_泵输入功率 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_扬程 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_流量 = new DevExpress.XtraEditors.LabelControl();
            this.数显仪表集合1 = new 控件库.数显区控件.数显仪表集合();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.凯泉报表控制板1 = new 控件库.项目控制板.凯泉报表控制板();
            this.grid1 = new 控件库.表格控件.Grid();
            this.xyGraph1 = new 控件库.曲线控件.XYGraph();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.数显仪表集合1);
            this.layoutControl1.Controls.Add(this.panelControl2);
            this.layoutControl1.Controls.Add(this.grid1);
            this.layoutControl1.Controls.Add(this.xyGraph1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(381, 281, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(959, 477);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl_泵效率);
            this.panelControl1.Controls.Add(this.labelControl_泵输入功率);
            this.panelControl1.Controls.Add(this.labelControl_扬程);
            this.panelControl1.Controls.Add(this.labelControl_流量);
            this.panelControl1.Location = new System.Drawing.Point(625, 74);
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(332, 34);
            this.panelControl1.TabIndex = 10;
            // 
            // labelControl_泵效率
            // 
            this.labelControl_泵效率.Location = new System.Drawing.Point(271, 10);
            this.labelControl_泵效率.Name = "labelControl_泵效率";
            this.labelControl_泵效率.Size = new System.Drawing.Size(86, 14);
            this.labelControl_泵效率.TabIndex = 0;
            this.labelControl_泵效率.Text = "泵效率:0000.00";
            // 
            // labelControl_泵输入功率
            // 
            this.labelControl_泵输入功率.Location = new System.Drawing.Point(155, 10);
            this.labelControl_泵输入功率.Name = "labelControl_泵输入功率";
            this.labelControl_泵输入功率.Size = new System.Drawing.Size(110, 14);
            this.labelControl_泵输入功率.TabIndex = 0;
            this.labelControl_泵输入功率.Text = "泵输入功率:0000.00";
            // 
            // labelControl_扬程
            // 
            this.labelControl_扬程.Location = new System.Drawing.Point(79, 10);
            this.labelControl_扬程.Name = "labelControl_扬程";
            this.labelControl_扬程.Size = new System.Drawing.Size(74, 14);
            this.labelControl_扬程.TabIndex = 0;
            this.labelControl_扬程.Text = "扬程:0000.00";
            // 
            // labelControl_流量
            // 
            this.labelControl_流量.Location = new System.Drawing.Point(3, 10);
            this.labelControl_流量.Name = "labelControl_流量";
            this.labelControl_流量.Size = new System.Drawing.Size(74, 14);
            this.labelControl_流量.TabIndex = 0;
            this.labelControl_流量.Text = "流量:0000.00";
            // 
            // 数显仪表集合1
            // 
            this.数显仪表集合1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.数显仪表集合1.Location = new System.Drawing.Point(2, 2);
            this.数显仪表集合1.Margin = new System.Windows.Forms.Padding(4);
            this.数显仪表集合1.Name = "数显仪表集合1";
            this.数显仪表集合1.Size = new System.Drawing.Size(955, 66);
            this.数显仪表集合1.TabIndex = 8;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.凯泉报表控制板1);
            this.panelControl2.Location = new System.Drawing.Point(2, 374);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(483, 101);
            this.panelControl2.TabIndex = 7;
            // 
            // 凯泉报表控制板1
            // 
            this.凯泉报表控制板1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.凯泉报表控制板1.Location = new System.Drawing.Point(2, 2);
            this.凯泉报表控制板1.Margin = new System.Windows.Forms.Padding(4);
            this.凯泉报表控制板1.Name = "凯泉报表控制板1";
            this.凯泉报表控制板1.Size = new System.Drawing.Size(479, 97);
            this.凯泉报表控制板1.TabIndex = 0;
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid1.BtnAddRow = true;
            this.grid1.BtnReduceRow = true;
            this.grid1.ButtonPanelVisible = true;
            this.grid1.Location = new System.Drawing.Point(2, 74);
            this.grid1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(483, 296);
            this.grid1.TabIndex = 4;
            this.grid1.分组面板 = false;
            this.grid1.删除记录 = true;
            this.grid1.删除记录按钮CAPTION = "删除";
            this.grid1.合并列值 = false;
            this.grid1.合计底栏 = false;
            this.grid1.导出表格 = false;
            this.grid1.执行命令 = true;
            this.grid1.执行命令按钮CAPTION = "同步汽蚀";
            this.grid1.新增记录 = true;
            this.grid1.新增记录按钮CAPTION = "采集";
            this.grid1.查找记录 = false;
            this.grid1.BtnAddRowClick += new System.EventHandler(this.grid1_BtnAddRowClick);
            this.grid1.BtnReduceRowClick += new System.EventHandler(this.grid1_BtnReduceRowClick);
            this.grid1.Btn执行命令1Click += new System.EventHandler(this.grid1_Btn执行命令1Click);
            // 
            // xyGraph1
            // 
            this.xyGraph1.coordinateStringColor = System.Drawing.SystemColors.ControlText;
            this.xyGraph1.CoordinateStringColor = System.Drawing.SystemColors.ControlText;
            this.xyGraph1.iAccuracy = 2;
            this.xyGraph1.isAutoModeXY = true;
            this.xyGraph1.isBigModeXY = false;
            this.xyGraph1.isLinesShowXY = false;
            this.xyGraph1.isShowBigSmallModeXY = false;
            this.xyGraph1.isShowModeXY = false;
            this.xyGraph1.Location = new System.Drawing.Point(494, 114);
            this.xyGraph1.m_ControlButtonForeColorH = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.xyGraph1.m_ControlButtonForeColorL = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.xyGraph1.MajorLineLineShowColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.xyGraph1.Margin = new System.Windows.Forms.Padding(4);
            this.xyGraph1.MinorLineLineShowColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.xyGraph1.Name = "xyGraph1";
            this.xyGraph1.Size = new System.Drawing.Size(463, 361);
            this.xyGraph1.TabIndex = 9;
            this.xyGraph1.X轴计数格式 = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            this.xyGraph1.是否启用停止曲线显示按钮 = true;
            this.xyGraph1.是否启用恢复默认网格按钮 = true;
            this.xyGraph1.是否启用放大查看按钮 = true;
            this.xyGraph1.是否启用显示网格按钮 = true;
            this.xyGraph1.是否启用计算差值按钮 = true;
            this.xyGraph1.是否开始绘制曲线 = false;
            this.xyGraph1.是否显示停止曲线显示按钮 = false;
            this.xyGraph1.是否显示切换Y轴按钮 = false;
            this.xyGraph1.是否显示恢复默认网格按钮 = false;
            this.xyGraph1.是否显示放大查看按钮 = false;
            this.xyGraph1.是否显示显示网格按钮 = true;
            this.xyGraph1.是否显示横向滚动条 = false;
            this.xyGraph1.是否显示计算差值按钮 = false;
            this.xyGraph1.汽蚀余量X轴 = 0D;
            this.xyGraph1.汽蚀余量Y轴 = 0D;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.simpleSeparator2,
            this.layoutControlItem4,
            this.splitterItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.simpleSeparator1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(959, 477);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grid1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(487, 300);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.数显仪表集合1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 70);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(104, 70);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(959, 70);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // simpleSeparator2
            // 
            this.simpleSeparator2.AllowHotTrack = false;
            this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
            this.simpleSeparator2.Location = new System.Drawing.Point(0, 70);
            this.simpleSeparator2.Name = "simpleSeparator2";
            this.simpleSeparator2.Size = new System.Drawing.Size(959, 2);
            this.simpleSeparator2.Text = "simpleSeparator2";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.panelControl2;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 372);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 105);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(104, 105);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(487, 105);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(487, 112);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 365);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xyGraph1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(492, 112);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(467, 365);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.panelControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(487, 72);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 38);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 38);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(472, 38);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "保证点性能参数测试结果";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(132, 14);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(487, 110);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(472, 2);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // 性能试验
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 477);
            this.Controls.Add(this.layoutControl1);
            this.Name = "性能试验";
            this.Text = "性能试验";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.性能试验_FormClosed);
            this.Load += new System.EventHandler(this.性能试验_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private 控件库.表格控件.Grid grid1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private 控件库.数显区控件.数显仪表集合 数显仪表集合1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private 控件库.项目控制板.凯泉报表控制板 凯泉报表控制板1;
        private 控件库.曲线控件.XYGraph xyGraph1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl labelControl_流量;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.LabelControl labelControl_泵效率;
        private DevExpress.XtraEditors.LabelControl labelControl_泵输入功率;
        private DevExpress.XtraEditors.LabelControl labelControl_扬程;
    }
}