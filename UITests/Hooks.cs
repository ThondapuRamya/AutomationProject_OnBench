using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using SeleniumCore.DriverUtils;
using SeleniumCore.Enums;
using SeleniumCore.LoggerUtils;
using SeleniumCore.Models;
using UITests.Providers;
using LogLevel = SeleniumCore.Enums.LogLevel;

namespace UITests
{
    [Binding]
    public class Hooks
    {        
        private static readonly Ilogger logger = LoggerFactory.logger;
        private static WebDriverConfiguration driverConfig;
        private readonly IObjectContainer objectContainer;
        IWebDriver driver;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        void CreateLogger()
        {           

           LoggerFactory.logger = LoggerFactory.GetLogger(ConfigurationProvider.loggerConfiguration.LoggerName);
        }

        [BeforeScenario("UI")]
        public void GetDriverInstance()
        {
            try
            {
                driverConfig = ConfigurationProvider.driverConfiguration;
                driver = new DriverFactory().GetWebDriver(driverConfig);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, "Failed while creating web driver instance." + e.Message);
            }
      
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void DeleteDriverInstance() 
        {
            driver.Quit();
        }

       
    }
}