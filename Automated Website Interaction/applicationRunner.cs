

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;




namespace SeleniumFirstProject
{
   public class SimpleApplicationRunner
    {

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
                IWebElement typeSearch = driver.FindElement(By.CssSelector("[name='q']"));
                string Search = "Youtube";
                string Search2 = "fail";
                typeSearch.SendKeys(Search);
                typeSearch.SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(2000);

       
                string currentWindowHandle = driver.CurrentWindowHandle;

                foreach (string windowHandle in driver.WindowHandles)
                {
                    if (windowHandle != currentWindowHandle)
                    {
                        driver.SwitchTo().Window(windowHandle);
                      

                    }
                }
                IWebElement youtubeLink = driver.FindElement(By.CssSelector("h3.LC20lb.MBeuO.DKV0Md"));
                youtubeLink.Click();
                System.Threading.Thread.Sleep(2000);
                driver.Close();
         
            }
        }
    }


}
