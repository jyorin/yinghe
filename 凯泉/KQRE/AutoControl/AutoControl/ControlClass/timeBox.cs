using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoControl
{
    internal class timeBox : ControlElement
    {
        timeBoxUC text = null;
        public timeBox(FieldElement field)
            : base(field)
        {
        }
        protected override void CreateTheControl()
        {
            text = new timeBoxUC();
        }

        public override void BindTheControl(BindData _data)
        {
            this.text.BindTheControl(_data.Value);
        }

        public override void ClearRecord()
        {
            this.text.ClearRecord();
        }

        public override string GetValue()
        {
            return this.text.GetValue();
        }

        public override object GetObject()
        {
            return this.text;
        }

        public override void SetValue(string value)
        {
            this.text.SetValue(value);
        }


        protected override System.Windows.Forms.UserControl GetUserControl()
        {
            return text;
        }

        public override void AddControlByLayout(System.Windows.Forms.Panel _panel)
        {
            _panel.Controls.Add(this.text);
        }
    }
}
