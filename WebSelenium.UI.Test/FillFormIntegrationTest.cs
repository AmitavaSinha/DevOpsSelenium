using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Collections.Generic;

namespace WebSelenium.UI.Test
{
    [TestClass]
    public class FillFormIntegrationTest 
    {
        private string appURL;
        private const string IE_DRIVER_PATH = @"C:\SeleniumDriver\";
        public string BaseUrl = "http://localhost:16699";
        private TestContext testContextInstance;
        private IWebDriver driver;
        
        // the max. time to wait before timing out.
        public const int TimeOut = 30;

        public FillFormIntegrationTest()
        {

        }


        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://localhost:16699";

            string browser = "IE";
            switch (browser)
            {
                
                case "IE":
                    driver = new InternetExplorerDriver(IE_DRIVER_PATH);
                    break;
                default:
                    driver = new InternetExplorerDriver(IE_DRIVER_PATH);
                    break;
            }

        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [TestCategory("IE")]
        public void CanLogin()
        {
            //var driver = new InternetExplorerDriver(IE_DRIVER_PATH);
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TimeOut));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeOut);
            driver.Navigate().GoToUrl(BaseUrl + "/Login.aspx");

            driver.FindElement(By.Id("userId")).SendKeys("testUser");
            driver.FindElement(By.Id("password")).SendKeys("foobar");

            driver.FindElement(By.Id("btnLogin")).Click();
            driver.Close();
            driver.Dispose();
            
        }
        [TestMethod]
        [TestCategory("IE")]
        public void CanFillAndSubmitForm()
        {
            //var driver = new ChromeDriver();
            ////var driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeOut);
            driver.Navigate().GoToUrl(BaseUrl + "/FillForm.aspx");
            //Assert.AreEqual("Fill out form", driver.Title);

            driver.FindElement(By.Id("firstName")).SendKeys("User");
            driver.FindElement(By.Id("lastName")).SendKeys("One");
            driver.FindElement(By.Id("address1")).SendKeys("99 Test Street");
            driver.FindElement(By.Id("city")).SendKeys("Test City");
            driver.FindElement(By.Id("state")).SendKeys("TX");

            driver.FindElement(By.Id("btnSubmit")).Click();

            Assert.IsTrue(driver.FindElement(By.CssSelector("confirm-label")).Text.
                   Contains("Submission successful."));

            driver.Close();
            driver.Dispose();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            var exceptions = new List<Exception>();
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
        }
    }
}

