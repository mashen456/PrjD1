using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PrjD1FW.Services
{
    public class logger
    {
        public bool INFO = false;
        public bool DBG = false;
        public bool ERROR = false;


        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        internal void Info(string info)
        {
            
            if (INFO)
            {
                string text = info + Environment.NewLine;
                File.WriteAllText(Path.Combine(docPath, "InfoLog.txt"), text);
            }
            

        }

        internal void Info(string[] info)
        {
            if (INFO)
            {
                File.AppendAllLines(Path.Combine(docPath, "InfoLog.txt"), info);
            }
        }


        internal void Error(string info)
        {
            if (ERROR)
            {
                string text = info + Environment.NewLine;
                File.WriteAllText(Path.Combine(docPath, "ErrorLog.txt"), text);
            }

        }


        internal void Error(string[] info)
        {
            if (ERROR)
            {
                File.AppendAllLines(Path.Combine(docPath, "ErrorLog.txt"), info);

            }
        }



        internal void Dbg(string info)
        {
            if (DBG)
            {
                string text = info + Environment.NewLine;
                File.WriteAllText(Path.Combine(docPath, "DbgLog.txt"), text);
            }

        }

        internal void Dbg(string[] info)
        {
            if (DBG)
            {
                File.AppendAllLines(Path.Combine(docPath, "DbgLog.txt"), info);
            }
        }
    }

}