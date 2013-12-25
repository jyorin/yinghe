using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace 控件库.表格控件
{
    public interface 显示采集频率
    {
        void 频率改变(int ndata);
    }
    public delegate void SelectRow(int nline);
    public partial class Grid : DevExpress.XtraEditors.XtraUserControl
    {
        #region 变量
        public event EventHandler ExportAccessClick;
        public event EventHandler ClickPanelVisible;
        public event EventHandler ClickRow;
        public event EventHandler Grid_MouseLeave;
        public event EventHandler BtnAddRowClick;
        public event EventHandler BtnReduceRowClick;
        public event EventHandler Btn执行命令1Click;
        public event DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler SelectRowChanged;
        public event SelectRow SelectRow;

        public Type ValuesType;
        public SpeicalShow[] SpeicalShows;
        public bool ButtonPanelVisible { set { _panelControl.Visible = value; } get { return this._panelControl.Visible; } }
        public bool BtnAddRow { set { this.btn_AddRow.Visible = value; } get { return this.btn_AddRow.Visible; } }
        public bool BtnReduceRow { set { this.btn_ReduceRow.Visible = value; } get { return this.btn_ReduceRow.Visible; } }
        public DevExpress.Utils.AppearanceDefault app_绿 { get { return new DevExpress.Utils.AppearanceDefault(Color.Black, Color.WhiteSmoke, Color.Empty, Color.GreenYellow, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal); } }
        public DevExpress.Utils.AppearanceDefault app_蓝绿 { get { return new DevExpress.Utils.AppearanceDefault(Color.Brown, Color.WhiteSmoke, Color.Empty, Color.WhiteSmoke, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal); } }
        public DevExpress.Utils.AppearanceDefault app_红 { get { return new DevExpress.Utils.AppearanceDefault(Color.White, Color.WhiteSmoke, Color.Empty, Color.Red, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal); } }
        public DevExpress.Utils.AppearanceDefault app_黄 { get { return new DevExpress.Utils.AppearanceDefault(Color.Brown, Color.WhiteSmoke, Color.Empty, Color.Yellow, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal); } }
        public DevExpress.Utils.AppearanceDefault app_删除 { get { return new DevExpress.Utils.AppearanceDefault(Color.Gray, Color.White, Color.Empty, Color.White, new Font(new FontFamily("Tahoma"), 9, FontStyle.Regular)); } }

        private bool _执行命令;

        public bool 执行命令
        {
            get { return _执行命令; }
            set { _执行命令 = value; btn_执行命令1.Visible = value ? true : false; }
            
        }

        显示采集频率 _显示采集频率 = null;
        public void 显示采集(显示采集频率 _显示采集频率)
        {
            this._显示采集频率 = _显示采集频率;
            
            this.采集模块.Visible = true;
            this.采集频率1.SelectedIndex = 0;
            this.采集频率1.SelectedIndexChanged += new EventHandler(采集频率1_SelectedIndexChanged);
            this.采集频率1.TextChanged += new EventHandler(采集频率1_Text_Changed);
        }

        void 采集频率1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nNum = 0;
            try
            {
                nNum = Convert.ToInt32(this.采集频率1.Text);
                this._显示采集频率.频率改变(nNum);
            }
            catch
            {

            }

        }

        void 采集频率1_Text_Changed(object sender, EventArgs e)
        {
            int nNum = 0;
            try
            {
                if (this.采集频率1.Text.Trim().Equals(""))
                {
                    nNum = 0;
                }
                else
                {
                    nNum = Convert.ToInt32(this.采集频率1.Text);
                }

                this._显示采集频率.频率改变(nNum);
            }
            catch
            {

            }

        }
        private bool _合计底栏;

        public bool 合计底栏
        {
            get { return _合计底栏; }
            set { _合计底栏 = value; btn_simpleCancelSum.Visible = value ? true : false; }
        }
        private bool _分组面板;

        public bool 分组面板
        {
            get { return _分组面板; }
            set { _分组面板 = value; btn_显示隐藏分组面板.Visible = value ? true : false; }
        }
        private bool _查找记录;

        public bool 查找记录
        {
            get { return _查找记录; }
            set { _查找记录 = value; btn_显示隐藏过滤面板.Visible = value ? true : false; }
        }
        private bool _合并列值;

        public bool 合并列值
        {
            get { return _合并列值; }
            set { _合并列值 = value; btn_合并取消合并表格.Visible = value ? true : false; }
        }
        private bool _导出表格;
        public bool 导出表格
        {
            get { return _导出表格; }
            set { _导出表格 = value; btn_Export.Visible = value ? true : false; }
        }

        private bool _新增记录;
        public bool 新增记录
        {
            get { return _新增记录; }
            set { _新增记录 = value; btn_AddRow.Visible = value ? true : false; }
        }
        private bool _删除记录;
        public bool 删除记录
        {
            get { return _删除记录; }
            set { _删除记录 = value; btn_ReduceRow.Visible = value ? true : false; }
        }


        private string _新增记录按钮CAPTION;

        public string 新增记录按钮CAPTION
        {
            get { return _新增记录按钮CAPTION; }
            set { _新增记录按钮CAPTION = value; this.btn_AddRow.Text = value; }
        }

        private string _删除记录按钮CAPTION;

        public string 删除记录按钮CAPTION
        {
            get { return _删除记录按钮CAPTION; }
            set { _删除记录按钮CAPTION = value; this.btn_ReduceRow.Text = value; }
        }

        private string _执行命令按钮CAPTION;

        public string 执行命令按钮CAPTION
        {
            get { return _执行命令按钮CAPTION; }
            set { _执行命令按钮CAPTION = value; this.btn_执行命令1.Text = value; }
        }
        #endregion

        public Grid()
        {
            InitializeComponent();
            this._gridControl.MainView = _gridView;
        }

        public DevExpress.XtraGrid.GridControl GetGridControl()
        { 
            return this._gridControl;
        }

        public void SetGridtoBandGrid()
        {
            this._gridControl.MainView = bandedGridView1;
        }

        public void InitViewLayout(string 配置文件路径)
        {
            string LayoutFileName = DevExpress.Utils.FilesHelper.FindingFileName(AppDomain.CurrentDomain.BaseDirectory, 配置文件路径);
            if (LayoutFileName != "")
            {
                this._gridControl.MainView.RestoreLayoutFromXml(LayoutFileName, null);
            }
        }

        #region 导出表格
        public DevExpress.XtraGrid.Views.Grid.GridView ExportView { get { return _gridView; } } // 常规表格
        public DevExpress.XtraGrid.Views.BandedGrid.BandedGridView ExportBandView { get { return bandedGridView1; } } // 带标头的表格
        #endregion

        #region 导出数据
        public void ExportGridView()
        {
            ParentForm.Cursor = Cursors.WaitCursor;

            const string title = "保存文件(XLS,HTML,PDF,MHT)";
            const string filter = "保存为XLS文件(*.XLS)|*.XLS|保存为PNG文件(*.PNG)|*.PNG|保存为HTML文件(*.HTML;*.HTM)|*.HTM|保存为PDF文件(*.PDF)|*.PDF|保存为MHT文件(*.MHT)|*.MHT";
            string names = string.Empty;
            string fileName = ShowSaveFileDialog(title, filter);

            if (fileName != "")
            {
                names = fileName.Substring(fileName.Length - 3, 3);
               
                    switch (names)
                    {
                        case "HTM":
                            _gridView.ExportToHtml(fileName);
                            break;
                        case "MHT":
                            _gridView.ExportToMht(fileName);
                            break;
                        case "PDF":
                            _gridView.ExportToPdf(fileName);
                            break;
                        case "XLS":
                            _gridView.ExportToExcelOld(fileName);
                            break;
                    }
               
            }

            if (fileName != "") OpenExcel(fileName);

            ParentForm.Cursor = Cursors.Arrow;
        }
        private string ShowSaveFileDialog(string title, string filter)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                string name = "dlg";
                int n = name.LastIndexOf(".") + 1;
                if (n > 0)
                    name = name.Substring(n, name.Length - n);
                dlg.Title = "保存 " + title;
                dlg.FileName = name;
                dlg.Filter = filter;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.FileName;
            }
            return "";
        }
        private void OpenExcel(string fileName)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("是否打开该文件?", "打开...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                    {
                        process.StartInfo.FileName = fileName;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("没有找到该文件", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 合并表格列
        public void MixedRow()
        {

                _gridView.OptionsView.AllowCellMerge = !_gridView.OptionsView.AllowCellMerge;
                _gridView.OptionsView.ShowVertLines = !_gridView.OptionsView.ShowVertLines;
          
        }

        #endregion

        #region 允许过滤

        public void FilterGrid()
        {
          
                _gridView.OptionsView.ShowAutoFilterRow = !_gridView.OptionsView.ShowAutoFilterRow;
                _gridView.OptionsCustomization.AllowFilter = !_gridView.OptionsCustomization.AllowFilter;
                _gridView.BestFitColumns();
        
        }

        #endregion

        #region 显示分组框
        public void ShowGroupPanel()
        {
         
                _gridView.OptionsView.ShowGroupPanel = !_gridView.OptionsView.ShowGroupPanel;
          
        }

        #endregion

        #region 固定表格列
        public void FixedColumns()
        {

                if (_gridView.FocusedColumn.Fixed == DevExpress.XtraGrid.Columns.FixedStyle.Left)
                    _gridView.FocusedColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                else
                    _gridView.FocusedColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
          
        }
        #endregion

        #region 显示合计行
        public void ShowSumRow()
        {
            
                _gridView.OptionsView.ShowFooter = !_gridView.OptionsView.ShowFooter;
          
        }
        #endregion

        #region 设置表格数据列
        /// <summary>
        /// 绑定一维表格(外挂表)
        /// </summary>
        /// <param name="columnNames">列名数组</param>
        /// <param name="columnIDs">数据字段数组</param>
        /// <param name="invisibleColumns">需要隐藏的数据字段数组</param>
        public void SetGridColumns(String[] columnNames, String[] columnIDs, String[] invisibleColumns)
        {
           
                _gridView.Columns.Clear();
                for (int i = 0; i < columnIDs.Length; i++)
                {
                    DevExpress.XtraGrid.Columns.GridColumn myc = new DevExpress.XtraGrid.Columns.GridColumn() { Name = columnIDs[i], Caption = columnNames[i], FieldName = columnIDs[i] };
                    foreach (string s in invisibleColumns)
                    {
                        if (columnIDs[i].Trim() == s.Trim())
                        {
                            myc.Visible = false;
                            myc.VisibleIndex = -1;
                            myc.OptionsColumn.AllowEdit = true;
                        }
                        else
                            myc.VisibleIndex = i;
                            myc.OptionsColumn.AllowEdit = true;
                    }

                    _gridView.Columns.Add(myc);

                }
            
         
        }
        #endregion

        #region 工具栏事件
        private void _gridView_DoubleClick(object sender, EventArgs e)
        {
            if (ClickRow != null)
                ClickRow(sender, e);
        }

        private void _gridControl_MouseLeave(object sender, EventArgs e)
        {
            if (Grid_MouseLeave != null)
                Grid_MouseLeave(sender, e);
        }
        /// <summary>
        /// 筛选栏是否打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnshow_Click(object sender, EventArgs e)
        {
            if (ClickPanelVisible != null)
                ClickPanelVisible(sender, e);
            ButtonPanelVisible = !ButtonPanelVisible;
        }

        /// <summary>
        /// 导出到ACCESS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_ExportAccess_Click(object sender, EventArgs e)
        {
            if (ExportAccessClick != null)
                ExportAccessClick(sender, e);
        }

        /// <summary>
        /// 导出本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
               ExportGridView();
            }
            catch (Exception err)
            { }
        }

        /// <summary>
        /// 打开/关闭筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TotleLocation_Click(object sender, EventArgs e)
        {
            FilterGrid();
        }

        /// <summary>
        /// 显示/隐藏合计行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_simpleCancelSum_Click(object sender, EventArgs e)
        {
            ShowSumRow();
        }

        /// <summary>
        /// 固定/取消固定选中列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_固定取消固定选中列_Click(object sender, EventArgs e)
        {
            FixedColumns();
        }

        /// <summary>
        /// 显示/隐藏分组面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_显示隐藏分组面板_Click(object sender, EventArgs e)
        {
            ShowGroupPanel();
        }

        /// <summary>
        /// 合并/取消合并表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_合并取消合并表格_Click(object sender, EventArgs e)
        {
            MixedRow();
        }
        #endregion

        #region 公用方法
        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="_数据源"></param>
        public void SetDataSource(object _数据源)
        {
           
                _gridView.GridControl.DataSource = _数据源;
         
        }
        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="_数据源"></param>
        public void SetDataSource(DataTable _数据源)
        {
      
                _gridView.GridControl.DataSource = _数据源.DefaultView;
          
        }

        public string GetFocusedRowCellValue(string FiledName)
        {
            return  Convert.ToString(_gridView.GetFocusedRowCellValue(FiledName));
        }
        /// <summary>
        /// 表格自适应界面
        /// </summary>
        public void BestFitColumns()
        {
         
                _gridView.BestFitColumns();
            
        }

        /// <summary>
        /// 表格是否只读
        /// </summary>
        /// <param name="isReadonly"></param>
        public void SetReadOnly(bool isReadonly)
        {
          
                _gridView.OptionsBehavior.Editable = !isReadonly;
           
        }

        /// <summary>
        /// 表格是否允许点击列头进行排序
        /// </summary>
        /// <param name="istrue"></param>
        public void SetAllowSort(DevExpress.Utils.DefaultBoolean istrue)
        {
            
                for (int i = 0; i < _gridView.Columns.Count; i++)
                {
                    _gridView.Columns[i].OptionsColumn.AllowSort = istrue;
                }
            
        }

        /// <summary>
        /// 设置行的背景色
        /// </summary>
        /// <param name="e"></param>
        /// <param name="speicalShows"></param>
        public void SetRowStyles(Type e, SpeicalShow[] speicalShows)
        {
            ValuesType = e;
            SpeicalShows = speicalShows;
            _gridView.RowStyle += rowStyleSetting;
        }

        private void rowStyleSetting(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle != -1)
            {
                object obj = _gridView.GetRow(e.RowHandle);

                foreach (SpeicalShow _样式类 in SpeicalShows)
                {
                    try
                    {
                        object unObj = null;
                        bool falg = false;

                        try
                        {

                            unObj = ((DataRowView)obj).Row[_样式类.FieldName];
                            if (unObj.ToString().Trim() == _样式类.Value.ToString().Trim())
                            {
                                falg = true;
                            }
                        }
                        catch
                        {
                            PropertyInfo pis = ValuesType.GetProperty(_样式类.FieldName);
                            unObj = pis.GetValue(obj, null);

                            if (_样式类.p_判断方式 == SpeicalShow.e_判断方式.等于)
                            {
                                if (unObj.Equals(_样式类.Value))
                                {
                                    falg = true;
                                }
                            }

                            if (_样式类.p_判断方式 == SpeicalShow.e_判断方式.不等于)
                            {
                                if (!unObj.Equals(_样式类.Value))
                                {
                                    falg = true;
                                }
                            }

                            if (_样式类.p_判断方式 == SpeicalShow.e_判断方式.大于)
                            {
                                try
                                {
                                    int i1 = Int32.Parse(unObj.ToString());
                                    int i2 = Int32.Parse(_样式类.Value.ToString());
                                    if (i1 > i2)
                                        falg = true;
                                }
                                catch
                                { }
                            }

                            if (_样式类.p_判断方式 == SpeicalShow.e_判断方式.小于)
                            {
                                try
                                {
                                    int i1 = Int32.Parse(unObj.ToString());
                                    int i2 = Int32.Parse(_样式类.Value.ToString());
                                    if (i1 < i2)
                                        falg = true;
                                }
                                catch
                                { }
                            }
                            if (_样式类.p_判断方式 == SpeicalShow.e_判断方式.包含)
                            {
                                try
                                {
                                    String str = unObj.ToString();
                                    if (str.IndexOf(_样式类.Value.ToString()) >= 0)
                                    {
                                        falg = true;
                                    }
                                }
                                catch
                                { }


                            }

                        }

                        if (falg) fireSetRowStyle(_样式类.p_行样式, e);

                    }
                    catch { }
                }
            }
        }

        private void fireSetRowStyle(SpeicalShow.e_表格行样式 style, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            switch (style)
            {
                case SpeicalShow.e_表格行样式.待完成:
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, app_黄);
                    break;
                case SpeicalShow.e_表格行样式.已完成:
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, app_绿);
                    break;
                case SpeicalShow.e_表格行样式.作废:
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, app_红);
                    break;
                case SpeicalShow.e_表格行样式.禁用:
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, app_黄);
                    break;
                case SpeicalShow.e_表格行样式.启用:
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, app_绿);
                    break;
                case SpeicalShow.e_表格行样式.趋势曲线:
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, app_绿);
                    break;
                case SpeicalShow.e_表格行样式.实时波形:
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, app_黄);
                    break;
            }
        }

        #endregion

        #region 增减行数

        #endregion

        private void btn_AddRow_MouseDown(object sender, MouseEventArgs e)
        {
            if (BtnAddRowClick != null)
                BtnAddRowClick(sender, e);
        }

        private void btn_ReduceRow_MouseDown(object sender, MouseEventArgs e)
        {
            if (BtnReduceRowClick != null)
                BtnReduceRowClick(sender, e);
        }

        private void _gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
          //  if (SelectRowChanged != null)
           //     SelectRowChanged(sender, e);

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (SelectRow != null)
            SelectRow(view.GetFocusedDataSourceRowIndex());


        }

        private void btn_执行命令1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Btn执行命令1Click != null)
                Btn执行命令1Click(sender, e);
        }

        private void btn_执行命令1_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddRow_Click(object sender, EventArgs e)
        {

        }

        private void btn_ReduceRow_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
