using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkLab
{
    public class HotelPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@for='search-type-selector-hotels']")]
        private IWebElement hotelLabel;
        [FindsBy(How = How.XPath, Using = "//input[@aria-labelledby='label-destination-input']")]
        private IWebElement destination;
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Check-in: - YYYY']")]
        private IWebElement yearOfCheckIn;
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Check-in: - MM']")]
        private IWebElement mounthOfCheckIn;
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Check-in: - DD']")]
        private IWebElement dayOfCheckIn;
        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Check-out: - YYYY']")]
        private IWebElement yearOfCheckOut;
        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Check-out: - MM']")]
        private IWebElement mounthOfCheckOut;
        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Check-out: - DD']")]
        private IWebElement dayOfCheckOut;
        [FindsBy(How = How.XPath, Using = "//li[@class='ryanair-error-tooltip']/span")]
        private IWebElement errorTooltipInHotelPage;
		
		public HotelPage(IWebDriver webDriver)
        {
            //PageFactory.InitElements(webDriver, this);
        }

		public HotelPage EnterDestinationField(string hotel)
		{
			Logger.Log.Info("EnterDestinationField method");
			destination.Clear();
			destination.SendKeys(hotel);
			return this;
		}

		public HotelPage SetPartOfDate(IWebElement webElement, string date)
        {
			Logger.Log.Info("SetPartOfDate method");
			webElement.Clear();
            webElement.SendKeys(date);
            return this;
        }

        public HotelPage SetDate_DayIn_DayOut_Mounth_Year(string dayCheckIn, string dayCheckOut, string mounth, string year)
        {
			Logger.Log.Info("SetDate_DayIn_DayOut_Mounth_Year method");
			return SetPartOfDate(yearOfCheckIn, year).
                SetPartOfDate(mounthOfCheckIn, mounth).
                SetPartOfDate(dayOfCheckIn, dayCheckIn).
                SetPartOfDate(yearOfCheckOut, year).
                SetPartOfDate(mounthOfCheckOut, mounth).
                SetPartOfDate(dayOfCheckOut, dayCheckOut);
        }
        public HotelPage Enter()
        {
			Logger.Log.Info("Enter() method");
			dayOfCheckOut.SendKeys(Keys.Enter);
            return this;
        }

        public string GetErrorTooltipFromHotelPage()
        {
			Logger.Log.Info("GetErrorTooltipFromHotelPage() method");
			return errorTooltipInHotelPage.Text;
        }
	}
}
