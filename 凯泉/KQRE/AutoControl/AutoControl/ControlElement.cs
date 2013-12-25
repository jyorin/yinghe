using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoControl
{
    public delegate string GetControlValue();
    public abstract class ControlElement
    {
        private FieldElement field;
        public FieldElement Field
        {
            get { return this.field; }
        }
        private GetControlValue _getValue = null;
        public ControlElement(FieldElement field)
        {
            this.field = field;
            _getValue = new AutoControl.GetControlValue(this.GetValue);
            this.field.BindGetValue(_getValue);
            ToBuild();
        }
        private void ToBuild()
        {
            CreateTheControl();
            BindTheControl(this.field.GetBindData());
        }
        protected abstract void CreateTheControl();
        public  abstract void BindTheControl(BindData _data);
        public  abstract void ClearRecord();
        public abstract string GetValue();
        public abstract void SetValue(string value);
        public abstract object GetObject();
        protected abstract UserControl GetUserControl();
        public abstract void AddControlByLayout(Panel _panel);

    }
}
