using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProductCart
{
    public class Log
    {
        string logFile = @"D:\ProductCart\LogFile.txt";
        internal void Logger(string v)
        {
            using (StreamWriter streamWriter = File.AppendText(logFile))
            {
                streamWriter.WriteLine(v);
            }
        }
    }
}