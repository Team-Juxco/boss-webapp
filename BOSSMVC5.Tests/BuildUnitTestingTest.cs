using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace BOSSMVC5.Tests
{
	/// <summary>
	/// The entry point class to ensure the testing environment is set up properly.
	/// This class should pass as it only instantiates a TestHelper class and opens the dashboard.
	/// </summary>
	[TestClass]
	public class BuildUnitTestingTest
	{
        [TestMethod]
		public void OpenDashboard()
		{
			TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/");
			RemoteWebDriver chromeDriver = th.GetChromeDriver();
			chromeDriver.Navigate().GoToUrl(th.GetURL());
			chromeDriver.Quit();
		}
    }
}
