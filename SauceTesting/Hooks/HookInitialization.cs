﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SauceTesting.Drivers;

namespace SauceTesting.Hooks
{
	[Binding]
	public sealed class HookInitialization
	{
		private readonly ScenarioContext _scenarioContext;

		public HookInitialization(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
			_scenarioContext.Set(seleniumDriver, "SeleniumDriver");
		}

		[AfterScenario]
		public void AfterScenario()
		{
			Console.WriteLine("Selenium webdriver quit");
			//_scenarioContext.Get<IWebDriver>("WebDriver").Quit();
		}
	}
}
