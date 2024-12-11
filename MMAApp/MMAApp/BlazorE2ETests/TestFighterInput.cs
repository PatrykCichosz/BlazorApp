using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System;

public class BlazorSearchTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public BlazorSearchTests()
    {
        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    [Fact]
    public void TestSearchFighterFunctionality()
    {
        _driver.Navigate().GoToUrl("https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/search");

        var inputField = _wait.Until(driver => driver.FindElement(By.ClassName("search-input")));

        System.Threading.Thread.Sleep(2000);

        inputField.SendKeys("Conor McGregor");

        var searchButton = _wait.Until(driver => driver.FindElement(By.ClassName("search-button")));


        System.Threading.Thread.Sleep(3000);

        searchButton.Click();

        var fighterCard = _wait.Until(driver => driver.FindElement(By.ClassName("fighter-card")));

        System.Threading.Thread.Sleep(2000);

        bool isFighterDisplayed = fighterCard.Text.Contains("Conor McGregor");

        Assert.True(isFighterDisplayed, "The fighter 'Conor McGregor' should be displayed in the search results.");
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
