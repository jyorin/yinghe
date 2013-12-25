namespace AutoControl
{
    partial class NumericEditUC
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
            this.numericEdit1 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericEdit1
            // 
            this.numericEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericEdit1.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(2);
            this.numericEdit1.Location = new System.Drawing.Point(0, 0);
            this.numericEdit1.Name = "numericEdit1";
            this.numericEdit1.Size = new System.Drawing.Size(200, 21);
            this.numericEdit1.TabIndex = 0;
            // 
            // NumericEditUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericEdit1);
            this.Name = "NumericEditUC";
            this.Size = new System.Drawing.Size(200, 26);
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.NumericEdit numericEdit1;
    }
}
