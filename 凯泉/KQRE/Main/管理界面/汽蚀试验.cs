using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using 控件库.数字仪表;
using 辅助库;
using LogicApp;
using LogicApp.采集模块;
using Gather;
using 全局缓存;
using 控件库.曲线控件;
using 控件库.表格控件;
using NationalInstruments.UI;
using System.IO;
using System.Drawing.Imaging;
using 辅助库;
using 数据库操作库;
using 数据存储;
using Computer;

namespace Main.管理界面
{
    public partial class 汽蚀试验 : DevExpress.XtraEditors.XtraForm, IThreadAction
    {
        private 曲线拟合 _曲线拟合 = null;
        private GatherLogic logic = null;
        private DataTable datatable_批次;
        private DataTable datatable_采集;
        private DataTable datatable;
        private IValue _批次编号;
        private double 曲线汽蚀余量 = 0;
        private decimal 批次号 = -1;
        public 汽蚀试验()
        {
           _曲线拟合 = new 曲线拟合();
           logic = new GatherLogic();

            InitializeComponent();
            xyGraph1.f_设置汽蚀试验模式();
           // grid2.SetGridtoBandGrid();         
        }


        private void 汽蚀试验_Load(object sender, EventArgs e)
        {

            this.凯泉报表控制板1.设置标题();
            DataPvg.LoadDataPvg(100);
            _批次编号 = (IValue)数据项哈希存储.GetIValue("批次编号");
            // 毋需注销的控件
            this.grid1.InitViewLayout("试验表格配置\\汽蚀试验批次.xml");
            grid2.SetGridtoBandGrid();
            this.grid2.InitViewLayout("试验表格配置\\汽蚀试验.xml");

            if (当前试验组信息.试验ID == 0) { return; }

            logic.Load("汽蚀试验", this, 当前试验组信息.试验ID, 5, 20);
            logic.LoadGrid(this.grid2, "汽蚀试验", string.Empty, "汽蚀余量 desc", false);

            //if (全局缓存.当前试验组信息.Has流量仪表 == false)
            //{
            //    logic.TableComputer("汽蚀试验", "流量", new 性能试验_额定转速下流量());
            //}
            InitGrid_批次();
            //logic.LoadGrid(this.grid2, "汽蚀试验");

          
            xyGraph1.Invalidate();

            // 需要人工注销的控件
            this.数显仪表集合1.f_初始化所有仪表("试验数显配置\\汽蚀试验数显区配置.xml");
            this.数显仪表集合1.添加警告项("汽蚀试验额定转速下流量");

            全局缓存.水泵试验缓存.汽蚀试验进行中 = true;
        }

        private void 汽蚀试验_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.数显仪表集合1.结束警告("流量");
            ((MainFrame)this.Parent.Parent).数显仪表集合1.结束警告("流量");
            this.数显仪表集合1.f_注销所有仪表();

            //this.凯泉报表控制板1.f_注销控制通道();
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            增加批次();
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            删除批次();
        }

        private void grid1_Btn执行命令1Click(object sender, EventArgs e)
        {

        }

        public bool isAction()
        {
            return this.IsHandleCreated;
        }

        public void Action(ActionData _action)
        {
            this.BeginInvoke(_action);
        }

        private void f_绘制全部曲线()
        {
            DataTable datatable批次 = 数据库操作类.GetTable("汽蚀试验批次");
            foreach (DataRow dr in datatable批次.Rows)
            {
                f_绘制采集曲线(xyGraph1, Convert.ToString(dr["批次编号"]), grid2, "扬程");
            }
        }

        private void f_绘制采集曲线(XYGraph 曲线控件, string 需要进行绘制的曲线ID, Grid 表格控件, string 采集样本_Y轴数据列名)
        {
            List<double> 曲线X坐标对集合 = new List<double>();
            List<double> 曲线Y坐标对集合 = new List<double>();
            曲线控件.汽蚀余量X轴 = 0;
            曲线控件.汽蚀余量Y轴 = 0;

            DataTable datatable汽蚀试验 = 数据库操作类.GetTableBySql("select * from 汽蚀试验 ORDER by 汽蚀余量 DESC");
             foreach (DataRow dr in datatable汽蚀试验.Rows)
             {
                 if (需要进行绘制的曲线ID.Equals(Convert.ToString(dr["批次编号"])))
                 {
                     double n流量 = Convert.ToDouble(dr["流量"]);
                     double n温度 = Convert.ToDouble(dr["温度"]);
                     double n进口表压 = Convert.ToDouble(dr["进口压力"]);
                     double 汽蚀余量 = Convert.ToDouble(dr["汽蚀余量"]);
                     double Y = Convert.ToDouble(dr[采集样本_Y轴数据列名]);
                     曲线X坐标对集合.Add(汽蚀余量);
                     曲线Y坐标对集合.Add(Y);
                 }
             }

            //显示曲线(曲线控件, 需要进行绘制的曲线ID);
            for (int j = 0; j < 曲线控件.Graph.Plots.Count; j++)
            {
                if ((曲线控件.Graph.Plots[j].Tag.ToString().Equals(需要进行绘制的曲线ID)) &&
                    ((曲线X坐标对集合.Count > 0) && (曲线Y坐标对集合.Count > 0)))
                {
                    曲线控件.Graph.Plots[j].Visible = true;
                    曲线控件.Graph.Plots[j].PlotXY(曲线X坐标对集合.ToArray(), 曲线Y坐标对集合.ToArray());
                    //曲线控件.f_设置汽蚀余量(需要进行绘制的曲线ID, 曲线汽蚀余量, 曲线X坐标对集合, 曲线Y坐标对集合);
                    f_绘制临界点(曲线控件, 需要进行绘制的曲线ID, 采集样本_Y轴数据列名);
                }
            }
        }

        private void f_绘制临界点(XYGraph 曲线控件, string 需要进行绘制的曲线ID, string 采集样本_Y轴数据列名)
        {
            List<double> 曲线X坐标对集合 = new List<double>();
            List<double> 曲线Y坐标对集合 = new List<double>();
            曲线控件.汽蚀余量X轴 = 0;
            曲线控件.汽蚀余量Y轴 = 0;

            DataTable datatable汽蚀试验批次 = 数据库操作类.GetTable("汽蚀试验批次");
            foreach (DataRow dr in datatable汽蚀试验批次.Rows)
            {
                if (需要进行绘制的曲线ID.Equals(Convert.ToString(dr["批次编号"])))
                {
                    double 汽蚀余量 = Convert.ToDouble(dr["汽蚀余量"]);
                    double Y = Convert.ToDouble(dr[采集样本_Y轴数据列名]);
                    曲线X坐标对集合.Add(汽蚀余量);
                    曲线Y坐标对集合.Add(Y);
                }
            }

            曲线控件.f_设置临界值(需要进行绘制的曲线ID, 曲线X坐标对集合, 曲线Y坐标对集合);
        }

        private void 显示曲线(XYGraph 曲线控件, string 曲线ID)
        {
        /*    for (int j = 0; j < 曲线控件.Graph.Plots.Count; j++)
            {
                if (曲线控件.Graph.Plots[j].Tag.ToString().Equals(曲线ID) || 
                    曲线控件.Graph.Plots[j].Tag.ToString().Equals(曲线ID+"汽蚀余量"))
                {
                    曲线控件.Graph.Plots[j].Visible = true;
                }
                else
                {
                    曲线控件.Graph.Plots[j].Visible = false;
                }
            }*/

        }


        public void SaveImage(NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph, NationalInstruments.UI.WindowsForms.Legend 标签组, int width, int height)
        {
            Color 原色 = scatterGraph.PlotAreaColor;
            scatterGraph.BackColor = Color.White;

            scatterGraph.PlotAreaColor = Color.Transparent;
            ChangeImageSize(scatterGraph, 标签组);

            Image image1 = scatterGraph.ToImage(new Size(width, height));
            Image image_标签组 = 标签组.ToImage(new Size(width, 标签组.Height));
            Bitmap offBm = new Bitmap(width, height + 11 + 标签组.Height);

            Graphics g = Graphics.FromImage(offBm);
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(width, height + 11 + 标签组.Height)));

            g.DrawImage(image1, new Point(3, 15));
            g.DrawString("nsp=" + 全局缓存.当前试验组信息.水泵额定转速.ToString() + "rpm", new Font("宋体", 14), Brushes.Black, new PointF(width - 220, 30));
            g.DrawString("扬程[m]", new Font("宋体", 14), Brushes.Black, new PointF(3, 1));
            g.DrawImage(image_标签组, new Point(3, 11 + height));

            MemoryStream ms = new MemoryStream();
            //保存为Jpg类型  
            offBm.Save(ms, ImageFormat.Png);
            byte[] imgData = ms.ToArray();

            数据库操作类.图片存储("汽蚀试验", imgData);
            scatterGraph.PlotAreaColor = 原色;
            ReturnImageSize(scatterGraph, 标签组);
        }


        public void ChangeImageSize(NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph, NationalInstruments.UI.WindowsForms.Legend 标签组)
        {
            scatterGraph.XAxes[0].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 14);
            标签组.Font = new System.Drawing.Font("宋体", 14);
            for (int i = 0; i < scatterGraph.YAxes.Count; i++)
            {
                scatterGraph.YAxes[i].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 14);
            }

        }

        public void ReturnImageSize(NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph, NationalInstruments.UI.WindowsForms.Legend 标签组)
        {
            scatterGraph.XAxes[0].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 9);
            标签组.Font = new System.Drawing.Font("宋体", 9);
            for (int i = 0; i < scatterGraph.YAxes.Count; i++)
            {
                scatterGraph.YAxes[i].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 9);
            }

        }

        private void InitGrid_批次()
        {
            string str批次编号 = "";
            double n流量 = 0;
            if (datatable_批次 == null)
            {
                datatable_批次 = new DataTable();
                datatable_批次.Columns.Add("批次编号");
                datatable_批次.Columns.Add("采集日期");
                datatable_批次.Columns.Add("流量");
                datatable_批次.Columns.Add("扬程");
                datatable_批次.Columns.Add("汽蚀余量");
            }
            datatable_批次.Clear();
            this.grid1.SetDataSource(datatable_批次);
            datatable = 数据库操作类.GetTable("汽蚀试验批次");
            foreach (DataRow dr in datatable.Rows)
            {
                if (全局缓存.当前试验组信息.试验ID.ToString().Equals(Convert.ToString(dr["试验组ID"]))==false)
                {
                    continue;
                }
                DataRow GridDataRow = datatable_批次.NewRow();
                object[] objs = { dr["批次编号"], dr["采集日期"], dr["流量"], dr["扬程"], dr["汽蚀余量"] };
                GridDataRow.ItemArray = objs;
                if (dr["批次编号"] == System.DBNull.Value)
                {
                    str批次编号 = "";
                }
                else
                {
                    str批次编号 = Convert.ToString(dr["批次编号"]);
                }

                xyGraph1.f_增加曲线(str批次编号);

                if (dr["流量"] == System.DBNull.Value)
                {
                    n流量 = 0;
                }
                else
                {
                    n流量 = Convert.ToDouble(dr["流量"]);
                }
                xyGraph1.f_更新曲线标签(str批次编号, n流量);
                datatable_批次.Rows.Add(GridDataRow);
            }
            f_绘制全部曲线();
        }

        //private void InitGrid_采集()
        //{
        //    if (datatable_采集 == null)
        //    {
        //        datatable_采集 = new DataTable();
        //        datatable_采集.Columns.Add("流量");
        //        datatable_采集.Columns.Add("输入功率");
        //        datatable_采集.Columns.Add("转速");
        //        datatable_采集.Columns.Add("轴功率");
        //        datatable_采集.Columns.Add("进口压力");
        //        datatable_采集.Columns.Add("出口压力");
        //        datatable_采集.Columns.Add("扬程");
        //        datatable_采集.Columns.Add("汽蚀余量");
        //        datatable_采集.Columns.Add("额定转速下_流量");
        //        datatable_采集.Columns.Add("额定转速下_扬程");
        //        datatable_采集.Columns.Add("额定转速下_轴功率");
        //        datatable_采集.Columns.Add("额定转速下_泵效率");
        //        datatable_采集.Columns.Add("额定转速下_汽蚀余量");
        //        datatable_采集.Columns.Add("id");
        //    }
        //    datatable_采集.Clear();
        //    this.grid2.SetDataSource(datatable_采集);
        //    datatable = 数据库操作类.GetTable("汽蚀试验");
        //    foreach (DataRow dr in datatable.Rows)
        //    {
        //        if ((全局缓存.当前试验组信息.试验ID.ToString().Equals(Convert.ToString(dr["groupid"])) == false) ||   
        //              (this.grid1.GetFocusedRowCellValue("批次编号").Equals(Convert.ToString(dr["批次编号"]))==false))
        //        {
        //            continue;
        //        }
        //        DataRow GridDataRow = datatable_采集.NewRow();
        //        object[] objs = { dr["流量"], dr["输入功率"], dr["转速"], dr["轴功率"], dr["进口压力"], dr["出口压力"], dr["扬程"], dr["汽蚀余量"], dr["额定转速下_流量"], dr["额定转速下_扬程"], dr["额定转速下_轴功率"], dr["额定转速下_泵效率"], dr["额定转速下_汽蚀余量"], dr["id"] };
        //        GridDataRow.ItemArray = objs;

        //        datatable_采集.Rows.Add(GridDataRow);
        //    }
        //}

        //private void 删除采集记录()
        //{
        //    Decimal ID = -1;
        //    ID = Convert.ToDecimal(this.grid2.GetFocusedRowCellValue("id"));
        //    if (ID >= 0)
        //    {
        //        string strsql = "delete from dbo.汽蚀试验 where id =" + ID;
        //        数据库操作库.数据库操作类.ExcuteSql(strsql);

        //        foreach (DataRow dr in datatable_采集.Rows)
        //        {

        //            if (Convert.ToDecimal(dr["id"]) == ID)
        //            {
        //                datatable_采集.Rows.Remove(dr);
        //                break;
        //            }
        //        }
        //    }
        //}
        //private void 增加采集记录()
        //{
        //    DataRowView row = (DataRowView)grid2.ExportView.GetRow(grid2.ExportView.FocusedRowHandle);
        //    if (row == null) return;
        //    decimal id = System.Convert.ToDecimal(row["id"].ToString());
        //    logic.RemoveRecord(id, "汽蚀试验");
        //    DataRow GridDataRow = datatable_采集.NewRow();
        //    object[] objs = { 0,0,0,0,0,0,0,0,0,0,0,0,0,id };
        //    GridDataRow.ItemArray = objs;
        //    datatable_采集.Rows.Add(GridDataRow);
        //}

        private string db_增加批次(Decimal n批次编号)
        {
            Decimal 批次编号 = -1;
            批次编号 = n批次编号;

            string strSql = "insert dbo.汽蚀试验批次  (试验组ID,批次编号,采集日期,流量,扬程,汽蚀余量) values (" +
                             全局缓存.当前试验组信息.试验ID+","+批次编号 + ",";

            string[] str = new string[2];
            str[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if ((str[0] != null) && (str[0].Equals("") == false))
            {
                strSql += "'";
                strSql += str[0];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }


            strSql += "0,0,0)";

            数据库操作库.数据库操作类.ExcuteSql(strSql);

            DataRow GridDataRow = datatable_批次.NewRow();
            object[] objs = { n批次编号, str[0],0, 0 ,0};
            GridDataRow.ItemArray = objs;
            datatable_批次.Rows.Add(GridDataRow);

            return strSql;
        }

        private void 增加批次()
        {
            decimal[] 批次数组;
            string strID;
            批次数组 = 数据库操作类.GetSystemID(1);
            批次号 =批次数组[0];
            strID = 批次号.ToString();
            _批次编号.Value = 批次号;
            db_增加批次(批次号);
            xyGraph1.f_增加曲线(strID);
          //  f_绘制汽蚀曲线(xyGraph1, 批次号.ToString(), grid2, "扬程");
        }

        private void db_删除批次()
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("批次编号"));
            if (ID >= 0)
            {
                string strsql = "delete from dbo.汽蚀试验批次 where 批次编号 =" + ID;
                数据库操作库.数据库操作类.ExcuteSql(strsql);

                foreach (DataRow dr in datatable_批次.Rows)
                {

                    if (Convert.ToDecimal(dr["批次编号"]) == ID)
                    {
                        datatable_批次.Rows.Remove(dr);
                        break;
                    }
                }

                db_删除批次对应的记录(ID);
            }
        }

        private void db_删除批次对应的记录(Decimal 批次ID)
        {
            datatable = logic.GetReportTable("汽蚀试验");
            if (批次ID >= 0)
            {
                string strsql = "delete from dbo.汽蚀试验 where 批次编号 =" + 批次ID;
                数据库操作库.数据库操作类.ExcuteSql(strsql);

                for (int i = datatable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = datatable.Rows[i];
                    if (Convert.ToDecimal(dr["批次编号"]) == 批次ID)
                    {
                        datatable.Rows.Remove(dr);
                    }

                }
            }
        }
        private bool 更新流量和汽蚀余量(Grid 表格控件,Decimal 批次ID)
        {
             double 流量=0;
             double 扬程 = 0;
             if (表格控件.ExportBandView.RowCount == 1)
             {
                 流量 = Convert.ToDouble(((DataRowView)表格控件.ExportBandView.GetRow(0))["流量"]);
                 扬程 = Convert.ToDouble(((DataRowView)表格控件.ExportBandView.GetRow(0))["扬程"]);
             }
             else if (表格控件.ExportBandView.RowCount == 0)
             {
                 流量 = 0;
                 扬程 = 0;
             }
             else
             {
                 计算临界值(批次ID);
                 return false;
             }
             xyGraph1.f_更新曲线标签(批次ID.ToString(), 流量);
             db_更新流量和扬程(批次ID, 流量, 扬程);

            return true;
        }
        private double 计算临界值(Decimal 批次ID)
        {
            double n临界扬程 = 0;
            double n临界汽蚀余量 = 0;
            double nMore扬程 = 0;
            double nMore汽蚀余量 = 0;
            double nLess扬程 = 0;
            double nLess汽蚀余量 = 0;

            DataTable datatable汽蚀试验批次 = 数据库操作类.GetTable("汽蚀试验批次");
            foreach (DataRow dr in datatable汽蚀试验批次.Rows)
            {
                if (批次ID.ToString().Equals(Convert.ToString(dr["批次编号"])))
                {
                     n临界扬程 = Convert.ToDouble(dr["扬程"]);
                }
            }

            //计算采集点与临界扬程直线相交的直线
            if (n临界扬程 != 0)
            {
                DataTable datatable汽蚀试验 = 数据库操作类.GetTable("汽蚀试验");
                foreach (DataRow dr in datatable汽蚀试验.Rows)
                {
                    if (批次ID.ToString().Equals(Convert.ToString(dr["批次编号"])))
                    {
                        double n扬程 = 0;
                        double n汽蚀余量 = 0;
                        n扬程 = Convert.ToDouble(dr["扬程"]);
                        n汽蚀余量 = Convert.ToDouble(dr["汽蚀余量"]);
                        if (n扬程 > n临界扬程)
                        {
                            if (((n扬程 < nMore扬程) && (n扬程 >= n临界扬程)) || (nMore扬程 <= n临界扬程))
                            {
                                nMore扬程 = n扬程;
                                nMore汽蚀余量 = n汽蚀余量;
                            }
                        }

                        if (n扬程 <= n临界扬程)
                        {
                            if (((n扬程 > nLess扬程) && (n扬程 < n临界扬程)) || (nLess扬程 > n临界扬程))
                            {
                                nLess扬程 = n扬程;
                                nLess汽蚀余量 = n汽蚀余量;
                            }
                        }
                    }
                }

                //计算临界汽蚀余量
                n临界汽蚀余量 = 计算临界汽蚀余量(n临界扬程, nMore扬程, nMore汽蚀余量, nLess扬程, nLess汽蚀余量);
                db_更新临界汽蚀余量(批次ID, n临界汽蚀余量);
            }
            return 0;
        }
        private double 计算临界汽蚀余量(double n临界扬程, double nMore扬程, double nMore汽蚀余量, double nLess扬程, double nLess汽蚀余量)
        {
            double n临界汽蚀余量 = 0;
            //解y=ax+c的直线
            double a = 0;
            double c = 0;

            if ((nLess扬程 == 0) || (nMore扬程==0))
            {
                return 0;
            }

            if (nMore汽蚀余量 == nLess汽蚀余量)
            {
                return nMore汽蚀余量;
            }
            a =  (nMore扬程 - nLess扬程)/(nMore汽蚀余量 - nLess汽蚀余量);
            c = nMore扬程- a*nMore汽蚀余量;
            //将临界扬程代入y=ax+c

            n临界汽蚀余量 = (n临界扬程-c)/a;
            return n临界汽蚀余量;
        }

        private void db_更新流量和扬程(Decimal 批次ID, double 流量, double 扬程)
        {
            double n汽蚀余量 = 0;
            Decimal id = -1;
            string strSql = "";
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("批次编号"));
            strSql = "update  dbo.汽蚀试验批次 set  ";

            strSql += "流量=";
            if (流量 == 0)
            {
                strSql += 0;
            }
            else
            {
                strSql += 流量;
            }
            strSql += ",";
            strSql += "扬程=";
            if (扬程 == 0)
            {
                strSql += 0;
            }
            else
            {
                strSql += 扬程*0.97;
            }
            strSql += ",";
            strSql += "汽蚀余量=";
            strSql += n汽蚀余量;

            strSql += " where 批次编号=" + 批次ID;

            数据库操作库.数据库操作类.ExcuteSql(strSql);
            if (批次ID >= 0)
            {
                foreach (DataRow dr in datatable_批次.Rows)
                {

                    if (Convert.ToDecimal(dr["批次编号"]) == 批次ID)
                    {
                        dr["流量"] = 流量;
                        dr["扬程"] = 扬程 * 0.97;
                        dr["汽蚀余量"] = n汽蚀余量;
                        break;
                    }
                }
            }
        }

        private void db_更新临界汽蚀余量(Decimal 批次ID, double n临界汽蚀余量)
        {
            Decimal id = -1;
            string strSql = "";
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("批次编号"));
            strSql = "update  dbo.汽蚀试验批次 set  ";

            strSql += "汽蚀余量=";
            strSql += n临界汽蚀余量;

            strSql += " where 批次编号=" + 批次ID;

            数据库操作库.数据库操作类.ExcuteSql(strSql);
            if (批次ID >= 0)
            {
                foreach (DataRow dr in datatable_批次.Rows)
                {

                    if (Convert.ToDecimal(dr["批次编号"]) == 批次ID)
                    {
                        dr["汽蚀余量"] = n临界汽蚀余量;
                        break;
                    }
                }
            }
        }
        private void 删除批次()
        {
            string strID;
            strID = 批次号.ToString();
            db_删除批次();
            xyGraph1.f_删除曲线(strID);
        }


        private void grid2_BtnAddRowClick(object sender, EventArgs e)
        {
            开始警告();
            if (超出警告值())
            {
                string strOut = "采集流量的上限为:";
                double strTemp;
                strTemp = 进制转换.f_保留N位小数((float)流量上限(), 2);
                strOut+=strTemp;
                strOut+="m3/h，下限为:";
                strTemp = 进制转换.f_保留N位小数((float)流量下限(), 2);
                strOut+=strTemp;
                strOut+="m3/h。";
                MessageBox.Show(strOut,"提示");
                return;
            }

            logic.HandGather("汽蚀试验");
            //增加采集记录();
            更新流量和汽蚀余量(this.grid2, 批次号);
           // f_绘制汽蚀曲线(xyGraph1, 批次号.ToString(), grid2, "扬程");
            f_绘制全部曲线();

            SaveImage(this.xyGraph1.Graph, this.xyGraph1.曲线标签组, 700, 700);
        }

        private void grid2_BtnReduceRowClick(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)grid2.ExportBandView.GetRow(grid2.ExportBandView.FocusedRowHandle);
            if (row == null) return;
            decimal id = System.Convert.ToDecimal(row["id"].ToString());
            logic.RemoveRecord(id, "汽蚀试验");
            //删除采集记录();
            更新流量和汽蚀余量(grid2, 批次号);
          //  f_绘制汽蚀曲线(xyGraph1, 批次号.ToString(), grid2, "扬程");
            f_绘制全部曲线();
           SaveImage(this.xyGraph1.Graph, this.xyGraph1.曲线标签组, 700, 700);
        }

        private void grid2_Btn执行命令1Click(object sender, EventArgs e)
        {
            logic.UpdateToDB("汽蚀试验");

           // f_绘制汽蚀曲线(xyGraph1, 批次号.ToString(), grid2, "扬程");
            f_绘制全部曲线();
            SaveImage(this.xyGraph1.Graph, this.xyGraph1.曲线标签组, 700, 700);
        }


        private void grid1_SelectRow(int nline)
        {
            double n汽蚀余量 = 0;

            this.数显仪表集合1.结束警告("流量");
            ((MainFrame)this.Parent.Parent).数显仪表集合1.结束警告("流量");

            if (Convert.ToString(this.grid1.GetFocusedRowCellValue("汽蚀余量")).Equals(""))
            {
                n汽蚀余量 = 0;
            }
            else
            {
                n汽蚀余量 = Convert.ToDouble(this.grid1.GetFocusedRowCellValue("汽蚀余量"));
            }
            string strID = this.grid1.GetFocusedRowCellValue("批次编号");
            曲线汽蚀余量 = n汽蚀余量;
            _批次编号.Value = strID;
            批次号 = Convert.ToDecimal(strID);
            strID = "批次编号=" + strID;
            logic.LoadGrid(this.grid2, "汽蚀试验", strID, "汽蚀余量 desc", false);
            //f_绘制汽蚀曲线(xyGraph1, 批次号.ToString(), this.grid2, "扬程");
           // f_绘制全部曲线();
            string str汽蚀余量 = this.grid1.GetFocusedRowCellValue("汽蚀余量");
            string str扬程 = this.grid1.GetFocusedRowCellValue("扬程");
            string str流量 = "流量:" + this.grid1.GetFocusedRowCellValue("流量");
            string strTemp = "汽蚀余量:[" + str汽蚀余量 + "," + str扬程 + "]";
            流量text.Text = str流量;
            汽蚀余量text.Text = strTemp;
            //InitGrid_采集();

        }

        private void grid1_SelectRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void 开始警告()
        {
            double n上限 = 0;
            double n下限 = 0;
            double 曲线流量=0;
            曲线流量 = Convert.ToDouble(this.grid1.GetFocusedRowCellValue("流量"));
            if (曲线流量 > 0)
            {
                n上限 = 曲线流量 + 曲线流量 * 0.02;
                n下限 = 曲线流量 - 曲线流量 * 0.02;
                this.数显仪表集合1.开始警告("流量",n上限,n下限);
                ((MainFrame)this.Parent.Parent).数显仪表集合1.开始警告("流量",n上限,n下限);
            }
        }

        private bool 超出警告值()
        {
            double d =this.数显仪表集合1.返回控件值("流量");
            double n警告上限 = 0;
            double n警告下限 = 0;
            double n流量 = Convert.ToDouble(this.grid1.GetFocusedRowCellValue("流量"));
            if (n流量 > 0)
            {
                 n警告上限 = n流量 + n流量 * 0.02;
                 n警告下限 = n流量 - n流量 * 0.02;
            }

            if ((d <= n警告上限) && (d >= n警告下限))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private double 流量上限()
        {
            double n警告上限 = 0;
            double n流量 = Convert.ToDouble(this.grid1.GetFocusedRowCellValue("流量"));
            if (n流量 > 0)
            {
                n警告上限 = n流量 + n流量 * 0.02;
            }
            return n警告上限;
        }

        private double 流量下限()
        {
            double n警告下限 = 0;
            double n流量 = Convert.ToDouble(this.grid1.GetFocusedRowCellValue("流量"));
            if (n流量 > 0)
            {
                n警告下限 = n流量 - n流量 * 0.02;
                if (n警告下限 < 0)
                {
                    n警告下限 = 0;
                }
            }
            return n警告下限;
        }
    }
}