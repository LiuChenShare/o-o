using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;

namespace 获取电脑硬件信息
{
    public class HardwareHepler
    {

        /// <summary>
        /// 获取操作系统信息
        /// </summary>
        /// <returns></returns>
        public static string Get_OSVersion()
        {
            ComputerInfo computer = new ComputerInfo();
            
            return $"操作系统：{computer.OSFullName}\n平台标识符：{computer.OSPlatform}\n操作系统版本：{computer.OSVersion}\n{(Environment.Is64BitOperatingSystem ? "64位" : "32位")}";
        }

        /// <summary>
        /// 获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            ManagementClass class2 = new ManagementClass("Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject obj2 in class2.GetInstances())
            {
                if (obj2["IPEnabled"].ToString() == "True")
                {
                    return obj2["MacAddress"].ToString();
                }
            }
            return null;
        }

        public static string CXX()
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");



            Console.WriteLine("电脑CPU使用率：" + cpuCounter.NextValue() + "%");
            Console.WriteLine("电脑可使用内存：" + ramCounter.NextValue() + "MB");
            return null;
        }

        /// <summary>
        /// 获取CPU信息
        /// </summary>
        /// <returns></returns>
        public static string CXX2()
        {
            //string a1 = string.Empty, a2 = string.Empty, a3 = string.Empty, a4 = string.Empty;
            //ManagementClass mc = new ManagementClass("win32_processor");//创建ManagementClass对象
            //ManagementObjectCollection moc = mc.GetInstances();//获取CPU信息
            //foreach (ManagementObject mo in moc)
            //{
            //    a1 = mo["processorid"].ToString();//获取CUP编号
            //}
            //ManagementObjectSearcher driveID = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");//查询CPU信息
            //foreach (ManagementObject MyXianKa in driveID.Get())
            //{
            //    a2 = MyXianKa["Manufacturer"].ToString();//获取CUP制造商名称
            //    a3 = MyXianKa["Version"].ToString();//获取CPU版本号
            //    a4 = MyXianKa["Name"].ToString();//获取CUP产品名称
            //}
            //return $"CUP编号：{a1}\nCUP制造商：{a2}\nCPU版本号：{a3}\nCUP产品名称：{a4}";

            ManagementClass class2 = new ManagementClass("Win32_Processor");
            StringBuilder sr = new StringBuilder();
            foreach (var obj in class2.GetInstances())
            {
                sr.Append("厂商:" + obj["Manufacturer"] + ";\n");
                sr.Append("产品名称:" + obj["Name"] + ";\n");
                sr.Append("最大频率:" + obj["MaxClockSpeed"] + ";\n");
                sr.Append("当前频率:" + obj["CurrentClockSpeed"] + ";\n");
            }
            return sr.ToString();
        }

        /// <summary>
        /// 获取内存信息
        /// </summary>
        /// <returns></returns>
        public static string GetMemoryInfo()
        {
            StringBuilder sr = new StringBuilder();
            long capacity = 0;
            ManagementClass class1 = new ManagementClass("Win32_PhysicalMemory");
            int index = 1;
            foreach (var obj in class1.GetInstances())
            {
                sr.Append("内存" + index + "频率:" + obj["ConfiguredClockSpeed"] + ";\n");
                capacity += Convert.ToInt64(obj["Capacity"]);
                index++;
            }
            sr.Append("总物理内存:");
            sr.Append(capacity / 1024 / 1024 + "MB;\n");
            
            ManagementClass class2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            sr.Append("总可用内存:");
            long available = 0;
            foreach (var obj in class2.GetInstances())
            {
                available += Convert.ToInt64(obj.Properties["AvailableMBytes"].Value);
            }
            sr.Append(available + "MB;\n");
            sr.AppendFormat("{0:F2}%可用; ", (double)available / (capacity / 1024 / 1024) * 100);

            return sr.ToString();
        }

        /// <summary>
        /// 获取硬盘信息
        /// </summary>
        /// <returns></returns>
        public static string HardDiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            StringBuilder sr = new StringBuilder();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    var val1 = (double)drive.TotalSize / 1024 / 1024;
                    var val2 = (double)drive.TotalFreeSpace / 1024 / 1024;
                    sr.AppendFormat("{0}:{2}/{3}MB/{4}MB/{1}%可用;\n",
                        drive.Name,
                        string.Format("{0:F2}", val2 / val1 * 100),
                        drive.DriveFormat,
                        (long)val1,
                        (long)val2);
                }
            }

            ManagementClass class1 = new ManagementClass("Win32_DiskDrive");
            foreach (var obj in class1.GetInstances())
            {
                sr.Append($"厂商：{obj["Manufacturer"]}\n");
                sr.Append($"产品名称：{obj["Name"]}\n");
                //sr.Append($"默认块大小：{obj["DefaultBlockSize"]}\n");
                sr.Append($"描述：{obj["Description"]}\n");
                sr.Append($"安装日期：{obj["InstallDate"]}\n");
                sr.Append($"磁盘驱动器的制造商的型号：{obj["Model"]}\n");
                break;
            }

            ManagementClass class2 = new ManagementClass("Win32_PhysicalMedia");
            foreach (var obj in class2.GetInstances())
            {
                sr.Append($"\nWin32_PhysicalMedia\n");
                sr.Append($"厂商：{obj["Manufacturer"]}\n");
                sr.Append($"产品名称：{obj["Name"]}\n");
                //sr.Append($"默认块大小：{obj["DefaultBlockSize"]}\n");
                sr.Append($"编号：{obj["SerialNumber"]}\n");
                sr.Append($"安装日期：{obj["InstallDate"]}\n");
                sr.Append($"型号：{obj["Model"]}\n");
                sr.Append($"其他识别信息：{obj["OtherIdentifyingInfo"]}\n");
                break;
            }


            return sr.ToString();
        }
    }
}
