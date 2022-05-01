using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Pages.Etsy
{
    public class WomenBootsPage
    {
        private IWebDriver _driver;

        public WomenBootsPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public List<IWebElement> BootsInMainArea => _driver.FindElements(By
            .CssSelector("[data-search-results-container] img")).ToList();

        public List<IWebElement> BootsWithDiscount => _driver.FindElements(By
            .CssSelector("[data-search-results-container] [class *= 'search-collage-promotion-price']")).ToList();
    }
}
