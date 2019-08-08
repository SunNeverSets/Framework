using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;

namespace MyFramework.Infrastructure.Pages
{
    public class SearchResultsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SearchResultsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            WaitUntilPageLoaded();
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/news']")]
        private IWebElement homePageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='se-searchbox-input-field']")]
        private IWebElement searchResultsInput;

        /// <summary>
        /// Get text from global search text field
        /// </summary>
        /// <returns>string value</returns>
        public string GetSearchText()
        {
            return searchResultsInput.GetAttribute("value");
        }

        private void WaitUntilPageLoaded()
        {
            _wait.Until(d => homePageLink.Displayed);
        }
    }
}
