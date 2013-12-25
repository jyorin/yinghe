using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace 辅助库
{
    public class 曲线拟合
    {
        #region 近似曲线拟合：此方法可使得曲线尽可能的通过所有的点，但不适合求取方程
        //public void f_曲线拟合(List<double> x, List<double> y, out List<double> _x, out List<double> _y)
        //{
        //    PointF[] temp = null;
        //    int count = x.Count;
        //    temp = new PointF[count];
        //    for (int i = 0; i < count; i++)
        //    {
        //        temp[i] = new PointF((float)x[i], (float)y[i]);
        //    }
        //    ArrayList arr = new ArrayList();
        //    Splined(temp, ref arr);
        //    count = arr.Count;
        //    List<double> x1 = new List<double>();
        //    List<double> y1 = new List<double>();
        //    PointF p;
        //    for (int i = 0; i < count; i++)
        //    {
        //        p = (PointF)arr[i];
        //        x1.Add(p.X);
        //        y1.Add(p.Y);
        //    }
        //    _x = x1;
        //    _y = y1;
        //}

        //private void Splined(PointF[] temp, ref ArrayList splinedPt)
        //{
        //    double x, y, t;
        //    double px, py;
        //    int q = 3;
        //    int phi;
        //    int kaw;
        //    int naw;
        //    int n = temp.Length;
        //    int add;
        //    phi = 5;
        //    naw = n;
        //    add = 5 * (naw + q - 1) + 1;
        //    for (t = -phi + 1.0; t < naw + phi; t = t + 0.2)
        //    {
        //        x = 0.0;
        //        y = 0.0;
        //        for (kaw = -2 * phi + 1; kaw < naw + 2 * phi; kaw++)
        //        {
        //            px = 0;
        //            py = 0;
        //            if (kaw < 1)
        //            {
        //                px = temp[0].X;
        //                py = temp[0].Y;
        //            }
        //            if (kaw > naw)
        //            {
        //                px = temp[naw - 1].X;
        //                py = temp[naw - 1].Y;
        //            }
        //            if (kaw > 0 && kaw <= naw)
        //            {
        //                px = temp[kaw - 1].X;
        //                py = temp[kaw - 1].Y;
        //            }
        //            x = x + nqt(q, t - kaw) * px;
        //            y = y + nqt(q, t - kaw) * py;
        //        }
        //        PointF point = new PointF((float)x, (float)y);
        //        splinedPt.Add(point);
        //    }

        //}

        //private  double nqt(double qq,double tt)
        //{
        //    double re, rel, re2, re3;
        //    re = 0;
        //    if (qq == 1)
        //    {
        //        re = 0.0;
        //        if (tt > -1.0 && tt <= 0.0)
        //            re = tt + 1.0;
        //        if (tt > 0.0 && tt < 1.0)
        //            re = -tt + 1.0;
        //    }
        //    else
        //    {
        //        re = 0.0;
        //        if (tt > -(qq + 1.0) / 2.0 && tt < (qq + 1.0) / 2.0)
        //        {
        //            rel = 1.0 / qq;
        //            re2 = (tt + (qq + 1.0) / 2.0) * nqt(qq - 1, tt + 0.5);
        //            re3 = ((qq + 1.0) / 2.0 - tt) * nqt(qq - 1, tt - 0.5);
        //            re = rel * (re2 + re3);
        //        }
        //    }
        //    return re;
        //}
        #endregion
    }
}
