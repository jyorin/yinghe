using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Main.管理界面
{
    public partial class 查看文档帮助 : DevExpress.XtraEditors.XtraForm
    {
        public 查看文档帮助()
        {
            InitializeComponent();
        }

        private void 查看文档帮助_Load(object sender, EventArgs e)
        {
            if (!checkAdobeReader())
            {
                return;
            }
            //openFileDialog1.Filter = "pdf文件|*.pdf";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axAcroPDF1.setShowToolbar(false);
                //axAcroPDF1.setShowScrollbars(false);
                axAcroPDF1.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "附件//帮助.pdf");
            }
        }

        public bool checkAdobeReader()
        {
            Microsoft.Win32.RegistryKey uninstallNode = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
            foreach(string subKeyName in uninstallNode.GetSubKeyNames()){
                Microsoft.Win32.RegistryKey subKey = uninstallNode.OpenSubKey(subKeyName);
                object displayName = subKey.GetValue("DisplayName");
                if (displayName != null)
                {
                    if (displayName.ToString().Contains("Adobe Reader"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}