using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 数据库操作库;
using 全局缓存;
namespace 辅助库
{
    public static class 公共函数
    {
        public static bool f_查询水密度(double n温度, out double n水密度)
        {
            DataTable datatable;
            datatable = 数据库操作类.GetTable("dbo.水密度");
            double n温度上限 = 0;
            double n温度下限 = 0;
            n水密度 = 0;

            foreach (DataRow dr in datatable.Rows)
            {
                n温度上限 = (double)dr["温度上限"];
                n温度下限 = (double)dr["温度下限"];

                if ((n温度 >= n温度下限) && (n温度 <= n温度上限))
                {
                    n水密度 = (double)dr["水密度"];
                    return true;
                }
            }

            return false;
        }

        public static bool 加载水泵环境参数(int ID)
        {
            string strSql = "Select * from 水泵环境参数 where ID = " + ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return false;
            }

            foreach (DataRow dr in tb.Rows)
            {
                水泵试验缓存.流量通道 = Convert.ToString(dr["流量通道"]);
                水泵试验缓存.水泵流量最大量程 = Convert.ToInt32(dr["流量最大量程"]);
                水泵试验缓存.进口压力通道 = Convert.ToString(dr["进口压力通道"]);
                水泵试验缓存.进口压力量程 = Convert.ToSingle(dr["进口压力量程"]);
                水泵试验缓存.出口压力通道 = Convert.ToString(dr["出口压力通道"]);
                水泵试验缓存.出口压力量程 = Convert.ToSingle(dr["出口压力量程"]);
                水泵试验缓存.变比 = Convert.ToSingle(dr["变比"]);
                水泵试验缓存.偏移量 = Convert.ToSingle(dr["偏移量"]);
                水泵试验缓存.常量 = Convert.ToSingle(dr["常量"]);
                return true;
            }

            return false;
        }
        public static bool f_查询汽化压力(double n温度, out double n汽化压力)
        {
            DataTable datatable;
            datatable = 数据库操作类.GetTable("dbo.汽化压力");
            double n温度上限 = 0;
            double n温度下限 = 0;
            n汽化压力 = 0;

            foreach (DataRow dr in datatable.Rows)
            {
                n温度上限 = (double)dr["温度上限"];
                n温度下限 = (double)dr["温度下限"];

                if ((n温度 >= n温度下限) && (n温度 <= n温度上限))
                {
                    n汽化压力 = (double)dr["汽化压力"];
                    return true;
                }
            }

            return false;
        }

        public static int List_最大值序号(List<double> 数组)
        {
            int index = -1;
            double num = 0;
            double temp = 0;
            for (int i = 0; i < 数组.Count; i++)
            {
                temp = 数组[i];
                if (num > temp)
                {
                    num = 数组[i];
                }

                index = i;
            }

            return index;
        }


        //NPSH= Z1+p1/(ρ*g)+(v1^2)/(2*g)+pb/(ρ*g)-pv/(ρ*g);
        //v1=Q1/Sr1;
        //Z1进口表矩
        //p1进口表压
        //Q1流量
        //g重力加速度
        //ρ水密度,根据温度查询
        //pv 汽化压力,根据温度查询
        //Sr1进口直径
        public static double f_计算NPSH的值(double 温度, double 进口表压, double 流量)
        {
            double npsh = 0;
            double pb = 0.1023*1000000;//标准大气
            double g = 9.81;//重力加速度
            double Z1 = 全局缓存.当前试验组信息.进口压力表距;//进口表距
            double ρ = 0;//水密度,根据温度查询
            公共函数.f_查询水密度(温度, out ρ);
            double pv = 0;//汽化压力,根据温度查询
            公共函数.f_查询汽化压力(温度, out pv);
            pv *= 1000000;
            double Q1 = 流量;//流量
            double Sr1 = 全局缓存.当前试验组信息.水泵进口直径/1000;//进口直径
            double mj = 3.14 * (Sr1 / 2) * (Sr1 / 2) ;//进口面积,=3600/4是时间的转换
            double p1 = 进口表压*1000;//进口表压
            double v1 = (Q1/3600)/ mj;//进口流速,900=3600/4是时间的转换
            if (ρ == 0)
            {
                npsh = 0;
            }
            else
            {
                npsh = Z1 + p1 / (ρ * g) + (v1 * v1) / (2 * g) + pb / (ρ * g) - pv / (ρ * g);
            }


            return npsh;
        }
    }
}
