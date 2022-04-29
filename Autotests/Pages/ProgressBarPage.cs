using OpenQA.Selenium;

namespace Autotests.Pages
{
    public class ProgressBarPage
    {
        private IWebDriver _driver;
        public ProgressBarPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement DownloadFrame => _driver.FindElement(By.CssSelector("[data-src $= 'progressbar/download.html']"));
        public IWebElement StartDownloadButton => _driver.FindElement(By.Id("downloadButton"));
        public IWebElement ProgressBarLabel => _driver.FindElement(By.CssSelector("div.progress-label"));
    }
}
