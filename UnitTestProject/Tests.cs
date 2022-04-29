using Autotests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Globalization;

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
        public void VerifyDateFormat()
        {
            _driver.Url = "https://www.globalsqa.com/";
            var globalSqaPage = new GlobalsqaPage(_driver);

            var action = new Actions(_driver);

            action.MoveToElement(globalSqaPage.TestersHubMenu)
                .MoveToElement(globalSqaPage.DemoTestingSiteSubMenu)
                .MoveToElement(globalSqaPage.DatePickerMenuItem)
                .Click().Perform();

            var datePickerPage = new DatePickerPage(_driver);

            _driver.SwitchTo().Frame(datePickerPage.DatePickerFrame);

            datePickerPage.DateInputField.Click();
            datePickerPage.NextMonthButton.Click();
            datePickerPage.SetDayOfMonth(DateTime.Today.Day);

            var chosenDate = datePickerPage.DateInputField.GetAttribute("value");
            string expectedDateFormat = "MM/dd/yyyy";
            bool ifDateFormatValid = DateTime.TryParseExact(chosenDate, expectedDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

            Assert.IsTrue(ifDateFormatValid, $"The format of the date {chosenDate} doesn't meet the required format - {expectedDateFormat}");
        }

        [Test]
        public void VerifyItemsCountInColumns()
        {
            _driver.Url = "https://www.globalsqa.com/";
            var globalSqaPage = new GlobalsqaPage(_driver);

            var action = new Actions(_driver);

            action.MoveToElement(globalSqaPage.TestersHubMenu)
                .MoveToElement(globalSqaPage.DemoTestingSiteSubMenu)
                .Click().Perform();

            var demoTestingSitePage = new DemoTestingSitePage(_driver);

            int expecteditemsCountInColumns = 6;
            foreach (var column in demoTestingSitePage.Columns)
            {
                var itemsCountInColumns = column.FindElements(By.CssSelector(".price_footer")).Count;
                Assert.IsTrue(itemsCountInColumns == expecteditemsCountInColumns,
                    $"Items count {itemsCountInColumns} in column {column.FindElement(By.ClassName("price_column_title")).Text} doesn't equal {expecteditemsCountInColumns}");
            }
        }

        [Test]
        public void VerifyDownload()
        {
            _driver.Url = "https://www.globalsqa.com/";
            var globalSqaPage = new GlobalsqaPage(_driver);

            var action = new Actions(_driver);

            action.MoveToElement(globalSqaPage.TestersHubMenu)
                .MoveToElement(globalSqaPage.DemoTestingSiteSubMenu)
                .MoveToElement(globalSqaPage.ProgressBarMenuItem)
                .Click().Perform();

            var progressBarPage = new ProgressBarPage(_driver);

            _driver.SwitchTo().Frame(progressBarPage.DownloadFrame);
            progressBarPage.StartDownloadButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
            {
                Message = $"Downloading didn't get to Completed state after 15 seconds",
                PollingInterval = TimeSpan.FromSeconds(3)
            };

            string expectedProgressBarLabel = "Complete!";
            wait.Until(ExpectedConditions.TextToBePresentInElement(progressBarPage.ProgressBarLabel, expectedProgressBarLabel));

            Assert.IsTrue(progressBarPage.ProgressBarLabel.Text == expectedProgressBarLabel);
        }
        
        //[Test]
        //public void DropdownItemsCountCheck()
        //{
            //_driver.Url = "https://www.globalsqa.com/demo-site/select-dropdown-menu/";
            //var globalsqapage = new GlobalsqaPage(_driver);

            //int expectedItemsCount = 249;
            //int obtainedItemsCount = globalsqapage.CountryDropdown.FindElements(By.TagName("option")).Count;

            //Assert.IsTrue(obtainedItemsCount == expectedItemsCount, $"Obtained items count ({obtainedItemsCount}) doesn't equal expected items count ({expectedItemsCount})");
        //}

        //[Test]
        //public void NavigationCheck()
        //{
            //_driver.Url = "https://www.google.com";

            //var searchField = _driver.FindElement(By.CssSelector("input.gLFyf.gsfi"));
            //var searchButton = _driver.FindElement(By.CssSelector("div.FPdoLc.lJ9FBc .gNO89b"));
            //searchField.SendKeys("Selenium");
            //searchButton.Click();

            //var linkElement = _driver.FindElement(By.CssSelector("a[href = 'https://www.selenium.dev/']"));
            //linkElement.Click();

            //var expectedPageUrl = "https://www.selenium.dev/";
            //var obtainedPageUrl = _driver.Url;

            //Assert.IsTrue(obtainedPageUrl == expectedPageUrl, $"Obtained URL ({obtainedPageUrl}) doesn't equal expected URL ({expectedPageUrl})");
        //}

        //[Test]
        //public void LogInCheck()
        //{
            //_driver.Url = "https://mail.google.com/";

            //var emailInputField = _driver.FindElement(By.CssSelector("input[type = 'email']"));
            //var submitEmailButton = _driver.FindElement(By.CssSelector("#identifierNext button"));

            //emailInputField.SendKeys("testpurposeaqa@gmail.com");
            //submitEmailButton.Click();

            //var passwordInputField = _driver.FindElement(By.CssSelector("#password input"));
            //var submitPasswordButton = _driver.FindElement(By.CssSelector("#passwordNext button"));

            //passwordInputField.SendKeys("*TempPass!2022");
            //submitPasswordButton.Click();

            //var accountIcons = _driver.FindElements(By.CssSelector("a[aria-label *= 'testpurposeaqa@gmail.com']"));

            //Assert.IsTrue(accountIcons.Count > 0, "Login failed");
        //}
    }
}
