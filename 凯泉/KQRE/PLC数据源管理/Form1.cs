using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PLC数据源管理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataSocket1_DataUpdated(object sender, NationalInstruments.Net.DataUpdatedEventArgs e)
        {

        }
    }
}
