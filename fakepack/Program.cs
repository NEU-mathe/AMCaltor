using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamSysWinform;
using ExamSysWinform.WebService;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;

namespace fakepack
{
    public class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string tempdir = Environment.GetEnvironmentVariable("TEMP");
            tempdir += @"\2645\AMCalTor\";
            //new Thread(new ThreadStart(this.LoginMethod)) { IsBackground = true }.Start();
            //MessageBox.Show(args[0]);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                if (args.Length == 0)
                    Application.Run(new Form1());
                else
                {
                    if (args.Length == 3)
                    {
                        if (!Function.Login(args[1], args[2]))
                            return;
                        if (Directory.Exists(tempdir))
                        {
                        }
                        else
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(tempdir);
                            directoryInfo.Create();
                        }
                        FileStream aFile = new FileStream(tempdir + "ExamInfo.txt", FileMode.Create);
                        StreamWriter sw = new StreamWriter(aFile, Encoding.GetEncoding("GB18030"));
                        string[] str = Function.ExamTemplate(args[0],args[1]);
                        foreach (string s in str)
                            if(s != null && s != "")
                                sw.WriteLine(s);
                        sw.Close();
                        return;
                    }
                    if (args.Length == 4)
                    {
                        if (!Function.Login(args[1], args[2]))
                            return;
                        if (Directory.Exists(tempdir))
                        {
                        }
                        else
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(tempdir);
                            directoryInfo.Create();
                        }
                        FileStream aFile = new FileStream(tempdir + "Bak.txt", FileMode.Create);
                        StreamWriter sw = new StreamWriter(aFile,Encoding.GetEncoding("GB18030"));
                        string[] str = Function.ExamTemplate(args[0],args[1], int.Parse(args[3]));
                        foreach (string s in str)
                            if (s != null && s != "")
                                sw.WriteLine(s);
                        sw.Close();
                        return;
                    }
                }

        }

    }
}

