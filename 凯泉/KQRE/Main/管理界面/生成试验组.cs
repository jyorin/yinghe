using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AutoControl;
using System.Collections;
using 数据存储.管理数据类;
using 数据库操作库;
using 全局缓存;
using LogicApp.试验组模块;
using 数据存储;
using PLC数据源管理;
using PLC数据源管理.数据获取;
using 辅助库;

namespace Main.管理界面
{
    public partial class 生成试验组 : DevExpress.XtraEditors.XtraForm
    {
        public 生成试验组()
        {
            InitializeComponent();
            this.grid1.InitViewLayout("管理表格配置\\生成实验组.xml");
            实验方案 = new 方案();

            注册控件数据("dbo.水泵型号管理", "水泵型号", "出厂编号", ref data_被试水泵);
            注册控件数据("dbo.电机型号管理", "电机型号", "出厂编号", ref data_拖动电机);
            注册控件数据("dbo.流量仪表", "流量计类型", "流量计编号", ref data_流量仪表);
            注册控件数据("dbo.转速测量", "传感器类型", "传感器编号", ref data_转速测量);
            注册控件数据("dbo.进口压力仪表", "变送器型号", "变送器编号", ref data_进口压力仪表);
            注册控件数据("dbo.出口压力仪表", "变送器型号", "变送器编号", ref data_出口压力仪表);
            注册控件数据("dbo.功率测量仪表", "扭矩传感器规格", "扭矩传感器编号", ref data_功率测量仪表);
            注册控件数据("dbo.温度测量仪表", "传感器类型", "传感器编号", ref data_温度测量仪表);
            注册控件数据("dbo.液力耦合器", "耦合器型号", "出厂编号", ref data_液力耦合器);
        }
        public void 控件赋值(string 字段名, string 值)
        {
            _form.GetControlElementByInfo("dbo.生成试验组", 字段名).SetValue(值);
        }
        public string 获取Combobox值(string strFildName, string strID)
        {
            string strValue = "";

            if (strFildName.Equals("被试水泵ID") == true)
            {
                strValue = 获取控件数据("dbo.水泵型号管理").获取字符串(strID);
                return strValue;
            }

            if (strFildName.Equals("拖动电机ID") == true)
            {
                strValue = 获取控件数据("dbo.电机型号管理").获取字符串(strID);
                return strValue;
            }

            if (strFildName.Equals("流量仪表ID") == true)
            {
                strValue = 获取控件数据("dbo.流量仪表").获取字符串(strID);
                return strValue;
            }

            if (strFildName.Equals("转速测量ID") == true)
            {
                strValue = 获取控件数据("dbo.转速测量").获取字符串(strID);
                return strValue;
            }

            if (strFildName.Equals("进口压力仪表ID") == true)
            {
                strValue = 获取控件数据("dbo.进口压力仪表").获取字符串(strID);
                return strValue;
            }

            if (strFildName.Equals("出口压力仪表ID") == true)
            {
                strValue = 获取控件数据("dbo.出口压力仪表").获取字符串(strID);
                return strValue;
            }

            if (strFildName.Equals("功率测量仪表ID") == true)
            {
                strValue = 获取控件数据("dbo.功率测量仪表").获取字符串(strID);
                return strValue;
            }

            if (strFildName.Equals("温度测量仪表ID") == true)
            {
                strValue = 获取控件数据("dbo.温度测量仪表").获取字符串(strID);
                return strValue;
            }


            if (strFildName.Equals("液力耦合器ID") == true)
            {
                strValue = 获取控件数据("dbo.液力耦合器").获取字符串(strID);
                return strValue;
            }


            return strValue;
        }

        #region 相关结构
        private struct structComboBox控件数据
        {
            public string 表名;
            public string 字段名1;
            public string 字段名2;
            public string ID值;
            public List<string> ID_list;
            public List<string> CtrlData_list;
            public string 获取选择字符串()
            {
                string strValue = "";
                int index = -1;
                bool bfind = false;
                foreach (string str in ID_list)
                {
                    index++;
                    if (str.Equals(ID值) == true)
                    {
                        bfind = true;
                        break;
                    }
                }
                if ((index >= 0) && (bfind == true))
                {
                    strValue = CtrlData_list[index];
                }
                return strValue;
            }
            public string 获取ID(string 字符串)
            {
                string strValue = "-1";
                int index = -1;
                bool bfind = false;
                foreach (string str in CtrlData_list)
                {
                    index++;
                    if (str.Equals(字符串) == true)
                    {
                        bfind = true;
                        break;
                    }
                }
                if ((index >= 0) && (bfind == true))
                {
                    strValue = ID_list[index];
                }
                return strValue;
            }
            public string 获取字符串(string strID)
            {
                string strValue = "";
                int index = -1;
                bool bfind = false;
                foreach (string str in ID_list)
                {
                    index++;
                    if (str.Equals(strID) == true)
                    {
                        bfind = true;
                        break;
                    }
                }
                if ((index >= 0) && (bfind == true))
                {
                    strValue = CtrlData_list[index];
                }
                return strValue;
            }
        }
        #endregion
        #region 成员变量
        private FormElement _form = null;
        private DataTable GridDataTabel = null;
        private DataTable datatable = null;
        private structComboBox控件数据 data_被试水泵 = new structComboBox控件数据();
        private structComboBox控件数据 data_拖动电机 = new structComboBox控件数据();
        private structComboBox控件数据 data_流量仪表 = new structComboBox控件数据();
        private structComboBox控件数据 data_转速测量 = new structComboBox控件数据();
        private structComboBox控件数据 data_进口压力仪表 = new structComboBox控件数据();
        private structComboBox控件数据 data_出口压力仪表 = new structComboBox控件数据();
        private structComboBox控件数据 data_功率测量仪表 = new structComboBox控件数据();
        private structComboBox控件数据 data_温度测量仪表 = new structComboBox控件数据();
        private structComboBox控件数据 data_液力耦合器 = new structComboBox控件数据();
        private 方案 _实验方案;
        public 方案 实验方案
        {
            get { return _实验方案; }
            set { _实验方案 = value; }
        }
        #endregion
        #region Grid操作
        private void 查询_试验组数据()
        {
            DataTable dt = _form.SelectTabs("dbo.生成试验组");
            // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("试验日期");
                GridDataTabel.Columns.Add("试验组名");
                GridDataTabel.Columns.Add("试验编号");
            }
            GridDataTabel.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["试验日期"], dr["试验组名"], dr["试验编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);
        }
        private void 保存_试验组数据()
        {
            string[] str = new string[15];
            string[] strFiled = new string[15];
            string strTemp = "";
            if (_form == null)
            {
                _form = new FormElement();
            }
            str[0] = _form.GetControlElementByInfo("dbo.生成试验组", "试验日期").GetValue();
            strFiled[0] = "试验日期";
            str[1] = _form.GetControlElementByInfo("dbo.生成试验组", "试验编号").GetValue();
            strFiled[1] = "试验编号";
            str[2] = _form.GetControlElementByInfo("dbo.生成试验组", "试验组名").GetValue();
            strFiled[2] = "试验组名";
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "被试水泵ID").GetValue();
            strFiled[3] = "被试水泵ID";
            str[3] = data_被试水泵.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "拖动电机ID").GetValue();
            strFiled[4] = "拖动电机ID";
            str[4] = data_拖动电机.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "流量仪表ID").GetValue();
            strFiled[5] = "流量仪表ID";
            str[5] = data_流量仪表.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "转速测量ID").GetValue();
            strFiled[6] = "转速测量ID";
            str[6] = data_转速测量.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "进口压力仪表ID").GetValue();
            strFiled[7] = "进口压力仪表ID";
            str[7] = data_进口压力仪表.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "出口压力仪表ID").GetValue();
            strFiled[8] = "出口压力仪表ID";
            str[8] = data_出口压力仪表.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "功率测量仪表ID").GetValue();
            strFiled[9] = "功率测量仪表ID";
            str[9] = data_功率测量仪表.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "温度测量仪表ID").GetValue();
            strFiled[10] = "温度测量仪表ID";
            str[10] = data_温度测量仪表.获取ID(strTemp);
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "液力耦合器ID").GetValue();
            strFiled[11] = "液力耦合器ID";
            str[11] =  data_液力耦合器.获取ID(strTemp);
            //-----------------add室温--------------begin
            strFiled[12] = "室温";
            str[12] = _form.GetControlElementByInfo("dbo.生成试验组", "室温").GetValue();
           //---------------- add 室温------------end
            strFiled[13] = "水温";
            str[13] = _form.GetControlElementByInfo("dbo.生成试验组", "水温").GetValue();
            strFiled[14] = "气压";
            str[14] = _form.GetControlElementByInfo("dbo.生成试验组", "气压").GetValue();
            _form.SaveTabs("dbo.生成试验组", strFiled,str);
        }
        private void 删除_试验组数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.生成试验组" });
        }
        private void 选择试验组数据()
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            datatable = _form.SelectTabs("dbo.生成试验组");

            foreach (DataRow dr in datatable.Rows)
            {
                if (ID == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.生成试验组", ID);
                    _form.LoadTabs(new string[] { "dbo.生成试验组" }, new decimal[] { ID });

                    data_被试水泵.ID值 = Convert.ToString(dr["被试水泵ID"]);
                    data_拖动电机.ID值 = Convert.ToString(dr["拖动电机ID"]);
                    data_流量仪表.ID值 = Convert.ToString(dr["流量仪表ID"]);
                    data_转速测量.ID值 = Convert.ToString(dr["转速测量ID"]);
                    data_进口压力仪表.ID值 = Convert.ToString(dr["进口压力仪表ID"]);
                    data_出口压力仪表.ID值 = Convert.ToString(dr["出口压力仪表ID"]);
                    data_功率测量仪表.ID值 = Convert.ToString(dr["功率测量仪表ID"]);
                    data_温度测量仪表.ID值 = Convert.ToString(dr["温度测量仪表ID"]);
                    data_液力耦合器.ID值 = Convert.ToString(dr["液力耦合器ID"]);

                //    实验方案 = 方案提取.提取方案(ID);
                    _form.BindControlAgin("dbo.生成试验组");
                }
            }
        }
        #endregion
        #region 窗口事件
        
        private void simpleButton_开启实验组_Click(object sender, EventArgs e)
        {
            设置环境配置();
            Decimal ID = -1;
            ID = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            if (ID == -1)
            {
                MessageBox.Show("提取方案失败!", "错误");
                return;
            }

            实验方案 = 方案提取.提取方案(ID);

            if (实验方案 == null)
            {
                MessageBox.Show("方案加载失败！","错误");
                return;
            }

            if (公共函数.加载水泵环境参数(实验方案.被试水泵ID) == false)
            {
                MessageBox.Show("试验前请先设置水泵环境参数！","错误");
                return;
            }

            #region 保存试验组数据
            List<工况点> 工况点集合 = new List<工况点>();
            全局缓存.当前试验组信息.工况组 = 工况点集合;
            /*试验ID*/
            全局缓存.当前试验组信息.试验ID = ID;
            全局缓存.当前试验组信息.试验编号 = 实验方案.试验编号;


             全局缓存.当前试验组信息.被试水泵ID = 实验方案.被试水泵ID;
             全局缓存.当前试验组信息.拖动电机ID = 实验方案.拖动电机ID;
             全局缓存.当前试验组信息.流量仪表ID = 实验方案.流量仪表ID;
             全局缓存.当前试验组信息.转速测量仪表ID = 实验方案.转速测量ID;
             全局缓存.当前试验组信息.进口压力仪表ID = 实验方案.进口压力仪表ID;
             全局缓存.当前试验组信息.出口压力仪表ID = 实验方案.出口压力仪表ID;
             全局缓存.当前试验组信息.功率测量仪表ID = 实验方案.功率测量仪表ID;
             全局缓存.当前试验组信息.温度测量仪表ID = 实验方案.温度测量仪表ID;
             全局缓存.当前试验组信息.液力耦合器ID = 实验方案.液力耦合器ID;
             全局缓存.当前试验组信息.温度 = 实验方案.水温; 

            #region 水泵型号管理
            字段 字段1 = 实验方案.提取字段("dbo.水泵型号管理", "额定转速");
            if (字段1 != null)
            {
                /*额定转速*/
                全局缓存.当前试验组信息.水泵额定转速 = double.Parse(字段1.字段值);
            }
            字段 字段2 = 实验方案.提取字段("dbo.水泵型号管理", "进口直径");
            if (字段2 != null)
            {
                /*水泵进口直径*/
                全局缓存.当前试验组信息.水泵进口直径 = double.Parse(字段2.字段值);
            }
            字段 字段3 = 实验方案.提取字段("dbo.水泵型号管理", "出口直径");
            if (字段3 != null)
            {
                /*水泵进口直径*/
                全局缓存.当前试验组信息.水泵出口直径 = double.Parse(字段3.字段值);
            }
            #region 5个工况点
            字段 字段4 = 实验方案.提取字段("dbo.水泵型号管理", "工况1_流量");
            字段 字段5 = 实验方案.提取字段("dbo.水泵型号管理", "工况1_汽蚀余量");
            字段 字段6 = 实验方案.提取字段("dbo.水泵型号管理", "工况1_扬程");
            字段 字段7 = 实验方案.提取字段("dbo.水泵型号管理", "工况1_轴功率");
            if (字段4 != null && 字段5 != null && 字段6 != null && 字段7 != null)
            {
                /*工况1*/
                全局缓存.当前试验组信息.工况组.Add(new 工况点()
                {
                    Name = "工况1",
                    流量 = double.Parse(字段4.字段值),
                    汽蚀余量 = double.Parse(字段5.字段值),
                    扬程 = double.Parse(字段6.字段值),
                    轴功率 = double.Parse(字段7.字段值)
                });
            }
            字段 字段8 = 实验方案.提取字段("dbo.水泵型号管理", "工况2_流量");
            字段 字段9 = 实验方案.提取字段("dbo.水泵型号管理", "工况2_汽蚀余量");
            字段 字段10 = 实验方案.提取字段("dbo.水泵型号管理", "工况2_扬程");
            字段 字段11 = 实验方案.提取字段("dbo.水泵型号管理", "工况2_轴功率");
            if (字段8 != null && 字段9 != null && 字段10 != null && 字段11 != null)
            {
                /*工况2*/
                全局缓存.当前试验组信息.工况组.Add(new 工况点()
                {
                    Name = "工况2",
                    流量 = double.Parse(字段8.字段值),
                    汽蚀余量 = double.Parse(字段9.字段值),
                    扬程 = double.Parse(字段10.字段值),
                    轴功率 = double.Parse(字段11.字段值)
                });
            }
            字段 字段12 = 实验方案.提取字段("dbo.水泵型号管理", "工况3_流量");
            字段 字段13= 实验方案.提取字段("dbo.水泵型号管理", "工况3_汽蚀余量");
            字段 字段14 = 实验方案.提取字段("dbo.水泵型号管理", "工况3_扬程");
            字段 字段15 = 实验方案.提取字段("dbo.水泵型号管理", "工况3_轴功率");
            if (字段12 != null && 字段13 != null && 字段14 != null && 字段15 != null)
            {
                /*工况3*/
                全局缓存.当前试验组信息.工况组.Add(new 工况点()
                {
                    Name = "工况3",
                    流量 = double.Parse(字段12.字段值),
                    汽蚀余量 = double.Parse(字段13.字段值),
                    扬程 = double.Parse(字段14.字段值),
                    轴功率 = double.Parse(字段15.字段值)
                });
            }
            字段 字段16 = 实验方案.提取字段("dbo.水泵型号管理", "工况4_流量");
            字段 字段17 = 实验方案.提取字段("dbo.水泵型号管理", "工况4_汽蚀余量");
            字段 字段18 = 实验方案.提取字段("dbo.水泵型号管理", "工况4_扬程");
            字段 字段19 = 实验方案.提取字段("dbo.水泵型号管理", "工况4_轴功率");
            if (字段16 != null && 字段17 != null && 字段18 != null && 字段19 != null)
            {
                /*工况4*/
                全局缓存.当前试验组信息.工况组.Add(new 工况点()
                {
                    Name = "工况4",
                    流量 = double.Parse(字段16.字段值),
                    汽蚀余量 = double.Parse(字段17.字段值),
                    扬程 = double.Parse(字段18.字段值),
                    轴功率 = double.Parse(字段19.字段值)
                });
            }
            字段 字段20 = 实验方案.提取字段("dbo.水泵型号管理", "工况5_流量");
            字段 字段21 = 实验方案.提取字段("dbo.水泵型号管理", "工况5_汽蚀余量");
            字段 字段22 = 实验方案.提取字段("dbo.水泵型号管理", "工况5_扬程");
            字段 字段23 = 实验方案.提取字段("dbo.水泵型号管理", "工况5_轴功率");
            if (字段20 != null && 字段21 != null && 字段22 != null && 字段23 != null)
            {
                /*工况5*/
                全局缓存.当前试验组信息.工况组.Add(new 工况点()
                {
                    Name = "工况5",
                    流量 = double.Parse(字段20.字段值),
                    汽蚀余量 = double.Parse(字段21.字段值),
                    扬程 = double.Parse(字段22.字段值),
                    轴功率 = double.Parse(字段23.字段值)
                });
            }
            #endregion
            字段 字段24 = 实验方案.提取字段("dbo.水泵型号管理", "水泵类型");
            if (字段24 != null)
            {
                /*水泵类型*/
                全局缓存.当前试验组信息.水泵类型 = 字段24.字段值;
            }
            字段 字段29 = 实验方案.提取字段("dbo.水泵型号管理", "额定流量");
            if (字段29 != null)
            {
                /*额定转速*/
                全局缓存.当前试验组信息.水泵额定流量 = double.Parse(字段29.字段值);
            }
            字段 字段28 = 实验方案.提取字段("dbo.水泵型号管理", "额定扬程");
            if (字段28 != null)
            {
                /*额定转速*/
                全局缓存.当前试验组信息.水泵额定扬程 = double.Parse(字段28.字段值);
            }
            #endregion

            #region 电机型号管理
            字段 字段27 = 实验方案.提取字段("dbo.电机型号管理", "额定效率");
            if (字段27 != null)
            {
                /*电机额定效率*/
                全局缓存.当前试验组信息.电机额定效率 = double.Parse(字段27.字段值) / 100;
            }

            #endregion

            #region 进出口压力仪表
            字段 字段25 = 实验方案.提取字段("dbo.出口压力仪表", "出口表距");
            if (字段25 != null)
            {
                /*出口表距*/
                全局缓存.当前试验组信息.出口压力表距 = double.Parse(字段25.字段值);
            }
            字段 字段26 = 实验方案.提取字段("dbo.进口压力仪表", "进口表距");
            if (字段26 != null)
            {
                /*进口表距*/
                全局缓存.当前试验组信息.进口压力表距 = double.Parse(字段26.字段值);
            }
            
            #endregion

           // 设置流量最大量程();

            #endregion
        }
        public void 设置环境配置()
        {
            string 流量 = "opc://localhost/National Instruments.NIOPCServers/kaiquan.kaiquan.water folw_READ." +　水泵试验缓存.流量通道;
            string 进口压力 = "opc://localhost/National Instruments.NIOPCServers/kaiquan.kaiquan.water pressure_READ." + 水泵试验缓存.进口压力通道;
            string 出口压力 = "opc://localhost/National Instruments.NIOPCServers/kaiquan.kaiquan.water pressure_READ." + 水泵试验缓存.出口压力通道;
            PLC数据项 _数据项 = null;
            _数据项 = 数据项哈希存储.GetItem("流量_源数据") as PLC数据项;
            _数据项.销毁();
            _数据项.SetData(流量);
            _数据项 = 数据项哈希存储.GetItem("进口压力_源数据") as PLC数据项;
            _数据项.销毁();
            _数据项.SetData(进口压力);
            _数据项 = 数据项哈希存储.GetItem("出口压力_源数据") as PLC数据项;
            _数据项.销毁();
            _数据项.SetData(出口压力);
        }
        public void 设置流量最大量程()
        {
           // string 泵类型 = System.Configuration.ConfigurationSettings.AppSettings["泵类型"].ToString();
            //if (全局缓存.当前试验组信息.水泵出口直径 == 250)
            //{
            //    选择流量量程 _form = new 选择流量量程();
            //    _form.ShowDialog();
            //    return;
            //}
            /* else if (全局缓存.当前试验组信息.水泵出口直径 == 400 && 泵类型 == "矿用")
            {
                全局缓存.水泵试验缓存.水泵流量最大量程 = 1450;
            }
            else if (全局缓存.当前试验组信息.水泵出口直径 == 400 && 泵类型 == "非矿用")
            {
                全局缓存.水泵试验缓存.水泵流量最大量程 = 3500;
            }
            else
            {
                int R = (int)全局缓存.当前试验组信息.水泵进口直径;
                switch (R)
                {
                    case 1600:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 45000;
                        break;
                    case 1200:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 19000;
                        break;
                    case 900:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 12800;
                        break;
                    case 600:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 5500;
                        break;
                    case 300:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 1800;
                        break;
                    case 200:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 600;
                        break;
                    case 100:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 200;
                        break;
                    case 65:
                        全局缓存.水泵试验缓存.水泵流量最大量程 = 70;
                        break;
                }
            }*/
        }
        private void simpleButton_保存实验组信息_Click(object sender, EventArgs e)
        {
            保存_试验组数据();
            查询_试验组数据();
            MessageBox.Show("数据保存成功！", "提示");
        }
        private void 生成试验组_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.生成试验组" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_试验日期, "dbo.生成试验组", "试验日期");
            _form.AddControlByLayout(this.panel_试验组名, "dbo.生成试验组", "试验组名");
            _form.AddControlByLayout(this.panel_试验编号, "dbo.生成试验组", "试验编号");
            //-----------------add室温--------------begin
            _form.AddControlByLayout(this.panel_室温, "dbo.生成试验组", "室温");
            //---------------- add 室温------------end
            _form.AddControlByLayout(this.panel_水温, "dbo.生成试验组", "水温");
            _form.AddControlByLayout(this.panel_气压, "dbo.生成试验组", "气压");
            _form.AddControlByLayout(this.panel_被试水泵, "dbo.生成试验组", "被试水泵ID");
            _form.AddControlByLayout(this.panel_拖动电机, "dbo.生成试验组", "拖动电机ID");
            _form.AddControlByLayout(this.panel_流量仪表, "dbo.生成试验组", "流量仪表ID");
            _form.AddControlByLayout(this.panel_转速测量, "dbo.生成试验组", "转速测量ID");
            _form.AddControlByLayout(this.panel_进口压力仪表, "dbo.生成试验组", "进口压力仪表ID");
            _form.AddControlByLayout(this.panel_出口压力仪表, "dbo.生成试验组", "出口压力仪表ID");
            _form.AddControlByLayout(this.panel_功率测量仪表, "dbo.生成试验组", "功率测量仪表ID");
            _form.AddControlByLayout(this.panel_温度测量仪表, "dbo.生成试验组", "温度测量仪表ID");
            _form.AddControlByLayout(this.panel_液力耦合器, "dbo.生成试验组", "液力耦合器ID");
            查询_试验组数据();
            刷新控件数据();
        }
        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.生成试验组");
        }
        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                删除_试验组数据();
                查询_试验组数据();
            }
        }
        private void grid1_SelectRow(int nline)
        {
            选择试验组数据();
            刷新控件数据();
        }
        private void simpleButton_选择试验组设置方案_Click(object sender, EventArgs e)
        {
            生成试验组方案选择 生成试验组方案选择 = new 生成试验组方案选择(this);
            生成试验组方案选择.ShowDialog();
        }
        private void simpleButton_保存试验组设置方案_Click(object sender, EventArgs e)
        {
               存储方案();
        }
        private Boolean 方案是否已经存在()
        {
            DataTable _data = null;
            string strSql = "select * from dbo.生成试验组方案";
            _data = _form.SelectTabsBySql(strSql);
            Decimal ID = -1;
            ID = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in _data.Rows)
            {
               Decimal _id = Convert.ToDecimal(dr["ID"]);

               if (_id == ID)
               {
                   return true;
               }
            }
            return false;
        }
        private void 存储方案()
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            if (id == -1)
            {
                MessageBox.Show("存储方案失败!", "错误");
                return;
            }

            string strSql = "";
            if (方案是否已经存在() == false)
            {
                strSql = 存储方案_拼接插入Sql();
            }
            else
            {
                strSql = 存储方案_拼接更新Sql();
            }

            数据库操作库.数据库操作类.ExcuteSql(strSql);
            MessageBox.Show("保存方案成功", "提示");
        }

        private string 存储方案_拼接插入Sql()
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));

            //-----------------add室温--------------begin
            string strSql = "insert dbo.生成试验组方案  (ID,试验日期,试验编号,试验组名,被试水泵ID,拖动电机ID,流量仪表ID,转速测量ID,进口压力仪表ID,出口压力仪表ID,功率测量仪表ID,温度测量仪表ID,液力耦合器ID,室温,水温) values (" +
                             id + ",";

            //-----------------add室温--------------end
            string[] str = new string[15];
            string strTemp = "";
            str[0] = _form.GetControlElementByInfo("dbo.生成试验组", "试验日期").GetValue();
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
            str[1] = _form.GetControlElementByInfo("dbo.生成试验组", "试验编号").GetValue();
            if ((str[1] != null) && (str[1].Equals("") == false))
            {
                strSql += "'";
                strSql += str[1];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            str[2] = _form.GetControlElementByInfo("dbo.生成试验组", "试验组名").GetValue();
            if ((str[2] != null) && (str[2].Equals("") == false))
            {
                strSql += "'";
                strSql += str[2];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "被试水泵ID").GetValue();
            str[3] = data_被试水泵.获取ID(strTemp);
            if ((str[3] != null) && (str[3].Equals("") == false))
            {
                strSql += "'";
                strSql += str[3];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "拖动电机ID").GetValue();
            str[4] = data_拖动电机.获取ID(strTemp);
            if ((str[4] != null) && (str[4].Equals("") == false))
            {
                strSql += "'";
                strSql += str[4];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "流量仪表ID").GetValue();
            str[5] = data_流量仪表.获取ID(strTemp);
            if ((str[5] != null) && (str[5].Equals("") == false))
            {
                strSql += "'";
                strSql += str[5];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "转速测量ID").GetValue();
            str[6] = data_转速测量.获取ID(strTemp);
            if ((str[6] != null) && (str[6].Equals("") == false))
            {
                strSql += "'";
                strSql += str[6];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "进口压力仪表ID").GetValue();
            str[7] = data_进口压力仪表.获取ID(strTemp);
            if ((str[7] != null) && (str[7].Equals("") == false))
            {
                strSql += "'";
                strSql += str[7];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "出口压力仪表ID").GetValue();
            str[8] = data_出口压力仪表.获取ID(strTemp);
            if ((str[8] != null) && (str[8].Equals("") == false))
            {
                strSql += "'";
                strSql += str[8];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "功率测量仪表ID").GetValue();
            str[9] = data_功率测量仪表.获取ID(strTemp);
            if ((str[9] != null) && (str[9].Equals("") == false))
            {
                strSql += "'";
                strSql += str[9];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "温度测量仪表ID").GetValue();
            str[10] = data_温度测量仪表.获取ID(strTemp);
            if ((str[10] != null) && (str[10].Equals("") == false))
            {
                strSql += "'";
                strSql += str[10];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "液力耦合器ID").GetValue();
            str[11] = data_液力耦合器.获取ID(strTemp);
            if ((str[11] != null) && (str[11].Equals("") == false))
            {
                strSql += "'";
                strSql += str[11];
                strSql += "')";
            }
            else
            {
                strSql += "null，";
            }

            //-----------------add室温--------------begin
            str[12]= _form.GetControlElementByInfo("dbo.生成试验组", "室温").GetValue();
            if ((str[12] != null) && (str[12].Equals("") == false))
            {
                strSql += "'";
                strSql += str[12];
                strSql += "')";
            }
            else
            {
                strSql += "null)";
            }
            //---------------- add 室温------------end
            str[13]= _form.GetControlElementByInfo("dbo.生成试验组", "水温").GetValue();
            if ((str[13] != null) && (str[13].Equals("") == false))
            {
                strSql += "'";
                strSql += str[13];
                strSql += "')";
            }
            else
            {
                strSql += "null)";
            }

            str[14] = _form.GetControlElementByInfo("dbo.生成试验组", "气压").GetValue();
            if ((str[14] != null) && (str[14].Equals("") == false))
            {
                strSql += "'";
                strSql += str[14];
                strSql += "')";
            }
            else
            {
                strSql += "null)";
            }
            return strSql;
        }

        private string 存储方案_拼接更新Sql()
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            string strSql = "update dbo.生成试验组方案  set 试验日期='";

            string[] str = new string[15];
            string strTemp = "";
            str[0] = _form.GetControlElementByInfo("dbo.生成试验组", "试验日期").GetValue();
            if ((str[0] != null) && (str[0].Equals("") == false))
            {
                strSql += str[0];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            str[1] = _form.GetControlElementByInfo("dbo.生成试验组", "试验编号").GetValue();
            if ((str[1] != null) && (str[1].Equals("") == false))
            {
                strSql += "试验编号='";
                strSql += str[1];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            str[2] = _form.GetControlElementByInfo("dbo.生成试验组", "试验组名").GetValue();
            if ((str[2] != null) && (str[2].Equals("") == false))
            {
                strSql += "试验组名='";
                strSql += str[2];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "被试水泵ID").GetValue();
            str[3] = data_被试水泵.获取ID(strTemp);
            if ((str[3] != null) && (str[3].Equals("") == false))
            {
                strSql += "被试水泵ID='";
                strSql += str[3];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "拖动电机ID").GetValue();
            str[4] = data_拖动电机.获取ID(strTemp);
            if ((str[4] != null) && (str[4].Equals("") == false))
            {
                strSql += "拖动电机ID='";
                strSql += str[4];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "流量仪表ID").GetValue();
            str[5] = data_流量仪表.获取ID(strTemp);
            if ((str[5] != null) && (str[5].Equals("") == false))
            {
                strSql += "流量仪表ID='";
                strSql += str[5];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "转速测量ID").GetValue();
            str[6] = data_转速测量.获取ID(strTemp);
            if ((str[6] != null) && (str[6].Equals("") == false))
            {
                strSql += "转速测量ID='";
                strSql += str[6];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "进口压力仪表ID").GetValue();
            str[7] = data_进口压力仪表.获取ID(strTemp);
            if ((str[7] != null) && (str[7].Equals("") == false))
            {
                strSql += "进口压力仪表ID='";
                strSql += str[7];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "出口压力仪表ID").GetValue();
            str[8] = data_出口压力仪表.获取ID(strTemp);
            if ((str[8] != null) && (str[8].Equals("") == false))
            {
                strSql += "出口压力仪表ID='";
                strSql += str[8];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "功率测量仪表ID").GetValue();
            str[9] = data_功率测量仪表.获取ID(strTemp);
            if ((str[9] != null) && (str[9].Equals("") == false))
            {
                strSql += "功率测量仪表ID='";
                strSql += str[9];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "温度测量仪表ID").GetValue();
            str[10] = data_温度测量仪表.获取ID(strTemp);
            if ((str[10] != null) && (str[10].Equals("") == false))
            {
                strSql += "温度测量仪表ID='";
                strSql += str[10];
                strSql += "',";
            }
            else
            {
                strSql += "null,";
            }
            strTemp = _form.GetControlElementByInfo("dbo.生成试验组", "液力耦合器ID").GetValue();
            str[11] = data_液力耦合器.获取ID(strTemp);
            if ((str[11] != null) && (str[11].Equals("") == false))
            {
                strSql += "液力耦合器ID='";
                strSql += str[11] + "'";
            }
            else
            {
                strSql += "null,";
            }

            //-----------------add室温--------------begin
            str[12] = _form.GetControlElementByInfo("dbo.生成试验组", "室温").GetValue();
            if ((str[12] != null) && (str[12].Equals("") == false))
            {
                strSql += "室温='";
                strSql += str[12] + "'";
            }
            else
            {
                strSql += "null";
            }
            //-----------------add室温--------------end
            str[13] = _form.GetControlElementByInfo("dbo.生成试验组", "水温").GetValue();
            if ((str[13] != null) && (str[13].Equals("") == false))
            {
                strSql += "水温='";
                strSql += str[13] + "'";
            }
            else
            {
                strSql += "null";
            }
            str[14] = _form.GetControlElementByInfo("dbo.生成试验组", "气压").GetValue();
            if ((str[14] != null) && (str[14].Equals("") == false))
            {
                strSql += "气压='";
                strSql += str[14] + "'";
            }
            else
            {
                strSql += "null";
            }
            strSql += " where ID=" + id;

            return strSql;
        }
        #endregion

        #region combobox控件操作
        private void 注册控件数据(string 表名, string 字段名1, string 字段名2, ref structComboBox控件数据 控件数据)
        {
            控件数据.表名 = 表名;
            控件数据.字段名1 = 字段名1;
            控件数据.字段名2 = 字段名2;
            控件数据.ID值 = "";
        }
        private structComboBox控件数据 获取控件数据(string 表名)
        {
            structComboBox控件数据 控件数据 = new structComboBox控件数据();
            if (data_被试水泵.表名.Equals(表名) == true)
            {
                InitListData(ref data_被试水泵);
                return data_被试水泵;
            }

            if (data_拖动电机.表名.Equals(表名) == true)
            {
                InitListData(ref data_拖动电机);
                return data_拖动电机;
            }

            if (data_流量仪表.表名.Equals(表名) == true)
            {
                InitListData(ref data_流量仪表);
                return data_流量仪表;
            }

            if (data_转速测量.表名.Equals(表名) == true)
            {
                InitListData(ref data_转速测量);
                return data_转速测量;
            }

            if (data_进口压力仪表.表名.Equals(表名) == true)
            {
                InitListData(ref data_进口压力仪表);
                return data_进口压力仪表;
            }

            if (data_出口压力仪表.表名.Equals(表名) == true)
            {
                InitListData(ref data_出口压力仪表);
                return data_出口压力仪表;
            }

            if (data_功率测量仪表.表名.Equals(表名) == true)
            {
                InitListData(ref data_功率测量仪表);
                return data_功率测量仪表;
            }

            if (data_温度测量仪表.表名.Equals(表名) == true)
            {
                InitListData(ref data_温度测量仪表);
                return data_温度测量仪表;
            }

            if (data_液力耦合器.表名.Equals(表名) == true)
            {
                InitListData(ref data_液力耦合器);
                return data_液力耦合器;
            }

            InitListData(ref 控件数据);
            return 控件数据;
        }
        private void InitListData(ref structComboBox控件数据 控件数据)
        {
            if (控件数据.ID_list == null)
            {
                控件数据.ID_list = new List<string>();

            }

            if (控件数据.CtrlData_list == null)
            {
                控件数据.CtrlData_list = new List<string>();
            }
        }
        private void 刷新控件数据()
        {
            查询控件数据("dbo.水泵型号管理");
            绑定控件("被试水泵ID",获取控件数据("dbo.水泵型号管理"));
            查询控件数据("dbo.电机型号管理");
            绑定控件("拖动电机ID", 获取控件数据("dbo.电机型号管理"));
            查询控件数据("dbo.流量仪表");
            绑定控件("流量仪表ID", 获取控件数据("dbo.流量仪表"));
            查询控件数据("dbo.转速测量");
            绑定控件("转速测量ID", 获取控件数据("dbo.转速测量"));
            查询控件数据("dbo.进口压力仪表");
            绑定控件("进口压力仪表ID", 获取控件数据("dbo.进口压力仪表"));
            查询控件数据("dbo.出口压力仪表");
            绑定控件("出口压力仪表ID", 获取控件数据("dbo.出口压力仪表"));
            查询控件数据("dbo.功率测量仪表");
            绑定控件("功率测量仪表ID", 获取控件数据("dbo.功率测量仪表"));
            查询控件数据("dbo.温度测量仪表");
            绑定控件("温度测量仪表ID", 获取控件数据("dbo.温度测量仪表"));
            查询控件数据("dbo.液力耦合器");
            绑定控件("液力耦合器ID", 获取控件数据("dbo.液力耦合器"));
        }
        private void 查询控件数据(string 表名)
        {
            DataTable dt = 数据库操作库.数据库操作类.GetTable(表名);

            获取控件数据(表名).ID_list.Clear();
            获取控件数据(表名).CtrlData_list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                获取控件数据(表名).ID_list.Add(Convert.ToString(dr["ID"]));
                string strValue = Convert.ToString(dr[获取控件数据(表名).字段名1]) + "_";
                strValue+=Convert.ToString(dr[获取控件数据(表名).字段名2]);
                获取控件数据(表名).CtrlData_list.Add(strValue);
            }
        }
        private void 绑定控件(string 字段名, structComboBox控件数据 控件数据)
        {
            string 表名 = "dbo.生成试验组";
            comBoxBD comBoxBD = new comBoxBD();
            ControlElement Control;
            comBoxBD.comboxList = 控件数据.CtrlData_list;
            comBoxBD.Value = 控件数据.获取选择字符串();
            Control = _form.GetControlElementByInfo(表名, 字段名);
            Control.BindTheControl(comBoxBD);
        }
        #endregion

        private void simpleButton_拷贝试验组_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)grid1.ExportView.GetRow(grid1.ExportView.FocusedRowHandle);
            if (row == null) return;
            decimal id = System.Convert.ToDecimal(row["id"].ToString());
            拷贝试验组.拷贝(id);
            查询_试验组数据();
        } 


    }
}