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
            string str = AppDomain.CurrentDomain.BaseDirectory + "App_Data"+"/log/";
            if (File.Exists(str + "log" + DateTime.Now.ToString("dd-MM-yy") + ".txt"))
            {
                FileStream fs = new FileStream(str + "log" + DateTime.Now.ToString("dd-MM-yy") + ".txt",FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(msg);
                sw.WriteLine(type.ToString());
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("-----------------------------------------");

                sw.Close();
                fs.Close();
            }
            else
            {
                File.WriteAllLines(str + "log" + DateTime.Now.ToString("dd-MM-yy") + ".txt", new string[]{
            msg,
            type.ToString()
            ,
            ""+DateTime.Now ,
            "-----------------------------------------"
            });
            }
        }
    }
}
