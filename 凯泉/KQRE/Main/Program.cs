using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Main
{
    static class Program
    {
        public static string licenseInfo;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //添加验证信息
            //licenseInfo = 辅助库.LicenseValidateHelper.ValidateLicense();
            //管理界面.软件注册 _软件注册 = new 管理界面.软件注册();
            //while (true)
            //{
            //    if (string.IsNullOrEmpty(licenseInfo))
            //    {
            //        if (_软件注册.ShowDialog() == DialogResult.OK)
            //        {
            //            licenseInfo = 辅助库.LicenseValidateHelper.ValidateLicense();
            //        }
            //        else
            //        {
            //            Process.GetCurrentProcess().Kill();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(licenseInfo);
            //        break;
            //    }
            //}
            Application.Run(new MainFrame());
        }
    }
}
