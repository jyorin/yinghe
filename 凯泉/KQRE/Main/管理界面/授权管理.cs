using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Microsoft.Win32;

namespace Main.管理界面
{
    public partial class 授权管理 : DevExpress.XtraEditors.XtraForm
    {
        public 授权管理()
        {
            InitializeComponent();
        }

        private void 授权管理_Load(object sender, EventArgs e)
        {
            this.label1.Text = "注册信息:"+"\r"+Program.licenseInfo;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\KQRE\\LicenseInfo", true);
            string licenseNumber = rk.GetValue("LicenseNumber") as string;
            this.txtLicenseNumber.Text = licenseNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            管理界面.软件注册 _软件注册 = new 管理界面.软件注册();
            if (_软件注册.ShowDialog() == DialogResult.OK)
            {
                Program.licenseInfo = 辅助库.LicenseValidateHelper.ValidateLicense();
                this.label1.Text = "注册信息:" + "\r" + Program.licenseInfo;
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\KQRE\\LicenseInfo", true);
                string licenseNumber = rk.GetValue("LicenseNumber") as string;
                this.txtLicenseNumber.Text = licenseNumber;
            }
            else
            {
                //
            }
        }
    }
}