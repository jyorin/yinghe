using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 控件库.曲线控件
{
    public partial class 调整坐标轴 : DevExpress.XtraEditors.XtraForm
    {
        XYGraph 曲线控件;
        public 调整坐标轴(XYGraph graph)
        {
            InitializeComponent();
            曲线控件 = graph;
            for (int i = 0; i < 曲线控件.Graph.Plots.Count; i++)
            {
                if (曲线控件.Graph.Plots[i].Tag == null) continue;
                if (曲线控件.Graph.Plots[i].Tag.ToString().EndsWith("S")) continue;
                CB_所属曲线.Items.Add(曲线控件.Graph.Plots[i].Tag.ToString());
            }
        }

        private void BTN_确定_Click(object sender, EventArgs e)
        {
            if (num_X_max.Value > num_X_min.Value && num_Y_max.Value > num_Y_min.Value)
            {
                曲线控件.x轴对象.Range = new NationalInstruments.UI.Range(num_X_min.Value, num_X_max.Value);
                string plotName = CB_所属曲线.Text;
                for (int i = 0; i < 曲线控件.Graph.Plots.Count; i++)
                {
                    if (曲线控件.Graph.Plots[i].Tag.ToString().Equals(plotName))
                    {
                        曲线控件.Graph.Plots[i].YAxis.Range = new NationalInstruments.UI.Range(num_Y_min.Value, num_Y_max.Value);
                    }
                }
            }
            else
            {
                MessageBox.Show("曲线坐标系设置异常,坐标轴最小值不能小于或等于最大值");
            }

        }

        private void BTN_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
