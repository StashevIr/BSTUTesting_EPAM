using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Opera;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkLab
{
	public class DriverSingleton
	{
		private static IWebDriver driver;

		private DriverSingleton() { }

		public static IWebDriver GetDriver()
		{
			if (driver == null)
			{
				switch(TestContext.Parameters.Get("browser"))
				{
					case "opera":
						new DriverManager().SetUpDriver(new OperaConfig());
						driver = new OperaDriver();
						break;

					case "edge":
						new DriverManager().SetUpDriver(new EdgeConfig());
						driver = new EdgeDriver();
						break;
					default:
						new DriverManager().SetUpDriver(new ChromeConfig());
						driver = new ChromeDriver();
						break;
				}
				driver.Manage().Window.Maximize();
			}
			return driver;
		}

		public static void CloseDriver()
		{
			driver.Quit();
			driver = null;
		}
	}
}
