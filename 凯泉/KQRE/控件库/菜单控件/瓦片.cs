using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using 辅助库;

namespace 控件库.菜单控件
{
    public partial class 瓦片 : UserControl
    {
        #region 公有变量
        private Bitmap _瓦片图片;

        public Bitmap 瓦片图片
        {
            get { return _瓦片图片; }
            set { _瓦片图片 = value; }
        }

        private int radius;

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        private Color _边线颜色;

        public Color 边线颜色
        {
            get { return _边线颜色; }
            set { _边线颜色 = value; }
        }

        private Color _瓦片上部颜色;

        public Color 瓦片上部颜色
        {
            get { return _瓦片上部颜色; }
            set { _瓦片上部颜色 = value; }
        }

        private Color _瓦片下部颜色;

        public Color 瓦片下部颜色
        {
            get { return _瓦片下部颜色; }
            set { _瓦片下部颜色 = value; }
        }

        private Color _标题颜色;

        public Color 标题颜色
        {
            get { return _标题颜色; }
            set { _标题颜色 = value; }
        }

        private Font _标题字体;

        public Font 标题字体
        {
            get { return _标题字体; }
            set { _标题字体 = value; }
        }

        private string _标题内容;

        public string 标题内容
        {
            get { return _标题内容; }
            set { _标题内容 = value; }
        }

        private int _标题X坐标;

        public int 标题X坐标
        {
            get { return _标题X坐标; }
            set { _标题X坐标 = value; }
        }

        private int _标题Y坐标;

        public int 标题Y坐标
        {
            get { return _标题Y坐标; }
            set { _标题Y坐标 = value; }
        }
        #endregion

        #region 公有事件

        #endregion
        public 瓦片()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //if (this.DesignMode == true) return;
            base.OnPaint(e);
            paintThisShit(e.Graphics);
        }

        private void paintThisShit(Graphics _graphics)
        {
            // 渐变背景画刷
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.pictureBox1.Height),
               _瓦片上部颜色, _瓦片下部颜色))
            // 边线笔
            using (Pen _边线色笔 = new Pen(_边线颜色))
            {
                // 绘制圆角
                绘图类.DrawRoundRect(_graphics, _边线色笔,brush, 0, 0, this.pictureBox1.Width - 1, this.pictureBox1.Height - 1, radius);
            }

            // 重绘贴图
            _graphics.DrawImage(_瓦片图片, new Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height));

            // 渐变背景画刷
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.pictureBox1.Height),
              _标题颜色, _标题颜色))
            // 钢笔写字
            using (Pen pe = new Pen(brush, 1f))
            {
                pe.Color = _标题颜色;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                _graphics.DrawString(_标题内容, _标题字体, brush, this.pictureBox1.Width - _标题X坐标, this.pictureBox1.Height - _标题Y坐标);
            }
        }
    }
}
