namespace MVC5App.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Chrome;
	using OpenQA.Selenium.Firefox;
	using OpenQA.Selenium.IE;
	using OpenQA.Selenium.Remote;
	using OpenQA.Selenium.PhantomJS;
	using System;

	[TestClass]
	public class TestUnitTest
	{
		private string baseURL = "http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/";
		private RemoteWebDriver driver;
		private string browser;
		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCategory("Selenium")]
		[Priority(1)]
		[Owner("Chrome")]

		public void TireSearch_Any()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
			driver.Navigate().GoToUrl(this.baseURL);
			driver.FindElementByLinkText("Dashboard").Click();
			//driver.FindElementById("search - box").Clear();
			//driver.FindElementById("search - box").SendKeys("tire");
			//do other Selenium things here!
		}

		[TestCleanup()]
		public void MyTestCleanup()
		{
			driver.Quit();
		}

		[TestInitialize()]
		public void MyTestInitialize()
		{
		}
	}
}