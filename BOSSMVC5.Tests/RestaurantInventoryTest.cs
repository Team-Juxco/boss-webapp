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

        /// <summary>
        ///  Tests the inserting and saving of the Cost column.
        /// </summary> 
        [TestMethod]
        public void CostColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/RestaurantInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-cost-display')]").Click();
            chromeDriver.Keyboard.SendKeys("1.99");
            chromeDriver.Keyboard.SendKeys(Keys.Return);
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Sold For column.
        /// </summary> 
        [TestMethod]
        public void SoldForColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/RestaurantInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-soldfor-display')]").Click();
            chromeDriver.Keyboard.SendKeys("1.00");
            chromeDriver.Keyboard.SendKeys(Keys.Return);
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Amount Sold column.
        /// </summary> 
        [TestMethod]
        public void AmountSoldColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/RestaurantInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-amountsold-display')]").Click();
            chromeDriver.Keyboard.SendKeys("9");
            chromeDriver.Keyboard.SendKeys(Keys.Return);
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of a whole row in the Restaurant Inventory.
        /// </summary> 
        [TestMethod]
        public void InsertButton()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/RestaurantInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, 'insert-button')]").Click();
            chromeDriver.FindElementByXPath("//tr/td/input[contains(@class, 'forminput')]").Click();
            chromeDriver.Keyboard.SendKeys("Aguachiles");
            chromeDriver.Keyboard.SendKeys(Keys.Tab);
            chromeDriver.Keyboard.SendKeys("4.00");
            chromeDriver.Keyboard.SendKeys(Keys.Tab);
            chromeDriver.Keyboard.SendKeys("3.00");
            chromeDriver.Keyboard.SendKeys(Keys.Tab);
            chromeDriver.Keyboard.SendKeys("50");
            chromeDriver.Keyboard.SendKeys(Keys.Return);
            th.QuitDriver();
        }
    }

}
