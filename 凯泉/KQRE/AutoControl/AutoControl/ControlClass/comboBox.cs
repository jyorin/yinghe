using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoControl
{
    internal class comboBox : ControlElement
    {
        comboBoxUC box = null;
        public comboBox(FieldElement field) : base(field)
        {
        }
        protected override void CreateTheControl()
        {
            box = new comboBoxUC();
        }

        public  override void BindTheControl(BindData _data)
        {
            comBoxBD _comBoxBD = (comBoxBD)_data;
            this.box.BindTheControl(_comBoxBD.comboxList, _comBoxBD.Value);
        }

        public  override string GetValue()
        {
            return box.GetValue();
        }

        public override void SetValue(string value)
        {
            this.box.SetValue(value);
        }

        public override object GetObject()
        {
            return this.box;
        }

        protected override System.Windows.Forms.UserControl GetUserControl()
        {
            return box;
        }

        public override void AddControlByLayout(System.Windows.Forms.Panel _panel)
        {
            _panel.Controls.Add(this.box);
        }

        public  override void ClearRecord()
        {
            this.box.ClearRecord();
        }
    }

}
