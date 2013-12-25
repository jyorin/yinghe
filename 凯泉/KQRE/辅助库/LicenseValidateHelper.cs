using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;


namespace 辅助库
{
    public class LicenseValidateHelper
    {
        private static RSACryptoServiceProvider currentRSA = new RSACryptoServiceProvider();

        /// <summary>
        /// Validate success will return,otherwise loop run register and validate till user cannel register
        /// </summary>
        public static string ValidateLicense()
        {
            string succ = "";
            try
            {
                succ = Validate();
            }
            catch (LicenseException lex)
            {
                MessageBox.Show(lex.Message);
            }
            catch
            {
                MessageBox.Show("序列号错误");
                //Process.GetCurrentProcess().Kill();
            }
            return succ;
        }

        private static string Validate()
        {
            string succ = "";
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\KQRE\\LicenseInfo", true);
                string machineCode = rk.GetValue("MachineCode") as string;
                string licenseNumber = rk.GetValue("LicenseNumber") as string;
                string plainString = Decrypt(licenseNumber);
                string currentMachineCode = HardWareInfo.GetInstance().GetMachineCode().Substring(0, 10);
                string[] strs = plainString.Split(" ".ToCharArray());
                if (strs.Length < 2)
                {
                    throw new LicenseException(typeof(Form), null, "序列号错误");
                }
                if (machineCode != currentMachineCode || machineCode != strs[0])
                {
                    throw new LicenseException(typeof(Form), null, "机器码错误");
                }
                if (IsExpire(strs[1]))
                {
                    throw new LicenseException(typeof(Form), null, "序列号已过期");
                }

                byte[] strBytes = Encoding.Unicode.GetBytes(DateTime.Now.ToString());
                rk.SetValue("LastRunTime", Convert.ToBase64String(strBytes));

                succ = "机器码:"+strs[0]+"\r过期时间:"+strs[1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return succ;
        }

        private static bool IsExpire(string dateString)
        {
            DateTime availableDate = DateTime.Parse(dateString);
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\KQRE\\LicenseInfo", true);
            if (rk.GetValue("LastRunTime") == null)
            {
                byte[] strBytes = Encoding.Unicode.GetBytes(DateTime.Now.ToString());
                rk.SetValue("LastRunTime", Convert.ToBase64String(strBytes));
            }
            byte[] bytes = Convert.FromBase64String((string)rk.GetValue("LastRunTime"));
            string lastRunTime = Encoding.Unicode.GetString(bytes);
            rk.Close();
            if (!string.IsNullOrEmpty(lastRunTime))
            {
                DateTime currnetTime = DateTime.Now;
                if (currnetTime < DateTime.Parse(lastRunTime) || availableDate.AddDays(-1) <= DateTime.Parse(lastRunTime))
                    return true;
            }

            if (availableDate > DateTime.Now)
            {
                return false;
            }
            return true;
        }

        private static string Decrypt(string licenseNumber)
        {
            //string prk = System.Configuration.ConfigurationManager.AppSettings["prk"];
            string prk = string.Empty;
            //using (OpenFileDialog open = new OpenFileDialog())
            {
                //open.Filter = "PublicKey/PrivateKey(*.prk;*puk)|*.prk;*.puk";
                //if (open.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "license.prk");
                        byte[] bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, bytes.Length);
                        prk = Encoding.Unicode.GetString(bytes, 0, bytes.Length);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (fs != null)
                            fs.Close();
                    }
                }
            }
            //byte[] prkBytes = Convert.FromBase64String(prk);
            //string prkString = Encoding.Unicode.GetString(prkBytes);
            currentRSA.FromXmlString(prk);
            //嵌套了DES解密
            byte[] licenseBytes = Convert.FromBase64String(DesDecrypt(licenseNumber, "12345678", "87654321"));
            //string licenseString = Encoding.Unicode.GetString(licenseBytes);
            //byte[] encryptBytes = Convert.FromBase64String(licenseNumber);
            byte[] plainBytes = currentRSA.Decrypt(licenseBytes, false);
            return Encoding.Unicode.GetString(plainBytes);
        }

        public static string DesEncrypt(string pToEncrypt, string key, string iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(iv);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                /*StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();*/
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string DesDecrypt(string pToDecrypt, string key, string iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);/*new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }*/
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(iv);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                cs.Dispose();
                //StringBuilder ret = new StringBuilder();
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}