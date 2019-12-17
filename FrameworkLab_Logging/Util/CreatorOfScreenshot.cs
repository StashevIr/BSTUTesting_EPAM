using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;

namespace FrameworkLab
{
	public class CreatorOfScreenshot
	{
		public static void TakeScreenshot(IWebDriver webDriver)
		{
			ITakesScreenshot screenshot = ((ITakesScreenshot)webDriver);
			DirectoryInfo directory = Directory.CreateDirectory(@"Screenshots\" + DateTime.Now.ToString("dd_MM_yyyy") + @"\");
			screenshot.GetScreenshot().SaveAsFile(directory.FullName + @"\" + DateTime.Now.ToString("HH_mm_ss") + ".png", ScreenshotImageFormat.Png);
		}
	}
}
