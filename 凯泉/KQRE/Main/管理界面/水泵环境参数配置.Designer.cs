namespace Main.管理界面
{
    partial class 水泵环境参数配置
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t出口压力 = new System.Windows.Forms.TextBox();
            this.t进口压力 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c流量 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c出口压力 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c进口压力 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.c = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.c流量最大量程 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c流量最大量程);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.t出口压力);
            this.groupBox1.Controls.Add(this.t进口压力);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.c流量);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.c出口压力);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.c进口压力);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(449, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "流量|进/出口压力";
            // 
            // t出口压力
            // 
            this.t出口压力.Location = new System.Drawing.Point(304, 84);
            this.t出口压力.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.t出口压力.Name = "t出口压力";
            this.t出口压力.Size = new System.Drawing.Size(95, 21);
            this.t出口压力.TabIndex = 9;
            this.t出口压力.Text = "1";
            // 
            // t进口压力
            // 
            this.t进口压力.Location = new System.Drawing.Point(304, 59);
            this.t进口压力.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.t进口压力.Name = "t进口压力";
            this.t进口压力.Size = new System.Drawing.Size(95, 21);
            this.t进口压力.TabIndex = 8;
            this.t进口压力.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "出口压力量程";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "进口压力量程";
            // 
            // c流量
            // 
            this.c流量.FormattingEnabled = true;
            this.c流量.Items.AddRange(new object[] {
            "num1",
            "num2",
            "num3"});
            this.c流量.Location = new System.Drawing.Point(99, 28);
            this.c流量.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c流量.Name = "c流量";
            this.c流量.Size = new System.Drawing.Size(82, 20);
            this.c流量.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "流量通道";
            // 
            // c出口压力
            // 
            this.c出口压力.FormattingEnabled = true;
            this.c出口压力.Items.AddRange(new object[] {
            "InputPre1",
            "InputPre2",
            "InputPre3",
            "OutputPre1",
            "OutputPre2",
            "OutputPre3"});
            this.c出口压力.Location = new System.Drawing.Point(99, 81);
            this.c出口压力.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c出口压力.Name = "c出口压力";
            this.c出口压力.Size = new System.Drawing.Size(82, 20);
            this.c出口压力.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "出口压力通道";
            // 
            // c进口压力
            // 
            this.c进口压力.FormattingEnabled = true;
            this.c进口压力.Items.AddRange(new object[] {
            "InputPre1",
            "InputPre2",
            "InputPre3",
            "OutputPre1",
            "OutputPre2",
            "OutputPre3"});
            this.c进口压力.Location = new System.Drawing.Point(99, 54);
            this.c进口压力.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c进口压力.Name = "c进口压力";
            this.c进口压力.Size = new System.Drawing.Size(82, 20);
            this.c进口压力.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "进口压力通道";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.c);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.b);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.a);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(17, 146);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(449, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轴功率 = a * (输入功率^2) + b*输入功率+c";
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(179, 23);
            this.b.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(68, 21);
            this.b.TabIndex = 13;
            this.b.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(164, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "b";
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(32, 23);
            this.a.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(68, 21);
            this.a.TabIndex = 11;
            this.a.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "a";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 211);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(320, 23);
            this.c.Margin = new System.Windows.Forms.Padding(2);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(68, 21);
            this.c.TabIndex = 15;
            this.c.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "c";
            // 
            // c流量最大量程
            // 
            this.c流量最大量程.FormattingEnabled = true;
            this.c流量最大量程.Items.AddRange(new object[] {
            "70",
            "200",
            "600",
            "1450",
            "1800",
            "3500",
            "5500",
            "12800",
            "19000",
            "45000"});
            this.c流量最大量程.Location = new System.Drawing.Point(304, 28);
            this.c流量最大量程.Margin = new System.Windows.Forms.Padding(2);
            this.c流量最大量程.Name = "c流量最大量程";
            this.c流量最大量程.Size = new System.Drawing.Size(95, 20);
            this.c流量最大量程.TabIndex = 11;
            this.c流量最大量程.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "流量最大量程";
            // 
            // 水泵环境参数配置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 257);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "水泵环境参数配置";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水泵环境参数配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox c流量;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox c出口压力;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox c进口压力;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox t出口压力;
        private System.Windows.Forms.TextBox t进口压力;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox c流量最大量程;
        private System.Windows.Forms.Label label9;
    }
}