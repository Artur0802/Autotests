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
        
        public IWebElement CountryDropdown => _driver.FindElement(By.XPath("//div[@rel-title = 'Select Country']//select"));
        
    }
}
