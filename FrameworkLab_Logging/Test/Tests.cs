using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FrameworkLab
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver webDriver;
        private const string url = "https://www.ryanair.com/gb/en/";

        [SetUp]
        public void OpenBrowserAndGoToSite()
        {
			Logger.InitLogger();
			Logger.Log.Warn("Driver initializing...");
			webDriver = DriverSingleton.GetDriver();
            webDriver.Navigate().GoToUrl(url);
			Logger.Log.Info("Driver initialized.");
		}

		[Test]
		public void Login_OneCanLogin()
		{
			Logger.Log.Info("OneCanLogin() unit test starts.");
			User testUser = UserCreator.WithCredentialsFromProperty();
			string loggedInUserName = new LoginPage(webDriver)
				.Login(testUser)
				.GetLoggedInUserName();
			Assert.AreEqual(loggedInUserName, testUser.GetUsername());
		}

		[Test]
		public void Login_EnterNonRegistratedUsername()
		{
			Logger.Log.Info("EnterNonRegistratedUsername() unit test starts.");
			User testUser = UserCreator.WithNonRegistratedUsername();
			string errorMessage = new LoginPage(webDriver)
				.Login(testUser)
				.GetErrorMessage();
			Assert.AreEqual(errorMessage, "Invalid password. 0 attempts left");
		}

		[Test]
		public void Login_EnterErrorPassword()
		{
			Logger.Log.Info("EnterErrorPassword() unit test starts.");
			User testUser = UserCreator.WithErrorPassword();
			string errorMessage = new LoginPage(webDriver)
				.Login(testUser)
				.GetErrorMessage();
			Assert.AreEqual(errorMessage, "Invalid password. 4 attempts left");
		}

		[Test]
        public void EnterEqualDepartureAndDestinationAirport()
        {
			Logger.Log.Info("EnterEqualDepartureAndDestinationAirport() unit test starts.");

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
			Logger.Log.Info("EnterNonexistentHotel() unit test starts.");

            HotelPage hotelPage = new HotelPage(webDriver)
				.EnterDestinationField("BSTU Hostel 5")
				.SetDate_DayIn_DayOut_Mounth_Year("12", "20", "05", "2020")
				.Enter();

            Assert.AreEqual("Please select a destination from the dropdown", hotelPage.GetErrorTooltipFromHotelPage());
		}
		
		[Test]
		public void NonEnterDestinationAirport()
		{
			Logger.Log.Info("NonEnterDestinationAirport() unit test starts.");
			FlightsPage flightsPage = new FlightsPage(webDriver)
				.EnterCityToAirportField("Warsaw Modlin", "Departure Airport")
				.ClickButtonContinue();

			Assert.AreEqual("You have not selected a destination airport.Please tell us where you want to go.", flightsPage.GetErrorDestinationTooltip());
		}


		[Test]
		public void NonEnterDepartureAirport()
		{
			Logger.Log.Info("NonEnterDepartureAirport() unit test starts.");
			FlightsPage flightsPage = new FlightsPage(webDriver)
				.EnterCityToAirportField("", "Departure Airport")
				.EnterCityToAirportField("Warsaw Modlin", "Destination Airport")
				.ClickButtonContinue();

			Assert.AreEqual("You have not selected a departure airport.Please tell us where you'll be taking off from.", flightsPage.GetErrorDepartureTooltip());
		}

		[Test]
		public void EnterCountOfTicketsMoreThanPlaneCapacity()
		{
			Logger.Log.Info("EnterCountOfTicketsMoreThanPlaneCapacity() unit test starts.");

			FlightsPage flightsPage = new FlightsPage(webDriver)
				.EnterCityToAirportField("Warsaw Modlin", "Departure Airport")
				.EnterCityToAirportField("Kyiv", "Destination Airport")
				.ClickButtonContinue()
				.ClickDropdown();

			Assert.AreEqual("The maximum number of passengers is 25. If there are more than 25 passengers please use our group booking form.", flightsPage.GetErrorIncrementTooltip());
		}

		[TearDown]
		public void StopBrowser()
		{
			if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
			{
				CreatorOfScreenshot.TakeScreenshot(webDriver);
				Logger.Log.Info("Take screenshot");
			}
			DriverSingleton.CloseDriver();
		}
	}
}