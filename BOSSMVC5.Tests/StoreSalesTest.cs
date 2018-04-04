using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace BOSSMVC5.Tests
{
    [TestClass]
    public class StoreSalesTest
    {

        /// FOUNTAIN SCREEN TESTS ------------------------------------------------------
        /// <summary>
		/// Tests the "Fountain" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenFountain()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-1").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Daily View Month" dropdown on Fountain Screen in Store Sales.
		/// </summary>
        [TestMethod]
        public void FDailyViewMonth()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementById("select-1").Click();
            int n = th.randomInt(1, 12);

            chromeDriver.FindElementByXPath("//select[@id='sales-daily-month-select']/option[@value='" + n + "']").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Daily View Year" dropdown on Fountain Screen in Store Sales.
		/// </summary>
        [TestMethod]
        public void FDailyViewYear()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            chromeDriver.FindElementById("select-1").Click();
            int n = th.randomInt(1, 12);

            chromeDriver.FindElementByXPath("//select[@id='sales-daily-year-select']/option[contains(@value, '20')]").Click();
            //th.QuitDriver();
        }


        /// <summary>
        /// Tests the "Beer & Wine" link on Store Sales screen
        /// </summary>
        [TestMethod]
        public void OpenBeerWine()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-2").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Supplies" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenSupplies()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-3").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Cig Pack" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenCigPack()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-4").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Cig Carton" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenCigCarton()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-5").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Lotto" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenLotto()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-6").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Propane" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenPropane()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-7").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Packaged Beverage" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenPackageBeverage()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-8").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Coffee" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenCoffee()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-9").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the "Phone Card" link on Store Sales screen
		/// </summary>
        [TestMethod]
        public void OpenPhoneCard()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();

            chromeDriver.FindElementById("select-10").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the functionality of the Store Sales Gross input in the Daily View table. 
        /// The test randomly selects a category, month, and year and updates the Daily View Table’s Gross Value.
		/// </summary>
        [TestMethod]
        public void StoreSalesDailyGross()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            // Se vilect random Categoryew
            int n1 = th.randomInt(1, 10);
            chromeDriver.FindElementById("select-" + n1).Click();
            // Select random daily view of Month 
            int n2 = th.randomInt(1, 3);
            chromeDriver.FindElementByXPath("//select[@id='sales-daily-month-select']/option[@value='" + n2 + "']").Click();
            // Select daily view of Year in 2018 (bc there is data)
            chromeDriver.FindElementByXPath("//select[@id='sales-daily-year-select']/option[@value='2018']").Click();
            // Update Daily View Table Gross Value
            chromeDriver.FindElementByXPath("//td[contains(@id, 'Gross-dis')]").Click();
            chromeDriver.FindElementById("numInput").Clear();
            chromeDriver.FindElementById("numInput").SendKeys("560");
            chromeDriver.FindElementByXPath("//td[contains(@id, 'Gross-upd')]/span[contains(text(), 'Save')]").Click();
            //th.QuitDriver();
        }

        /// <summary>
		/// Tests the functionality of the Store Sales Net input in the Daily View table. 
        /// The test randomly selects a category, month, and year and updates the Daily View Table’s Net Value.
		/// </summary>
        [TestMethod]
        public void StoreSalesDailyNet()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            // Select random Category view
            int n1 = th.randomInt(1, 10);
            chromeDriver.FindElementById("select-" + n1).Click();
            // Select random daily view of Month 
            int n2 = th.randomInt(1, 3);
            chromeDriver.FindElementByXPath("//select[@id='sales-daily-month-select']/option[@value='" + n2 + "']").Click();
            // Select daily view of Year in 2018 (bc there is data)
            chromeDriver.FindElementByXPath("//select[@id='sales-daily-year-select']/option[@value='2018']").Click();
            // Update Daily View Table Gross Value
            chromeDriver.FindElementByXPath("//td[contains(@id, 'Net-dis')]").Click();
            chromeDriver.FindElementById("numInput").Clear();
            chromeDriver.FindElementById("numInput").SendKeys("560");
            chromeDriver.FindElementByXPath("//td[contains(@id, 'Net-upd')]/span[contains(text(), 'Save')]").Click();
            th.QuitDriver();
        }

        /// <summary>
		/// Tests the Store Sales Screen by randomly selecting a category view, randomly selecting a daily view of the month and year, 
        /// and tests the Fountain Gross and Fountain Net insert.
		/// </summary>
        [TestMethod]
        public void RandomStoreSalesYearly()
        {
            TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/Sales/Sales/");
            RemoteWebDriver chromeDriver = th.GetChromeDriver();
            // Select random Category view
            int n1 = th.randomInt(1, 10);
            chromeDriver.FindElementById("select-" + n1).Click();
            chromeDriver.FindElementByCssSelector("td[onclick*='displayCategoryMonthly(2016)']").Click();
            //th.QuitDriver();
        }
    }
}