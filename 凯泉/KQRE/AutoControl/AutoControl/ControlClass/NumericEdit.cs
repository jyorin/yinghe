using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoControl
{
    internal class NumericEdit : ControlElement
    {
        NumericEditUC text = null;
        public NumericEdit(FieldElement field): base(field)
        {
        }
        public  override void BindTheControl(BindData _data)
        {
            this.text.BindTheControl(_data.Value);
        }

        public override string GetValue()
        {
            return text.GetValue();
        }

        public override void SetValue(string value)
        {
            this.text.SetValue(value);
        }

        public override object GetObject()
        {
            return this.text;
        }

        protected override void CreateTheControl()
        {
            text = new NumericEditUC();
        }

        protected override System.Windows.Forms.UserControl GetUserControl()
        {
            return text;
        }

        public override void AddControlByLayout(System.Windows.Forms.Panel _panel)
        {
            _panel.Controls.Add(this.text);
        }

        public  override void ClearRecord()
        {
            this.text.ClearRecord();
        }
    }
}
