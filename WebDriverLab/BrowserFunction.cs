using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace WebDriverLab
{
    public abstract class BrowserFunction
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrowserAndGoToSite()
        {
            webDriver = new ChromeDriver(); 
            webDriver.Navigate().GoToUrl("https://www.ryanair.com/gb/en/");
        }

        [TearDown]
        public void QuitBrowser()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
