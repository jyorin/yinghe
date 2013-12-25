using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AutoControl
{
    internal class DBControl
    {
        public static decimal[] GetSystemID(int count)
        {
            OleDbConnection Con = GetConnection();
            Con.Open();
            decimal _id = 0;
            int iii=0;
            string sql = "select dbo.IDTable.ID from dbo.IDTable";
            iii = (int)ExecuteScalar(sql, Con);
            _id = (decimal)iii;
           // _id = (decimal)ExecuteScalar(sql, Con);
            decimal[] ids = new decimal[count];
            ids[0] = ++_id;
            for (int i = 1; i < count; i++)
            {
                ids[i] = ++_id;
            }
            sql = "UPDATE dbo.IDTable SET dbo.IDTable.ID = " + _id;
            ExecuteScalar(sql, Con);
            Con.Close();
            return ids;
        }

        public static object ExecuteScalar(string sql, OleDbConnection conn)
        {

            OleDbCommand cmd = new OleDbCommand(sql, conn);
            return cmd.ExecuteScalar();

        }

        public static OleDbConnection GetConnection()
        {
            string DBServer = System.Configuration.ConfigurationSettings.AppSettings["DBServer"].ToString();
            string DBName = System.Configuration.ConfigurationSettings.AppSettings["DBName"].ToString();
            string USER = System.Configuration.ConfigurationSettings.AppSettings["USER"].ToString();
            string PASS = System.Configuration.ConfigurationSettings.AppSettings["PASS"].ToString();
            //OleDbConnection Con = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.0.150,1433\\SQLEXPRESS;Initial Catalog=KQRE_DB;UId=sa;pwd=1234");
            //OleDbConnection Con = new OleDbConnection("Provider=SQLOLEDB;Data Source=127.0.0.1,1433\\LENOVO-THINK;Initial Catalog=KQRE_DB;UId=sa;pwd=1234");
            OleDbConnection Con = new OleDbConnection(string.Format("Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};UId={2};pwd={3}", DBServer, DBName, USER, PASS));
            return Con;
        }

        public static void ExcuteSqlInputParam(string sql, OleDbParameter[] param,int len)
        {
            using (OleDbConnection Connection = GetConnection())
            {
                Connection.Open();
                OleDbCommand cmd = new OleDbCommand(sql, Connection);
                for (int i = 0; i < len;i++ )
                {
                    cmd.Parameters.Add(param[0]);
                }
                cmd.ExecuteNonQuery();
            }
        }
        public static void ExcuteSql(string sql)
        {
            using (OleDbConnection Connection = GetConnection())
            {
                Connection.Open();
                OleDbCommand cmd = new OleDbCommand(sql, Connection);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetTable(string sql)
        {
            DataSet ds = new DataSet();
            using (OleDbDataAdapter da = new OleDbDataAdapter() { SelectCommand = new OleDbCommand() })
            {
                using (OleDbConnection Connection = GetConnection())
                {
                    Connection.Open();
                    da.SelectCommand.Connection = Connection;
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.SelectCommand.CommandText = sql;
                    da.Fill(ds);
                }
            }   
            return ds.Tables[0];
        }

        public static void  FillDataSet(DataSet ds,string tableName,string sql)
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter() { SelectCommand = new OleDbCommand() })
            {
                using (OleDbConnection Connection = GetConnection())
                {
                    Connection.Open();
                    da.SelectCommand.Connection = Connection;
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.SelectCommand.CommandText = sql;
                    da.Fill(ds,tableName);
                }
            }     
        }

    }
}
