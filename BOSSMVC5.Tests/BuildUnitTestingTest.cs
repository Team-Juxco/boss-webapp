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
	public class BuildUnitTestingTest
	{
        // 
        // Dashboard Navigation Link TestMethods
        //

        

        [TestMethod]
		public void DashboardLink()
		{
			RemoteWebDriver driver;
			string url = "http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/";
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElementByLinkText("Dashboard").Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);



            //driver.Quit();
		}

        
    }
}
