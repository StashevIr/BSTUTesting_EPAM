using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectLab
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver webDriver;
        private const string url = "https://www.ryanair.com/gb/en/";

        [SetUp]
        public void OpenBrowserAndGoToSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(url);
        }

        [Test]
        public void EnterEqualDepartureAndDestinationAirport()
        {
            string city = "Warsaw Modlin";
            string errorTextForValidAirport = "Please enter a valid airport.";

            FlightsPage flightsPage = new FlightsPage(webDriver).
                ClearAirportFields().
                SendKeysToAirportFields(city).
                ClickButtonContinue();

            Assert.AreEqual(errorTextForValidAirport, flightsPage.ErrorTooltipFromFlightsPage());
        }

        [Test]
        public void EnterNonexistentHotel()
        {
            string hotel = "BSTU Hostel 5";
            string errorTextForDestination = "Please select a destination from the dropdown";

            HotelPage hotelPage = new HotelPage(webDriver).
                ClearDestinationField().
                SendKeysToDestinationField(hotel).
                SetDate().
                SendEnter();

            Assert.AreEqual(errorTextForDestination, hotelPage.EroorTooltipFromHotelPage());
        }
    }
}