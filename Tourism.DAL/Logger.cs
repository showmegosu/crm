using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.DAL
{
    public sealed class Logger
    {
        private StreamWriter writer;
        private Logger()
        {
            string fileName = DateTime.Now.ToString("YYYYMMDD");
            writer = new StreamWriter("date.txt");
        }

        public static Logger Instance => Nested.Instance;

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly Logger Instance = new Logger();
        }

        public void LogException()
        {
        }

        public void LogWarning()
        {
        }

        public void LogInfo()
        {
        }
    }
}