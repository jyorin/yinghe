using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using 辅助库;
using 控件库;
using 控件库.菜单控件;
using Main.管理界面;
using System.Reflection;
using AnyWay数据源管理;
using PLC数据源管理;
using 数据存储;
using 全局缓存;
using LogicApp.试验组模块;
using Gather;
using Computer;

namespace Main
{
    public partial class MainFrame : DevExpress.XtraEditors.XtraForm
    {
        IComputerItem _电压 = null;
        IComputerItem _电流 = null;
        IComputerItem _输入功率 = null;
        System.Threading.Thread thead_触屏 = null;

        bool _现场图是否打开 = true;
        string _收放横条标题 = "点 击 收 起";
        PLC数据集 PLC = null;
        public MainFrame()
        {
            InitializeComponent();
            电参数地址集合 _电参数地址集合 = new 电参数地址集合();
            AnyWay类构造.获取AnyWay数据集();
            PLC = PLC类构造.获取PLC数据集();
            装载计算列.To装载计算列();
            装载值列.To装载值列();
            PLC.加载触屏数据();
            加载触屏数据();
            数据服务类.获取数据服务对象();
            foreach (var item in barManager1.Items)
            { 
                if(item.GetType().ToString().Equals("DevExpress.XtraBars.BarButtonItem"))
                    ((DevExpress.XtraBars.BarButtonItem)item).ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(MainFrame_ItemClick);
            }
            this.axShockwaveFlash1.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\附件\\running.swf"; //指定FLASH路径
            数显仪表集合1.BorderStyle = BorderStyle.None; //仪表控件会自动显示成3D边框,原因未知,此处强隐。

            thead_触屏 = new System.Threading.Thread(this.触屏_Run);
            thead_触屏.IsBackground = true;
            thead_触屏.Start();
        }

        public void 触屏_Run()
        {
            while (true)
            {
                this.PLC.写载触屏数据(this._电压.数据值, this._电流.数据值, this._输入功率.数据值);
                System.Threading.Thread.Sleep(500);
            }
        }

        public void 加载触屏数据()
        {
            _电压 = 数据项哈希存储.GetComputerItem("电压");
            _电流 = 数据项哈希存储.GetComputerItem("电流");
            _输入功率 = 数据项哈希存储.GetComputerItem("输入功率");
        }

        #region 置顶菜单控制
        void MainFrame_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string className = "Main.管理界面." + e.Item.Caption;

            if (!f_检测TAB页是否重复打开(e.Item.Caption))
                return;

            string dllpath = AppDomain.CurrentDomain.BaseDirectory + "Main.exe";
            Assembly mya = Assembly.LoadFile(dllpath);
            Type myp = mya.GetType(className);

            XtraForm form = (XtraForm)mya.CreateInstance(className, true, System.Reflection.BindingFlags.CreateInstance, null, null, null, null) as XtraForm;
            //if (className == "Main.管理界面.振动试验")
            //{
            //    form.Size = new System.Drawing.Size(870,565);
            //    OpenDialog(form); return;
            //}
            //else if (className == "Main.管理界面.噪声试验")
            //{
            //    form.Size = new System.Drawing.Size(960,695);
            //    OpenDialog(form); return;
            //}
            form.Text = e.Item.Caption;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.CloseBox = false;
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this;
            form.Show();
        }

        public void OpenDialog(XtraForm form)
        {
            form.ShowDialog();
        }
        private bool f_检测TAB页是否重复打开(string Name)
        {
            foreach (Form item in MdiChildren)
            {
                if (item.Text == Name)
                {
                    Cursor = Cursors.Default;
                    return false;
                }
                item.Close();
            }
            return true;
        }
        #endregion

        #region 收放横条情况控制
        private void pictureBox_收起展开系统图_Click(object sender, EventArgs e)
        {
            _现场图是否打开 = !_现场图是否打开;
            this.panelControl1.Height = _现场图是否打开?265:66;
            if (_现场图是否打开)
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _收放横条标题 = _现场图是否打开 ? "点 击 收 起" : "点 击 展 开";
        }

        private void pictureBox_收起展开系统图_Paint(object sender, PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;
            f_收放横条情况控制(_graphics, Color.Gainsboro, Color.White, Color.Gray, Color.DarkGray, _收放横条标题);
        }

        private void pictureBox_收起展开系统图_MouseEnter(object sender, EventArgs e)
        {
            Graphics _graphics = pictureBox_收起展开系统图.CreateGraphics();
            f_收放横条情况控制(_graphics, Color.Gainsboro, Color.White, Color.Gray, Color.DarkRed, _收放横条标题);
        }

        private void pictureBox_收起展开系统图_MouseLeave(object sender, EventArgs e)
        {
            Graphics _graphics = pictureBox_收起展开系统图.CreateGraphics();
            f_收放横条情况控制(_graphics, Color.Gainsboro, Color.White, Color.Gray, Color.DarkGray, _收放横条标题);
        }

        /// <summary>
        /// 收放横条情况控制
        /// </summary>
        /// <param name="_graphics">控件显示内存</param>
        /// <param name="colorB">上部渐变色</param>
        /// <param name="colorE">下部渐变色</param>
        /// <param name="borderColor">边框色</param>
        /// <param name="TextColor">字体色</param>
        /// <param name="_收放横条标题">标题内容</param>
        private void f_收放横条情况控制(Graphics _graphics, Color colorB, Color colorE,Color borderColor, Color TextColor, string _收放横条标题)
        {
            // 渐变背景画刷
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.pictureBox_收起展开系统图.Height),
              colorB, colorE))
            // 边线笔
            using (Pen _边线色笔 = new Pen(borderColor))
            {
                // 绘制圆角
                绘图类.DrawRoundRect(_graphics, _边线色笔, brush, 0, 0, this.pictureBox_收起展开系统图.Width, this.pictureBox_收起展开系统图.Height, 1);
            }

            // 渐变背景画刷
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.pictureBox_收起展开系统图.Height),
              TextColor, TextColor))
            using (Font FOE = new Font("微软雅黑", 9))
            // 钢笔写字
            using (Pen pe = new Pen(brush, 1f))
            {
                pe.Color = TextColor;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                _graphics.DrawString(_收放横条标题, FOE, brush, new PointF(this.pictureBox_收起展开系统图.Width / 2 - 15, 0));
            }
        }
        #endregion

        private void MainFrame_Load(object sender, EventArgs e)
        {
            this.数显仪表集合1.f_初始化所有仪表("试验数显配置\\主界面数显区配置.xml");
        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.数显仪表集合1.f_注销所有仪表();
            this.PLC.销毁PLC();
        }

        private void barButtonItem_汽蚀试验_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


    }
}