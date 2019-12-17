using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkLab
{
	public class LoginPage
	{
		[FindsBy(How = How.XPath, Using = "//li[@id='myryanair-auth-login']")]
		private IWebElement logInMenuItem;
		[FindsBy(How = How.XPath, Using = "//input[@id='email346']")]
		private IWebElement emailField;
		[FindsBy(How = How.XPath, Using = "//input[@id='password355']")]
		private IWebElement passwordField;
		[FindsBy(How = How.XPath, Using = "//button[@id class='core-btn-primary']")]
		private IWebElement buttonLogIn;
		[FindsBy(How = How.XPath, Using = "//span[@class='username'][@data-hj-suppress='']")]
		private IWebElement usernameElement;
		[FindsBy(How = How.XPath, Using = "//li[@translate='MYRYANAIR.INVALID.ACCOUNT.PASSWORD']")]
		private IWebElement errorPassword;
		

		public LoginPage(IWebDriver webDriver)
		{
			PageFactory.InitElements(webDriver, this);
		}

		public LoginPage OpenPage()
		{
			Logger.Log.Info("Open Login page");
			logInMenuItem.Click();
			return this;
		}

		public LoginPage Login(User user)
		{
			Logger.Log.Info("Login method");
			emailField.SendKeys(user.GetUsername());
			passwordField.SendKeys(user.GetPassword());
			buttonLogIn.Click();
			return this;
		}

		public string GetLoggedInUserName()
		{
			Logger.Log.Info("GetLoggedInUserName() method");
			return usernameElement.Text;
		}

		public string GetErrorMessage()
		{
			Logger.Log.Info("GetErrorMessage() method");
			return errorPassword.Text;
		}
	}
}
