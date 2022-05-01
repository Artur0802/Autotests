using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Pages.Etsy
{
    public class CartPage
    {
        private IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string OrderTotalText => _driver.FindElement(By.XPath("//h1[contains(text(), 'Total')]"))
            .GetAttribute("textContent");

        public string OrderTotalPrice => _driver.FindElement(By
            .CssSelector("h1.wt-text-title-01 .currency-value")).GetAttribute("textContent");
    }
}
