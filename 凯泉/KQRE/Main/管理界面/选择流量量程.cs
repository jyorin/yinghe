using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Main.管理界面
{
  
    public partial class 选择流量量程 : Form
    {
        
        public 选择流量量程()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                全局缓存.水泵试验缓存.水泵流量最大量程 = 275;
            }
            else if (this.radioButton2.Checked)
            {
                全局缓存.水泵试验缓存.水泵流量最大量程 = 550;
            }
            else if (this.radioButton3.Checked)
            {
                全局缓存.水泵试验缓存.水泵流量最大量程 = 725;
            }
            this.Close();
        }
    }
}
