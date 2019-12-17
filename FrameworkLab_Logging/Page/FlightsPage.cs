using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkLab
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
		[FindsBy(How = How.XPath, Using = "//span[@translate='foh.home.flight_search_errors.departure_required']")]
		private IWebElement errorDepartureTooltip;
		[FindsBy(How = How.XPath, Using = "//span[@translate='foh.home.flight_search_errors.destination_required']")]
		private IWebElement errorDestinationTooltip;
		[FindsBy(How = How.XPath, Using = "//div[@ng-show='type=='dropdown'']")]
		private IWebElement dropdown;
		[FindsBy(How = How.XPath, Using = "//button[@data-ref='core-inc-dec-increment']")]
		private IWebElement incrementButton;
		[FindsBy(How = How.XPath, Using = "//div[@ng-class='{'shown':paxInput.showMaxPassengersAlert}']")]
		private IWebElement messageMaxPassengersAlert;

		public FlightsPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
		
		public FlightsPage EnterCityToAirportField(string city, string airportName)
		{
			Logger.Log.Info("EnterCityToAirportField method");
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
			Logger.Log.Info("ClickButtonContinue() method");
			buttonContinue.Click();
            return this;
        }

		public FlightsPage ClickDropdown()
		{
			Logger.Log.Info("ClickDropdown() method");
			dropdown.Click();
			return this;
		}

		public string GetErrorIncrementTooltip()
		{
			Logger.Log.Info("GetErrorIncrementTooltip() method");
			int maxCount = 25;
			for (int i = 1; i < maxCount; i++)
			{
				incrementButton.Click();
			}
			return messageMaxPassengersAlert.Text;
		}

		public string ErrorTooltipFromFlightsPage()
        {
			Logger.Log.Info("ErrorTooltipFromFlightsPage() method");
			return errorTooltip.Text;
        }

		public string GetErrorDestinationTooltip()
		{
			Logger.Log.Info("GetErrorDestinationTooltip() method");
			return errorDestinationTooltip.Text;
		}

		public string GetErrorDepartureTooltip()
		{
			Logger.Log.Info("GetErrorDepartureTooltipTooltip() method");
			return errorDepartureTooltip.Text;
		}
	}
}
