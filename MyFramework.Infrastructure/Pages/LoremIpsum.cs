using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyFramework.Infrastructure.Pages
{
    public class LoremIpsum
    {
        private readonly IWebDriver _driver;
        public LoremIpsum(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement AmountOfSymbols { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='bytes']")]
        private IWebElement RadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        public IWebElement GenerateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='lipsum']/p")]
        public IWebElement GeneratedText { get; set; }

        public void SetInfo(int amountOfSymbols)
        {
            AmountOfSymbols.Click();
            AmountOfSymbols.Clear();
            AmountOfSymbols.SendKeys(amountOfSymbols.ToString());
            RadioButton.Click();
        }
    }
}
