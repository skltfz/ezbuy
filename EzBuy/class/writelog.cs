using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
namespace EzBuy
{
    public class writelog
    {
        public static string  path = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        public static void createDirectory()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void writeentry(int priority,string x)
        {
            createDirectory();
            string filepath = path +  DateTime.Now.ToString("yyyyMMdd")+".txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
            {
                file.WriteLine(marking(priority) + x + "(" + DateTime.Now.ToString() +")");
                //0 is normal, 3 is highest
            }
            /*                File.AppendAllText(filepath,
                       DateTime.Now.ToString() + Environment.NewLine);*/
            
        }
        private static string marking(int x )
        {
            if (x == 0)
                return "Notice:";
            else if (x == 1)
                return "Warning:";
            else
                return "Fatal:";
        }

    }
}
