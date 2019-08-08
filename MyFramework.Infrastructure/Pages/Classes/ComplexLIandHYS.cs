using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace MyFramework.Infrastructure.Pages
{
    public class ComplexLIandHYS
    {
        
        private readonly IWebDriver _driver;
        private HaveYourSayPage _haveYourSayPage;
        private LoremIpsum _lorem;

        public ComplexLIandHYS(IWebDriver driver)
        {
            _driver = driver;
            _lorem = new LoremIpsum(_driver);
            _haveYourSayPage = new HaveYourSayPage(_driver);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//h2[@id='featured-contents']/following-sibling::div//a)[1]")]
        public IWebElement DoYouHaveStory { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Age']")]
        public IWebElement Age { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Postcode']")]
        public IWebElement Postcode { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea")]
        public IWebElement FieldForGeneratedText { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button']")]
        private IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class=\"input-error-message\"][text()=\"Name can't be blank\"]")]
        private IWebElement ErrorName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message'][text()=\"Email adress can't be blank]")]
        private IWebElement ErrorEmail { get; set; }

        private void SetPrivacyInfo(Dictionary<string,string> dict)
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com");
            
            _haveYourSayPage.News_HaveYourSay();
            DoYouHaveStory.Click();
            FieldForGeneratedText.SendKeys(dict["text"]);
            Name.SendKeys(dict["name"]);
            Email.SendKeys(dict["email"]);
            Age.SendKeys(dict["age"]);
            Postcode.SendKeys(dict["postcode"]);
        }

        private void Submit()
        {
            SubmitButton.Click();
        }

        public string GetErrorName()
        {
            return ErrorName.Text; 
        }
        public string GetErrorEmail()
        {
            return ErrorEmail.Text;
        }

        public string GenerateSymbols(int size)
        {
            _lorem.SetInfo(size);
            _lorem.GenerateButton.Click();
            return _lorem.GeneratedText.Text;
        }
        public enum modes
        {
            MakeScreen,
            PressSubmit,
        }

        public string loremIpsum()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.lipsum.com/");
            _lorem.SetInfo(140);
            _lorem.GenerateButton.Click();
            string s = _lorem.GeneratedText.Text;
            return s;
        }

        private void MakeScreen()
        {
            Random random = new Random();
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshot.SaveAsFile("D:\\\\screenshots AT\\test" + random.Next(90) + ".png", OpenQA.Selenium.ScreenshotImageFormat.Png);
        }
        public void FillForm(Dictionary<string, string> dict, bool MakeScreenOrPressSubmit)
        {
           SetPrivacyInfo(dict);
           if (MakeScreenOrPressSubmit)
            {
                MakeScreen();
            }
           else
            {
                Submit();
            }
            System.Threading.Thread.Sleep(5000);
        }
    }
}
