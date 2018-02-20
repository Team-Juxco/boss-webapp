using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace BOSSMVC5.Tests
{
	class TestHelper
	{

		/// <summary>
		/// The link for the page being tested
		/// </summary>
		private string URL;
		public string GetURL() { return URL; }
		public void SetURL(string URL) { this.URL = URL; }

		/// <summary>
		/// Create a new TestHelper object to drive the Selenium testing with reduced redundancy 
		/// </summary>
		/// <param name="URL">The link to the page being tested for this object</param>
		public TestHelper(string URL)
		{
			this.URL = URL;
		}

		/// <summary>
		/// Instantiates and returns a Chrome-based web driver to be used for Selenium testing.
		/// Also, this function will open the page specified by this object's URL field
		/// </summary>
		/// <returns>RemoteWebDriver - the Chrome Driver to be used in Selenium testing</returns>
		public RemoteWebDriver GetChromeDriver()
		{
			RemoteWebDriver driver;
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl(URL);
			return driver;
		}
	}
}
