using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 数据库操作库;

namespace LogicApp.试验组模块
{
    public class 拷贝试验组
    {
        public static void 拷贝(decimal id)
        {
            decimal theId = 数据库操作类.GetSystemID();
            DataSet ds = new DataSet();
            DataTable kb = new DataTable("生成试验组");
            ds.Tables.Add(kb);
            数据库操作类.FillDataSet(ds, "生成试验组", string.Format("select * from dbo.生成试验组 where id = {0}",id));
            ds.Tables["生成试验组"].Rows[0]["id"] = theId;
            ds.Tables["生成试验组"].Rows[0]["试验编号"] = ds.Tables["生成试验组"].Rows[0]["试验编号"] + "-" + theId;
            ds.Tables["生成试验组"].Rows[0]["试验组名"] = ds.Tables["生成试验组"].Rows[0]["试验组名"] + "-" + theId;
            ds.Tables["生成试验组"].AcceptChanges();
            ds.Tables["生成试验组"].Rows[0].SetAdded();
            数据库操作类.Save(ds.Tables["生成试验组"], "生成试验组");

            ////////////////////////////// 潜水泵性能试验
            DataTable kb1 = new DataTable("潜水泵性能试验");
            ds.Tables.Add(kb1);
            数据库操作类.FillDataSet(ds, "潜水泵性能试验", string.Format("select * from dbo.潜水泵性能试验 where groupid = {0}", id));
            int len = ds.Tables["潜水泵性能试验"].Rows.Count;   
            for (int i = 0; i < len; i++)
            {
                ds.Tables["潜水泵性能试验"].Rows[i]["id"] = 数据库操作类.GetSystemID();
                ds.Tables["潜水泵性能试验"].Rows[i]["groupid"] = theId;
                ds.Tables["潜水泵性能试验"].Rows[i].AcceptChanges();
                ds.Tables["潜水泵性能试验"].Rows[i].SetAdded();
            }
           
            数据库操作类.Save(ds.Tables["潜水泵性能试验"], "潜水泵性能试验");

            ////////////////////////////// 运转试验
            ds.Clear();
            DataTable kb2 = new DataTable("运转试验");
            ds.Tables.Add(kb2);
            数据库操作类.FillDataSet(ds, "运转试验", string.Format("select * from dbo.运转试验 where groupid = {0}", id));
            len = ds.Tables["运转试验"].Rows.Count;
            for (int i = 0; i < len; i++)
            {
                ds.Tables["运转试验"].Rows[i]["id"] = 数据库操作类.GetSystemID();
                ds.Tables["运转试验"].Rows[i]["groupid"] = theId;
                ds.Tables["运转试验"].Rows[i].AcceptChanges();
                ds.Tables["运转试验"].Rows[i].SetAdded();
            }

            数据库操作类.Save(ds.Tables["运转试验"], "运转试验");

            ////////////////////////////// 启动试验
            ds.Clear();
            DataTable kb3 = new DataTable("启动试验");
            ds.Tables.Add(kb3);
            数据库操作类.FillDataSet(ds, "启动试验", string.Format("select * from dbo.启动试验 where groupid = {0}", id));
            len = ds.Tables["启动试验"].Rows.Count;
            for (int i = 0; i < len; i++)
            {
                ds.Tables["启动试验"].Rows[i]["id"] = 数据库操作类.GetSystemID();
                ds.Tables["启动试验"].Rows[i]["groupid"] = theId;
                ds.Tables["启动试验"].Rows[i].AcceptChanges();
                ds.Tables["启动试验"].Rows[i].SetAdded();
            }

            数据库操作类.Save(ds.Tables["启动试验"], "启动试验");


            ////////////////////////////// 惰转试验
            ds.Clear();
            DataTable kbadd = new DataTable("惰转试验");
            ds.Tables.Add(kbadd);
            数据库操作类.FillDataSet(ds, "惰转试验", string.Format("select * from dbo.惰转试验 where groupid = {0}", id));
            len = ds.Tables["惰转试验"].Rows.Count;
            for (int i = 0; i < len; i++)
            {
                ds.Tables["惰转试验"].Rows[i]["id"] = 数据库操作类.GetSystemID();
                ds.Tables["惰转试验"].Rows[i]["groupid"] = theId;
                ds.Tables["惰转试验"].Rows[i].AcceptChanges();
                ds.Tables["惰转试验"].Rows[i].SetAdded();
            }

            数据库操作类.Save(ds.Tables["惰转试验"], "惰转试验");

            ////////////////////////////// 汽蚀试验
            List<int> list_old = new List<int>();
            List<int> list_new = new List<int>();
            ds.Clear();
            DataTable kb4 = new DataTable("汽蚀试验");
            ds.Tables.Add(kb4);
            数据库操作类.FillDataSet(ds, "汽蚀试验", string.Format("select * from dbo.汽蚀试验 where groupid = {0}", id));
            len = ds.Tables["汽蚀试验"].Rows.Count;
            for (int i = 0; i < len; i++)
            {
                ds.Tables["汽蚀试验"].Rows[i]["id"] = 数据库操作类.GetSystemID();
                ds.Tables["汽蚀试验"].Rows[i]["groupid"] = theId;
                list_old.Add(System.Convert.ToInt32(ds.Tables["汽蚀试验"].Rows[i]["批次编号"].ToString()));
                ds.Tables["汽蚀试验"].Rows[i]["批次编号"] = 数据库操作类.GetSystemID();
                list_new.Add(System.Convert.ToInt32(ds.Tables["汽蚀试验"].Rows[i]["批次编号"].ToString()));
                ds.Tables["汽蚀试验"].Rows[i].AcceptChanges();
                ds.Tables["汽蚀试验"].Rows[i].SetAdded();
            }

            数据库操作类.Save(ds.Tables["汽蚀试验"], "汽蚀试验");
            ////////////////////////////////汽蚀试验批次
            ds.Clear();
            string sql = string.Empty;
            for (int i = 0; i < len; i++)
            {
                sql = "select * from dbo.汽蚀试验批次 where 批次编号 = " + list_old[i];
                DataTable tb = 数据库操作类.GetTableBySql(sql);
                tb.Rows[0]["批次编号"] = list_new[i];
                if (i == 0)
                {
                    tb.TableName = "汽蚀试验批次";
                    ds.Tables.Add(tb);
                }
                else
                {
                    ds.Tables[0].ImportRow(tb.Rows[0]);
                }
            }
            数据库操作类.Save(ds.Tables["汽蚀试验批次"], "汽蚀试验批次");
        }
    }
}
