using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Plasmoid.Extensions;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.ComponentModel;

namespace 控件库.数字仪表
{
    public class HarrProgressBar : Panel
    {
        public string 通道编码 = string.Empty;
        public float 上限;
        public float 下限;
        public delegate void 单击Handler(object HarrProgressBar);
        public event 单击Handler 单击Event;

        public int Index { get; set; }
        public bool Checked
        {
            get;
            set;
        }

        public int LeftBarSize { get; set; }
        public int StatusBarSize { get; set; }

        public int RoundedCornerAngle { get; set; }
        public Padding Padding { get; set; }
        public Font MainFont { get; set; }
        public Font StatusFont { get; set; }

        public string MainText { get; set; }
        public string StatusText { get; set; }
        public string 绑定参数编码 { get; set; }

        private Color FirstColor;
        private Color SecondColor;
        private Color StatusColor1;
        private Color StatusColor2;

        public System.Timers.Timer time = null;
        private bool m_bWanning = false;
        private double m_n警告上限 = 0;
        private double m_n警告下限 = 0;
        public void StartWanning()
        {
            m_bWanning = true;
        }

        public void 设置警告上下限(double n上限, double n下限)
        {
            m_n警告上限 = n上限;
            m_n警告下限 = n下限;

        }
        public void 警告重绘()
        {
            if (m_bWanning == false)
            {
                return;
            }
            //double d = Convert.ToDouble(this.MainText);
            //if ((d < m_n警告上限) || (d > m_n警告下限))
            //{
            //    FillDegree = 0;
            //}
            //else
            //{
                FillDegree = 100;
            //}
        }

        public double 返回值()
        {
            double d = Convert.ToDouble(this.MainText);
            return d;
        }
        public void StopWanning()
        {
            m_bWanning = false;
            FillDegree = 0;
            this.Refresh();
        }

        private Color _数值背景色;

        public Color 数值背景色
        {
            get { return _数值背景色; }
            set { _数值背景色 = value; }
        }

        private Color _边框颜色;
        public Color 边框颜色
        {
            get { return _边框颜色; }
            set { _边框颜色 = value; }
        }

        private int _FillDegree = 80;
        public int FillDegree
        {
            get { return _FillDegree; }
            set
            {
                if (value >= 75)
                {
                    FirstColor = Color.Red;
                    SecondColor = Color.DarkRed;
                }
                else if (value > 50)
                {
                    FirstColor = Color.Orange;
                    SecondColor = Color.DarkOrange;
                }
                else if (value > 25)
                {
                    FirstColor = Color.Gold;
                    SecondColor = Color.DarkGoldenrod;
                }
                else
                {
                    FirstColor = Color.Green;
                    SecondColor = Color.DarkGreen;
                }
                _FillDegree = value;
            }
        }

        //Check radius for begin drag n drop
        public bool AllowDrag { get; set; }
        private bool _isDragging = false;
        private int _DDradius = 40;
        private int _mX = 0;
        private int _mY = 0;

        public HarrProgressBar()
        {
            MainFont = new Font("Arial", 10);
            StatusFont = new Font("Arial", 10); 
            FillDegree = 50;
            RoundedCornerAngle = 6;
            Margin = new Padding(0);
            MainText = "MainText";
            AllowDrag = true;
            _数值背景色 = Color.Black;
            _边框颜色 = Color.Red;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            Checked = true;
            //this.BackColor = Color.SandyBrown;
           // Console.WriteLine("获取焦点");

            base.OnGotFocus(e);

        }

        protected override void OnLostFocus(EventArgs e)
        {
            Checked = true;
            //this.BackColor = Color.Transparent;
            base.OnLostFocus(e);
          //  Console.WriteLine("失去焦点");
        }

        protected override void OnClick(EventArgs e)
        {
           // Console.WriteLine("单击");
            this.Focus();
            base.OnClick(e);
            if (单击Event != null)
                单击Event(this);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = true;
           // Console.WriteLine("鼠标点下");
            this.Focus();
            base.OnMouseDown(e);
            _mX = e.X;
            _mY = e.Y;
            this._isDragging = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_isDragging)
            {
                // This is a check to see if the mouse is moving while pressed.
                // Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
                if (e.Button == MouseButtons.Left && _DDradius > 0 && this.AllowDrag)
                {
                    int num1 = _mX - e.X;
                    int num2 = _mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > _DDradius)
                    {
                        DoDragDrop(this, DragDropEffects.All);
                        _isDragging = true;
                        return;
                    }
                }
                base.OnMouseMove(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            //Checked = !Checked;
            _isDragging = false;
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            paintThisShit(e.Graphics);
        }
        /// <summary>
        /// 不让重画背景
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Console.WriteLine("进入重绘" + Checked);
            if (Checked)
            {
                base.OnPaintBackground(e);
                //Console.WriteLine("重绘");
                Checked = false;
            }
        }

        public void paintThisShit(Graphics _graphics)
        {
            警告重绘();
            Bitmap offBm = new Bitmap(this.Size.Width, this.Size.Height);
            Graphics offerSreen = Graphics.FromImage(offBm);//定义画画到图片上
            // Textformat
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            f.LineAlignment = StringAlignment.Center;

            // Misc
            _graphics = Graphics.FromImage(offBm);
            
            LinearGradientBrush _StatusBrush = new LinearGradientBrush(GetStatusArea(), FirstColor, SecondColor, LinearGradientMode.Horizontal);
            SolidBrush _背景色Brush = new SolidBrush(_数值背景色);
            // Draw status
            if (StatusBarSize > 0)
            {
                _graphics.FillRoundedRectangle(_StatusBrush, this.GetStatusArea(), this.RoundedCornerAngle, RectangleEdgeFilter.BottomRight | RectangleEdgeFilter.BottomLeft);
                _graphics.DrawString(this.StatusText, this.StatusFont, Brushes.White, this.GetStatusArea(), f);
            }

            // Draw main background
            _graphics.FillRoundedRectangle(_背景色Brush, GetMainAreaBackground(), this.RoundedCornerAngle, RectangleEdgeFilter.TopLeft | RectangleEdgeFilter.TopRight);
            _graphics.DrawString(this.MainText, this.MainFont, Brushes.White, this.GetMainAreaBackground(), f);


            this.CreateGraphics().DrawImage(offBm, 0, 0);//贴出来显示
            offBm.Dispose();//释放
            offerSreen.Dispose();

            // Clean up
            _StatusBrush.Dispose();
            _背景色Brush.Dispose();
        }

        private Rectangle GetStatusArea()
        {
            return new Rectangle(
                Padding.Left,
                this.ClientRectangle.Height - (StatusBarSize + Padding.Bottom ),
                this.ClientRectangle.Width - (Padding.Left + Padding.Right),
                StatusBarSize);
        }

        private Rectangle GetMainAreaBackground()
        {
            return new Rectangle(
                   Padding.Left,
                   Padding.Top,
                   this.ClientRectangle.Width - (Padding.Left + Padding.Right),
                   this.ClientRectangle.Height - (Padding.Bottom + Padding.Top + StatusBarSize));
        }

        private Rectangle Get仪表Rect()
        {
            return new Rectangle(
            Padding.Left,
            Padding.Top,
            this.ClientRectangle.Width - (Padding.Left + Padding.Right),
            Padding.Bottom + Padding.Top + StatusBarSize);
        }

        public void 显示仪表数据(float d, int t)
        {
            this.MainText = d.ToString();
            if (this.上限 != 0 || this.下限 != 0)
            {
                this.FillDegree = (int)上下限管理.上下限计算(this.上限, this.下限, d);
            }
            this.paintThisShit(null);
        }
    }
}
