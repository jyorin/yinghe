using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AutoControl;
using System.IO;
using System.Data.OleDb;
namespace Main.管理界面
{
    public partial class 水泵型号管理 : DevExpress.XtraEditors.XtraForm
    {
        private DataTable GridDataTabel = null;
        private FormElement _form = null;
        private Decimal ID号=-1;
        private string 图片路径 = "";
        public void 控件赋值(string 字段名, string 值)
        {
            _form.GetControlElementByInfo("dbo.水泵型号管理", 字段名).SetValue(值);
        }
        public void 设置图片(System.Drawing.Image image)
        {
            this.pictureBox_图片.Image = image;
        }
        public 水泵型号管理()
        {
            InitializeComponent();
            this.grid1.InitViewLayout("管理表格配置\\水泵型号管理表格.xml");
        }

        private void 保存_水泵型号管理数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            Decimal[] ID = _form.SaveTabs(new string[] { "dbo.水泵型号管理" });
            foreach (Decimal _ID in ID)
            {
                添加图片ToDB(_ID);
                break;
            }
        }

        private void 删除_水泵型号管理数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.水泵型号管理" });
        }


        private void simpleButton1_保存型号信息_Click(object sender, EventArgs e)
        {
            保存_水泵型号管理数据();
            查询_水泵型号管理数据();
            MessageBox.Show("数据保存成功！", "提示");
        }

        private void 水泵型号管理_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.水泵型号管理" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_用户名称, "dbo.水泵型号管理", "用户名称");
            _form.AddControlByLayout(this.panel_出厂编号, "dbo.水泵型号管理", "出厂编号");
            _form.AddControlByLayout(this.panel_水泵型号, "dbo.水泵型号管理", "水泵型号");
            _form.AddControlByLayout(this.panel_水泵类型, "dbo.水泵型号管理", "水泵类型");
            _form.AddControlByLayout(this.panel_额定流量, "dbo.水泵型号管理", "额定流量");
            _form.AddControlByLayout(this.panel_额定扬程, "dbo.水泵型号管理", "额定扬程");
            _form.AddControlByLayout(this.panel_额定轴功率, "dbo.水泵型号管理", "额定轴功率");
            _form.AddControlByLayout(this.panel_汽蚀余量, "dbo.水泵型号管理", "汽蚀余量");
            _form.AddControlByLayout(this.panel_进口直径, "dbo.水泵型号管理", "进口直径");
            _form.AddControlByLayout(this.panel_出口直径, "dbo.水泵型号管理", "出口直径");
            _form.AddControlByLayout(this.panel_额定转速, "dbo.水泵型号管理", "额定转速");
            _form.AddControlByLayout(this.panel_工况1_流量, "dbo.水泵型号管理", "工况1_流量");
            _form.AddControlByLayout(this.panel_工况1_扬程, "dbo.水泵型号管理", "工况1_扬程");
            _form.AddControlByLayout(this.panel_工况1_轴功率, "dbo.水泵型号管理", "工况1_轴功率");
            _form.AddControlByLayout(this.panel_工况1_汽蚀余量, "dbo.水泵型号管理", "工况1_汽蚀余量");
            _form.AddControlByLayout(this.panel_工况2_流量, "dbo.水泵型号管理", "工况2_流量");
            _form.AddControlByLayout(this.panel_工况2_扬程, "dbo.水泵型号管理", "工况2_扬程");
            _form.AddControlByLayout(this.panel_工况2_轴功率, "dbo.水泵型号管理", "工况2_轴功率");
            _form.AddControlByLayout(this.panel_工况2_汽蚀余量, "dbo.水泵型号管理", "工况2_汽蚀余量");
            _form.AddControlByLayout(this.panel_工况3_流量, "dbo.水泵型号管理", "工况3_流量");
            _form.AddControlByLayout(this.panel_工况3_扬程, "dbo.水泵型号管理", "工况3_扬程");
            _form.AddControlByLayout(this.panel_工况3_轴功率, "dbo.水泵型号管理", "工况3_轴功率");
            _form.AddControlByLayout(this.panel_工况3_汽蚀余量, "dbo.水泵型号管理", "工况3_汽蚀余量");
            _form.AddControlByLayout(this.panel_工况4_流量, "dbo.水泵型号管理", "工况4_流量");
            _form.AddControlByLayout(this.panel_工况4_扬程, "dbo.水泵型号管理", "工况4_扬程");
            _form.AddControlByLayout(this.panel_工况4_轴功率, "dbo.水泵型号管理", "工况4_轴功率");
            _form.AddControlByLayout(this.panel_工况4_汽蚀余量, "dbo.水泵型号管理", "工况4_汽蚀余量");
            _form.AddControlByLayout(this.panel_工况5_流量, "dbo.水泵型号管理", "工况5_流量");
            _form.AddControlByLayout(this.panel_工况5_扬程, "dbo.水泵型号管理", "工况5_扬程");
            _form.AddControlByLayout(this.panel_工况5_轴功率, "dbo.水泵型号管理", "工况5_轴功率");
            _form.AddControlByLayout(this.panel_工况5_汽蚀余量, "dbo.水泵型号管理", "工况5_汽蚀余量");
            查询_水泵型号管理数据();
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                删除_水泵型号管理数据();
                查询_水泵型号管理数据();
            }
        }

        private void 查询_水泵型号管理数据()
        {
            DataTable dt = _form.SelectTabs("dbo.水泵型号管理");
            // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("用户名称");
                GridDataTabel.Columns.Add("水泵型号");
                GridDataTabel.Columns.Add("出厂编号");
            }
            GridDataTabel.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["用户名称"], dr["水泵型号"], dr["出厂编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);

        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.水泵型号管理");
        }

        private void grid1_SelectRow(int nline)
        {
            图片路径 = "";
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in GridDataTabel.Rows)
            {
                if (id == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.水泵型号管理", id);
                    _form.LoadTabs(new string[] { "dbo.水泵型号管理" }, new decimal[] { id });
                    _form.BindControlAgin("dbo.水泵型号管理");
                    ID号 = id;
                    读取图片FromDB();
                }
            }
        }

        private void simpleButton_添加图片_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string picFileName = this.openFileDialog1.FileName;
                    pictureBox_图片.Load(picFileName);
                    图片路径 = picFileName;
                }
                catch
                {
                    MessageBox.Show("图片加载失败!", "错误");
                }
            }
        }


        private void 添加图片ToDB(Decimal id)
        {
            int 图片大小 = 0;
            if (图片路径 == null)
            {
                return;
            }
            if (图片路径 == "") return;
            FileStream fs = new FileStream(图片路径, FileMode.Open, FileAccess.Read);
            byte[] byteArray = new byte[fs.Length];
            图片大小 = Convert.ToInt32(fs.Length);
            fs.Read(byteArray, 0, 图片大小);
            fs.Close();
            string sql = "UPDATE dbo.水泵型号管理  SET 安装图片=? WHERE ID=" + ID号;
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("?安装图片", OleDbType.Binary, 图片大小);
            param[0].Value = byteArray;
            if (图片大小 > 0)
            {
                _form.ExcuteSqlInputParam(sql, param,1);
            }
        }

        private void 读取图片FromDB()
        {
            DataTable dt = _form.SelectTabs("dbo.水泵型号管理");
            Byte[] buf = null;
            this.pictureBox_图片.CreateGraphics().Clear(Color.White);

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行

                if (ID号==Convert.ToDecimal(dr["ID"]))
                {
                    if (dr.IsNull("安装图片")==false)
                    {
                        buf = (Byte[])dr["安装图片"];
                        this.pictureBox_图片.Image = Image.FromStream(new MemoryStream(buf));
                        break;
                    }
                }
            }

        }

        private void simpleButton_选择方案_Click(object sender, EventArgs e)
        {
            水泵型号管理方案选择 _form = new 水泵型号管理方案选择(this);
            _form.ShowDialog();
        }
        private void simpleButton_保存方案_Click(object sender, EventArgs e)
        {
            存储方案();
            MessageBox.Show("方案保存成功！", "提示");
        }
        private Boolean 方案是否已经存在()
        {
            DataTable _data = null;
            string strSql = "select * from dbo.水泵型号管理方案";
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
            string strSql = "";
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            if (id == -1)
            {
                MessageBox.Show("存储方案失败!", "错误");
                return;
            }

            if (方案是否已经存在() == false)
            {
                strSql = 方案保存_拼接插入Sql();
            }
            else
            {
                strSql = 方案保存_拼接更新Sql();
            }
            int 图片大小 = 0;
            MemoryStream ms = new MemoryStream();

            this.pictureBox_图片.Image.Save("temp.bmp");
            FileStream fs = new FileStream("temp.bmp", FileMode.Open, FileAccess.Read);
            byte[] byteArray = new byte[fs.Length];
            图片大小 = Convert.ToInt32(fs.Length);
            fs.Read(byteArray, 0, 图片大小);
            fs.Close();
            File.Delete("temp.bmp");
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("?安装图片", OleDbType.Binary, 图片大小);
            param[0].Value = byteArray;
            _form.ExcuteSqlInputParam(strSql, param, 1);
        }
        private string 方案保存_拼接插入Sql()
        {
            Decimal id = -1;
            string strSql = "";
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            strSql = "insert into dbo.水泵型号管理方案  (ID,水泵型号,水泵类型,用户名称,出厂编号,额定流量," +
                             "额定扬程,额定轴功率,汽蚀余量,进口直径,出口直径,额定转速,安装图片," +
                              "工况1_流量,工况2_流量,工况3_流量,工况4_流量,工况5_流量,工况1_扬程," +
                              "工况2_扬程,工况3_扬程,工况4_扬程,工况5_扬程,工况1_轴功率,工况2_轴功率," +
                              "工况3_轴功率,工况4_轴功率,工况5_轴功率,工况1_汽蚀余量,工况2_汽蚀余量," +
                              "工况3_汽蚀余量,工况4_汽蚀余量,工况5_汽蚀余量) values (" +
                              id + ",";

            ControlElement control = _form.GetControlElementByInfo("dbo.水泵型号管理", "水泵型号");
            strSql += "'";          
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "水泵类型");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "用户名称");
            strSql += "'";      
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "出厂编号");
            strSql += "'";      
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定流量");  
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定扬程");   
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定轴功率");  
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "汽蚀余量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "进口直径");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "出口直径");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定转速");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "安装图片");
            strSql += "?,";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_流量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_流量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_流量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_流量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_流量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_扬程");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_扬程");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_扬程");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_扬程");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_扬程");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_轴功率");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_轴功率");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_轴功率");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_轴功率");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_轴功率");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_汽蚀余量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_汽蚀余量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_汽蚀余量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_汽蚀余量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_汽蚀余量");
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ")";

            return strSql;
        }

        private string 方案保存_拼接更新Sql()
        {
            Decimal id = -1;
            string strSql = "";
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            strSql = "update  dbo.水泵型号管理方案 set  ";

            ControlElement control = _form.GetControlElementByInfo("dbo.水泵型号管理", "水泵型号");
            strSql += "水泵型号='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "水泵类型");
            strSql += "水泵类型='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "用户名称");
            strSql += "用户名称='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "出厂编号");
            strSql += "出厂编号='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定流量");
            strSql += "额定流量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定扬程");
            strSql += "额定扬程=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定轴功率");
            strSql += "额定轴功率=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "汽蚀余量");
            strSql += "汽蚀余量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "进口直径");
            strSql += "进口直径=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "出口直径");
            strSql += "出口直径=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "额定转速");
            strSql += "额定转速=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "安装图片");
            strSql += "安装图片=";
            strSql += "?,";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_流量");
            strSql += "工况1_流量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_流量");
            strSql += "工况2_流量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_流量");
            strSql += "工况3_流量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_流量");
            strSql += "工况4_流量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_流量");
            strSql += "工况5_流量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_扬程");
            strSql += "工况1_扬程=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_扬程");
            strSql += "工况2_扬程=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_扬程");
            strSql += "工况3_扬程=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_扬程");
            strSql += "工况4_扬程=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_扬程");
            strSql += "工况5_扬程=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_轴功率");
            strSql += "工况1_轴功率=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_轴功率");
            strSql += "工况2_轴功率=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_轴功率");
            strSql += "工况3_轴功率=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_轴功率");
            strSql += "工况4_轴功率=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_轴功率");
            strSql += "工况5_轴功率=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况1_汽蚀余量");
            strSql += "工况1_汽蚀余量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况2_汽蚀余量");
            strSql += "工况2_汽蚀余量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况3_汽蚀余量");
            strSql += "工况3_汽蚀余量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况4_汽蚀余量");
            strSql += "工况4_汽蚀余量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += ",";
            control = _form.GetControlElementByInfo("dbo.水泵型号管理", "工况5_汽蚀余量");
            strSql += "工况5_汽蚀余量=";
            strSql += Convert.ToDouble(control.GetValue());
            strSql += " where ID=" + id;

            return strSql;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str出厂编号="";
            ControlElement control = _form.GetControlElementByInfo("dbo.水泵型号管理", "出厂编号");
            str出厂编号 += control.GetValue();
            水泵环境参数配置 dp = new 水泵环境参数配置(str出厂编号,(int)ID号);
            dp.ShowDialog();
        }
    }
}