using ExampleCheckProcess.Object;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleCheckProcess.Service
{
    class ProcessMonitoring
    {
        Thread th;
        ProcessInfo[] pInfo;

        public ProcessMonitoring(ProcessInfo[] pInfo)
        {
            Console.WriteLine("initialized Process Monitoring!!");
            this.pInfo = pInfo;
            th = new Thread(new ThreadStart(Run));
        }

        public void Start()
        {
            th.Start();
        }

        public void Stop()
        {
            th.Abort();
        }

        public void Run()
        {
            while (true)
            {
                for (int i = 0; i < pInfo.Length; i++)
                {
                    try
                    {
                        String pName = pInfo[i].Name;
                        Process[] process = Process.GetProcessesByName(pName);
                        if (process.Length < 1)
                        {
                            Console.WriteLine("Not found Process Name : " + pName);
                            ProcessStart(pInfo[i].Name, pInfo[i].Path, pInfo[i].Delay);
                        }
                        else
                        {
                            Console.WriteLine("Detected Process Name : " + pName);
                        }
                        Thread.Sleep(1500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        public void ProcessStart(String name, String path, int delay)
        {
            try
            {
                Process.Start(path);
                Console.WriteLine("Start Process Name : " + name);
                Console.WriteLine("Start Process Path : " + path);
                Console.WriteLine("Delay is " + delay + " sec");
                Thread.Sleep(1000 * delay);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Start Process Name : " + name);
                Console.WriteLine(ex);
            }
        }
    }
}
