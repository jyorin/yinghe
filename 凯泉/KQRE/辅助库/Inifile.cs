using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;

namespace 辅助库
{
    public class IniFile
    {
        public string FilePath = "";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileStringA(string section, string key, string def, byte[] buffer, int size, string filePath);

        public IniFile(string filename)
        {
            string IniFilePath = System.Environment.CurrentDirectory + "//" + filename;
            FilePath = IniFilePath;
        }
        //写文件
        public void WriteIniFile(string WantSetSection, string WantSetKey, string WantSetval)
        {
            WritePrivateProfileString(WantSetSection, WantSetKey, WantSetval, this.FilePath);
        }
        //读文件
        public string ReadIniFile(string WAntGetSection, string WantGetKey)
        {
            StringBuilder ReadTemp = new StringBuilder(255);
            int i = GetPrivateProfileString(WAntGetSection, WantGetKey, "", ReadTemp, 255, this.FilePath);
            return ReadTemp.ToString();
        }

        public ArrayList ReadKeys(string sectionName)
        {
            byte[] buffer = new byte[5120];
            int rel = GetPrivateProfileStringA(sectionName, null, "", buffer, buffer.GetUpperBound(0), this.FilePath);
            int iCnt = 0, iPos = 0;
            ArrayList arrayList = new ArrayList();
            string tmp;
            for (iCnt = 0; iCnt < rel; iCnt++)
            {
                if (buffer[iCnt] == 0x00)
                {
                    tmp = System.Text.ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                    iPos = iCnt + 1;
                    if (tmp != "")
                        arrayList.Add(tmp);
                }
            }
            return arrayList;
        }

    }
}
