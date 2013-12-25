using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 全局缓存;
using 数据库操作库;
using 辅助库;

namespace Main.管理界面
{
    public partial class 噪声试验 : DevExpress.XtraEditors.XtraForm
    {
        保存振动噪声 _cun = null;
        public 噪声试验()
        {
            InitializeComponent();
        }

        private void cellLefttop52_Load(object sender, EventArgs e)
        {

        }

        private void B_退出试验_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 噪声试验_Load(object sender, EventArgs e)
        {
            Control form = this.Parent.Parent;
            this.panel1.Left = (form.Width - this.panel1.Width) / 2;
            _cun = new 保存振动噪声();
            _cun.加载振动噪声("噪声试验", this);
            _cun.绑定数据();
            T_产品型号.Text = 全局缓存.当前试验组信息.水泵类型;
            T_报告编号.Text = 全局缓存.当前试验组信息.试验编号;
            T_流量.Text = Convert.ToString(全局缓存.当前试验组信息.水泵额定流量);
            T_扬程.Text = Convert.ToString(全局缓存.当前试验组信息.水泵额定扬程);
            T_转速.Text = Convert.ToString(全局缓存.当前试验组信息.水泵额定转速);
            T_效率.Text = Convert.ToString(全局缓存.当前试验组信息.电机额定效率);
          
            绑定图片列表();
            加载ComBox数据();
        }

        public void 绑定图片列表()
        {
            string Path = "试验图片配置\\噪声试验图片.xml";
            List<噪声试验图片> list = 辅助库.类XML转化.XML转类(Path, typeof(List<噪声试验图片>)) as List<噪声试验图片>;
            int len = list.Count;
            foreach (var item in list)
            {
                this.comboBox1.Items.Add(item.图片编号);
            }
            string sql = "select 示意图 from 噪声试验 where groupid =" + 当前试验组信息.试验ID;
            DataTable tb = 数据库操作类.GetTableBySql(sql);
            if (tb.Rows.Count > 0)
            {
                this.comboBox1.SelectedItem = tb.Rows[0]["示意图"].ToString().Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _cun.保存参数("噪声试验");
            string sql = string.Format("update 噪声试验 set 示意图 = '{0}' where groupid = {1}", (string)this.comboBox1.SelectedItem, 当前试验组信息.试验ID);
            数据库操作类.ExcuteSql(sql);
            保存ComBox数据();
            加载ComBox数据();
        }

        private void 加载ComBox数据()
        {
            this.T_测试员.Items.Clear();

            IniFile IniFile = new IniFile("SysConfig.ini");
            string SectionName = "显示配置";
            string user = IniFile.ReadIniFile(SectionName, "username");
            string[] sArray = user.Split(';');

            for (int i = 0; i < sArray.Length; i++)
            {
                this.T_测试员.Items.Add(sArray[i]);
            }
        }

        private void 保存ComBox数据()
        {
            string value = this.T_测试员.Text;
            IniFile IniFile = new IniFile("SysConfig.ini");
            string SectionName = "显示配置";
            string keyname = "username";
            string user = IniFile.ReadIniFile(SectionName, keyname);
            string[] sArray = user.Split(';');


                int flag = 0;
                for (int i = 0; i < sArray.Length; i++)
                {
                    if (sArray[i] == value)
                    {
                        flag = 1;
                        return;
                    }
                }

                if (flag == 0)
                {
                    if (user != string.Empty)
                    {
                        user = user + ";" + value;
                    }
                    else
                    {
                        user = value;
                    }
                    IniFile.WriteIniFile(SectionName, keyname, user);
                }

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Path = "试验图片配置\\" + (string)this.comboBox1.SelectedItem + ".png";
            this.pictureBox1.Load(Path);
        }

        private void T_P1读数值_TextChanged(object sender, EventArgs e)
        {
            计算平均值();
        }

        private void 计算平均值()
        {
           double np = 0;
           int ncount = 0;
           double ntemp = 0;

           if (T_P1读数值.Text.Trim().Equals("") == false)
           {
              ntemp = Convert.ToDouble(T_P1读数值.Text);
              ncount++;
              np += ntemp;
           }

           if (T_P2读数值.Text.Trim().Equals("") == false)
           {
               ntemp = Convert.ToDouble(T_P2读数值.Text);
               ncount++;
               np += ntemp;
           }

           if (T_P3读数值.Text.Trim().Equals("") == false)
           {
               ntemp = Convert.ToDouble(T_P3读数值.Text);
               ncount++;
               np += ntemp;
           }

           if (T_P4读数值.Text.Trim().Equals("") == false)
           {
               ntemp = Convert.ToDouble(T_P4读数值.Text);
               ncount++;
               np += ntemp;
           }

           if (T_P5读数值.Text.Trim().Equals("") == false)
           {
               ntemp = Convert.ToDouble(T_P5读数值.Text);
               ncount++;
               np += ntemp;
           }

           np = np / ncount;
           np = 进制转换.f_保留N位小数((float)np, 2);
           平均噪声.Text = Convert.ToString(np);
        }

        private void T_P2读数值_TextChanged(object sender, EventArgs e)
        {
            计算平均值();
        }

        private void T_P3读数值_TextChanged(object sender, EventArgs e)
        {
            计算平均值();
        }

        private void T_P4读数值_TextChanged(object sender, EventArgs e)
        {
            计算平均值();
        }

        private void T_P5读数值_TextChanged(object sender, EventArgs e)
        {
            计算平均值();
        }
    }
}
