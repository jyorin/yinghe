using System;
using System.Collections.Generic;
using System.Linq;

namespace 控件库.表格控件
{
    /// <summary>
    /// 样式类
    /// </summary>
    public class SpeicalShow
    {
        public enum e_表格行样式 { 已完成, 待完成, 作废,启用,禁用, 趋势曲线,实时波形 }
        public enum e_判断方式 { 等于, 不等于, 大于, 小于, 包含 }

        public String FieldName;
        public object Value;
        public e_判断方式 p_判断方式;
        public e_表格行样式 p_行样式;

        public SpeicalShow() { }
        public SpeicalShow(String fieldName, object value, e_判断方式 判断方式, e_表格行样式 行样式)
        {
            FieldName = fieldName;
            Value = value;
            p_判断方式 = 判断方式;
            p_行样式 = 行样式;
        }
    }
}
