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
        /// <summary>
		/// Front end functionality tests -------------------------------------------------------------------------
		/// </summary>


        /// <summary>
		/// Tests the "Tank A" link on Fuel Inventory screen
		/// </summary>
        [TestMethod]
        public void OpenTankA()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/FuelInventory/A/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
           
            chromeDriver.FindElementByLinkText("Tank A").Click();

            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Tank B" link on Fuel Inventory screen
		/// </summary>
        [TestMethod]
        public void OpenTankB()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/FuelInventory/A/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByLinkText("Tank B").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the Editing of Recent Table Input
		/// </summary>
        [TestMethod]
        public void RecentTableInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/FuelInventory/A/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByXPath("//a[@href='#edit']").Click();
            //chromeDriver.FindElementByPartialLinkText("gallons").Click();             //works as well
            chromeDriver.Keyboard.SendKeys("12.00");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            //th.QuitDriver();
        }

        /// <summary>
		/// Tests the Editing of Recent Table Input of Tank A
		/// </summary>
        [TestMethod]
        public void RecentTableInputTankA()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/FuelInventory/A/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByLinkText("Tank A").Click();
            chromeDriver.FindElementByPartialLinkText("gallons").Click();
            chromeDriver.Keyboard.SendKeys("12.00");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the Editing of Recent Table Input of Tank B
		/// </summary>
        [TestMethod]
        public void RecentTableInputTankB()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/FuelInventory/A/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByLinkText("Tank B").Click();
            chromeDriver.FindElementByPartialLinkText("gallons").Click();
            chromeDriver.Keyboard.SendKeys("12.00");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the link to Individual Months in Past Year Table
        /// 
        /// Description: href will always be in form "YYYY-MM" Finds Element by looking for links that contain "-"
        /// 
		/// </summary>
        [TestMethod]
        public void OpenIndividualMonth()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/FuelInventory/A/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            
            chromeDriver.FindElementByXPath("//a[contains(@href, '-')]").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests editing of Individual month table
		/// </summary>
        [TestMethod]
        public void IndividualMonthInput()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/FuelInventory/A/2017-03");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementByPartialLinkText("gallons").Click();
            chromeDriver.Keyboard.SendKeys("6.00");
            chromeDriver.FindElementByCssSelector("input.forminput.formsubmit").Click();
            th.QuitDriver();
        }


        /// <summary>
		/// Back functionality tests -------------------------------------------------------------------------
		/// </summary>
    }
}
