using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClinicWallyMisr
{
    public enum LogType
    {
        Error,
        Info,
        Warning
    }
    public class Logger
    {
        public static void Log(string msg, LogType type)
        {
            //TODO append
            string str = AppDomain.CurrentDomain.BaseDirectory;
            File.WriteAllLines(str + "log.txt", new string[]{
            msg,
            "-----------------------------------------",
            type.ToString()
            ,
            DateTime.Now.ToLongDateString()
            });
        }
    }
}
