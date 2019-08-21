using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace MyFramework.Infrastructure.Pages
{
    class DoYouHaveAStoryPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//textarea")]
        private IWebElement FieldForGeneratedText { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button']")]
        private IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message'][contains(text(),'Name')]")]
        public IWebElement ErrorName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message'][contains(text(),'Email')]")]
        public IWebElement ErrorEmail { get; set; }

        public DoYouHaveAStoryPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void Submit()
        {
            SubmitButton.Click();
        }
                      
        public void FillForm(Dictionary<string, string> dict)
        {
            var actions = new Actions(_driver);
            actions.Click(FieldForGeneratedText)
                .SendKeys(dict["text"] + Keys.Tab)
                .SendKeys(dict["name"] + Keys.Tab)
                .SendKeys(dict["email"] + Keys.Tab)
                .SendKeys(dict["age"] + Keys.Tab)
                .SendKeys(dict["postcode"])
                .Build()
                .Perform();
        }
    }
}
