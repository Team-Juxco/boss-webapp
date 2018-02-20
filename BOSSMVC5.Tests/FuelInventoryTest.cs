using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BOSSMVC5.Tests
{
    [TestClass]
    public class FuelInventoryTest
    {
        public RemoteWebDriver StartBrowser()
        {
            RemoteWebDriver driver;
            string url = "http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            return driver;
        }
        

        [TestMethod]
        public void FuelInventoryLink()
        {
            RemoteWebDriver driver = StartBrowser();
            driver.FindElementByLinkText("Fuel Inventory").Click();
            
        }

        [TestMethod]
        public void RecentTableInput()
        {
            RemoteWebDriver driver = StartBrowser();
            driver.FindElementByLinkText("Fuel Inventory").Click();
            driver.FindElementById("February 7, 2018-display").Click();
            driver.Keyboard.SendKeys("1.00");
            driver.FindElementByName("Save").Click();
        }

        [TestMethod]
        public void DashboardLink()
        {
            RemoteWebDriver driver = StartBrowser();
            driver.FindElementByLinkText("Fuel Inventory").Click();

        }
    }
}
