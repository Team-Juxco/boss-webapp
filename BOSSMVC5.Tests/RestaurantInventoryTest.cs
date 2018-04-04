using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BOSSMVC5.Tests
{
    [TestClass]
    public class RestaurantInventoryTest
    {
        /// <summary>
        /// Order by Headings test - Clicks on each column heading which orders the rows respectively
        /// </summary> 
        [TestMethod]
        public void OrderByColumns()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/RestaurantInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByLinkText("Item").Click();
            chromeDriver.FindElementByLinkText("Cost").Click();
            chromeDriver.FindElementByLinkText("Sold For").Click();
            chromeDriver.FindElementByLinkText("Amount Sold").Click();
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Item column.
        /// </summary> 
        [TestMethod]
        public void ItemColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/RestaurantInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-item-display')]").Click();
            chromeDriver.Keyboard.SendKeys("Chorizo Burrito");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }
    }

}
