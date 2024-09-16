using SeleniumCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Models;

namespace UITests.Providers
{
    internal class ConfigurationProvider : UICore.Providers.ConfigurationProvider
    {
        static readonly string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../", "TestSettings.json");

        public static ApplicationDetails applicationDetails => Load<ApplicationDetails>(SettingsPath, "UIDetails");
        public static LoggerConfiguration loggerConfiguration => Load<LoggerConfiguration>(SettingsPath, "logger");

        public static WebDriverConfiguration driverConfiguration => Load<WebDriverConfiguration>(SettingsPath, "WebDriver");

    }
}
