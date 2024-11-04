using OpenQA.Selenium;
using Reqnroll.BoDi;
using SeleniumCore.DriverUtils;
using SeleniumCore.LoggerUtils;
using SeleniumCore.Models;
using UITests.Providers;
using LogLevel = SeleniumCore.Enums.LogLevel;

namespace UITests
{
    public class BaseTest
    {
        protected IWebDriver driver;    
        private static readonly Ilogger logger = LoggerFactory.logger;

        public BaseTest(IObjectContainer objectContainer)
        {
          driver=  objectContainer.Resolve<IWebDriver>();
        }     
        
        public void PalindromeTest()
        {
            string input = "";
            for (int i = 0, j = input.Length; i < input.Length / 2; i++,j--)
            {
                if (input[i] == input[j])
                {

                }

            }
        }
    }
}
