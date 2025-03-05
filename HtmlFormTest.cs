using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

[TestFixture]
public class HtmlFormTest : IDisposable
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        //driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
    }

    [Test]
    public void WorkingWithAdvancedControls()
    {
        // Load the local test page
        driver.Navigate().GoToUrl("file:///C:/Users/91817/source/repos/TestProject3/Testpage.html");

        // Fill the form
        SeleniumHelper.EnterText(driver.FindElement(By.Id("name")), "Geetha Eswaramurthi");
        SeleniumHelper.EnterText(driver.FindElement(By.Id("email")), "geethaeswaramurthi@outlook.com");
        SeleniumHelper.EnterText(driver.FindElement(By.Id("doj")), "2020-03-08");

        SeleniumHelper.Click(driver.FindElement(By.CssSelector("input[name='gender'][value='female']")));
        SeleniumHelper.SelectDropDownByText(driver.FindElement(By.Id("city")), "Coimbatore");
        SeleniumHelper.EnterText(driver.FindElement(By.Id("designation")), "Senior Product Engineer");
        SeleniumHelper.MultiSelectElements(driver.FindElement(By.Id("skills")), new string[] { "testing", "cloud" });

        // Print selected skills
        var getSelectedOptions = SeleniumHelper.GetAllSelectedLists(driver.FindElement(By.Id("skills")));
        getSelectedOptions.ForEach(Console.WriteLine);

        // Select hobbies
        SeleniumHelper.Click(driver.FindElement(By.CssSelector("input[name='hobbies'][value='Reading Books']")));
        SeleniumHelper.Click(driver.FindElement(By.CssSelector("input[name='hobbies'][value='Playing Baseball']")));

        // Print selected hobbies
        var getSelectedHobbies = SeleniumHelper.GetAllCheckedCheckboxes(driver, By.Name("hobbies"));
        getSelectedHobbies.ForEach(Console.WriteLine);

        // Submit form
        SeleniumHelper.Click(driver.FindElement(By.CssSelector("button[type='submit']")));

        // Validation: Check if the form submitted successfully
        Thread.Sleep(2000);
        bool isSubmissionSuccessful = driver.PageSource.Contains("Thank you for registering");
       // Assert.IsTrue(isSubmissionSuccessful, "Form submission failed.");
    }

    [TearDown]
    public void TearDown()
    {
        Dispose();  // Ensure driver is properly disposed
    }

    public void Dispose()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}