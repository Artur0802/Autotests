using OpenQA.Selenium;

namespace Autotests.Pages
{
    public class GlobalsqaPage
    {
        private IWebDriver _driver;

        public GlobalsqaPage(IWebDriver driver)
        {
            _driver = driver;
        }        

        public IWebElement TestersHubMenu => _driver.FindElement(By.CssSelector("#menu [href $= 'testers-hub/']"));
        public IWebElement DemoTestingSiteSubMenu => _driver.FindElement(By.CssSelector("#menu [href $= 'demo-site/']"));
        public IWebElement DatePickerMenuItem => _driver.FindElement(By.CssSelector("#menu [href $= 'datepicker/']"));
        public IWebElement ProgressBarMenuItem => _driver.FindElement(By.CssSelector("#menu [href $= 'progress-bar/']"));
    }
}
