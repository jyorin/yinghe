using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 辅助库
{
    public class CurveFitting
    {
        ///<summary>
        ///用最小二乘法拟合二元多次曲线
        ///例如y=ax+b
        ///其中MultiLine将返回a，b两个参数。
        ///a对应MultiLine[1]
        ///b对应MultiLine[0]
        ///</summary>
        ///<param name="x">已知点的x坐标集合</param>
        ///<param name="y">已知点的y坐标集合</param>
        ///<param name="dimension">方程的最高次数</param>
        ///<param name="n">分割成多少个点</param>
        ///<param name="DataX">计算完毕的x坐标集合</param>
        ///<param name="DataY">计算完毕的y坐标集合</param>
        public static void f_曲线拟合(double[] x, double[] y, int fitting_count,int n, out List<double> DataX, out List<double> DataY,out double[] ratio)
        {
            /****************************
            * 从数据库中查出U0、 If的对应值
            * 最小二乘法求出系数
            * 根据曲线拟合次数n得出对应的y = a x^ (n -1) + b x^(n - 2) + c x^(n - 3) + d 曲线
            * startX, step, xStep 
            * PlotXY画曲线
            *****************************/
            DataX = new List<double>();
            DataY = new List<double>();

            ratio = new double[fitting_count + 1];  //曲线系数

            //求方程系数
            PlotFit(x, y, ratio, x.Length, fitting_count);
            //方程
            int i;
            double _被分割的单份长度 = (x.Max() - x.Min()) / n;
            switch (fitting_count)
            {
                case 2:
                    //二次曲线
                    for (i = 0; i < n; i++)
                    {
                        if (i == 0)
                            DataX.Add(x.Min());
                        else
                            DataX.Add(DataX[i - 1] + _被分割的单份长度);

                        DataY.Add(ratio[2] * Math.Pow(DataX[i], 2) + ratio[1] * DataX[i] + ratio[0]);
                    }
                    break;
                case 3:
                    //三次曲线
                    for (i = 0; i < n; i++)
                    {
                        if (i == 0)
                            DataX.Add(x.Min());
                        else
                            DataX.Add(DataX[i - 1] + _被分割的单份长度);

                        DataY.Add(ratio[3] * Math.Pow(DataX[i], 3) + ratio[2] * Math.Pow(DataX[i], 2) + ratio[1] * DataX[i] + ratio[0]);
                    }
                    break;
                case 4:
                    //四次曲线
                    for (i = 0; i < n; i++)
                    {
                        if (i == 0)
                        {
                            DataX.Add(x.Min());
                        }
                        else
                            DataX.Add(DataX[i - 1] + _被分割的单份长度);

                        DataY.Add(ratio[4] * Math.Pow(DataX[i], 4) + ratio[3] * Math.Pow(DataX[i], 3) + ratio[2] * Math.Pow(DataX[i], 2) + ratio[1] * DataX[i] + ratio[0]);
                        //DataY.Add(ratio[0] * Math.Pow(DataX[i], 4) + ratio[1] * Math.Pow(DataX[i], 3) + ratio[2] * Math.Pow(DataX[i], 2) + ratio[3] * DataX[i] + ratio[4]);
                    }
                    break;
            }
        }
        //          (X,Y,返回系数)
        public static void PlotFit(double[] x, double[] y, double[] b, int n, int iOrder)
        {

            double[,] a = new double[10, 10];
            double s, l;
            int star, endr;
            int max, i, j, k;//用来记录行列；
            int order = 3;//阶数  //可以用来修改这一行来修改拟和的次数  
            order = iOrder;
            //求正规方程组
            for (i = 0; i <= 2 * order; i++)
            {
                star = (i < order ? i : order); //起始行标
                endr = (i < order ? 0 : i - star); //终止行标
                a[star, i - star] = 0;
                for (j = 0; j < n; j++)
                    a[star, i - star] += Math.Pow(x[j], i);
                for (j = star - 1; j >= endr; j--)
                    a[j, i - j] = a[star, i - star];
            }
            for (i = 0; i <= order; i++)
            {
                b[i] = 0;
                for (j = 0; j < n; j++)
                    b[i] += Math.Pow(x[j], i) * y[j];
            }
            //正规方程组求解完毕
            //---------------------------------------------------------------
            //选列主元法 解方程组
            for (i = 0; i <= order; i++)
            {
                //交换主元
                max = i;
                for (k = i + 1; k <= order; k++)
                    if (Math.Abs(a[k, i]) > Math.Abs(a[max, i]))
                        max = k;
                for (k = i; k <= order; k++)
                {
                    s = a[max, k];
                    a[max, k] = a[i, k];
                    a[i, k] = s;
                }
                s = b[max];
                b[max] = b[i];
                b[i] = s;
                //交换完毕
                for (j = i + 1; j <= order; j++)
                {
                    l = a[j, i] / a[i, i];
                    b[j] -= l * b[i];
                    for (k = i; k <= order; k++)
                        a[j, k] -= l * a[i, k];
                }
                //消元完毕
            }
            //回代过程
            for (i = order; i >= 0; i--)
            {
                for (j = i + 1; j <= order; j++)
                    b[i] -= a[i, j] * b[j];
                b[i] /= a[i, i];
            }

        }

        ///<summary>
        ///用最小二乘法拟合二元多次曲线
        ///</summary>
        ///<param name="arrX">已知点的x坐标集合</param>
        ///<param name="arrY">已知点的y坐标集合</param>
        ///<param name="length">已知点的个数</param>
        ///<param name="dimension">方程的最高次数</param>

        //public static double[] MultiLine(double[] arrX, double[] arrY, int length, int dimension)//二元多次线性方程拟合曲线
        //{
        //    int n = dimension + 1;                       //dimension次方程需要求 dimension+1个 系数
        //    double[,] Guass = new double[n, n + 1];      //高斯矩阵 例如：y=a0+a1*x+a2*x*x
        //    for (int i = 0; i < n; i++)
        //    {
        //        int j;
        //        for (j = 0; j < n; j++)
        //        {
        //            Guass[i, j] = SumArr(arrX, j + i, length);
        //        }
        //        Guass[i, j] = SumArr(arrX, i, arrY, 1, length);
        //    }
        //    return ComputGauss(Guass, n);

        //}

        //public static double SumArr(double[] arr, int n, int length) //求数组的元素的n次方的和
        //{
        //    double s = 0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        if (arr[i] != 0 || n != 0)
        //            s = s + Math.Pow(arr[i], n);
        //        else
        //            s = s + 1;
        //    }
        //    return s;
        //}

        //public static double SumArr(double[] arr1, int n1, double[] arr2, int n2, int length)
        //{
        //    double s = 0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        if ((arr1[i] != 0 || n1 != 0) && (arr2[i] != 0 || n2 != 0))
        //            s = s + Math.Pow(arr1[i], n1) * Math.Pow(arr2[i], n2);
        //        else
        //            s = s + 1;
        //    }
        //    return s;

        //}

        //public static double[] ComputGauss(double[,] Guass, int n)
        //{
        //    int i, j;
        //    int k, m;
        //    double temp;
        //    double max;
        //    double s;
        //    double[] x = new double[n];

        //    for (i = 0; i < n; i++) x[i] = 0.0;//初始化


        //    for (j = 0; j < n; j++)
        //    {
        //        max = 0;

        //        k = j;
        //        for (i = j; i < n; i++)
        //        {
        //            if (Math.Abs(Guass[i, j]) > max)
        //            {
        //                max = Guass[i, j];
        //                k = i;
        //            }
        //        }



        //        if (k != j)
        //        {
        //            for (m = j; m < n + 1; m++)
        //            {
        //                temp = Guass[j, m];
        //                Guass[j, m] = Guass[k, m];
        //                Guass[k, m] = temp;

        //            }
        //        }

        //        if (0 == max)
        //        {
        //            // "此线性方程为奇异线性方程" 

        //            return x;
        //        }


        //        for (i = j + 1; i < n; i++)
        //        {

        //            s = Guass[i, j];
        //            for (m = j; m < n + 1; m++)
        //            {
        //                Guass[i, m] = Guass[i, m] - Guass[j, m] * s / (Guass[j, j]);

        //            }
        //        }


        //    }//结束for (j=0;j<n;j++)


        //    for (i = n - 1; i >= 0; i--)
        //    {
        //        s = 0;
        //        for (j = i + 1; j < n; j++)
        //        {
        //            s = s + Guass[i, j] * x[j];
        //        }

        //        x[i] = (Guass[i, n] - s) / Guass[i, i];

        //    }

        //    return x;
        //}//返回值是函数的系数

        /// <summary>
        /// 根据传入的X坐标值集合计算对应的Y值集合
        /// </summary>
        /// <param name="X"></param>
        /// <param name="常量组"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static double[] f_根据X计算Y(double[] X, double[] 常量组, int dimension)
        {
            List<double> d = new List<double>();

            switch (dimension)
            {
                case 4:
                    for (int i = 0; i < X.Length; i++)
                    {
                        d.Add(常量组[4] * Math.Pow(X[i], 4) + 常量组[3] * Math.Pow(X[i], 3) + 常量组[2] * Math.Pow(X[i], 2) + 常量组[1] * X[i] + 常量组[0]);
                    }

                    break;
            }
            return d.ToArray();
        }
    }
}
