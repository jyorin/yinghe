using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using 全局缓存;

namespace 数据库操作库
{
    public class 数据库操作类
    {
        private static OleDbConnection 数据库操作对象 = null;
        public static Boolean 连接数据库()
        {
            string DBServer = System.Configuration.ConfigurationSettings.AppSettings["DBServer"].ToString();
            string DBName = System.Configuration.ConfigurationSettings.AppSettings["DBName"].ToString();
            string USER = System.Configuration.ConfigurationSettings.AppSettings["USER"].ToString();
            string PASS = System.Configuration.ConfigurationSettings.AppSettings["PASS"].ToString();
            try
            {
                if (数据库操作对象 == null)
                {
                    //数据库操作对象 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.1.151,1433\\SQLEXPRESS;Initial Catalog=KQRE_DB;UId=sa;pwd=1234");
                    数据库操作对象 = new OleDbConnection(string.Format("Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};UId={2};pwd={3}", DBServer, DBName,USER,PASS));
                   
                    数据库操作对象.Open();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean 关闭数据库()
        {
            try
            {
                if (数据库操作对象 != null)
                {
                    数据库操作对象.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void ExcuteSqlInputParam(string sql, OleDbParameter[] param, int len)
        {
            if (连接数据库() == true)
            {
                OleDbCommand cmd = new OleDbCommand(sql, 数据库操作对象);
                for (int i = 0; i < len; i++)
                {
                    cmd.Parameters.Add(param[0]);
                }
                cmd.ExecuteNonQuery();
            }
        }
        public static void ExcuteSql(string sql)
        {
             if (连接数据库()==true)
             {
                 OleDbCommand cmd = new OleDbCommand(sql, 数据库操作对象);
                cmd.ExecuteNonQuery();
              }
        }
        public static DataTable GetTable(string strTabName)
        {
            string sql = "select * from " + strTabName;
            DataSet ds = new DataSet();
            using (OleDbDataAdapter da = new OleDbDataAdapter() { SelectCommand = new OleDbCommand() })
            {
                if (连接数据库() == true)
                {
                    da.SelectCommand.Connection = 数据库操作对象;
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.SelectCommand.CommandText = sql;
                    da.Fill(ds);
                }
            }
            return ds.Tables[0];
        }
        public static DataTable GetTableBySql(string sql)
        {
            DataSet ds = new DataSet();
            using (OleDbDataAdapter da = new OleDbDataAdapter() { SelectCommand = new OleDbCommand() })
            {
                if (连接数据库() == true)
                {
                    da.SelectCommand.Connection = 数据库操作对象;
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.SelectCommand.CommandText = sql;
                    da.Fill(ds);
                }
            }
            return ds.Tables[0];
        }
        public static object ExecuteScalar(string sql)
        {
            
            OleDbCommand cmd = new OleDbCommand(sql, 数据库操作对象);
            return cmd.ExecuteScalar();

        }
        public static decimal[] GetSystemID(int count)
        {
            连接数据库();

            decimal _id = 0;
            int iii = 0;
            string sql = "select dbo.IDTable.ID from dbo.IDTable";
            iii = (int)ExecuteScalar(sql);
            _id = (decimal)iii;
            decimal[] ids = new decimal[count];
            ids[0] = ++_id;
            for (int i = 1; i < count; i++)
            {
                ids[i] = ++_id;
            }
            sql = "UPDATE dbo.IDTable SET dbo.IDTable.ID = " + _id;
            ExecuteScalar(sql);

            return ids;
        }
        public static decimal GetSystemID()
        {
            连接数据库();

            decimal _id = 0;
            int iii = 0;
            string sql = "select dbo.IDTable.ID from dbo.IDTable";
            iii = (int)ExecuteScalar(sql);
            _id = (decimal)iii;
            decimal ids;
            ids = ++_id;

            sql = "UPDATE dbo.IDTable SET dbo.IDTable.ID = " + _id;
            ExecuteScalar(sql);

            return ids;
        }

        public static void FillDataSet(DataSet ds, string tableName, string sql)
        {
            if (连接数据库() == true)
            {
                using (OleDbDataAdapter da = new OleDbDataAdapter() { SelectCommand = new OleDbCommand() })
                {

                    da.SelectCommand.Connection = 数据库操作对象;
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.SelectCommand.CommandText = sql;
                    da.Fill(ds, tableName);

                }
            }
           
        }
        public static decimal GetTableMaxIDByName(string tabName)
        {
            连接数据库();
            decimal _id = 0;
            string sql = string.Format("select max(id) from {0}",tabName.Trim());
            object obj = ExecuteScalar(sql);
            if (obj != System.DBNull.Value) { return (decimal)obj; }
            return 0;
        }

        public static int Save(DataTable tb,string tbName)
        {
            if (连接数据库() == true)
            {
              
                tb.TableName = "dbo." + tbName;
                OleDbDataAdapter da = new OleDbDataAdapter(string.Format("select * from {0}", "dbo." + tbName), 数据库操作对象);
                da.MissingSchemaAction = MissingSchemaAction.Ignore;
                OleDbCommandBuilder CommandBuilder = new OleDbCommandBuilder(da);
                da.InsertCommand = CommandBuilder.GetInsertCommand();
                da.DeleteCommand = CommandBuilder.GetDeleteCommand();
                da.UpdateCommand = CommandBuilder.GetUpdateCommand();
                return da.Update(tb);
            }
            return -1;
        }

        public static void 图片存储(string 列名, byte[] bytes)
        {
            decimal id = 当前试验组信息.试验ID;
            string sql = string.Format("UPDATE 生成试验组  SET {0} = ? WHERE ID = {1}", 列名,id);
            if (连接数据库() == true)
            {
                OleDbCommand cmd = new OleDbCommand(sql, 数据库操作对象);
                OleDbParameter par = new OleDbParameter();
                par.ParameterName = "@par";
                par.OleDbType = OleDbType.LongVarBinary;
                par.Value = bytes;
                cmd.Parameters.Add(par);
                cmd.ExecuteNonQuery();     
            }
        }
    }
}
