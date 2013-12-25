using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Computer;
using DevExpress.XtraEditors.Repository;
using System.Data;

namespace Gather
{
    public class GatherItem 
    {
        // 关联仪表数据
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edit;
        public 控件库.表格控件.Grid _Grid;
        public ITableComputer computer;
        public  GatherField field = null;
        public IComputerItem item = null;
        public IValue _VALUE;

        public GatherItem(GatherField field, IComputerItem item)
        {
            this.field = field;
            this.item = item;
        }

        public GatherItem(GatherField field,IValue _VALUE)
        {
            this.field = field;
            this._VALUE = _VALUE;
        }

        public float GetValue()
        {
            float v = (float)Math.Round(this.item.数据值,2);
            return v;
        }

        public object GetObjValue()
        {
            return this._VALUE.Value;
        }

        public void 计算列准备(控件库.表格控件.Grid _Grid,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edit)
        {
            this._Grid = _Grid;
            this.edit = edit;
        }

        public void 加载计算列(ITableComputer computer)
        {
            this.computer = computer;
            if(this.edit != null)
            edit.Validating += new System.ComponentModel.CancelEventHandler(edit_Validating);
        }

        void edit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string editvalue = _Grid.ExportBandView.EditingValue.ToString();
            DataRowView row = (DataRowView)_Grid.ExportBandView.GetRow(_Grid.ExportBandView.FocusedRowHandle);
            this.computer.Computer(System.Convert.ToSingle(editvalue), row);
        }
    }
}
