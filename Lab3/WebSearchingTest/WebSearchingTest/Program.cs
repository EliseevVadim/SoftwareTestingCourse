using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Linq;

namespace WebSearchingTest
{
    internal class Program
    {
        static readonly IWebDriver _driver = new ChromeDriver();

        static void Main(string[] args)
        {
            const string request = "unit testing";
            const string wikiRequest = "NUnit";
            const string _googleLink = @"http://www.google.com";
            const string _wikiLink = @"https://en.wikipedia.org";
            const string _wikiInputId = "searchInput";

            _driver.Navigate().GoToUrl(_googleLink);
            IWebElement searchField = _driver.FindElement(By.Name("q"));

            searchField.SendKeys(request);
            Thread.Sleep(2500);
            searchField.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(By.Id("result-stats")));

            var searchResults = _driver.FindElements(By.CssSelector("div>cite"));

            IWebElement correctLink = searchResults.Where(element => element.Text.StartsWith(_wikiLink)).FirstOrDefault();
            if (correctLink == null)
                return;
            correctLink.Click();

            wait.Until(driver => driver.FindElement(By.Id(_wikiInputId)));

            IWebElement wikiInput = _driver.FindElement(By.Id(_wikiInputId));
            wikiInput.SendKeys(wikiRequest);
            Thread.Sleep(2500);
            wikiInput.SendKeys(Keys.Enter);

            wait.Until(driver => driver.FindElements(By.ClassName("vector-menu-content")));
            var languagesLinks = _driver.FindElements(By.CssSelector("div > ul > li.interlanguage-link > a"));

            Console.Clear();
            Console.WriteLine(languagesLinks.Any(link => link.GetAttribute("lang").Equals("ru")) ? "Русская статья найдена" : "Русской статьи нет");
            Console.ReadKey();
            _driver.Quit();
        }
    }
}
