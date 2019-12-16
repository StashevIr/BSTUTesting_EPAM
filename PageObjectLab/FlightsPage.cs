using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjectLab
{
    public class FlightsPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Departure airport']")]
        private IWebElement departureAirport;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Destination airport']")]
        private IWebElement destinationAirport;
        [FindsBy(How = How.XPath, Using = "//button[@class='core-btn-primary core-btn-block core-btn-big']")]
        private IWebElement buttonContinue;
        [FindsBy(How = How.XPath, Using = "//li[@class='ryanair-error-tooltip']")]
        private IWebElement errorTooltip;
        
        public FlightsPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
		
		public FlightsPage EnterCityToAirportField(string city, string airportName)
		{
			IWebElement airport;
			switch (airportName)
			{
				case "Departure Airport":
					airport = departureAirport;
					break;
				case "Destination Airport":
					airport = destinationAirport;
					break;
				default:
					airport = departureAirport;
					break;
			}
			airport.Clear();
			airport.SendKeys(city);
			return this;
		}

        public FlightsPage ClickButtonContinue()
        {
            buttonContinue.Click();
            return this;
        }

        public string ErrorTooltipFromFlightsPage()
        {
            return errorTooltip.Text;
        }
    }
}
