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
    public class ReportingTest
    {
        /// <summary>
		/// Tests reporting of all features. This test clicks on each page and exports the reports.
		/// </summary>
        [TestMethod]
        public void Reporting()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Reporting/Index/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementByLinkText("Fuel Sales Report").Click();
            chromeDriver.FindElementByLinkText("Export").Click();
            chromeDriver.FindElementByLinkText("Back").Click();
            chromeDriver.FindElementByLinkText("Fuel Inventory Report").Click();
            chromeDriver.FindElementByLinkText("Export").Click();
            chromeDriver.FindElementByLinkText("Back").Click();
            chromeDriver.FindElementByLinkText("Store Sales Report").Click();
            chromeDriver.FindElementByLinkText("Export").Click();
            chromeDriver.FindElementByLinkText("Back").Click();
            chromeDriver.FindElementByLinkText("CStore Report").Click();
            chromeDriver.FindElementByLinkText("Export").Click();
            chromeDriver.FindElementByLinkText("Back").Click();
            chromeDriver.FindElementByLinkText("Restaurant Inventory Report").Click();
            chromeDriver.FindElementByLinkText("Export").Click();
            chromeDriver.FindElementByLinkText("Back").Click();
            chromeDriver.FindElementByLinkText("Business Expenses Report").Click();
            chromeDriver.FindElementByLinkText("Export").Click();
            chromeDriver.FindElementByLinkText("Back").Click();
            th.QuitDriver();
        }

    }
}
