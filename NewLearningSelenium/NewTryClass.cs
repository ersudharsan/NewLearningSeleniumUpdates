using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NewLearningSelenium.BaseClass;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NPOI.XSSF.UserModel;
using System.IO;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using OpenQA.Selenium.Support.Extensions;
using WDSE;

namespace Learning_Selenium
{
	[TestFixture]
	internal class NewTryClass : BaseTest
	{
		public PropertyValues propertyvalues = new PropertyValues();

		public PathValues pathvalues = new PathValues();

		[Test]
		
		public void CambridgeDictionary()
		{

			driver.Navigate().GoToUrl("https://dictionary.cambridge.org/");

			driver.FindElement(By.XPath("//*[@id='onetrust-close-btn-container']/button")).Click();

			driver.SwitchTo().DefaultContent();

			IWebElement SearchBar = driver.FindElement(By.Name("q"));

			SearchBar.SendKeys("Victory");

			//Thread.Sleep(2000);

			IWebElement SearchIcon = driver.FindElement(By.XPath("//*[@id='searchForm']/div[1]/div[1]/span/button[3]/i"));

			SearchIcon.Click();

			Thread.Sleep(3000);

			propertyvalues.filename = "VictoryMeaning";

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path.Combine(pathvalues.CambridgeDictionary,propertyvalues.filename), ScreenshotImageFormat.Png);

			String title = driver.Title;

			Console.WriteLine(title);

			propertyvalues.filename = "Full Image of Victory page";

			VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting());

			driver.TakeScreenshot(vcd).ToMagickImage().Write(Path.Combine(pathvalues.CambridgeDictionary,propertyvalues.filename), ImageMagick.MagickFormat.Png);
		}

		[Test]

		public void NameOftheObject()
		{
			driver.Navigate().GoToUrl("https://dictionary.cambridge.org/");

			string HomePageword = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[1]/h1")).Text;

			Console.WriteLine(HomePageword);

			
			string Name1 = driver.FindElement(By.XPath(".//a[@class='bh hao hbtn hbtn-tab tb lmb-5']")).Text;

			Console.WriteLine(Name1);
			

			driver.FindElement(By.XPath(".//input[@type='text'][@name='q']")).SendKeys("Element");

			driver.FindElement(By.XPath(".//i[@class='i i-search']")).Click();

			Thread.Sleep(1000);

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("ElementMeaning.Png", ScreenshotImageFormat.Png);

			driver.Navigate().Back();

			Thread.Sleep(2000);

		
			driver.FindElement(By.XPath(".//a[@href='/plus/']")).Click();

			Thread.Sleep(2000);

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("GotoPlus.Png", ScreenshotImageFormat.Png);

			driver.Navigate().Back();

			string Wordings1 = driver.FindElement(By.XPath(".//*[@class='lpl-10']")).Text;

			Console.WriteLine(Wordings1);
		}

		[Test]
		public void SeleniumDemoPortal()
		{
			driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/selenium_automation_practice.htm");

			driver.FindElement(By.Name("firstname")).SendKeys("Sudharsan");
			driver.FindElement(By.Name("lastname")).SendKeys("Ramakrishnan");

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("DemoPortal.png", ScreenshotImageFormat.Png);

			driver.FindElement(By.XPath(".//input[@name='sex'and @data-gtm-form-interact-field-id='0']")).Click();

			
			//driver.FindElement(By.XPath(".//input[@name='exp' and @value='3']")).Click();
		}
		[Test]
		public void CommbankLoanCalculator()
		{
			string CommbankCalculatorUrl = "https://www.commbank.com.au/digital/home-loans/calculator/how-much-can-i-borrow?ei=calc_borrow";

			driver.Navigate().GoToUrl(CommbankCalculatorUrl);			

			driver.FindElement(By.ClassName("toast-dismiss-button")).Click();

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Navigate().Refresh();

			IWebElement ThisLoanIsFor = driver.FindElement(By.Id("applicants"));

			SelectElement selectElement = new SelectElement(ThisLoanIsFor);

			IList<IWebElement> DropdownOptions = selectElement.Options;

			Console.WriteLine(DropdownOptions.Count);

			foreach (var item in DropdownOptions)
			{
				Console.WriteLine(item.Text);
			}

			selectElement.SelectByIndex(0);

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("It'sJustMe.png", ScreenshotImageFormat.Png);

			selectElement.SelectByIndex(1);

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("ThereAreTwoOfUs.png", ScreenshotImageFormat.Png);

			bool CheckMultipleOptions = selectElement.IsMultiple;

			Console.WriteLine(CheckMultipleOptions);

			if (CheckMultipleOptions == false)
			{
				Console.WriteLine(selectElement.SelectedOption.Text);
			}			
		}
		[Test]
		public void ExplicitWait()
		{
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

			driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Contact");

			driver.FindElement(By.PartialLinkText("This is")).Click();

			WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			webDriverWait.Until(ExpectedConditions.ElementExists(By.ClassName("ContactUs")));

			String contactus = driver.FindElement(By.ClassName("ContactUs")).Text;

			Console.WriteLine(contactus.Contains("Python"));

			Console.WriteLine("The ContactUs Text as follows:\n" + contactus);			

			propertyvalues.filename = "ContactUs";			

			((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path.Combine(pathvalues.ExplicitWaitepath, propertyvalues.filename), ScreenshotImageFormat.Png);
		}

		[Test]
		public void ExcelRead()
		{
			String xlpath = @"C:\Users\DELL\source\repos\NewLearningSelenium\NewLearningSelenium\Excel Data\SeleniumTestData.xlsx";

			XSSFWorkbook workbook = new XSSFWorkbook(File.Open(xlpath, FileMode.Open));

			var sheet = workbook.GetSheetAt(0);

			var row = sheet.GetRow(1);

			var firstname = row.GetCell(0).StringCellValue.Trim();

			var lastname = row.GetCell(1).StringCellValue.Trim();

			Console.WriteLine(firstname + " " + lastname);

			Console.WriteLine(DateTime.Now);
		}
		
	}
}
