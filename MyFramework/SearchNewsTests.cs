using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using MyFramework.Infrastructure.Pages;
using System;
using System.Collections.Generic;

namespace MyFramework
{
    [TestClass]

    public class Submit
    {
        private IWebDriver _driver;
        [TestInitialize()]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
        }
        [TestMethod]
        public void TestSubmit()
        {
            var main = new ComplexLIandHYS(_driver);
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["text"] = main.loremIpsum(),
                ["name"] = "Vova",
                ["email"] = "vova.shulga2011@gmail.com",
                ["age"] = "22",
                ["postcode"] = "123456",
            };

            //Act
            main.FillForm(dict, true);
        }
    }
    [TestClass]
    public class Tests
    {
        private IWebDriver _driver;

        [TestInitialize()]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void SearchNews()
        {
            //Arrange
            _driver.Navigate().GoToUrl("https://www.bbc.com/");
            _driver.Manage().Window.Maximize();
            var searchText = "Ukraine";

            //Act
            var bbcHomePage = new HomePageBBC(_driver);
            bbcHomePage.SearchArticle(searchText);

            //Assert
            var resultsPage = new SearchResultsPage(_driver);
            Assert.AreEqual(searchText, resultsPage.GetSearchText());
        }

        [TestMethod]

        public void HaveYourSayLink()
        {
            //Arrange
            _driver.Navigate().GoToUrl("https://www.bbc.com/");
            _driver.Manage().Window.Maximize();
            var searchText = "Have Your Say";

            //Act
            var haveyoursay = new HaveYourSayPage(_driver);
            haveyoursay.News_HaveYourSay();
            
            //Assert
            var resultText = new HaveYourSayPage(_driver);
            Assert.AreEqual(searchText, resultText.SearchText.Text);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void LoremIpsumTest()
        {
            //Arrange
            _driver.Navigate().GoToUrl("https://www.lipsum.com/");
            _driver.Manage().Window.Maximize();

            //Act
            var lorIps = new LoremIpsum(_driver);
            lorIps.SetInfo(141);
            lorIps.GenerateButton.Click();
            var generatedText = lorIps.GeneratedText.Text;
            string newText = generatedText.Substring(0, generatedText.Length - 1);
            Console.WriteLine(newText);

            //Assert
            Assert.IsNotNull(newText);
        }

        [TestMethod]
        public void News()
        {
            //Arrange
            _driver.Navigate().GoToUrl("https://www.bbc.com/news");
            _driver.Manage().Window.Maximize();
            
            //Act
            var newsPage = new NewsPage(_driver);
            newsPage.BusinessLink.Click();

            //Assert
        }

        [TestMethod]
        public void Test()
        {
            //Arrange
            var main = new ComplexLIandHYS(_driver);
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["text"] = main.loremIpsum(),
                ["name"] = "",
                ["email"] = "vova.shulga2011@gmail.com",
                ["age"] = "22",
                ["postcode"] = "123456",
            };
            
            //Act
            main.FillForm(dict, false);
            
            //Assert
            Assert.AreEqual(main.GetErrorName(), "Name can't be blank");
        }
    }
}

