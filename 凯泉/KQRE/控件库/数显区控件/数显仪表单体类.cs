using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace 控件库.数显区控件
{
    public class 数显仪表单体类
    {
        public 数显仪表单体类()
        { 
        }
        private string _数据编码;

        public string 数据编码
        {
            get { return _数据编码; }
            set { _数据编码 = value; }
        }
        private int _间距;

        public int 间距
        {
            get { return _间距; }
            set { _间距 = value; }
        }
        private int _高度;

        public int 高度
        {
            get { return _高度; }
            set { _高度 = value; }
        }
        private int _长度;

        public int 长度
        {
            get { return _长度; }
            set { _长度 = value; }
        }
        private int _标题部分高度;

        public int 标题部分高度
        {
            get { return _标题部分高度; }
            set { _标题部分高度 = value; }
        }
        private int _标题部分颜色占比;

        public int 标题部分颜色占比
        {
            get { return _标题部分颜色占比; }
            set { _标题部分颜色占比 = value; }
        }
        private string _数字字体;

        public string 数字字体
        {
            get { return _数字字体; }
            set { _数字字体 = value; }
        }
        private float _数字大小;

        public float 数字大小
        {
            get { return _数字大小; }
            set { _数字大小 = value; }
        }
        private string _标题字体;

        public string 标题字体
        {
            get { return _标题字体; }
            set { _标题字体 = value; }
        }
        private float _标题大小;

        public float 标题大小
        {
            get { return _标题大小; }
            set { _标题大小 = value; }
        }

        private string _标题内容;

        public string 标题内容
        {
            get { return _标题内容; }
            set { _标题内容 = value; }
        }

        private int _计算类型;

        public int 计算类型
        {
            get { return _计算类型; }
            set { _计算类型 = value; }
        }
    }
}
