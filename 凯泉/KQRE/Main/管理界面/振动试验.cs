using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using 全局缓存;
using 数据库操作库;
using 辅助库;

namespace Main.管理界面
{
    public partial class 振动试验 : DevExpress.XtraEditors.XtraForm
    {
        保存振动噪声 _cun = null;
        List<int> 仪器编号列表;
        public 振动试验()
        {
            InitializeComponent();
             if (仪器编号列表 == null)
             仪器编号列表 = new List<int>();
            仪器编号列表.Clear();
        }

        private void 振动试验_Load(object sender, EventArgs e)
        {
            Control form = this.Parent.Parent;
            this.panel2.Left = (form.Width - this.panel2.Width) / 2;
            _cun = new 保存振动噪声();
            _cun.加载振动噪声("振动试验", this);
            _cun.绑定数据();
            T_产品型号.Text = 全局缓存.当前试验组信息.水泵类型;
            T_报告编号.Text = 全局缓存.当前试验组信息.试验编号;
            T_流量.Text = Convert.ToString(全局缓存.当前试验组信息.水泵额定流量);
            T_扬程.Text = Convert.ToString(全局缓存.当前试验组信息.水泵额定扬程);
            绑定图片列表();
            重新装载控件参数();
            加载ComBox数据();
        }

        public void 绑定图片列表()
        {
            string Path = "试验图片配置\\振动试验图片.xml";
            List<振动试验图片> list = 辅助库.类XML转化.XML转类(Path, typeof(List<振动试验图片>)) as List<振动试验图片>;
            int len = list.Count;
            foreach (var item in list)
            {
                this.comboBox1.Items.Add(item.图片编号);
            }
            string sql = "select 示意图 from 振动试验 where groupid =" + 当前试验组信息.试验ID;
            DataTable tb = 数据库操作类.GetTableBySql(sql);
            if (tb.Rows.Count > 0)
            {
                this.comboBox1.SelectedItem = tb.Rows[0]["示意图"].ToString().Trim();
            }
        }

        private void B_退出试验_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_保存试验_Click(object sender, EventArgs e)
        {
            _cun.保存参数("振动试验");
            string sql = string.Format("update 振动试验 set 示意图 = '{0}' where groupid = {1}",(string)this.comboBox1.SelectedItem,当前试验组信息.试验ID);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Path = "试验图片配置\\" + (string)this.comboBox1.SelectedItem + ".png";
            this.pictureBox1.Load(Path);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 重新装载控件参数()
        {
            T_仪器名称.Items.Clear();
            if (仪器编号列表 == null)
                仪器编号列表 = new List<int>();
            仪器编号列表.Clear();

            DataTable datatable;
            datatable = 数据库操作类.GetTable("dbo.振动测量仪表");

            foreach (DataRow dr in datatable.Rows)
            {
                int  n编号 = (int)dr["ID"];
                仪器编号列表.Insert(仪器编号列表.Count, n编号);
                T_仪器名称.Items.Insert(T_仪器名称.Items.Count, (string)dr["仪器名称"]);
            }

        }
        private void 选择仪器()
        {
            int nindex = T_仪器名称.SelectedIndex;
            if (仪器编号列表.Count < (nindex+1))
            {
                return;
            }
            string sql = "select * from 振动测量仪表 where ID =" + 仪器编号列表[nindex];
            DataTable tb = 数据库操作类.GetTableBySql(sql);
            if (tb.Rows.Count > 0)
            {
                T_仪器型号.Text = tb.Rows[0]["仪器型号"].ToString();
                T_检定单位.Text = tb.Rows[0]["检定单位"].ToString();
            }
        }

        private void T_仪器名称_SelectedIndexChanged(object sender, EventArgs e)
        {
            选择仪器();
        }
    }
}