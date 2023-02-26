using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace NewLearningSelenium.BaseClass
{
	public class BaseTest
	{
		public IWebDriver driver;

		[OneTimeSetUp]
		public void BrowserLaunch()
		{
			driver = new ChromeDriver(@"C:\Users\DELL\OneDrive\Documents\Visual Studio 2022\ChromeDriver");

			driver.Manage().Window.Maximize();
		}

		[OneTimeTearDown]
		public void ClosetheBrowser()
		{
			driver.Close();
		}
		
	}

	public class PropertyValues
	{
		private string? _filename;

		public string filename
		{
			get { return _filename; }

			set
			{		
				var datetimenow = Convert.ToString(DateTime.Now).Replace(":", "_").Replace("-", "").Replace(" ","_");

				_filename = value + "_" + datetimenow + ".png";		
								
			}			
		}	
		
	}

	public class PathValues
	{
		private string _ExplicitWaitepath = @"C:\Users\DELL\source\repos\NewLearningSelenium\NewLearningSelenium\bin\Debug\ExplicitWait";

		public string ExplicitWaitepath
		{
			get { return _ExplicitWaitepath; }
		}

		private string _CambridgeDictionary = @"C:\Users\DELL\source\repos\NewLearningSelenium\NewLearningSelenium\bin\Debug\CambridgeDictionary";
		public string CambridgeDictionary
		{
			get { return _CambridgeDictionary; }
		}
	}
}


	


	
		