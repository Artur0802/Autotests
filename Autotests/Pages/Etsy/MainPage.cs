using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Autotests.Pages.Etsy
{
    public class MainPage
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void MoveSubmenuItem(IWebElement menuItem, IWebElement subMenuItem)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(menuItem).Perform();
            actions.MoveToElement(subMenuItem).Click().Perform();
        }

        public IWebElement ClothingAndShoesMenuItem => _driver.FindElement(By.Id("catnav-primary-link-10923"));
        public IWebElement WomensBootsMenuItem => _driver.FindElement(By.Id("catnav-l4-10935"));
    }
}
