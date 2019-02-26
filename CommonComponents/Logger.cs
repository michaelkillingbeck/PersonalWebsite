using CommonComponents.Interfaces;
using log4net;
using log4net.Config;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CommonComponents
{
    public class Logger : ILogger
    {
        private ILog _logger;

        public Logger()
        {
            try
            {
                string filePath = @"C:\Github Code\PersonalWebsite\CommonComponents\log4net.config";

                XmlConfigurator.Configure(new FileInfo(filePath));
                _logger = LogManager.GetLogger("LOGGER");

                if (!log4net.LogManager.GetRepository().Configured)
                {
                    // log4net not configured
                    foreach (log4net.Util.LogLog message in log4net.LogManager.GetRepository().ConfigurationMessages.Cast<log4net.Util.LogLog>())
                    {
                        // evaluate configuration message
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Could not get the logger. " + ex.ToString());
            }
        }

        public string FormatString(string message, string callingMemberName)
        {
            return string.Format("{0} : {1}", callingMemberName, message);
        }

        public void DebugFormat(string message, [CallerMemberName]string methodName = "")
        {
            _logger.DebugFormat(FormatString(message, methodName));
        }

        public void ErrorFormat(string message, [CallerMemberName]string methodName = "")
        {
            _logger.ErrorFormat(FormatString(message, methodName));
        }

        public void LogException(string Message, Exception ex, [CallerMemberName]string methodName = "")
        {
            _logger.ErrorFormat(FormatString(string.Format("Exception caught and logged; \n{0}, \n{1}.", ex, Message), methodName));
        }

        public void WarnFormat(string message, [CallerMemberName]string methodName = "")
        {
            _logger.WarnFormat(FormatString(message, methodName));
        }
    }
}
