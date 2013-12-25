using System.Management;
using System.Text;
using System.Web.Security;

namespace 辅助库
{
    public class HardWareInfo
    {
        private static readonly object syncRoot = new object();
        private static volatile HardWareInfo uniqueInstace;
        private string cpuID = "";
        private string hardDiskID = "";
        private string ipAddress = "";
        private string netAdapterID = "";
        private string osType = "";
        private string userName = "";
        private string computerName = "";
        private string totalPhyMemory = "";

        private HardWareInfo()
        {
        }

        public static HardWareInfo GetInstance()
        {
            if (uniqueInstace == null)
            {
                lock (syncRoot)
                {
                    if (uniqueInstace == null)
                    {
                        uniqueInstace = new HardWareInfo();
                    }
                }
            }
            return uniqueInstace;
        }

        public string CpuID
        {
            get
            {
                if (cpuID == string.Empty)
                {
                    cpuID = GetComponentInfo("Win32_Processor", "ProcessorID");
                }
                return cpuID;
            }
        }

        public string HardDiskID
        {
            get
            {
                if (hardDiskID == string.Empty)
                {
                    hardDiskID = GetComponentInfo("Win32_DiskDrive", "Model");
                }
                return hardDiskID;
            }
        }

        public string NetAdapterID
        {
            get
            {
                if (netAdapterID == string.Empty)
                {
                    //netAdapterID = GetComponentInfo("Win32_NetworkAdapterConfiguration", "MacAddress");
                    ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");  
                    ManagementObjectCollection moc2 = mc.GetInstances();  
                    foreach(ManagementObject mo in moc2)  
                    {  
                        if((bool)mo["IPEnabled"] == true)  {
                            netAdapterID= mo["MacAddress"].ToString();  
                            break;
                        }
                    }  
                }
                return netAdapterID;
            }
        }

        public string IpAddress
        {
            get
            {
                if (ipAddress == string.Empty)
                {
                    ipAddress = GetComponentInfo("Win32_NetworkAdapterConfiguration", "IPAddress");
                }
                return ipAddress;
            }
        }

        public string OsType
        {
            get
            {
                if (osType == string.Empty)
                {
                    osType = GetComponentInfo("Win32_ComputerSystem", "SystemType");
                }
                return osType;
            }
        }

        public string UserName
        {
            get
            {
                if (userName == string.Empty)
                {
                    userName = GetComponentInfo("Win32_ComputerSystem", "UserName");
                }
                return userName;
            }
        }

        public string ComputerName
        {
            get
            {
                if (computerName == string.Empty)
                {
                    computerName = System.Environment.GetEnvironmentVariable("ComputerName");
                }
                return computerName;
            }
        }

        public string TotalPhyMemory
        {
            get
            {
                if (totalPhyMemory == string.Empty)
                {
                    totalPhyMemory = GetComponentInfo("Win32_ComputerSystem", "TotalPhysicalMemory");
                }
                return totalPhyMemory;
            }
        }

        private string GetComponentInfo(string componentName, string componentProperty)
        {
            string info = string.Empty;
            using (ManagementClass mc = new ManagementClass(componentName))
            {
                using (ManagementObjectCollection moc = mc.GetInstances())
                {
                    foreach (ManagementObject mo in moc)
                    {
                        info = mo.Properties[componentProperty].Value.ToString();
                        break;
                    }
                }
            }
            return info;
        }

        public string GetMachineCode()
        {
            string machineCode = CpuID + HardDiskID;// +NetAdapterID;
            return FormsAuthentication.HashPasswordForStoringInConfigFile(machineCode, "MD5");
        }
    }
}