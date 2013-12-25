using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using NationalInstruments.UI;

namespace 控件库.曲线控件
{
    public partial class XYGraph : UserControl
    {

        #region ** 按钮 下移菜单 **
        private void buttonItemsDown_Click(object sender, EventArgs e)
        {
            //button_itemsDown.Enabled = false;                //禁用按钮
            //button_itemsDown.Parent.Focus();                 //取消焦点
            //Point po = new Point();
            //po.X = panel_itemsIN.Location.X;
            //po.Y = panel_itemsIN.Location.Y;
            //po.Y += 33;
            //panel_itemsIN.Location = po;
            //button_itemsDown.Enabled = true;                 //启用按钮
        }
        #endregion

        #region ** 按钮 上移菜单 **
        private void buttonControlItemUP_Click(object sender, EventArgs e)
        {
            //button_itemsUp.Enabled = false;            //禁用按钮
            //button_itemsUp.Parent.Focus();             //取消焦点
            //Point po = new Point();
            //po.X = panel_itemsIN.Location.X;
            //po.Y = panel_itemsIN.Location.Y;
            //po.Y -= 33;
            //panel_itemsIN.Location = po;
            //button_itemsUp.Enabled = true;             //启用按钮
        }
        #endregion

        #region **按钮 显示网格按钮**
        // 按钮 显示网格按钮 单击
        public void buttonLinesShowXY_Click(object sender, EventArgs e)
        {
            buttonLinesShowXY.Parent.Focus();               //取消焦点
            if (_isLinesShowXY)                             //标记是否可显示网络
            {
                _isLinesShowXY = false;                     //标记
                网格显示ToolStripMenuItem.Checked = false;
            }
            else
            {
                _isLinesShowXY = true;                      //标记
                网格显示ToolStripMenuItem.Checked = true;
            }
            setGraphStyle(Graph_View);                      //刷新界面
            panel_itemsIN.Refresh();                         //刷新按钮显示
        }
        // 显示网格按钮 鼠标经过
        private void buttonLinesShowXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panel_itemsIN.Location.X - 115;
            po.Y = panel_itemsIN.Location.Y + buttonLinesShowXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "网格显示";            //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
            labelItemShuoMing.BringToFront();
            
        }
        // 显示网络按钮 鼠标离开
        private void buttonLinesShowXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
         // 显示网络按钮 绘图
        private void buttonLinesShowXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();
            if (!_isLinesShowXY)
            {
                buttonLinesShowXY.ForeColor = ControlButtonForeColorH;    //未选中时边框颜色
                colorD = ControlButtonForeColorH;
            }
            else
            {
                buttonLinesShowXY.ForeColor = ControlButtonForeColorL;    //选中时边框颜色
                colorD = ControlButtonForeColorL;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 30),
                Color.FromArgb(100, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                pe.Brush = brush;
                pe.StartCap = LineCap.Flat;
                pe.EndCap = LineCap.Flat;
                for (int i = 11; i < 26; i += 5)
                {
                    Grap.DrawLine(pe, 6, i, 25, i);         //水平线
                    Grap.DrawLine(pe, i, 6, i, 26);         //垂直线
                }
            }

        }
        #endregion

        #region ** 放大选取按钮 **
        // 放大选取按钮 单击
        public void buttonBigModeXY_Click(object sender, EventArgs e)
        {
         
            buttonBigModeXY.Parent.Focus();                 //取消焦点
            if (_isShowBigSmallModeXY)                      //标记是否可显示放大按钮
            {
                _isShowBigSmallModeXY = false;              //标记
                放大选取框功能ToolStripMenuItem.Checked = false;
                Graph_View.Cursor = Cursors.Arrow;     //箭头光标
                pictureBoxBigXY.Visible = false;            //隐藏[波形放大框]
                panelBigXY.Visible = false;                 //隐藏[波形放大操作框]
            }
            else
            {
                _isShowBigSmallModeXY = true;               //标记
                放大选取框功能ToolStripMenuItem.Checked = true;
                Graph_View.Cursor = Cursors.Cross;     //十字光标
            }
            panel_itemsIN.Refresh();                         //刷新按钮显示
        }
        // 放大选取按钮 鼠标经过
        private void buttonBigModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panel_itemsIN.Location.X - 115;
            po.Y = panel_itemsIN.Location.Y + buttonBigModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "放大选取框功能";      //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        // 放大选取按钮 鼠标离开
        private void buttonBigModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        // 放大选取按钮 绘图
        private void buttonBigModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();
            if (!_isShowBigSmallModeXY)
            {
                buttonBigModeXY.ForeColor = ControlButtonForeColorH;    //未选中时边框颜色
                colorD = ControlButtonForeColorH;
            }
            else
            {
                buttonBigModeXY.ForeColor = ControlButtonForeColorL;    //选中时边框颜色
                colorD = ControlButtonForeColorL;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 30),
                Color.FromArgb(100, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画矩形框
                pe.Brush = brush;
                pe.StartCap = LineCap.Flat;
                pe.EndCap = LineCap.Flat;
                pe.DashStyle = DashStyle.Dot;
                Grap.DrawRectangle(pe, 7, 7, 18, 18);
                //画边角
                pe.DashStyle = DashStyle.Solid;
                Grap.DrawLine(pe, 7, 7, 7, 12);
                Grap.DrawLine(pe, 7, 7, 12, 7);
                Grap.DrawLine(pe, 7, 25, 12, 25);
                Grap.DrawLine(pe, 7, 25, 7, 20);
                Grap.DrawLine(pe, 25, 7, 20, 7);
                Grap.DrawLine(pe, 25, 7, 25, 12);
                Grap.DrawLine(pe, 25, 25, 20, 25);
                Grap.DrawLine(pe, 25, 25, 25, 20);
                //画放大镜
                Grap.DrawEllipse(pe, 10, 10, 11, 11);
                pe.Width = 4;
                Grap.DrawLine(pe, 19, 19, 22, 22);

            }
        }
        #endregion

        #region **按钮 计算差值按钮**

        void xyCursorE_AfterMove(object sender, NationalInstruments.UI.AfterMoveXYCursorEventArgs e)
        {
            if (游标E移动后触发委托 != null)
                游标E移动后触发委托(sender, e);
        }

        void xyCursorB_AfterMove(object sender, NationalInstruments.UI.AfterMoveXYCursorEventArgs e)
        {
            if (游标B移动后触发委托 != null)
                游标B移动后触发委托(sender,e);
        }

        // 按钮 显示网格按钮 单击
        public void buttonModeXY_Click(object sender, EventArgs e)
        {
          
            buttonModeXY.Parent.Focus();               //取消焦点
            if (_isShowModeXY)                             //标记是否可显示网络
            {
                _isShowModeXY = false;                     //标记
                xyCursorB.Visible = false;
                xyCursorE.Visible = false;
            }
            else
            {
                _isShowModeXY = true;                      //标记
                xyCursorB.Plot = Graph_View.Plots[0];
                xyCursorE.Plot = Graph_View.Plots[0];

                xyCursorB.Visible = true; xyCursorB.LabelVisible = true; 
                xyCursorB.XPosition = (xAxis_Looking.Range.Maximum - xAxis_Looking.Range.Minimum) / 2 + xAxis_Looking.Range.Minimum;
                xyCursorE.Visible = true; xyCursorE.LabelVisible = true; 
                xyCursorE.XPosition = (xAxis_Looking.Range.Maximum - xAxis_Looking.Range.Minimum) / 2 + xAxis_Looking.Range.Minimum;
            }

            panel_itemsIN.Refresh();                         //刷新按钮显示
       
        }
        // 显示网格按钮 鼠标经过
        private void buttonModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panel_itemsIN.Location.X - 115;
            po.Y = panel_itemsIN.Location.Y + buttonModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "计算差值";            //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        // 显示网络按钮 鼠标离开
        private void buttonModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        // 显示网络按钮 绘图
        private void buttonModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();
            if (!_isShowModeXY)
            {
                buttonModeXY.ForeColor = ControlButtonForeColorH;       //未选中边框颜色
                colorD = ControlButtonForeColorH;
            }
            else
            {
                buttonModeXY.ForeColor = ControlButtonForeColorL;    //选中时边框颜色
                colorD = ControlButtonForeColorL;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                colorD, colorD))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            using (Font foR = new Font("宋体", 7))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画文字
                Grap.DrawString("Calc", foR, brush, 6, 14);
                Grap.DrawString("y", fo, brush, 7, 3);
                Grap.DrawString("x", fo, brush, 20, 6);

            }
        }
        #endregion

        #region ** 默认坐标范围 **
        // 恢复默认坐标范围
        public void buttonReXY_Click(object sender, EventArgs e)
        {
       
            buttonReXY.Parent.Focus();                      //取消焦点
            _isAutoModeXY = false;                          //标记，取消自动调整大小模式
            pictureBoxBigXY.Visible = false;                //隐藏[波形放大框]
            panelBigXY.Visible = false;                     //隐藏[波形放大操作框]
            buttonBigXYBig.Enabled = true;                  //状态，允许放大按钮操作，之前的放大操作到达极限时会禁用掉放大操作按钮
            坐标自动调整ToolStripMenuItem.Checked = false;
            //初始化坐标值和坐标标定值
            xAxis_Looking.Range = _defaultXRang;
           
            panel_itemsIN.Refresh();                         //刷新按钮显示
       
        }
        // 恢复默认坐标范围 鼠标经过
        private void buttonReXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panel_itemsIN.Location.X - 115;
            po.Y = panel_itemsIN.Location.Y + buttonReXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "默认坐标范围";        //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        // 恢复默认坐标范围 鼠标离开
        private void buttonReXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        // 恢复默认坐标范围 绘图
        private void buttonReXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            buttonReXY.ForeColor = ControlButtonForeColorH;       //未选中边框颜色
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                ControlButtonForeColorH, ControlButtonForeColorH))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            using (Font foR = new Font("宋体", 9))
            {
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画文字
                Grap.DrawString("Re", foR, brush, 6, 14);
                Grap.DrawString("y", fo, brush, 7, 3);
                Grap.DrawString("x", fo, brush, 20, 6);

            }
        }
        #endregion

        #region ** 按钮 切换Y轴 **
        int Y轴索引 = 0;
        private void BTN_切换Y轴_Click(object sender, EventArgs e)
        {
            Y轴索引++;
            if (Y轴索引 == Graph_View.YAxes.Count)
            {
                Y轴索引 = 0;
                Graph_View.YAxes[Y轴索引].Visible = true;
                Graph_View.YAxes[Graph_View.YAxes.Count-1].Visible = false;
            }
            else
            {
                Graph_View.YAxes[Y轴索引 - 1].Visible = false;
                Graph_View.YAxes[Y轴索引].Visible = true;
            }

            // 当有网格线时的处理
            //if (!_isLinesShowXY) return;
            setGraphStyle(Graph_View);
        }
        // 放大选取按钮 鼠标经过
        private void BTN_切换Y轴_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panel_itemsIN.Location.X - 115;
            po.Y = panel_itemsIN.Location.Y + BTN_切换Y轴.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "切换Y轴显示";      //更新标签说明文字
            labelItemShuoMing.Visible = true;
            labelItemShuoMing.BringToFront();//显示标签说明
        }
        // 放大选取按钮 鼠标离开
        private void BTN_切换Y轴_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
       
        #endregion

        #region ** 按钮 停止显示曲线活动 **
        enum 显示状态
        { 
            正在显示,
            停止显示
        }
        private 显示状态 _当前显示状态 = 显示状态.正在显示;
        // 放大选取按钮 单击
        public void BTN_停止显示_Click(object sender, EventArgs e)
        {
            BTN_停止显示.Parent.Focus();                 //取消焦点

            switch (_当前显示状态)
            { 
                case 显示状态.正在显示:
                    _当前显示状态 = 显示状态.停止显示;
                    是否启用放大查看按钮 = true;
                    是否启用恢复默认网格按钮 = true;
                    是否启用计算差值按钮 = true;
                    foreach (曲线信息 item in List_曲线信息)
                    {
                        if (item.数据项 == null) return;
                        item.数据项.TheWChannelManager.暂停绘制波形();
                    }
                    BTN_停止显示.Image = global::控件库.Properties.Resources.Action_Exit_32x32;
                    _defaultXRang = xAxis_Looking.Range;
                   

                    break;
                case 显示状态.停止显示:
                    _当前显示状态 = 显示状态.正在显示;
                     是否启用放大查看按钮 = false;
                     是否启用恢复默认网格按钮 = false;
                     是否启用计算差值按钮 = false;
                     foreach (曲线信息 item in List_曲线信息)
                     {
                         if (item.数据项 == null) return;
                         item.数据项.TheWChannelManager.恢复绘制波形();
                     }
                     BTN_停止显示.Image = global::控件库.Properties.Resources.active;
                     xAxis_Looking.Range = _defaultXRang;
                     if (_isShowBigSmallModeXY) buttonBigModeXY_Click(null, null);
                    break;
            }

            
        }
        // 放大选取按钮 鼠标经过
        private void BTN_停止显示_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panel_itemsIN.Location.X - 115;
            po.Y = panel_itemsIN.Location.Y + BTN_停止显示.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "暂停绘制曲线";      //更新标签说明文字
            labelItemShuoMing.Visible = true;
            labelItemShuoMing.BringToFront();//显示标签说明
        }
        // 放大选取按钮 鼠标离开
        private void BTN_停止显示_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
       
        #endregion

        #region ** 按钮 停止显示曲线活动 **
        private void btn_调整坐标轴_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }

        private void btn_调整坐标轴_Click(object sender, EventArgs e)
        {
            调整坐标轴 长度设置窗口 = new 调整坐标轴(this);
            长度设置窗口.ShowDialog();
        }

        private void btn_调整坐标轴_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panel_itemsIN.Location.X - 115;
            po.Y = panel_itemsIN.Location.Y + btn_调整坐标轴.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "调整坐标轴";        //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        #endregion

        #region 拖动曲线
        private void slide_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (拖动曲线触发委托 != null)
                拖动曲线触发委托(sender,e);
        }
        #endregion

        #region **私有方法** 波形显示控件鼠标事件 [波形放大]**

        private Point _pictureBoxBigXY_L;   //存放[波形放大方框]的起点坐标
        private Point _pictureBoxBigXY_R;   //存放鼠标移动时的坐标
        private Point _pictureBoxBigXY_M;   //存放最后调整后[波形放大框]的位置坐标
        private double _labelXYNumX;         //存放坐标显示Label的X值
        private double _labelXYNumY;         //存放坐标显示Label的Y值
        private NationalInstruments.UI.Range _currentXRang;
        private NationalInstruments.UI.Range _currentYRang;
       

        //波形显示控件 鼠标按下
        private void Graph_View_MouseDown(object sender, MouseEventArgs e)
        {
            //[波形放大]操作：如果当前可以显示[波形放大框]并且鼠标左键按下
            if (_isShowBigSmallModeXY && e.Button == MouseButtons.Left)
            {
                Graph_View.Cursor = Cursors.Cross;         //十字光标
                pictureBoxBigXY.Visible = false;                //隐藏[波形放大框]
                panelBigXY.Visible = false;                     //隐藏[隐藏波形放大操作框]
                pictureBoxBigXY.Parent = Graph_View;       //父容器[波形放大框]
                panelBigXY.Parent = pictureBoxBigXY;            //父容器[波形放大操作框]
                _pictureBoxBigXY_L.X = e.Location.X;
                _pictureBoxBigXY_L.Y = e.Location.Y;
                pictureBoxBigXY.Location = _pictureBoxBigXY_L;  //更新[波形放大框]位置坐标
            }

            //显示当前坐标
            if (e.Button == MouseButtons.Right)
            {
                _changeXYPointsToNum(Graph_View,e.Location.X, e.Location.Y, ref _labelXYNumX, ref _labelXYNumY);
                toolStripTextBoxX.Text = string.Format(" X：{0}", Math.Round(_labelXYNumX, _iAccuracy + 2));
                toolStripTextBoxY.Text = string.Format(" Y：{0}", Math.Round(_labelXYNumY, _iAccuracy + 2));
            }
        }

        //波形显示控件 鼠标移动
        private void Graph_View_MouseMove(object sender, MouseEventArgs e)
        {
            //[波形放大]操作
            //如果当前可以显示[波形放大框]并且鼠标左键按下
            if (_isShowBigSmallModeXY && e.Button == MouseButtons.Left)
            {
                //获取鼠标当前坐标并调整[波形放大框]的位置坐标和大小，超出显示范围则取边界坐标
                if (e.Location.X > Graph_View.Width - 12)
                { _pictureBoxBigXY_R.X = Graph_View.Width - 12; }
                else if (e.Location.X < 35)
                { _pictureBoxBigXY_R.X = 35; }
                else
                { _pictureBoxBigXY_R.X = e.Location.X; }

                if (e.Location.Y > Graph_View.Height - 25)
                { _pictureBoxBigXY_R.Y = Graph_View.Height - 25; }
                else if (e.Location.Y < 12)
                { _pictureBoxBigXY_R.Y = 12; }
                else
                { _pictureBoxBigXY_R.Y = e.Location.Y; }
                //坐标调整，获取[波形放大框]的位置坐标
                _pictureBoxBigXY_M.X = (_pictureBoxBigXY_L.X < _pictureBoxBigXY_R.X) ? _pictureBoxBigXY_L.X : _pictureBoxBigXY_R.X;
                _pictureBoxBigXY_M.Y = (_pictureBoxBigXY_L.Y < _pictureBoxBigXY_R.Y) ? _pictureBoxBigXY_L.Y : _pictureBoxBigXY_R.Y;
                pictureBoxBigXY.Location = _pictureBoxBigXY_M;
                //[波形放大框]大小调整
                pictureBoxBigXY.Width = Math.Abs(_pictureBoxBigXY_R.X - _pictureBoxBigXY_L.X);
                pictureBoxBigXY.Height = Math.Abs(_pictureBoxBigXY_R.Y - _pictureBoxBigXY_L.Y);
                //显示[波形放大框]
                pictureBoxBigXY.Visible = true;
            }
        }

        //波形显示控件 鼠标抬起
        private void Graph_View_MouseUp(object sender, MouseEventArgs e)
        {
            //[波形放大]操作
            //如果当前可以显示[波形放大框]并且鼠标左键曾按下，并且[波形放大框]足够大
            if (_isShowBigSmallModeXY && e.Button == MouseButtons.Left && pictureBoxBigXY.Width > 82 && pictureBoxBigXY.Height > 25)
            {
                //[波形放大操作框]坐标调整
                panelBigXY.Location = new Point(0, 0);
                //[波形放大操作框]大小调整
                panelBigXY.Width = pictureBoxBigXY.Width - 2;
                panelBigXY.Height = pictureBoxBigXY.Height - 2;
                //显示[波形放大操作框]
                panelBigXY.Visible = true;
            }
        }

        //波形显示控件 鼠标离开
        private void Graph_View_MouseLeave(object sender, EventArgs e)
        {
        }

        //波形放大操作框 放大按钮
        private void buttonBigXYBig_Click(object sender, EventArgs e)
        {
            double _XB = 0; // X起点百分比
            double _XE = 0; // X终点百分比

            double _YB = 0; // Y起点百分比
            double _YE = 0; // Y终点百分比

            buttonBigXYBig.Enabled = false;                     //禁用按钮
            buttonBigXYBig.Parent.Focus();                      //取消焦点
            pictureBoxBigXY.Visible = false;                    //隐藏[波形放大框]
            panelBigXY.Visible = false;                         //隐藏[波形放大操作框]
            _isBigModeXY = true;                                //标记，启用放大查看模式
            _isAutoModeXY = false;                              //标记，取消自动调整大小模式

            坐标自动调整ToolStripMenuItem.Checked = false;

            _changeXYPointsToNum(Graph_View, pictureBoxBigXY.Location.X, pictureBoxBigXY.Location.X + pictureBoxBigXY.Width,
                pictureBoxBigXY.Location.Y, pictureBoxBigXY.Location.Y + pictureBoxBigXY.Height,
                ref _XB, ref _XE, ref _YB, ref _YE);

            if (_currentXRang == null)
            {
                xAxis_Looking.Range = new NationalInstruments.UI.Range(_XB,_XE);
                _currentXRang = xAxis_Looking.Range;
            }
            else
            {
                if (_XB != _XE)
                _currentXRang =  xAxis_Looking.Range = new NationalInstruments.UI.Range(_XB, _XE);
            }

            //if (_currentYRang == null)
            //{
            //    yAxis_Looking.Range = new NationalInstruments.UI.Range(Math.Round(_YE * _defaultXRang.Maximum, MidpointRounding.AwayFromZero), Math.Round(_YB * _defaultXRang.Maximum, MidpointRounding.AwayFromZero));
            //    _currentYRang = yAxis_Looking.Range;
            //}
            //else
            //{
            //    _currentYRang = yAxis_Looking.Range = new NationalInstruments.UI.Range(Math.Round(_YE * _currentYRang.Maximum, MidpointRounding.AwayFromZero), Math.Round(_YB * _currentYRang.Maximum, MidpointRounding.AwayFromZero));
            //}

            panel_itemsIN.Refresh();                             //刷新按钮显示
            buttonBigXYBig.Enabled = true;                      //启用按钮
        }

        //波形放大操作框 取消放大按钮
        private void buttonBigXYQuit_Click(object sender, EventArgs e)
        {
            buttonBigXYQuit.Enabled = false;                    //禁用按钮
            buttonBigXYQuit.Parent.Focus();                     //取消焦点
            pictureBoxBigXY.Visible = false;                    //隐藏[波形放大框]
            panelBigXY.Visible = false;                         //隐藏[波形放大操作框]
            buttonBigXYQuit.Enabled = true;                     //启用按钮
        }

        #endregion

        #region **私有方法** 移动游标

        #endregion
    }
}
