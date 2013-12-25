namespace 控件库.采集控件
{
    partial class 采集表格
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_启动采集 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_停止采集 = new DevExpress.XtraEditors.SimpleButton();
            this.txt_采集时长 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_采集间隔 = new DevExpress.XtraEditors.TextEdit();
            this.grid1 = new 控件库.表格控件.Grid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_采集时长.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_采集间隔.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_采集间隔);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txt_采集时长);
            this.panel1.Controls.Add(this.btn_停止采集);
            this.panel1.Controls.Add(this.btn_启动采集);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 45);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 327);
            this.panel2.TabIndex = 1;
            // 
            // btn_启动采集
            // 
            this.btn_启动采集.Location = new System.Drawing.Point(110, 12);
            this.btn_启动采集.Name = "btn_启动采集";
            this.btn_启动采集.Size = new System.Drawing.Size(75, 23);
            this.btn_启动采集.TabIndex = 0;
            this.btn_启动采集.Text = "启动采集 ";
            this.btn_启动采集.Click += new System.EventHandler(this.btn_启动采集_Click);
            // 
            // btn_停止采集
            // 
            this.btn_停止采集.Location = new System.Drawing.Point(200, 12);
            this.btn_停止采集.Name = "btn_停止采集";
            this.btn_停止采集.Size = new System.Drawing.Size(75, 23);
            this.btn_停止采集.TabIndex = 1;
            this.btn_停止采集.Text = "停止采集 ";
            this.btn_停止采集.Click += new System.EventHandler(this.btn_停止采集_Click);
            // 
            // txt_采集时长
            // 
            this.txt_采集时长.Location = new System.Drawing.Point(353, 13);
            this.txt_采集时长.Name = "txt_采集时长";
            this.txt_采集时长.Size = new System.Drawing.Size(75, 20);
            this.txt_采集时长.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(290, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "采集时长";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(448, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "采集间隔";
            // 
            // txt_采集间隔
            // 
            this.txt_采集间隔.Location = new System.Drawing.Point(511, 13);
            this.txt_采集间隔.Name = "txt_采集间隔";
            this.txt_采集间隔.Size = new System.Drawing.Size(75, 20);
            this.txt_采集间隔.TabIndex = 5;
            // 
            // grid1
            // 
            this.grid1.BtnAddRow = false;
            this.grid1.BtnReduceRow = false;
            this.grid1.ButtonPanelVisible = false;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.Location = new System.Drawing.Point(0, 0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(616, 327);
            this.grid1.TabIndex = 0;
            this.grid1.分组面板 = false;
            this.grid1.删除记录 = false;
            this.grid1.删除记录按钮CAPTION = null;
            this.grid1.合并列值 = false;
            this.grid1.合计底栏 = false;
            this.grid1.导出表格 = false;
            this.grid1.执行命令 = false;
            this.grid1.执行命令按钮CAPTION = null;
            this.grid1.新增记录 = false;
            this.grid1.新增记录按钮CAPTION = null;
            this.grid1.查找记录 = false;
            // 
            // 采集表格
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "采集表格";
            this.Size = new System.Drawing.Size(616, 372);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_采集时长.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_采集间隔.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private 表格控件.Grid grid1;
        private DevExpress.XtraEditors.TextEdit txt_采集间隔;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_采集时长;
        private DevExpress.XtraEditors.SimpleButton btn_停止采集;
        private DevExpress.XtraEditors.SimpleButton btn_启动采集;
    }
}
