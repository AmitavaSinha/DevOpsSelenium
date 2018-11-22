using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace WebSelenium.UI.Test
{
    [TestClass]
    public class FillFormIntegrationTest 
    {
        public static string BaseUrl = "https://demodevd.azurewebsites.net";

        // the max. time to wait before timing out.
        public const int TimeOut = 30;

        [TestMethod]
        public void CanLogin()
        {
            var driver = new ChromeDriver();

            // we need to setup implicit wait times so that selenium waits for some time and
            // re-checks if an element isn't found.
            // This is useful to ensure that a page 
            // gets fully loaded before selenium tries to look for stuff.
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
        public void CanFillAndSubmitForm()
        {
            
            //var driver = new ChromeDriver();

            var driver = new InternetExplorerDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeOut);
            driver.Navigate().GoToUrl(BaseUrl + "/FillForm.aspx");
            Assert.AreEqual("Fill out form", driver.Title);

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
    }
}
