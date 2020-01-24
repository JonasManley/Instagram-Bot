using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace InstaBot
{
    class Program
    {
        //URL to login page
        static string url = "https://www.instagram.com/accounts/login/?source=auth_switcher";
        //End

        //-----------------------------------------------------------------------------------//
        //Insert your login informations and the descired search tag 
        // OBS functionallity need, the option to change between a list of tags. 
        static string username = "runners_space_life";
        static string password = "Test123456";
        static string searchTag = "Løb";
        //-----------------------------------------------------------------------------------//


        /// <summary>
        /// The bot itself 
        /// </summary>
        /// <param name="args"></param>
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
            int row = 1;
            int drivingCondition = 1; 
           
            while (drivingCondition < 2)
            {
                for (int i = 1; i < 4; i++)
                {
                    Random random = new Random();
                    var timeToWait1 = random.Next(3000, 10000);
                    driver.FindElement(By.CssSelector($"#react-root > section > main > article > div:nth-child(3) > div > div:nth-child({row}) > div:nth-child({i})")).Click();
                    Thread.Sleep(timeToWait1);
                    var timeToWait2 = random.Next(5000, 20000);
                    driver.FindElement(By.CssSelector("body > div._2dDPU.vCf6V > div.zZYga > div > article > div.eo2As > section.ltpMr.Slqrh > span.fr66n > button > svg")).Click();
                    Thread.Sleep(timeToWait2);
                    var timeToWait3 = random.Next(21000, 250000);
                    driver.FindElement(By.CssSelector("body > div._2dDPU.vCf6V > div.zZYga > div > article > header > div.o-MQd.z8cbW > div.PQo_0.RqtMr > div.bY2yH > button")).Click();
                    Thread.Sleep(timeToWait3);
                    var timeToWait4 = random.Next(2000, 10000);
                    driver.FindElement(By.CssSelector(" body > div._2dDPU.vCf6V > button.ckWGn")).Click();
                    Thread.Sleep(timeToWait4);

                    
                    var extraWait = random.Next(1, 10);
                    if (extraWait == 2 || extraWait == 6 || extraWait == 1)
                    {
                        var timeToWait5 = random.Next(3000, 60000);
                        Thread.Sleep(timeToWait5);
                    }


                    row++;
                    drivingCondition++;
                }
            }
        }
    }
}
