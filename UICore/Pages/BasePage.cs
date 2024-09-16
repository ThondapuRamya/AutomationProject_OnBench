using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UICore.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait WebDriverWait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            WebDriverWait.IgnoreExceptionTypes(typeof(WebDriverException));
        }
    }
}
