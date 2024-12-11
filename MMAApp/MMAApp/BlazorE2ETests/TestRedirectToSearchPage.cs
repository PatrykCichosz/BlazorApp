using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System;

public class BlazorTests : IDisposable
{
    private readonly IWebDriver _driver;
    private WebDriverWait _wait;

    public BlazorTests()
    {
        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [Fact]
    public void TestRedirectToSearchPage()
    {
        _driver.Navigate().GoToUrl("https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/");

        var searchButton = _wait.Until(driver =>
        {
            var button = driver.FindElement(By.ClassName("mma-button"));
            return button.Displayed && button.Enabled ? button : null;
        });

        Assert.NotNull(searchButton);
        Assert.True(searchButton.Displayed, "Search button should be visible.");
        Assert.True(searchButton.Enabled, "Search button should be enabled.");

        Console.WriteLine("Clicking the 'Search for a fighter' button...");
        searchButton.Click();

        _wait.Until(driver => driver.Url.Contains("/search"));

        var currentUrl = _driver.Url;
        Console.WriteLine($"Current URL: {currentUrl}");

        Assert.Contains("/search", currentUrl);
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
