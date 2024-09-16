using NLog;
using SeleniumCore.Enums;

namespace SeleniumCore.LoggerUtils
{
    public class NLogImplementation : Ilogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public NLogImplementation()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");          

            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logfile);
            

            NLog.LogManager.Configuration = config;
        }

       public void Log( SeleniumCore.Enums.LogLevel logLevel, string message)
        {
            switch (logLevel) 
            {
                case SeleniumCore.Enums.LogLevel.Info:
                    logger.Info(message);
                    break;

                case SeleniumCore.Enums.LogLevel.Warn:
                    logger.Warn(message);
                    break;

                    case SeleniumCore.Enums.LogLevel.Debug:
                    logger.Debug(message); 
                    break;

                    case SeleniumCore.Enums.LogLevel.Error:
                    logger.Error(message); 
                    break;
            }
        }
    }
}
