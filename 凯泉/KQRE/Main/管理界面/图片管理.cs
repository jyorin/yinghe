using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Main.管理界面
{
    public class 图片管理
    {
        public static void SaveImage(控件库.曲线控件.XYGraph g, string name, int width, int height)
        {
            Graphics g1 = g.CreateGraphics();
            Bitmap MyImage = new Bitmap(800, 800);
            Graphics g2 = Graphics.FromImage(MyImage);
            IntPtr dc3 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
        
            MyImage.Save("d:\\kk.jpg");
        }
    }
}
