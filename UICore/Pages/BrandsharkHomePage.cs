using OpenQA.Selenium;
using SeleniumCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UICore.Pages
{
    public class BrandsharkHomePage:BasePage
    {
        public BrandsharkHomePage(IWebDriver driver) : base(driver) { }

        private IWebElement Name => driver.GetElement(By.Name("fname"));
        private IWebElement Company => driver.GetElement(By.XPath("//input[@placeholder='Company']"));

        private IWebElement Phone => driver.GetElement(By.Name("phone"));
        private IWebElement Email => driver.GetElement(By.Name("email"));
        private IWebElement SubmitBtn => driver.GetElement(By.XPath("//input[@value='Submit']"));
        private IWebElement ThankYouConfirmationMessage => driver.GetElement(By.XPath("//h1[text()='Thank You for Connecting with Brandshark.']"));
        private IWebElement LetsGetStartedSession => driver.GetElement(By.XPath("//span[text()=' Started']"));
        public void SetName(string value)
        {
            WebDriverWait.Until(drv => driver.FindElement(By.Name("fname")).Displayed);
            Name.SetText(value);
        }

        public void SetCompany(string value)
        {
            WebDriverWait.Until(drv=> Company.Displayed);
            Company.SetText(value);
        }

        public void SetPhone(string value)
        {
            WebDriverWait.Until(drv=>  Phone.Displayed);
            Phone.SetText(value);
        }

        public void SetEmail(string value)
        {
            WebDriverWait.Until(drv=>  Email.Displayed);
            Email.SetText(value);
        }

        public void ClickOnSubmit()
        {
            WebDriverWait.Until(drv=> SubmitBtn.Displayed);
            driver.Click(SubmitBtn);
          
            WebDriverWait.Until(drv => driver.FindElement(By.XPath("//h1[text()='Thank You for Connecting with Brandshark.']")).Displayed);
        }

        public void ValidateNewWindowIsOpenedWithurlContainsAndSwitchToWindow(string expectedUrlText)
        {
            var allWindows = driver.WindowHandles;
            var currentWindowHandle = driver.CurrentWindowHandle;

            foreach (var windowHandle in allWindows)
            {
                if (windowHandle != currentWindowHandle)
                    driver.SwitchTo().Window(windowHandle);
                if (driver.Url.Contains(expectedUrlText))
                    break;
            }            
        }

        public void SwitchToDefaultWindow()
        {
            driver.SwitchTo().DefaultContent();       
        }

        public bool ValidateLetsGetStartedSessionIsDisplayed()
        {
            driver.ScrollElementIntoView(LetsGetStartedSession);
            return LetsGetStartedSession.Displayed;
        }
    }
}
