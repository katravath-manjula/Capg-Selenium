using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver;
        private SeleniumHelper helper;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            helper = new SeleniumHelper(driver);

        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Window.Maximize();
            IWebElement webElement = driver.FindElement(By.Name("q"));
            webElement.SendKeys("Azure tutorials");
            webElement.SendKeys(Keys.Return);
            driver.Close();
        }
        public void EAWebsiteTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
            loginLink.Click();
            IWebElement txtUsername = driver.FindElement(By.Id("UserName"));
            txtUsername.SendKeys("admin");
            IWebElement txtPassword = driver.FindElement(By.Id("Password"));
            txtPassword.SendKeys("password");
            IWebElement btnLogin = driver.FindElement(By.Id("loginIn"));
            btnLogin.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.TagName("img")));

            // Verify the image is present
            try
            {
                IWebElement imageElement = driver.FindElement(By.CssSelector("img[src='/Image/EA_banner_white_v1.jpg']"));
                Assert.IsTrue(imageElement.Displayed, "Image is displayed on the page.");
                Console.WriteLine("Image is present on the page.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Image not found on the page.");
            }
        }

        [Test]
        public void LoginAndVerifyImage()
        {
            helper.NavigateUrl("http://eaapp.somee.com/");

            // Click on login link
            helper.ClickElement(By.Id("loginLink"));

            // Enter username and password
            helper.EnterText(By.Id("UserName"), "admin");
            helper.EnterText(By.Id("Password"), "password");

            // Click login button
            helper.ClickElement(By.Id("loginIn"));

            // Wait for image to be present
            helper.WaitForElement(By.TagName("img"));

            // Verify if the image is displayed
            bool isImageDisplayed = helper.IsElementDisplayed(By.CssSelector("img[src='/Image/EA_banner_white_v1.jpg']"));
            Assert.IsTrue(isImageDisplayed, "Image is displayed on the page.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}