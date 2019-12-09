using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WebDriverLab
{
    [TestClass]
    public class UnitTestsForWebDriverLab : BrowserFunction
    {
        [TestMethod]
        public void EnterEqualDepartureAndDestinationAirport()
        {
            string city = "Warsaw Modlin";
            string errorTextForValidAirport = "Please enter a valid airport.";

            IWebElement departureAirport = webDriver.FindElement(By.XPath("//*[@type='text'][@tabindex='0'][@placeholder='Departure airport'][@role='textbox']"));
            departureAirport.Clear();
            departureAirport.SendKeys(city);

            IWebElement destinationAirport = webDriver.FindElement(By.XPath("//*[@type='text'][@tabindex='0'][@placeholder='Destination airport'][@role='textbox']"));
            destinationAirport.Clear();
            destinationAirport.SendKeys(city);

            IWebElement buttonContinue = webDriver.FindElement(By.XPath("//*[@class='core-btn-primary core-btn-block core-btn-big'][@role='button']"));
            buttonContinue.Click();

            IWebElement errorTooltip = webDriver.FindElement(By.XPath("//*[@class='ryanair-error-tooltip']"));

            Assert.AreEqual(errorTextForValidAirport, errorTooltip.Text);
        }

        [TestMethod]
        public void EnterNonexistentHotel()
        {
            string hotel = "BSTU Hostel 5";
            string errorTextForDestination = "Please select a destination from the dropdown";

            IWebElement hotelLabel = webDriver.FindElement(By.XPath("//*[@class='hotels'][@for='search-type-selector-hotels][@ng-click='$ctrl.itemClicked(search)']"));
            hotelLabel.Click();

            IWebElement destination = webDriver.FindElement(By.XPath("//*[@type='text'][@tabindex='0'][@placeholder='Find me a hotel']"));
            destination.Clear();
            destination.SendKeys(hotel);

            SetDate();

            IWebElement searchButton = webDriver.FindElement(By.XPath("//*[type='submit'][@class='core-btn-primary core-btn-block core-btn-big']"));
            searchButton.Click();

            IWebElement errorTooltip = webDriver.FindElement(By.XPath("//*[@class='ryanair-error-tooltip']"));

            Assert.AreEqual(errorTextForDestination, errorTooltip.Text);
        }

        public void SetDate()
        {
            string dayCheckIn = "12";
            string dayCheckOut = "20";
            string mounth = "05";
            string year = "2020";

            IWebElement yearOfCheckIn = webDriver.FindElement(By.XPath("//*[@label='Check-in: - YYYY']"));
            yearOfCheckIn.Clear();
            yearOfCheckIn.SendKeys(year);

            IWebElement mounthOfCheckIn = webDriver.FindElement(By.XPath("//*[@label='Check-in: - MM']"));
            mounthOfCheckIn.Clear();
            mounthOfCheckIn.SendKeys(mounth);

            IWebElement dayOfCheckIn = webDriver.FindElement(By.XPath("//*[@label='Check-in: - DD']"));
            dayOfCheckIn.Clear();
            dayOfCheckIn.SendKeys(dayCheckIn);

            IWebElement yearOfCheckOut = webDriver.FindElement(By.XPath("//*[@label='Check-out: - YYYY']"));
            yearOfCheckOut.Clear();
            yearOfCheckOut.SendKeys(year);

            IWebElement mounthOfCheckOut = webDriver.FindElement(By.XPath("//*[@label='Check-out: - MM']"));
            mounthOfCheckOut.Clear();
            mounthOfCheckOut.SendKeys(mounth);

            IWebElement dayOfCheckOut = webDriver.FindElement(By.XPath("//*[@label='Check-out: - DD']"));
            dayOfCheckOut.Clear();
            dayOfCheckOut.SendKeys(dayCheckOut);
        }
    }
}
