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
using AutoControl;
using 辅助库;

namespace Main.管理界面
{
    public partial class 水泵环境参数配置 : Form
    {
        private int 水泵ID;
        private string m_str出厂编号;
        private FormElement _form = null;
        public 水泵环境参数配置(string 出厂编号,int ID)
        {
            InitializeComponent();

            m_str出厂编号 = 出厂编号;
            公共函数.加载水泵环境参数(ID);
            水泵ID = ID;
            ResetCtrl();
            //this.c流量.SelectedItem = 水泵试验缓存.流量通道;
            //this.c出口压力.SelectedItem = 水泵试验缓存.出口压力通道;
            //this.c进口压力.SelectedItem = 水泵试验缓存.进口压力通道;
            //a.Text = 水泵试验缓存.变比.ToString();
            //b.Text = 水泵试验缓存.偏移量.ToString();
            //c.Text = 水泵试验缓存.常量.ToString();
            //t出口压力.Text = 水泵试验缓存.出口压力量程.ToString();
            //t进口压力.Text = 水泵试验缓存.进口压力量程.ToString();
            //c流量最大量程.Text = 水泵试验缓存.水泵流量最大量程.ToString();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            //水泵试验缓存.水泵流量最大量程 = System.Convert.ToInt32(c流量最大量程.Text);
            //水泵试验缓存.变比 = System.Convert.ToSingle(a.Text);
            //水泵试验缓存.偏移量 = System.Convert.ToSingle(b.Text);
            //水泵试验缓存.常量 = System.Convert.ToSingle(c.Text);
            //水泵试验缓存.出口压力量程 = System.Convert.ToSingle(t出口压力.Text);
            //水泵试验缓存.进口压力量程 = System.Convert.ToSingle(t进口压力.Text);
            //水泵试验缓存.进口压力通道 = (string)c进口压力.SelectedItem;
            //水泵试验缓存.出口压力通道 = (string)c出口压力.SelectedItem;
            //水泵试验缓存.流量通道 = (string)c流量.SelectedItem;

            if (水泵环境参数配置保存(水泵ID))
            {
                ResetBuf();
            }
            else
            {
                MessageBox.Show("水泵参数设置失败！", "提示");
            }

            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void ResetCtrl()
        {
            this.c流量.SelectedItem = 水泵试验缓存.流量通道;
            this.c出口压力.SelectedItem = 水泵试验缓存.出口压力通道;
            this.c进口压力.SelectedItem = 水泵试验缓存.进口压力通道;
            a.Text = 水泵试验缓存.变比.ToString();
            b.Text = 水泵试验缓存.偏移量.ToString();
            c.Text = 水泵试验缓存.常量.ToString();
            t出口压力.Text = 水泵试验缓存.出口压力量程.ToString();
            t进口压力.Text = 水泵试验缓存.进口压力量程.ToString();
            c流量最大量程.Text = 水泵试验缓存.水泵流量最大量程.ToString();
        }
        private void ResetBuf()
        {
            水泵试验缓存.水泵流量最大量程 = System.Convert.ToInt32(c流量最大量程.Text);
            水泵试验缓存.变比 = System.Convert.ToSingle(a.Text);
            水泵试验缓存.偏移量 = System.Convert.ToSingle(b.Text);
            水泵试验缓存.常量 = System.Convert.ToSingle(c.Text);
            水泵试验缓存.出口压力量程 = System.Convert.ToSingle(t出口压力.Text);
            水泵试验缓存.进口压力量程 = System.Convert.ToSingle(t进口压力.Text);
            水泵试验缓存.进口压力通道 = (string)c进口压力.SelectedItem;
            水泵试验缓存.出口压力通道 = (string)c出口压力.SelectedItem;
            水泵试验缓存.流量通道 = (string)c流量.SelectedItem;
        }

        private bool 水泵环境参数配置保存(int ID)
        {
            bool bInsert = false;
            string strSql = "Select * from 水泵环境参数 where ID = "+ ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                bInsert = true;
            }

            if (bInsert)
            {
                return insert水泵环境参数配置(ID);
            }
            else
            {
                return update水泵环境参数配置(ID);
            }
            return true;
        }

        private bool insert水泵环境参数配置(int ID)
        {
            string strSql = "insert into dbo.水泵环境参数  (ID,出厂编号,流量通道,流量最大量程,进口压力通道,进口压力量程," +
                "出口压力通道,出口压力量程,变比,偏移量,常量) values (" +
                              ID + ",";

            strSql += "'";
            strSql += m_str出厂编号;
            strSql += "','";
            strSql += c流量.SelectedItem;
            strSql += "',";
            strSql += Convert.ToSingle(c流量最大量程.Text);
            strSql += ",'";
            strSql += c进口压力.SelectedItem;
            strSql += "',";
            strSql += System.Convert.ToSingle(t进口压力.Text);
            strSql += ",'";
            strSql += c出口压力.SelectedItem;
            strSql += "',";
            strSql += System.Convert.ToSingle(t出口压力.Text);
            strSql += ",";
            strSql += System.Convert.ToSingle(a.Text);
            strSql += ",";
            strSql += System.Convert.ToSingle(b.Text);
            strSql += ",";
            strSql += System.Convert.ToSingle(c.Text);
            strSql += ")";

            try
            {
                if (_form == null)
                {
                    _form = new FormElement();
                }
                _form.ExcuteSql(strSql);
            }
            catch (System.Exception ex)
            {
                return false; 	
            }
             return true;
        }

        private bool update水泵环境参数配置(int ID)
        {
            string strSql = "update dbo.水泵环境参数  set ";

            strSql += "出厂编号='";
            strSql += m_str出厂编号;
            strSql += "',";
            strSql += "流量通道='";
            strSql +=  c流量.SelectedItem;
            strSql += "',";
            strSql += "流量最大量程=";
            strSql += Convert.ToSingle(c流量最大量程.Text);
            strSql += ",";
            strSql += "进口压力通道='";
            strSql += c进口压力.SelectedItem;
            strSql += "',";
            strSql += "进口压力量程=";
            strSql += System.Convert.ToSingle(t进口压力.Text);
            strSql += ",";
            strSql += "出口压力通道='";
            strSql += c出口压力.SelectedItem;
            strSql += "',";
            strSql += "出口压力量程=";
            strSql += System.Convert.ToSingle(t出口压力.Text);
            strSql += ",";
            strSql += "变比=";
            strSql += System.Convert.ToSingle(a.Text);
            strSql += ",";
            strSql += "偏移量=";
            strSql += System.Convert.ToSingle(b.Text);
            strSql += ",";
            strSql += "常量=";
            strSql += System.Convert.ToSingle(c.Text);
            strSql += " where ID=" + ID;

            try
            {
                if (_form == null)
                {
                    _form = new FormElement();
                }
                _form.ExcuteSql(strSql);
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return true;
        }

    }
}
