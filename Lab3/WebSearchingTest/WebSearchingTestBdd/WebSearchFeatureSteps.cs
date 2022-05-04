using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace WebSearchingTestBdd
{
    [Binding]
    public class WebSearchFeatureSteps
    {
        private IWebDriver _driver;
        private IWebElement _searchField;
        private IWebElement _correctLink;
        private IWebElement _wikiInput;
        private WebDriverWait _wait;
        private string _request = "unit testing";
        private string _wikiRequest = "NUnit";
        private string _googleLink = @"http://www.google.com";
        private string _wikiLink = @"https://en.wikipedia.org";
        private string _wikiInputId = "searchInput";

        [BeforeScenario]
        public void Init()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [AfterScenario]
        public void Quit()
        {
            _driver.Quit();
        }

        [Given(@"I have opened Google Chrome search page")]
        public void GivenIHaveOpenedGoogleChromeSearchPage()
        {
            _driver.Navigate().GoToUrl(_googleLink);
        }

        [Given(@"I have entered unit testing")]
        public void GivenIHaveEnteredUnitTesting()
        {
            _searchField = _driver.FindElement(By.Name("q"));
            _searchField.SendKeys(_request);
        }

        [When(@"I pressed search button")]
        public void WhenIPressedSearchButton()
        {
            Thread.Sleep(2500);
            _searchField.SendKeys(Keys.Enter);
        }

        [Then(@"The search relusts contains english Wikipedia link")]
        public void ThenTheSearchRelustsContainsEnglishWikipediaLink()
        {
            _wait.Until(driver => driver.FindElement(By.Id("result-stats")));
            var searchResults = _driver.FindElements(By.CssSelector("div>cite"));
            _correctLink = searchResults.Where(element => element.Text.StartsWith(_wikiLink)).FirstOrDefault();
            Assert.That(_correctLink, Is.Not.Null);
        }

        [Then(@"I follow the english Wikipedia link")]
        public void ThenIFollowTheEnglishWikipediaLink()
        {
            _correctLink.Click();
            _wait.Until(driver => driver.FindElement(By.Id(_wikiInputId)));
        }

        [Then(@"I have entered NUnit to Wikipedia search field")]
        public void ThenIHaveEnteredNUnitToWikipediaSearchField()
        {
            _wikiInput = _driver.FindElement(By.Id(_wikiInputId));
            _wikiInput.SendKeys(_wikiRequest);
        }

        [When(@"I confirmed the NUnit searching")]
        public void WhenIConfirmedTheNUnitSearching()
        {
            Thread.Sleep(2500);
            _wikiInput.SendKeys(Keys.Enter);
        }

        [Then(@"Must be a link to a russian article about NUnit on Wikipedia")]
        public void ThenMustBeALinkToARussianArticleAboutNUnitOnWikipedia()
        {
            _wait.Until(driver => driver.FindElements(By.ClassName("vector-menu-content")));
            var languagesLinks = _driver.FindElements(By.CssSelector("div > ul > li.interlanguage-link > a"));
            bool result = languagesLinks.Any(link => link.GetAttribute("lang").Equals("ru"));
            Assert.That(result, Is.True);
        }
    }
}
