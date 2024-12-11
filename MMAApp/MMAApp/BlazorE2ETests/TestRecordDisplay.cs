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

        WebDriverWait wait = new WebDriverWait(new SystemClock(), _driver, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(500));

        var searchInput = wait.Until(drv =>
        {
            var element = drv.FindElement(By.CssSelector(".search-input"));
            return element != null && element.Displayed && element.Enabled ? element : null;
        });
        Assert.NotNull(searchInput);
        searchInput!.Clear();
        searchInput.SendKeys("Alex Pereira");

        var searchButton = wait.Until(drv =>
        {
            var element = drv.FindElement(By.CssSelector(".search-button"));
            return element != null && element.Displayed && element.Enabled ? element : null;
        });
        Assert.NotNull(searchButton);
        searchButton!.Click();

        await Task.Delay(5000);

        var getRecordButton = wait.Until(drv =>
        {
            var element = drv.FindElement(By.CssSelector(".record-button"));
            return element != null && element.Displayed && element.Enabled ? element : null;
        });
        Assert.NotNull(getRecordButton);
        getRecordButton!.Click();

        await Task.Delay(4000);

        var recordDetails = wait.Until(drv =>
        {
            var element = drv.FindElement(By.CssSelector(".fighter-record"));
            return element != null && element.Displayed ? element : null;
        });
        Assert.NotNull(recordDetails);

        var recordText = recordDetails!.Text;
        Assert.Contains("Wins", recordText);
        Assert.Contains("Losses", recordText);
        Assert.Contains("Draws", recordText);
    }


    public void Dispose()
    {
        _driver.Quit();
    }
}
