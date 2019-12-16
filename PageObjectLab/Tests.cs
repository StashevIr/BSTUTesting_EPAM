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

            FlightsPage flightsPage = new FlightsPage(webDriver)
				.EnterCityToAirportField(city, "Departure Airport")
				.EnterCityToAirportField(city, "Destination Airport")
				.ClickButtonContinue();

            Assert.AreEqual("Please enter a valid airport.", flightsPage.ErrorTooltipFromFlightsPage());
        }

        [Test]
        public void EnterNonexistentHotel()
        {
            string hotel = "BSTU Hostel 5";

            HotelPage hotelPage = new HotelPage(webDriver)
				.EnterDestinationField(hotel)
				.SetDate_DayIn_DayOut_Mounth_Year("12", "20", "05", "2020")
				.Enter();

            Assert.AreEqual("Please select a destination from the dropdown", hotelPage.EroorTooltipFromHotelPage());
        }
    }
}