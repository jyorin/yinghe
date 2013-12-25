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
    internal partial class comboBoxUC : UserControl
    {
        public comboBoxUC()
        {
            InitializeComponent();
        }

        public string GetValue()
        {
            return (string)this.comboBox1.SelectedItem;
        }

        public void SetValue(string value)
        {
            if (value != null)
            {
                //for (int i=0;i<this.comboBox1.Items.Count;i++)
                //{
                //    if (this.comboBox1.Items[i].ToString().Equals(value) == true)
                //    {
                //    }
                //}
                this.comboBox1.SelectedItem = null;
                this.comboBox1.SelectedItem = value.Trim();
                if (this.comboBox1.SelectedItem == null)
                {
                    ClearRecord();
                }
            }
            else
            {
                ClearRecord();
            }
        }

        public void BindTheControl(List<string> list,string value)
        {
            this.comboBox1.Items.Clear();
            foreach (string item in list)
            {
                this.comboBox1.Items.Add(item.Trim());
            }
            if (value != null)
            {
                this.comboBox1.SelectedItem = value.Trim();
                if (this.comboBox1.SelectedItem == null)
                {
                    ClearRecord();
                }
            }
            else
            {
                ClearRecord();
            }
        }

        public void ClearRecord()
        {
            this.comboBox1.SelectedIndex = -1;
            this.comboBox1.Text = "";
        }

    }
}
