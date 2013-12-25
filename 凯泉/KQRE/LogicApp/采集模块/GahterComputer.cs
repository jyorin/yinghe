using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gather;
using 全局缓存;
namespace LogicApp.采集模块
{
    public class 出口压力计算 : ITableComputer
    {
        float ITableComputer.Computer(float d, System.Data.DataRowView row)
        {
            if (d != 0)
            {
                row["扬程"] = Math.Round(d * 1.02 + 当前试验组信息.出口压力表距,2);
                double 转速 = Convert.ToDouble(row["转速"]);
                row["额定转速下_扬程"] = Math.Round(Math.Pow(当前试验组信息.水泵额定转速 / 转速, 2) * Convert.ToDouble(row["扬程"]),2);
            }
            return -1;
        }
    }
    public class 额定转速计算 : ITableComputer
    {
        float ITableComputer.Computer(float d, System.Data.DataRowView row)
        {
            //说明 d 对应注册的列修改的值,然后根据d来修改其他的列的值
            //如：row["流量"] = d * 1000 / 456;
            //return -1;  返回值暂时没用。

            // 计算顺序不可更改
            if (d != 0)
            {
                row["扬程"] = Math.Round(Convert.ToDouble(row["出口压力"]) * 1.02 + 当前试验组信息.出口压力表距,2);
              
                row["额定转速下_流量"] = Math.Round(当前试验组信息.水泵额定转速 / d * Convert.ToDouble(row["流量"]),2);
                row["额定转速下_扬程"] = Math.Round(Math.Pow(当前试验组信息.水泵额定转速 / d, 2) * Convert.ToDouble(row["扬程"]),2);
                row["额定转速下_轴功率"] = Math.Round(Math.Pow(当前试验组信息.水泵额定转速 / d, 3) * Convert.ToDouble(row["轴功率"]),2);
            }
            if (Convert.ToDouble(row["额定转速下_轴功率"])!=0)
            row["额定转速下_泵效率"] = Math.Round((Convert.ToDouble(row["额定转速下_流量"]) * Convert.ToDouble(row["额定转速下_扬程"])) / (102 * 3.6) / Convert.ToDouble(row["额定转速下_轴功率"]) * 100,2);
            row["额定转速下_机组效率"] = Math.Round(Convert.ToDouble(row["额定转速下_泵效率"]) * 当前试验组信息.电机额定效率,2);
            return -1;
        }
    }

}
