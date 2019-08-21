using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyFramework.Infrastructure.Pages
{
    public class LoremIpsumPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement AmountOfSymbols { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='bytes']")]
        private IWebElement RadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        public IWebElement GenerateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='lipsum']/p")]
        public IWebElement GeneratedText { get; set; }
        public LoremIpsumPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        private void SetInfo(int amountOfSymbols)
        {
            AmountOfSymbols.Click();
            AmountOfSymbols.Clear();
            AmountOfSymbols.SendKeys(amountOfSymbols.ToString());
            RadioButton.Click();
        }
        public string GetGeneratedSymbols()
        {
            _driver.Navigate().GoToUrl("https://www.lipsum.com/");
            SetInfo(140);
            GenerateButton.Click();
            string s = GeneratedText.Text;
            return s;
        }
    }
}
