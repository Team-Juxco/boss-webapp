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
		[TestMethod]
		public void TestMethod1()
		{
			RemoteWebDriver driver;
			string url = "http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/";
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl(url);
			Console.WriteLine("Hello World!");
		}
	}
}
