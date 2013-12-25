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
    public partial class timeBoxUC : UserControl
    {
        public timeBoxUC()
        {
            InitializeComponent();
        }

        public string GetValue()
        {
            return this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
        }

        public void SetValue(string value)
        {
            this.dateTimePicker1.Value = DateTime.Parse(value);
        }

        public void BindTheControl(string value)
        {
            DateTime time;
            string strvalue="";
            if (value != null)
            {
                strvalue = value;
            }

            if (strvalue.Equals("") == true)
            {
                time = DateTime.Now;
            }
            else
            {
                time = DateTime.Parse(strvalue);
            }
            this.dateTimePicker1.Value = time;
        }

        public void ClearRecord()
        {
            this.dateTimePicker1.Value = System.DateTime.Now;
        }
    }
}
