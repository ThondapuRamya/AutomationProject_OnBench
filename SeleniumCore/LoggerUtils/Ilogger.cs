using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCore.LoggerUtils
{
    public interface Ilogger
    {
        public void Log(SeleniumCore.Enums.LogLevel logLevel, string message);
    }
}
