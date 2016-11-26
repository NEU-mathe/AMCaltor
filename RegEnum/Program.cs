using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            string appdata = Environment.GetEnvironmentVariable("AppData");
            if(Directory.Exists(appdata + "\\AMFairy") == false)
            {
                Directory.CreateDirectory(appdata + "\\AMFairy");
            }
            if(Directory.Exists(appdata + "\\AMFairy\\AMCalTor") == false)
            {
                Directory.CreateDirectory(appdata + "\\AMFairy\\AMCalTor");
            }
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE");
                Console.WriteLine(key.GetValueNames());
                key = key.OpenSubKey("Microsoft");
                Console.WriteLine(key.GetValueNames());
                key = key.OpenSubKey("Windows");
                Console.WriteLine(key.GetValueNames());
                key = key.OpenSubKey("CurrentVersion");
                Console.WriteLine(key.GetValueNames());
                key = key.OpenSubKey("Installer");
                Console.WriteLine(key.GetValueNames());
                key = key.OpenSubKey("Folders");
                string[] valueNames = key.GetValueNames();
                foreach (string s in valueNames)
                {
                    Console.WriteLine(s);
                    if (s.Contains("大学数学过程学习系统") && (!s.Contains("skin")) && (!s.Contains("Start Menu")))
                    {
                        FileStream aFile = new FileStream(appdata + "\\AMFairy\\AMCalTor\\WorkingDir.ini", FileMode.Create);
                        StreamWriter sw = new StreamWriter(aFile, Encoding.GetEncoding("GB18030"));
                        sw.Write(s);
                        sw.Close();
                    }
                }
            }
            catch(Exception)
            {

            }
            //Console.ReadKey();
        }
    }
}
