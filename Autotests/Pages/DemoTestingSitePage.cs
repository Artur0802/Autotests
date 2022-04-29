using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Autotests.Pages
{
    public class DemoTestingSitePage
    {
        private IWebDriver _driver;

        public DemoTestingSitePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public List<IWebElement> Columns => _driver.FindElements(By.CssSelector("div[class ^= 'price_column']")).ToList();
    }
}
