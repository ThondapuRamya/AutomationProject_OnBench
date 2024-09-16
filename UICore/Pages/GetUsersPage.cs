using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCore.Common;

namespace UICore.Pages
{
    public class GetUsersPage :BasePage
    {
        public GetUsersPage(IWebDriver driver) : base(driver) { }
       
        private IWebElement RequiredHyperLink(string linkText)=> driver.GetElement(By.XPath($"//span[text()='{linkText}']"));
        private IWebElement VisitWebsite => driver.GetElement(By.XPath("//span[contains(text(),'Visit Website')]"));
        public void ClickOnGivenLink(string linkText)
        {
            driver.SwitchTo().Frame(0);         
            driver.Click(RequiredHyperLink(linkText));
            driver.SwitchTo().Frame(1);
            WebDriverWait.Until(drv=>VisitWebsite.Displayed);
        }

        public void ClickOnVisitWebsite()
        {
            driver.Click(VisitWebsite);
            driver.SwitchTo().DefaultContent();
        }

        
    }
}
