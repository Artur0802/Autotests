using OpenQA.Selenium;

namespace Autotests.Pages
{
    public class DatePickerPage
    {
        private IWebDriver _driver;

        public DatePickerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement DatePickerFrame => _driver.FindElement(By.CssSelector("[data-src $= 'datepicker/default.html']"));

        public IWebElement DateInputField => _driver.FindElement(By.CssSelector("input#datepicker"));
        public IWebElement NextMonthButton => _driver.FindElement(By.CssSelector("[data-handler = 'next']"));

        public void SetDayOfMonth(int dayNumber)
        {
            _driver.FindElement(By.XPath($"//a[text() = {dayNumber}]")).Click();
        }


    }
}
