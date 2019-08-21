using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyFramework.Infrastructure.Pages
{
    public class HaveYourSayPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "(//h2[@id='featured-contents']/following-sibling::div//a)[1]")]
        public IWebElement DoYouHaveStory { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.bbc.com/news']")]
        private IWebElement NewsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='gel-long-primer gs-u-ph']")]
        private IWebElement MoreLink { get; set; }

        [FindsBy(How = How.XPath, Using = ("//a[@href='/news/have_your_say']"))]
        private IWebElement HaveYourSayLink { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@class='gel-great-primer gs-u-display-inline-block gs-u-mv gs-u-pb--']"))]
        public IWebElement SearchText { get; set; }

        public HaveYourSayPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
        public void News_StoryPage()
        {
            NewsLink.Click();
            MoreLink.Click();
            HaveYourSayLink.Click();
            DoYouHaveStory.Click();
        }
    }
}
