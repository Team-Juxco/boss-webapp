using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BOSSMVC5.Tests
{
    [TestClass]
    public class C_StoreInventoryTest
    {

        /// <summary>
		/// Order by Headings test - Clicks on each column heading which orders the rows respectively
		/// </summary> 
        [TestMethod]
        public void OrderByColumns()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByLinkText("Id").Click();
            chromeDriver.FindElementByLinkText("Category").Click();
            chromeDriver.FindElementByLinkText("Description").Click();
            chromeDriver.FindElementByLinkText("Stock").Click();
            chromeDriver.FindElementByLinkText("Sale Price").Click();
            chromeDriver.FindElementByLinkText("List Price").Click();
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Id column.
        /// </summary> 
        [TestMethod]
        public void IdColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-id-display')]").Click();
            chromeDriver.Keyboard.SendKeys("700235");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Category column.
        /// </summary> 
        [TestMethod]
        public void CategoryColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-category-display')]").Click();
            chromeDriver.FindElementByXPath("//select[@id='category']").Click();
            // chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            //th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Description column.
        /// </summary> 
        [TestMethod]
        public void DescriptionColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-description-display')]").Click();
            chromeDriver.Keyboard.SendKeys("Hot Cheetos");

            //th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Stock column.
        /// </summary> 
        [TestMethod]
        public void StockColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-stock-display')]").Click();
            chromeDriver.Keyboard.SendKeys("82");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Stock column.
        /// </summary> 
        [TestMethod]
        public void SalePriceColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-price-display')]").Click();
            chromeDriver.Keyboard.SendKeys("1.00");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Stock column.
        /// </summary> 
        [TestMethod]
        public void ListPriceColumnInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, '-cost-display')]").Click();
            chromeDriver.Keyboard.SendKeys("1.99");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }

        /// <summary>
        ///  Tests the inserting and saving of the Stock column.
        /// </summary> 
        [TestMethod]
        public void InsertButton()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/CStoreInventory/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[contains(@id, 'insert-button')]").Click();

        }

    }
}
