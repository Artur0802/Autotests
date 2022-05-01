using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autotests.Pages.Etsy
{
    public class ShoesProductPage
    {
        private IWebDriver _driver;

        public ShoesProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public SelectElement SizeDropdown => new SelectElement(_driver.FindElement(By
            .CssSelector("select[id*=variation-selector]")));

        public IWebElement AddToCardButton => _driver.FindElement(By
            .CssSelector("[data-add-to-cart-button] button"));

        public string Price => _driver.FindElement(By
            .XPath("//p[contains(text(), 'USD')]")).GetAttribute("textContent").Trim();
    }
}
