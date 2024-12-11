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

        var inputField = _wait.Until(driver =>
        {
            var element = driver.FindElement(By.ClassName("search-input"));
            return element.Displayed && element.Enabled ? element : null;
        });

        if (inputField == null)
            throw new InvalidOperationException("The input field could not be found.");

        inputField.SendKeys("NonExistent Fighter");

        var searchButton = _wait.Until(driver =>
        {
            var element = driver.FindElement(By.ClassName("search-button"));
            return element.Displayed && element.Enabled ? element : null;
        });

        if (searchButton == null)
            throw new InvalidOperationException("The search button could not be found.");

        searchButton.Click();

        var errorMessage = _wait.Until(driver =>
        {
            var element = driver.FindElement(By.ClassName("error-message"));
            return element.Displayed ? element : null;
        });

        if (errorMessage == null)
            throw new InvalidOperationException("The error message could not be found.");

        Assert.True(errorMessage.Displayed, "An error message should be displayed when no fighter is found.");
        Assert.Contains("No fighter found", errorMessage.Text);
    }


    public void Dispose()
    {
        _driver.Quit();
    }
}
