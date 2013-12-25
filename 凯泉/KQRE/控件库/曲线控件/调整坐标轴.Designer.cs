namespace 控件库.曲线控件
{
    partial class 调整坐标轴
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
            this.CB_所属曲线 = new System.Windows.Forms.ComboBox();
            this.BTN_取消 = new DevExpress.XtraEditors.SimpleButton();
            this.BTN_确定 = new DevExpress.XtraEditors.SimpleButton();
            this.num_Y_max = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.num_Y_min = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.num_X_max = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.num_X_min = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Y_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Y_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_X_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_X_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CB_所属曲线);
            this.layoutControl1.Controls.Add(this.BTN_取消);
            this.layoutControl1.Controls.Add(this.BTN_确定);
            this.layoutControl1.Controls.Add(this.num_Y_max);
            this.layoutControl1.Controls.Add(this.num_Y_min);
            this.layoutControl1.Controls.Add(this.num_X_max);
            this.layoutControl1.Controls.Add(this.num_X_min);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(609, 85, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(383, 421);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CB_所属曲线
            // 
            this.CB_所属曲线.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_所属曲线.FormattingEnabled = true;
            this.CB_所属曲线.Location = new System.Drawing.Point(100, 204);
            this.CB_所属曲线.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_所属曲线.Name = "CB_所属曲线";
            this.CB_所属曲线.Size = new System.Drawing.Size(259, 30);
            this.CB_所属曲线.TabIndex = 10;
            // 
            // BTN_取消
            // 
            this.BTN_取消.Location = new System.Drawing.Point(206, 350);
            this.BTN_取消.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_取消.Name = "BTN_取消";
            this.BTN_取消.Size = new System.Drawing.Size(165, 29);
            this.BTN_取消.StyleController = this.layoutControl1;
            this.BTN_取消.TabIndex = 9;
            this.BTN_取消.Text = "取 消";
            this.BTN_取消.Click += new System.EventHandler(this.BTN_取消_Click);
            // 
            // BTN_确定
            // 
            this.BTN_确定.Location = new System.Drawing.Point(12, 350);
            this.BTN_确定.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_确定.Name = "BTN_确定";
            this.BTN_确定.Size = new System.Drawing.Size(175, 29);
            this.BTN_确定.StyleController = this.layoutControl1;
            this.BTN_确定.TabIndex = 8;
            this.BTN_确定.Text = "确 定";
            this.BTN_确定.Click += new System.EventHandler(this.BTN_确定_Click);
            // 
            // num_Y_max
            // 
            this.num_Y_max.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.num_Y_max.Location = new System.Drawing.Point(100, 286);
            this.num_Y_max.Name = "num_Y_max";
            this.num_Y_max.Size = new System.Drawing.Size(259, 29);
            this.num_Y_max.TabIndex = 7;
            this.num_Y_max.Value = 100D;
            // 
            // num_Y_min
            // 
            this.num_Y_min.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.num_Y_min.Location = new System.Drawing.Point(100, 230);
            this.num_Y_min.Name = "num_Y_min";
            this.num_Y_min.Size = new System.Drawing.Size(259, 29);
            this.num_Y_min.TabIndex = 6;
            // 
            // num_X_max
            // 
            this.num_X_max.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.num_X_max.Location = new System.Drawing.Point(100, 102);
            this.num_X_max.Name = "num_X_max";
            this.num_X_max.Size = new System.Drawing.Size(259, 29);
            this.num_X_max.TabIndex = 5;
            this.num_X_max.Value = 100D;
            // 
            // num_X_min
            // 
            this.num_X_min.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.num_X_min.Location = new System.Drawing.Point(100, 52);
            this.num_X_min.Name = "num_X_min";
            this.num_X_min.Size = new System.Drawing.Size(259, 29);
            this.num_X_min.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(383, 421);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BTN_确定;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 338);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(179, 33);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BTN_取消;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(194, 338);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(169, 33);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(179, 338);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(15, 33);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "调整X轴";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(363, 152);
            this.layoutControlGroup2.Text = "调整X轴";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.num_X_min;
            this.layoutControlItem1.CustomizationFormText = "最小值";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(339, 50);
            this.layoutControlItem1.Text = "最小值";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 22);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.num_X_max;
            this.layoutControlItem2.CustomizationFormText = "最大值";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(339, 50);
            this.layoutControlItem2.Text = "最大值";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 22);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "调整Y轴";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem7});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 152);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(363, 186);
            this.layoutControlGroup3.Text = "调整Y轴";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.num_Y_min;
            this.layoutControlItem3.CustomizationFormText = "最小值";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(339, 56);
            this.layoutControlItem3.Text = "最小值";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 22);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.num_Y_max;
            this.layoutControlItem4.CustomizationFormText = "最大值";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(213, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(339, 52);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "最大值";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 22);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.CB_所属曲线;
            this.layoutControlItem7.CustomizationFormText = "所属曲线";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(339, 26);
            this.layoutControlItem7.Text = "所属曲线";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(72, 22);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 371);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(363, 30);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // 调整坐标轴
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 421);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "调整坐标轴";
            this.Text = "调整坐标轴";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_Y_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Y_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_X_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_X_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton BTN_取消;
        private DevExpress.XtraEditors.SimpleButton BTN_确定;
        private NationalInstruments.UI.WindowsForms.NumericEdit num_Y_max;
        private NationalInstruments.UI.WindowsForms.NumericEdit num_Y_min;
        private NationalInstruments.UI.WindowsForms.NumericEdit num_X_max;
        private NationalInstruments.UI.WindowsForms.NumericEdit num_X_min;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.ComboBox CB_所属曲线;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}