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
    class BusinessExpensesTest
    {
        /// <summary>
		/// Tests the Month dropdown on the Business Expenses screen.
		/// </summary>
        [TestMethod]
        public void ViewMonth()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/BusinessExp/BusinessExp/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementById("month-select").Click();
            int n = th.randomInt(1, 12);

            //chromeDriver.FindElementByXPath("//select[@id='sales-daily-month-select']/option[@value='" + n + "']").Click();
            //th.QuitDriver();
        }
    }
}
