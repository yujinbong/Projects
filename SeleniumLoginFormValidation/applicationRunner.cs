

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;




namespace SeleniumFirstProject
{
   public class SimpleApplicationRunner
    {
        public static object ExpectedConditions { get; private set; }

        public static void Main(string[] args)
        {

            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("file:///C:/Users/aso23/.vscode/Project/website.html");


            string ID = "YBONG";
            int PW = 1234;


            IWebElement typeID = driver.FindElement(By.CssSelector("[name='id']"));
            typeID.SendKeys(ID);
            typeID.SendKeys(Keys.Enter);

            IWebElement typePW = driver.FindElement(By.CssSelector("[name='pw']"));
            typePW.SendKeys(PW.ToString());
            typePW.SendKeys(Keys.Enter);

            IWebElement btn = driver.FindElement(By.CssSelector("[id='btn']"));
            btn.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector(".style-scope ytd-playlist-renderer"))
           .Select(item => item.Text.ToLower())
           .ToList();

            IList<string> expectedItems = actualItems
           .Where(item => item.Contains("invalid search"))
           .ToList();

            Assert.AreEqual(expectedItems, actualItems);

            string currentUrl = driver.Url;

            if (currentUrl.Contains("website2.html"))
            {

                System.Threading.Thread.Sleep(2000);
                IWebElement typeSearch = driver.FindElement(By.CssSelector("[name='q']"));
                string Search = "Youtube";
                typeSearch.SendKeys(Search);
                typeSearch.SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);
                string newUrl = driver.Url;


            }
            if (currentUrl.Contains("https://www.google.com/search?q=Youtube"))
            {
                string currentWindowHandle = driver.CurrentWindowHandle;

                foreach (string windowHandle in driver.WindowHandles)
                {
                    if (windowHandle != currentWindowHandle)
                    {
                        driver.SwitchTo().Window(windowHandle);
                        break;
                    }
                }
                IWebElement element = driver.FindElement(By.CssSelector(".g"));
                element.Click();
           
                driver.Close();

                driver.SwitchTo().Window(currentWindowHandle);
            }











        }
    }


}
