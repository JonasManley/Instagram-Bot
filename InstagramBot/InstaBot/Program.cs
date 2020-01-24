using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace InstaBot
{
    class Program
    {
     

        static string url = "https://www.instagram.com/accounts/login/?source=auth_switcher";

        static string username = "peterpedersen_1996";
        static string password = "Test12345";
        static string searchTag = "Running";

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            //Logging in
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            driver.FindElement(By.Name("username")).SendKeys(username);
            Thread.Sleep(200);
            driver.FindElement(By.Name("password")).SendKeys(password);
            Thread.Sleep(200);
            driver.FindElement(By.CssSelector("button[class='sqdOP  L3NKy   y3zKF     ']")).Click();
            Thread.Sleep(2000);
            //End


            //Search the hashtag
            var searchbox = driver.FindElement(By.CssSelector("#react-root > section > nav > div._8MQSO.Cx7Bp > div > div > div.LWmhU._0aCwM > input"));
            searchbox.SendKeys(searchTag);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#react-root > section > nav > div._8MQSO.Cx7Bp > div > div > div.LWmhU._0aCwM > div:nth-child(4) > div.drKGC > div > a:nth-child(1)")).Click();
            Thread.Sleep(2000);

            //Like and follow
            for (int i = 1; i < 4; i++)
            {
                driver.FindElement(By.CssSelector($"#react-root > section > main > article > div:nth-child(3) > div > div:nth-child(1) > div:nth-child({i})")).Click();
                Thread.Sleep(410);
                driver.FindElement(By.CssSelector("body > div._2dDPU.vCf6V > div.zZYga > div > article > div.eo2As > section.ltpMr.Slqrh > span.fr66n > button > svg")).Click();
                Thread.Sleep(420);
                driver.FindElement(By.CssSelector("body > div._2dDPU.vCf6V > div.zZYga > div > article > header > div.o-MQd.z8cbW > div.PQo_0.RqtMr > div.bY2yH > button")).Click();
               
            }
           




        }
    }
}
