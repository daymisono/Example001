using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example001.Object
{
    class ProcessInfo
    {
        private string name;

        private string path;

        private int failedCount;

        private int delay;

        public string Name { get; set; }

        public string Path { get; set; }

        public int FailedCount { get; set; }

        public int Delay { get; set; }
    }
}
