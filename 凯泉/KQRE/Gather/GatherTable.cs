using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Computer;

namespace Gather
{
    public enum DataStoreType
    {
        SynDB = 1, // 同步保存到存储介质
        LastDB = 2 // 最后保存到存储介质
    }

    public class GatherTable
    {
       // 总的缓存
        DataStoreType storeType;
        IGatherComplete _GatherComplete = null;
        IGatherRow _GahterRowEvent = null;
        GatherRow row = null;
        public GatherTimer time = null;
        GatherInfo _info;
        IGatherDB _db;
        DataTable tb;
        IThreadAction _action;
        ActionData actionData = null;
        DataTable 临时缓存 = null;
        public GatherTable(){}

        public DataTable Cache
        {
            get { return this.tb; }
        }

        public IGatherComplete GatherComplete
        {
            set { this._GatherComplete = value; }
        }

        public IGatherRow GatherRowEvent
        {
            set { this._GahterRowEvent = value; }
        }

        public void LoadGatherTable(GatherInfo info, GatherTimer time, IGatherItem IItem,IGatherDB db,IThreadAction _action)
        {
            this._action = _action;
            this._db = db;
            this._info = info;
            this.tb = db.GetDataTable();
            this.临时缓存 = this.tb.Clone();
            this.临时缓存.TableName = info.reportName;
            this.time = time;
            GatherItem item = null;
            row = new GatherRow();
            int count = this.tb.Columns.Count;
            GatherField field = null;
            for (int i = 0; i < count; i++)
            {
                field = info.GetFiled(this.tb.Columns[i].ColumnName);
                if (field == null) { continue; }
                if (field._SourceType != 数据来源类型.未知)
                    item = new GatherItem(field, IItem.GetComputerItem(field.DataNo));
                else
                    item = new GatherItem(field, IItem.GetIValue(field.DataNo));
                this.row.AddItem(item);
            }
            storeType = DataStoreType.SynDB; // 默认采集模式是同步进行
        }

        public void 采集模式(DataStoreType storeType)
        {
            this.storeType = storeType;
            if (storeType == DataStoreType.LastDB)
            {
                actionData = AddArr;
            }
            else
            {
                actionData = AddArrToDB;
            }
        }

        public void 修改时间间隔(int 时间间隔)
        {
            this.time.间隔时间 = 时间间隔;
        }

        public void time_采集开始()
        {
            this.临时缓存.Clear();
        }

        public void time_采集事件()
        {
            
            if (_action.isAction())
            {
                _action.Action(this.actionData);
            }
        }

        public void time_采集完成()
        {
            if (storeType ==  DataStoreType.LastDB)
            {
                actionData = 数据拷贝;
                if (_action.isAction())
                {
                    _action.Action(this.actionData);
                    actionData = AddArr;
                }
            }
            else
            {
                this._GatherComplete.采集完毕处理();
            }
            
        }

        public void 数据拷贝()
        {
            this.实时采集完成处理();
            int len = this.临时缓存.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                this.Cache.ImportRow(this.临时缓存.Rows[i]);
            }
            this._GatherComplete.采集完毕处理();
        }

        public void AddArr()
        {
            object[] d = this.row.GetFloats();
            this.临时缓存.Rows.Add(d);
        }

        public void AddArrToDB()
        {
            DataRow row = null;
            object[] d = this.row.GetFloats();
            row = this.tb.Rows.Add(d);
            string sql = this._info.GetSql(d, _db);
            _db.InsertSql(sql);
            if (this._GahterRowEvent != null)
            {
                this._GahterRowEvent.RowEvent(row);
            }
        }

        public void UpdateToDB(string reportName) // 更新表到数据库
        {
            int count = this.Cache.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Cache.Rows[i].RowState == DataRowState.Added)
                {
                    this.Cache.Rows[i].AcceptChanges();
                    this.Cache.Rows[i].SetModified();
                }
            }
            this._db.SaveDB(this.Cache, reportName);
        }

        public void 实时采集完成处理()
        {
            this._db.SaveDB(this.临时缓存, this.临时缓存.TableName);
        }

        public void RemoveRecord(decimal id,string reportName)
        {
            DataRow row = null;
            DataRow[] rows = this.tb.Select("id=" + id);
            if (rows.Length > 0)
            {
                row = rows[0];
                this.Cache.Rows.Remove(row);
                this._db.DeleteRecord(id, reportName);
            }
        }

        public void 计算列准备(string filedName, 控件库.表格控件.Grid _Grid, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edit)
        {
            int len = this.row.List.Count;
            for (int i = 0; i < len; i++)
            {
                if (this.row.List[i].field.FieldName == filedName)
                {
                    this.row.List[i].计算列准备(_Grid, edit);
                }
            }
        }

        public void 加载计算列(string filedName, ITableComputer computer)
        {
            int len = this.row.List.Count;
            for (int i = 0; i < len; i++)
            {
                if (this.row.List[i].field.FieldName == filedName)
                {
                    this.row.List[i].加载计算列(computer);
                }
            }
        }

        public GatherTimer GetGatherTimer()
        {
            return this.time;
        }
    }
}
