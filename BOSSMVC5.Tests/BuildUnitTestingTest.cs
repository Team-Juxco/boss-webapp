using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace BOSSMVC5.Tests
{
	/// <summary>
	/// The entry point class to ensure the testing environment is set up properly.
	/// This class should pass as it only instantiates a TestHelper class and opens the dashboard.
	/// </summary>
	[TestClass]
	public class BuildUnitTestingTest
	{
		/// <summary>
		/// Instantiates a TestHelper object, grabs a chrome driver, and then opens the dashboard.
		/// </summary>
        [TestMethod]
		public void OpenDashboard()
		{
			TestHelper th = new TestHelper("http://teamjuxcoboss-env.us-west-1.elasticbeanstalk.com/");
			RemoteWebDriver chromeDriver = th.GetChromeDriver();
			th.QuitDriver();
		}
    }
}
