using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace BOSSMVC5.Tests
{
	/// <summary>
	/// Tests the navigation menu across all pages.
	/// </summary>
	[TestClass]
	public class MainNavigationTest
	{
		/// <summary>
		/// Tests the "Dashboard" link on every single page
		/// </summary>
		[TestMethod]
		public void TestDashboardNavigationLinks()
		{
			TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/");
			RemoteWebDriver chromeDriver = th.GetChromeDriver();

			// Dashboard -> Dashboard
			chromeDriver.FindElementByLinkText("Dashboard").Click();

			// Fuel Inventory -> Dashboard
			chromeDriver.FindElementByLinkText("Fuel Inventory").Click();
			chromeDriver.FindElementByLinkText("Dashboard").Click();

			th.QuitDriver();
		}
	}
}
