using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Net;
using 辅助库;
using DevExpress.XtraEditors;
using System.Reflection;
using 变频器控制;
namespace 控件库.项目控制板
{
    public partial class 凯泉报表控制板 : UserControl
    {
        变频器控制.变频器控制 control = null;
        public 凯泉报表控制板()
        {
            InitializeComponent();
            //设置标题();
            control = 变频器控制.变频器控制.Get_变频器控制();
        }

        public void 设置标题()
        {
            string 组1 = System.Configuration.ConfigurationSettings.AppSettings["组1"].ToString();
            string 组2 = System.Configuration.ConfigurationSettings.AppSettings["组2"].ToString();
            string 组3 = System.Configuration.ConfigurationSettings.AppSettings["组3"].ToString();
            this.BTN_控制组1_正转.Text = 组1 + " # 阀门开";
            this.BTN_控制组1_反转.Text = 组1 + " # 阀门关";
            this.BTN_控制组2_正转.Text = 组2 + " # 阀门开";
            this.BTN_控制组2_反转.Text = 组2 + " # 阀门关";
            this.BTN_控制组3_正转.Text = 组3 + " # 阀门开";
            this.BTN_控制组3_反转.Text = 组3 + " # 阀门关";
            layoutControlGroup2.Text = 组1 + " #";
            layoutControlGroup3.Text = 组2 + " #";
            layoutControlGroup4.Text = 组3 + " #";
        }

        private void BTN_控制组1_正转_MouseDown(object sender, MouseEventArgs e)
        {
            if (!control.变频器1正转())
            {
                MessageBox.Show("设置1#的频率");
            }
            else
            {
                this.BTN_控制组1_正转.ForeColor = Color.Red;
                
            }
        }

        private void BTN_控制组1_正转_MouseUp(object sender, MouseEventArgs e)
        {
            control.变频器1正转停();
            this.BTN_控制组1_正转.ForeColor = Color.Black;
        }

        private void BTN_控制组1_反转_MouseDown(object sender, MouseEventArgs e)
        {
            if (!control.变频器1反转())
            {
                MessageBox.Show("设置1#的频率");
            }
            else
            {
                this.BTN_控制组1_反转.ForeColor = Color.Red;
            }
        }

        private void BTN_控制组1_反转_MouseUp(object sender, MouseEventArgs e)
        {
            control.变频器1反转停();
            this.BTN_控制组1_反转.ForeColor = Color.Black;
        }

        private void BTN_控制组2_正转_MouseDown(object sender, MouseEventArgs e)
        {
            if (!control.变频器2正转())
            {
                MessageBox.Show("设置2#的频率");
            }
            else
            {
                this.BTN_控制组2_正转.ForeColor = Color.Red;
            }
        }

        private void BTN_控制组2_正转_MouseUp(object sender, MouseEventArgs e)
        {
            control.变频器2正转停();
            this.BTN_控制组2_正转.ForeColor = Color.Black;
        }

        private void BTN_控制组2_反转_MouseDown(object sender, MouseEventArgs e)
        {
            if (!control.变频器2反转())
            {
                MessageBox.Show("设置2#的频率");
            }
            else
            {
                this.BTN_控制组2_反转.ForeColor = Color.Red;
            }
        }

        private void BTN_控制组2_反转_MouseUp(object sender, MouseEventArgs e)
        {
            control.变频器2反转停();
            this.BTN_控制组2_反转.ForeColor = Color.Black;
        }

        private void BTN_控制组1_步长_Click(object sender, EventArgs e)
        {
            control.变频器1写频率((decimal)this.numericEdit1.Value);
        }

        private void BTN_控制组2_步长_Click(object sender, EventArgs e)
        {
            control.变频器2写频率((decimal)this.numericEdit2.Value);
        }

        private void BTN_控制组3_正转_MouseDown(object sender, MouseEventArgs e)
        {
            control.变频器3正转();
            this.BTN_控制组3_正转.ForeColor = Color.Red;
        }

        private void BTN_控制组3_正转_MouseUp(object sender, MouseEventArgs e)
        {
            control.变频器3正转停();
            this.BTN_控制组3_正转.ForeColor = Color.Black;
        }

        private void BTN_控制组3_反转_MouseDown(object sender, MouseEventArgs e)
        {
            control.变频器3反转();
            this.BTN_控制组3_反转.ForeColor = Color.Red;
        }

        private void BTN_控制组3_反转_MouseUp(object sender, MouseEventArgs e)
        {
            control.变频器3反转停();
            this.BTN_控制组3_反转.ForeColor = Color.Black;
        }
    }
}
