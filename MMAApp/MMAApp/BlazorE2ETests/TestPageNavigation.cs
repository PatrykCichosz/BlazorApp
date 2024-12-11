using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System;
using System.Threading;

public class BlazorSearchTest : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public BlazorSearchTest()
    {

        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
    }

    [Fact]
    public void TestNavigationToSearchFighterAndBackToHome()
    {
        _driver.Navigate().GoToUrl("https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/");

        Thread.Sleep(3000);

        var searchFighterLink = _wait.Until(driver => driver.FindElement(By.LinkText("Search Fighter")));
        searchFighterLink.Click();


        Thread.Sleep(2000);

        _wait.Until(driver => driver.Url.Contains("/search"));

        Thread.Sleep(2000);

        var mmaAppLogo = _driver.FindElement(By.ClassName("navbar-brand"));
        mmaAppLogo.Click();

        Thread.Sleep(2000);

        _wait.Until(driver => driver.Url == "https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/");

        Assert.Equal("https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/", _driver.Url);
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
