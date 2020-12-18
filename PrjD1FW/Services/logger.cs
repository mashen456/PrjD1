using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PrjD1FW.Services
{
    public class logger
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        internal void Info(string info)
        {
            string text = info + Environment.NewLine;
            File.WriteAllText(Path.Combine(docPath, "InfoLog.txt"), text);

        }

        internal void Info(string[] info)
        {
            File.AppendAllLines(Path.Combine(docPath, "InfoLog.txt"), info);
        }


        internal void Error(string info)
        {
            string text = info + Environment.NewLine;
            File.WriteAllText(Path.Combine(docPath, "ErrorLog.txt"), text);

        }


        internal void Error(string[] info)
        {
            File.AppendAllLines(Path.Combine(docPath, "ErrorLog.txt"), info);
        }



        internal void Dev(string info)
        {
            string text = info + Environment.NewLine;
            File.WriteAllText(Path.Combine(docPath, "DevLog.txt"), text);

        }

        internal void Dev(string[] info)
        {
            File.AppendAllLines(Path.Combine(docPath, "DevLog.txt"), info);
        }
    }

}