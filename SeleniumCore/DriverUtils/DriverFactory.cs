using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using SeleniumCore.Enums;
using SeleniumCore.Models;

namespace SeleniumCore.DriverUtils
{
    public class DriverFactory
    {
        public IWebDriver GetWebDriver(WebDriverConfiguration config)
        {
            switch(config.BrowserName)
            {               
                case BrowserName.IE:
                    var IEOptions = WebDriverSettings.InternetExplorerOptions(config);
                    InternetExplorerDriver IEDriver = new InternetExplorerDriver(IEOptions);
                    IEDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(60));
                    return IEDriver;


                case BrowserName.Edge:
                    var edgeOptions = WebDriverSettings.EdgeOptions(config);
                    EdgeDriver EdgeDriver = new EdgeDriver(edgeOptions);
                    EdgeDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(60));
                    return EdgeDriver;

                default: //BrowserName.Chrome
                    var chromeOptions = WebDriverSettings.ChromeOptions(config);
                    // ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);                                      
                    var chromeDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                    chromeDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(60));
                    return chromeDriver;
            }
        }
    }
}
