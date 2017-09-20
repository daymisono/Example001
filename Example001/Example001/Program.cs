using Example001.Object;
using Example001.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example001
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ProcessInfo[] proInfo = new ProcessInfo[2];

                proInfo[0] = new ProcessInfo();
                proInfo[0].Name = "notepad";
                proInfo[0].Path = @"C:\Windows\notepad.exe";
                proInfo[0].Delay = 3;

                proInfo[1] = new ProcessInfo();
                proInfo[1].Name = "EXCEL";
                proInfo[1].Path = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Microsoft Office 2013\Excel 2013.lnk";
                proInfo[1].Delay = 3;


                ProcessMonitoring pro = new ProcessMonitoring(proInfo);
                pro.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

////////
