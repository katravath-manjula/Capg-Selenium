using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
     public class SeleniumHelper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait _wait;

        public SeleniumHelper(IWebDriver driver, int timeoutInSeconds = 10)
        {
            this.driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }


        public void NavigateUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        // Method to click an element after waiting
        public void ClickElement(By locator)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        // Method to enter text into an input field
        public void EnterText(By locator, string text)
        {
            var element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
            element.SendKeys(text);
        }

        // Method to wait for an element to be present
        public void WaitForElement(By locator)
        {
            _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        // Method to check if an element is displayed
        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

}

