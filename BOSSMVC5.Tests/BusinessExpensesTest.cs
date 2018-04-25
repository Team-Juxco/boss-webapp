using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BOSSMVC5.Tests
{
    [TestClass]
    public class BusinessExpensesTest
    {
        /// <summary>
		/// The test randomly selects a month from the dropdown menu.
		/// </summary>
        [TestMethod]
        public void ViewMonth()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementById("month-select").Click();
            int n = th.randomInt(1, 12);
            chromeDriver.FindElementByXPath("//select[@id='month-select']/option[@value='" + n + "']").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// The test randomly selects a year from the dropdown menu.
		/// </summary>
        [TestMethod]
        public void ViewYear()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementById("year-select").Click();
            chromeDriver.Keyboard.SendKeys(Keys.Down);
            chromeDriver.Keyboard.SendKeys(Keys.Return);
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the inserting and saving of VendorID.
		/// </summary>
        [TestMethod]
        public void InsertVendorID()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementByXPath("//td[contains(@id, '-VendorId-dis')]").Click();
            chromeDriver.FindElementByXPath("//input[contains(@id, 'numInput')]").Clear();
            chromeDriver.Keyboard.SendKeys("116");
            chromeDriver.FindElementByXPath("//span[contains(@id, 'saveBut')]").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the inserting and saving of Date.
		/// </summary>
        [TestMethod]
        public void InsertDate()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementByXPath("//*[contains(@id, '-OnDate-dis')]").Click();
            chromeDriver.FindElementByXPath("//*[@id='datepicker']").Click();
            int n = th.randomInt(1, 4);
            int n2 = th.randomInt(1, 5);
            chromeDriver.FindElementByXPath("//*[@id='ui-datepicker-div']/table/tbody/tr[" + n + "]/td[" + n2 + "]/a").Click();
            chromeDriver.FindElementByXPath("//span[contains(@id, 'saveBut')]").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the inserting and saving of Date.
		/// </summary>
        [TestMethod]
        public void InsertDueDate()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();


            th.QuitDriver();
        }

        /// <summary>
		/// Tests the inserting and saving of Date.
		/// </summary>
        [TestMethod]
        public void InsertAccountNum()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementByXPath("//td[contains(@id, '-AccountNum-dis')]").Click();
            chromeDriver.FindElementByXPath("//input[contains(@id, 'numInput')]").Clear();
            chromeDriver.Keyboard.SendKeys("17");
            chromeDriver.FindElementByXPath("//span[contains(@id, 'saveBut')]").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the inserting and saving of Date.
		/// </summary>
        [TestMethod]
        public void InsertAmount()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementByXPath("//td[contains(@id, '-Amount-dis')]").Click();
            chromeDriver.FindElementByXPath("//input[contains(@id, 'numInput')]").Clear();
            chromeDriver.Keyboard.SendKeys("17.00");
            chromeDriver.FindElementByXPath("//span[contains(@id, 'saveBut')]").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the inserting and saving of a whole row. This test uses the keyboard to tab through each input to insert data. When arriving to the datepicker, 
        /// the test will randomly select a date.
		/// </summary>
        [TestMethod]
        public void InsertAll()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementByLinkText("Insert").Click();
            chromeDriver.FindElementByXPath("//input[contains(@id, 'ven-input')]").Click();
            chromeDriver.Keyboard.SendKeys("150");
            chromeDriver.Keyboard.SendKeys(Keys.Tab);
            int n = th.randomInt(1, 4);
            int n2 = th.randomInt(1, 5);
            chromeDriver.FindElementByXPath("//*[@id='ui-datepicker-div']/table/tbody/tr[" + n + "]/td[" + n2 + "]/a").Click();
            chromeDriver.FindElementByXPath("//input[contains(@id, 'on-date-input')]").Click();
            chromeDriver.Keyboard.SendKeys(Keys.Tab);
            n = th.randomInt(1, 4);
            n2 = th.randomInt(1, 5);
            chromeDriver.FindElementByXPath("//*[@id='ui-datepicker-div']/table/tbody/tr[" + n + "]/td[" + n2 + "]/a").Click();
            chromeDriver.FindElementByXPath("//input[contains(@id, 'due-date-input')]").Click();
            chromeDriver.Keyboard.SendKeys(Keys.Tab);
            chromeDriver.Keyboard.SendKeys("11");
            chromeDriver.Keyboard.SendKeys(Keys.Tab);
            chromeDriver.Keyboard.SendKeys("11.11");
            chromeDriver.FindElementByLinkText("Save").Click();
            th.QuitDriver();
        }
    }
}
