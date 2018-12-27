using System;
using System.Web.Http.ExceptionHandling;
using System.IO;
using System.Configuration;

namespace ProjectManagerWebApi
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var ex = context.Exception;

            string strLogText = "";
            strLogText += Environment.NewLine + "Source ---\n{0}" + ex.Source;
            strLogText += Environment.NewLine + "StackTrace ---\n{0}" + ex.StackTrace;
            strLogText += Environment.NewLine + "TargetSite ---\n{0}" + ex.TargetSite;

            if (ex.InnerException != null)
            {
                strLogText += Environment.NewLine + "Inner Exception is {0}" + ex.InnerException;
            }

            if (ex.Message != null)
            {
                strLogText += Environment.NewLine + "Inner Exception is {0}" + ex.Message;
            }

            var requestedURi = (string)context.Request.RequestUri.AbsoluteUri;
            var requestMethod = context.Request.Method.ToString();

            string strLogFilePath = Convert.ToString(ConfigurationManager.AppSettings["logfilepath"]);

            string strFileName = "Logs_" + DateTime.Now.Date.ToString("ddMMyyyy") + ".txt"; 

            using (StreamWriter sw = new StreamWriter(Path.Combine(strLogFilePath,strFileName), true))
            {
                sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy @ HH:mm:ss "));
                sw.WriteLine("RequestMethod -->" + requestMethod);
                sw.WriteLine("RequestUri -->" + requestedURi);
                sw.WriteLine("Error Messgage -->" + strLogText);
            }
          
        }
    }
}