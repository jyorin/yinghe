using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoControl
{
    internal partial class charTextUC : UserControl
    {
        public charTextUC()
        {
            InitializeComponent();
            this.Name = System.DateTime.Now.Millisecond.ToString();
        }

        public string GetValue()
        {
            return this.textEdit1.Text;
        }

        public void SetValue(string value)
        {
            this.textEdit1.Text = value;
        }

        public void BindTheControl(string value)
        {
            this.textEdit1.Text = value;
        }

        public  void ClearRecord()
        {
            this.textEdit1.Text = string.Empty;
        }
    }
}
