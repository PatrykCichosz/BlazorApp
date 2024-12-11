using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;
using Xunit;

public class MMAAppTests : IDisposable
{
    private readonly IWebDriver _driver;

    public MMAAppTests()
    {
        _driver = new ChromeDriver();
    }

    [Fact]
    public async Task TestSearchFighterAndGetRecordFunctionality()
    {
        _driver.Navigate().GoToUrl("https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/search");

        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var searchInput = wait.Until(drv => drv.FindElement(By.CssSelector(".search-input")));

        searchInput.Clear();

        searchInput.SendKeys("Alex Pereira");

        var searchButton = wait.Until(drv => drv.FindElement(By.CssSelector(".search-button")));
        searchButton.Click();

        await Task.Delay(4000);

        var getRecordButton = wait.Until(drv => drv.FindElement(By.CssSelector(".record-button")));
        getRecordButton.Click();

        await Task.Delay(3000);

        var recordDetails = wait.Until(drv => drv.FindElement(By.CssSelector(".fighter-record")));
        Assert.True(recordDetails.Displayed, "The fighter's record is not displayed");

        var recordText = recordDetails.Text;
        Assert.Contains("Wins", recordText);
        Assert.Contains("Losses", recordText);
        Assert.Contains("Draws", recordText);
    }
    public void Dispose()
    {
        _driver.Quit();
    }
}
