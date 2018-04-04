using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace BOSSMVC5.Tests
{
	/// <summary>
	/// Wrapper class for all Selenium-based tests. 
	/// Helps abstract the implenetation of the RemoteWebDriver, as well as querying the database.
	/// </summary>
	class TestHelper
	{

		/// <summary>
		/// The link for the page being tested
		/// </summary>
		private string URL;
		public string GetURL() { return URL; }
		public void SetURL(string URL) { this.URL = URL; }

		private RemoteWebDriver driver;

		/// <summary>
		/// Create a new TestHelper object to drive the Selenium testing with reduced redundancy.
		/// </summary>
		/// <param name="URL">The link to the page being tested for this object</param>
		public TestHelper(string URL)
		{
			this.URL = URL;
		}

		/// <summary>
		/// Instantiates and returns a Chrome-based web driver to be used for Selenium testing.
		/// Also, this function will open the page specified by this object's URL field.
		/// </summary>
		/// <returns>RemoteWebDriver - the Chrome Driver to be used in Selenium testing</returns>
		public RemoteWebDriver GetChromeDriver()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl(URL);
			driver.Manage().Window.Maximize(); // TODO: Testing for mobile TBD
			return driver;
		}

		/// <summary>
		/// Attempts to close and dispose the current driver. Returns false if unable to do so.
		/// </summary>
		/// <returns>bool - false if unable to close and/or dispose the current driver</returns>
		public bool QuitDriver()
		{
			try
			{
				driver.Quit();
				return true;
			} catch(System.Exception)
			{
				return false;
			}
		}

        /// <summary>
		/// Selects a random int between a min and max.
		/// </summary>
        public int randomInt(int min, int max)
        {
            Random r = new Random();
            int n = r.Next(min, max);
            return n;
        }


	}
}
