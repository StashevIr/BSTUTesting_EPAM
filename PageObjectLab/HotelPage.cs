using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectLab
{
    public class HotelPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@class='hotels'][@for='search-type-selector-hotels'][@ng-click='$ctrl.itemClicked(search)']")]
        private IWebElement hotelLabel;
        [FindsBy(How = How.XPath, Using = "//*[@type='text'][@tabindex='0'][@aria-labelledby='label-destination-input']")]
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
            PageFactory.InitElements(webDriver, this);
        }

        public HotelPage ClickHotel()
        {
            hotelLabel.Click();
            return this;
        }

        public HotelPage ClearDestinationField()
        {
            destination.Clear();
            return this;
        }

        public HotelPage SendKeysToDestinationField(string hotel)
        {
            destination.SendKeys(hotel);
            return this;
        }

        public HotelPage SetPartOfDate(IWebElement webElement, string date)
        {
            webElement.Clear();
            webElement.SendKeys(date);
            return this;
        }

        public HotelPage SetDate()
        {
            string dayCheckIn = "12";
            string dayCheckOut = "20";
            string mounth = "05";
            string year = "2020";

            return this.
                SetPartOfDate(yearOfCheckIn, year).
                SetPartOfDate(mounthOfCheckIn, mounth).
                SetPartOfDate(dayOfCheckIn, dayCheckIn).
                SetPartOfDate(yearOfCheckOut, year).
                SetPartOfDate(mounthOfCheckOut, mounth).
                SetPartOfDate(dayOfCheckOut, dayCheckOut);
        }
        public HotelPage SendEnter()
        {
            dayOfCheckOut.SendKeys(Keys.Enter);
            return this;
        }

        public string EroorTooltipFromHotelPage()
        {
            return errorTooltipInHotelPage.Text;
        }
    }
}
