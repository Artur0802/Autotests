using Autotests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class Tests
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void BeforeEveryTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterEveryTest()
        {
            _driver.Quit();
        }
        
        [Test]
        public void DropdownItemsCountCheck()
        {
            _driver.Url = "https://www.globalsqa.com/demo-site/select-dropdown-menu/";
            var globalsqapage = new GlobalsqaPage(_driver);

            int expectedItemsCount = 249;
            int obtainedItemsCount = globalsqapage.CountryDropdown.FindElements(By.TagName("option")).Count;

            Assert.IsTrue(obtainedItemsCount == expectedItemsCount, $"Obtained items count ({obtainedItemsCount}) doesn't equal expected items count ({expectedItemsCount})");
        }

        [Test]
        public void NavigationCheck()
        {
            _driver.Url = "https://www.google.com";

            var searchField = _driver.FindElement(By.CssSelector("input.gLFyf.gsfi"));
            var searchButton = _driver.FindElement(By.CssSelector("div.FPdoLc.lJ9FBc .gNO89b"));
            searchField.SendKeys("Selenium");
            searchButton.Click();

            var linkElement = _driver.FindElement(By.CssSelector("a[href = 'https://www.selenium.dev/']"));
            linkElement.Click();

            var expectedPageUrl = "https://www.selenium.dev/";
            var obtainedPageUrl = _driver.Url;

            Assert.IsTrue(obtainedPageUrl == expectedPageUrl, $"Obtained URL ({obtainedPageUrl}) doesn't equal expected URL ({expectedPageUrl})");
        }

        [Test]
        public void LogInCheck()
        {
            _driver.Url = "https://mail.google.com/";

            var emailInputField = _driver.FindElement(By.CssSelector("input[type = 'email']"));
            var submitEmailButton = _driver.FindElement(By.CssSelector("#identifierNext button"));

            emailInputField.SendKeys("testpurposeaqa@gmail.com");
            submitEmailButton.Click();

            var passwordInputField = _driver.FindElement(By.CssSelector("#password input"));
            var submitPasswordButton = _driver.FindElement(By.CssSelector("#passwordNext button"));

            passwordInputField.SendKeys("*TempPass!2022");
            submitPasswordButton.Click();

            var accountIcons = _driver.FindElements(By.CssSelector("a[aria-label *= 'testpurposeaqa@gmail.com']"));

            Assert.IsTrue(accountIcons.Count > 0, "Login failed");
        }
    }
}
