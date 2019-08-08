using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;

namespace MyFramework.Infrastructure.Pages
{
    public class HomePageBBC
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public HomePageBBC(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5)); 
            WaitUntilPageLoaded();
        }
        public void GoHome()
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com");
        }
        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/news']")]
        private IWebElement HomePageLink { get; set; }

        public void SearchArticle(string newsTitle)
        {
            SearchField.Click();
            SearchField.SendKeys(newsTitle);
            SearchButton.Click();
        }

        private void WaitUntilPageLoaded()
        {
            _wait.Until(d => HomePageLink.Displayed);
        }
    }
}
