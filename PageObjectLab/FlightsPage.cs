using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjectLab
{
    public class FlightsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@type='text'][@tabindex='0'][@placeholder='Departure airport'][@role='textbox']")]
        private IWebElement departureAirport;
        [FindsBy(How = How.XPath, Using = "//*[@type='text'][@tabindex='0'][@placeholder='Destination airport'][@role='textbox']")]
        private IWebElement destinationAirport;
        [FindsBy(How = How.XPath, Using = "//*[@class='core-btn-primary core-btn-block core-btn-big'][@role='button']")]
        private IWebElement buttonContinue;
        [FindsBy(How = How.XPath, Using = "//*[@class='ryanair-error-tooltip']")]
        private IWebElement errorTooltip;
        
        public FlightsPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public FlightsPage ClearAirportFields()
        {
            departureAirport.Clear();
            destinationAirport.Clear();
            return this;
        }

        public FlightsPage SendKeysToAirportFields(string city)
        {
            departureAirport.SendKeys(city);
            destinationAirport.SendKeys(city);
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
