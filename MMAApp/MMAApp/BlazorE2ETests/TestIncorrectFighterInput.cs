using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System;

public class BlazorSearch : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public BlazorSearch()
    {
        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void TestSearchFighterWhenFighterDoesNotExist()
    {
        _driver.Navigate().GoToUrl("https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/search");

        var inputField = _wait.Until(driver => driver.FindElement(By.ClassName("search-input")));

        inputField.SendKeys("NonExistent Fighter");

        System.Threading.Thread.Sleep(2000);

        var searchButton = _driver.FindElement(By.ClassName("search-button"));
        searchButton.Click();

        _wait.Until(driver => driver.FindElement(By.ClassName("error-message")).Displayed);

        var errorMessage = _driver.FindElement(By.ClassName("error-message"));

        System.Threading.Thread.Sleep(2000);

        bool isErrorMessageDisplayed = errorMessage.Displayed;

        Assert.True(isErrorMessageDisplayed, "An error message should be displayed when no fighter is found.");

        bool isErrorMessageTextCorrect = errorMessage.Text.Contains("No fighter found");
        Assert.True(isErrorMessageTextCorrect, "The error message should contain 'No fighter found' text.");
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
