using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using static SauceTesting.SiteElements.SauceTestingElements;
using SauceTesting.SiteElements;
using SauceTesting.Drivers;
using System;
using TechTalk.SpecFlow;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SauceTesting.Steps
{
    [Binding]
    public sealed class SauceTestingStepDefinitions
    {
        private string url = "https://www.saucedemo.com/";
        IWebDriver driver;

        [Given(@"I navigate to site")]
        public void NavigateToSauceSite()
        {
            driver = new ChromeDriver();
            driver.Url = url;
        }

        [Given(@"I enter valid username")]
        public void IEnterValidUsername()
        {
            driver.FindElement(By.Name(ReturnUsernameElement())).SendKeys("standard_user");
        }

        [Given(@"I enter valid password")]
        public void IEnterValidPassword()
        {
            driver.FindElement(By.Name(ReturnPasswordElement())).SendKeys("secret_sauce");
        }

        [Then(@"I click on login button")]
        public void IClickLoginButton()
        {
            driver.FindElement(By.Name(ReturnLoginButton())).Click();
        }

        [Given(@"I'm buying Labs Backpack")]
        public void IBuyBackpack()
        {
            driver.FindElement(By.Name(ReturnSauceBackpackButton())).Click();
        }

        [Given(@"I'm buying Bike Light")]
        public void IBuyBikeLight()
        {
            driver.FindElement(By.Name(ReturnSauceBikeLightButton())).Click();
        }

        [Given(@"I'm buying Bolt T-Shirt")]
        public void IBuyBoltTShirt()
        {
            driver.FindElement(By.Name(ReturnSauceBoltTShirtButton())).Click();
        }

        [Given(@"I'm buying Fleece Jacket")]
        public void IBuyFleeceJacket()
        {
            driver.FindElement(By.Name(ReturnSauceFleeceJacketButton())).Click();
        }

        [Given(@"I'm buying Onesie")]
        public void IBuyOnesie()
        {
            driver.FindElement(By.Name(ReturnSauceOnesieButton())).Click();
        }

        [Given(@"I'm buying Red T-shirt")]
        public void IBuyRedTShirt()
        {
            driver.FindElement(By.Name(ReturnSauceTShirtRedButton())).Click();
        }

        [Then(@"I'm changing sort option")]
        public void IChangeSort()
        {
            var select = driver.FindElement(By.XPath(ReturnSauceProductsSort()));
            var optionElement = new SelectElement(select);

            optionElement.SelectByValue("za");
            Thread.Sleep(1000);
        }
        [Then(@"I'm going to basket")]
        public void IGoBasket()
        {
            driver.FindElement(By.XPath(ReturnSauceBasket())).Click();
        }

        [Then(@"I click checkout")]
        public void ICheckout()
        {
            driver.FindElement(By.Name(ReturnSauceCheckoutButton())).Click();
        }

        [Given(@"I enter First Name (.*)")]
        public void IEnterFirstName(string fname)
        {
            driver.FindElement(By.Name(ReturnSauceFirstNameElement())).SendKeys(fname);
        }

        [Given(@"I enter Last Name (.*)")]
        public void IEnterLastName(string lname)
        {
            driver.FindElement(By.Name(ReturnSauceLastNameElement())).SendKeys(lname);
        }

        [Given(@"I enter Postal Code (.*)")]
        public void IEnterPostalCode(string code)
        {
            driver.FindElement(By.Name(ReturnSaucePostalCodeElement())).SendKeys(code);
        }

        [Then(@"I click Continue")]
        public void IContinueFromBasket()
        {
            driver.FindElement(By.Name(ReturnSauceContinueElement())).Click();
        }

        [Then(@"I click Continue Overview")]
        public void IContinueFromOverview()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Name(ReturnSauceCheckoutOverviewFinishElement())).Click();
        }

        [Then(@"Close the test")]
        public void CloseTest()
        {
            driver.Close();
        }
    }
}
