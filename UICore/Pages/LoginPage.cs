using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UICore.Pages
{
    public class LoginPage :BasePage
    {
        public LoginPage(IWebDriver driver):base(driver) { }

        public void LaunchUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
