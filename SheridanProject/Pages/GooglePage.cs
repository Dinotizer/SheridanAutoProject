﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using FluentAssertions;
using SheridanProject.Utilities;

namespace SheridanAutoProject.Pages
{
    public class GooglePage
    {
        private readonly IWebDriver _driver;
        private readonly By _googleSearchBox = By.CssSelector("input[class=\"gLFyf\"]");
        //private readonly By _googleSearchBox = By.XPath("/html/body");
        private readonly By _googleTermsAccept = By.Id("L2AGLb");
        private readonly By _prestonCouncilLink = By.PartialLinkText("Preston City Council: Home Page");
        
        public GooglePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void NavigateToGoogleSite()
        {
            _driver.Navigate().GoToUrl(TestConstants.GoogleWebsite);
            
            var acceptAll = _driver.FindElement(_googleTermsAccept);
            if (acceptAll.Displayed)
            {
                acceptAll.Click();
            }
        }
        public void SearchForPrestonCityCouncil()
        {
            var searchBox = _driver.FindElement(_googleSearchBox);
            searchBox.Click();
            searchBox.SendKeys("Preston City Council" + Keys.Enter);
        }
        public void SelectPCCLink()
        {
            _driver.FindElement(_prestonCouncilLink).Click();
        }
    }
}
