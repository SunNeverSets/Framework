using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;
namespace MyFramework.Infrastructure.Pages
{
    public class NewsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public NewsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            WaitUntilPageLoaded();
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/news']")]
        public IWebElement ToNewsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@href='/news/video_and_audio/headlines')[1]")]
        public IWebElement VideoLink { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@href='/news/business']//span)[1]")]
        public IWebElement BusinessLink { get; set; }


        private void WaitUntilPageLoaded()
        {
            _wait.Until(d => ToNewsLink.Displayed);
        }

    }
}
