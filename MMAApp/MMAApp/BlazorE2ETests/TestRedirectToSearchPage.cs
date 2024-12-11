using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

public class BlazorTests : IDisposable
{
    private readonly IWebDriver _driver;

    public BlazorTests()
    {
        // Start the Chrome WebDriver
        _driver = new ChromeDriver();
    }

    [Fact]
    public void TestRedirectToSearchPage()
    {
        _driver.Navigate().GoToUrl("https://mmablazorapp-ecetddcpccehcfax.westeurope-01.azurewebsites.net/");


        System.Threading.Thread.Sleep(2000);

        var searchButton = _driver.FindElement(By.ClassName("mma-button"));

        Console.WriteLine("Clicking the 'Search for a fighter' button...");
        searchButton.Click();
        System.Threading.Thread.Sleep(3000);
        var currentUrl = _driver.Url;

        Console.WriteLine("Waiting for the URL to update...");
        System.Threading.Thread.Sleep(2000); 

        Console.WriteLine($"Current URL: {currentUrl}");
        Assert.Contains("/search", currentUrl);
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
