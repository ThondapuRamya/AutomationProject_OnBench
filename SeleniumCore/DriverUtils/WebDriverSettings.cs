using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumCore.Models;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace SeleniumCore.DriverUtils
{
    public class WebDriverSettings
    {
        public static readonly string DOWNLOADSLOCATION = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads\\");
        public static ChromeOptions ChromeOptions(WebDriverConfiguration config)
        {
            var options = new ChromeOptions();
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddArgument("--start-maximized");
            options.AddArgument("--no-sandbox");           
            options.AddExcludedArgument("enable-automation");
            options.AddUserProfilePreference("download.default_directory", DOWNLOADSLOCATION);
            options.AddArgument($"--lang={config.BrowserLanguage}");           
            options.AddUserProfilePreference("intl.accept_languages", config.BrowserLanguage);
            options.AddAdditionalOption("resolution", "1920x1080");
           
            return options;
        }

        public static InternetExplorerOptions InternetExplorerOptions(WebDriverConfiguration config) 
        {

            return new InternetExplorerOptions(); 
        }

        public static EdgeOptions EdgeOptions(WebDriverConfiguration config)
        {
            return new EdgeOptions();
        }
    }
}
