using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace MyFramework.Infrastructure.Pages
{
    public class HaveYourSayPage
    {
        public HaveYourSayPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/news']")]
        private IWebElement NewsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='gel-long-primer gs-u-ph']")]
        private IWebElement MoreLink { get; set; }

        [FindsBy(How = How.XPath, Using = ("//a[@href='/news/have_your_say']"))]
        private IWebElement HaveYourSayLink { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@class='gel-great-primer gs-u-display-inline-block gs-u-mv gs-u-pb--']"))]
        public IWebElement SearchText { get; set; }

        public void News_HaveYourSay()
        {
            NewsLink.Click();
            MoreLink.Click();
            HaveYourSayLink.Click();
        }
    }
}
