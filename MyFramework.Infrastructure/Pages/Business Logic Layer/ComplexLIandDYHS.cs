using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace MyFramework.Infrastructure.Pages
{
    public class ComplexLIandHYS
    {
        
        private readonly IWebDriver _driver;
        private HaveYourSayPage _haveYourSayPage;
        private LoremIpsumPage _lorem;
        private DoYouHaveAStoryPage _storyPage;

        public ComplexLIandHYS(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Window.Maximize();
            _lorem = new LoremIpsumPage(_driver);
            _storyPage = new DoYouHaveAStoryPage(_driver);
            _haveYourSayPage = new HaveYourSayPage(_driver);
        }

        public void GoToReportForm()
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com");
            _haveYourSayPage.News_StoryPage();
        }

        public string loremIpsum()
        {
            return _lorem.GetGeneratedSymbols();
        }

        private void MakeScreen()
        {
            Random random = new Random();
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshot.SaveAsFile("D:\\\\screenshots AT\\test" + random.Next(90) + ".png", OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        public void MakeScreenOrPressSubmit(Dictionary<string, string> dict, bool makeScreenOrPressSubmit)
        {
            GoToReportForm();
            _storyPage.FillForm(dict);
           if (makeScreenOrPressSubmit)
            {
                MakeScreen();
            }
           else
            {
                _storyPage.Submit();
            }
            System.Threading.Thread.Sleep(5000);
        }

        public string GetErrorName()
        {
            return _storyPage.ErrorName.Text;
        }

        public string GetErrorEmail()
        {
            return _storyPage.ErrorEmail.Text;
        }
    }
}
