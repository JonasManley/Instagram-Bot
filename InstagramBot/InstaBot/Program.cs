using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace InstaBot
{
    class Program
    {

        static string url = "https://www.instagram.com/accounts/login/?source=auth_switcher";

        static string username = "peterpedersen_1996";
        static string password = "Test12345";

        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(200);
            driver.FindElement(By.Name("username")).SendKeys(username);
            Thread.Sleep(200);
            driver.FindElement(By.Name("password")).SendKeys(password);
            Thread.Sleep(200);

            driver.FindElement(By.CssSelector("button[class='sqdOP  L3NKy   y3zKF     ']")).Click();

        }
    }
}
