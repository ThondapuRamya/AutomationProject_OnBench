using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumCore.Enums;
using SeleniumCore.LoggerUtils;
using System.Runtime.CompilerServices;
using LogLevel = SeleniumCore.Enums.LogLevel;

namespace SeleniumCore.Common
{
    public static class ExtensionActions
    {
        public static Ilogger logger = LoggerFactory.logger;
        public static IWebElement GetElement(this IWebDriver webDriver, By locator)
        {
            bool staleElement = true;
            int count = 0;
            while (staleElement && count < 2)
            {
                try
                {
                   return webDriver.FindElement(locator);
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                    count++;
                }
                catch (Exception e)
                {
                    logger.Log(LogLevel.Info, "unexpected error occurred while loading web element");
                    throw new Exception(e.Message + " unexpected error occurred while loading web element");

                }
            }
            throw new Exception("Could not get the web element with locator " + locator);

        }

        public static void ScrollElementIntoView(this IWebDriver driver,IWebElement webElement)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: \"smooth\", block: \"center\", inline: \"nearest\"});", webElement);

        }
        private static Actions GetActions(IWebDriver driver) 
        {
            Actions actions= new Actions(driver);
            return actions;
        }
        public static void MoveToElementAndClick(this IWebDriver driver , IWebElement webElement)
        {
            Actions actions = GetActions(driver);
            actions.MoveToElement(webElement).Click().Build().Perform();
        }

        public static void DoubleClick(this IWebDriver driver , IWebElement webElement)
        {
            Actions actions = GetActions(driver);
            actions.DoubleClick(webElement).Build().Perform();
        }

        public static void Click(this IWebDriver driver , IWebElement webElement)
        {

            try
            {
                if (webElement == null)
                {
                    logger.Log(LogLevel.Error, "Web element is null");
                }
                webElement.Click();
            }
            catch (ElementClickInterceptedException e)
            {
                driver.ScrollElementIntoView(webElement);
                webElement.Click();
            }
        }

        public static void SetText(this IWebElement webElement, string text)
        {
            if (webElement == null)
                logger.Log(LogLevel.Error,"Element is null");
            else
            {
                webElement.Clear();
                webElement.Click();
                webElement.SendKeys(text);
            }
        }
    }
}
