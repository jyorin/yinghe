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
    public partial class NumericEditUC : UserControl
    {
        public NumericEditUC()
        {
            InitializeComponent();
            this.Name = System.DateTime.Now.Millisecond.ToString();
        }

        public string GetValue()
        {
            return this.numericEdit1.Text;
        }

        public void SetValue(string value)
        {
            this.numericEdit1.Text = value;
        }

        public void BindTheControl(string value)
        {
            if (value != null)
            {
                this.numericEdit1.Text = value;
            }
            else
            {
                this.numericEdit1.Text = "0";
            }
        }

        public  void ClearRecord()
        {
            this.numericEdit1.Text = string.Empty;
        }
    }
}
