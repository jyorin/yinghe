using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Main.管理界面
{
    public partial class 软件注册 : Form
    {
        public 软件注册()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
                return;
            RegistryKey rk = Registry.CurrentUser;
            rk = rk.OpenSubKey("Software", true);
            rk = rk.CreateSubKey("KQRE\\LicenseInfo");
            rk.SetValue("MachineCode", textBox1.Text);
            rk.SetValue("LicenseNumber", textBox2.Text);
            rk.Close();
            MessageBox.Show("感谢您的注册!");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = 辅助库.HardWareInfo.GetInstance().GetMachineCode().Substring(0,10);
        }
    }
}



