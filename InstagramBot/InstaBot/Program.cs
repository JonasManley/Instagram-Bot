using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
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
        static List<string> searchTag = new List<string> { "run", "runner", "running", "runs"};
        static Random random = new Random();
        static IWebDriver driver = new ChromeDriver("C:\\Users\\xjmp\\Documents\\GitHub\\Instagram-Bot\\InstagramBot");
        //-----------------------------------------------------------------------------------//



        /// <summary>
        /// The bot itself 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Logging in writting one letter at the time
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(10000);

            bool acceptConditions = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div")).Displayed;
            if(acceptConditions = true)
            {
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/button[1]")).Click();
                Thread.Sleep(random.Next(2250, 4120));
            }
            Thread.Sleep(random.Next(2250, 3120));

            RealWritter(username, "//*[@id='loginForm']/div/div[1]/div/label/input");
            Thread.Sleep(random.Next(1250, 3523));
            RealWritter(password, "//*[@id='loginForm']/div/div[2]/div/label/input");
            Thread.Sleep(random.Next(3250, 5241));
            driver.FindElement(By.CssSelector("button[class='sqdOP  L3NKy   y3zKF     ']")).Click();  // Login button
            Thread.Sleep(random.Next(1250, 2900));
            //End


            //Search the hashtag
            Thread.Sleep(random.Next(4521,12120));
            bool isElementDisplayed = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div")).Displayed;
            Thread.Sleep(random.Next(1250, 2900));

            if (isElementDisplayed == true)
            {
                driver.FindElement(By.ClassName("piCib")).Click();
                Thread.Sleep(random.Next(4210, 7210));
            }

                var searchbox = driver.FindElement(By.CssSelector("#react-root > section > nav > div._8MQSO.Cx7Bp > div > div > div.LWmhU._0aCwM > input"));
                var indexOfHashtag = random.Next(0, searchTag.Count);
                searchbox.SendKeys(searchTag[indexOfHashtag]);
                Thread.Sleep(random.Next(1750, 3257));
                driver.FindElement(By.CssSelector("#react-root > section > nav > div._8MQSO.Cx7Bp > div > div > div.LWmhU._0aCwM > div:nth-child(4) > div.drKGC > div > a:nth-child(1)")).Click();  // Search button
                Thread.Sleep(2000);

                Console.ReadLine();

           
            

            //Like and follow
            int row = 1;
            int drivingCondition = 1;

            var weigthedNumber = new List<string> { "1", "1", "1", "1", "1", "1", "2", "3", "4", "5", };
            var randomPickedNumber = random.Next(1, 10);

            switch (Int32.Parse(weigthedNumber[randomPickedNumber]))
            {
                case 1: // See the pickture but clicks away
                    return;
                case 2: // likes the pictures and go further 
                    return;
                case 3: // Likes the picutre and follow the person 
                    // remeber to add follow to a list, so the person can be unfollowed later (like 10 days later)
                    return;
                case 4: // Writes a comment to the picture 
                    return;
                case 5: // see picture and clicks around on user profile (1-5 pictures) and follows at the end 
                    return;
            }

            while (drivingCondition < 2)
            {
                for (int i = 1; i < 4; i++)
                {
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

        public static void RealWritter(string thingToWrite, string XPath)
        {
            var val = thingToWrite.ToCharArray();
            for (int i = 0; i < thingToWrite.Length; i++)
            {
                char c = thingToWrite[i];
                string newLetter = new StringBuilder().Append(c).ToString();
                driver.FindElement(By.XPath($"{XPath}")).SendKeys(newLetter);
                Thread.Sleep(random.Next(55, 250));
            }
        }
    }
}
