using SeleniumCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCore.LoggerUtils
{
    public class LoggerFactory
    {
        public static Ilogger logger { get;  set; }

        public static Ilogger GetLogger(LoggerType loggerType)
        {
            if (logger == null)
            {
               return CreateLogger(loggerType);
            }
            return logger;

        }

        private static Ilogger CreateLogger(LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.NLog:
                    return new NLogImplementation();
                default: //LoggerType.NLog
                    return new NLogImplementation();
            }
        }
    }
}
