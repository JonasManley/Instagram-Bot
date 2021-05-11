using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace InstaBot
{
    class Program
    {
        //-----------------------------------------------------------------------------------//
        // insert your login informations and the descired search tag 
        // OBS functionallity need, the option to change between a list of tags. 
        static string username = "runners_space_life";  //need to be updated if first time you run on pc
        static string password = "Test123456";  //need to be updated if first time you run on pc
        static int language = 0; // 0 = English, 1 = dansih 
        static string pahtToFollowedUsersTxtFile = "C:\\Users\\jmp\\Documents\\GitHub\\Instagram-Bot\\InstagramBot";  //need to be updated if first time you run on pc
        static IWebDriver driver = new ChromeDriver("C:\\Users\\jmp\\Documents\\GitHub\\Instagram-Bot\\InstagramBot");  //need to be updated if first time you run on pc
        static List<string> hashtagsEnglish = new List<string>()
        { 
            "#run", "#runner", "#running", "#runner", "#runninghigh"
            , "#runnershigh", "#trailrunning", "#workout", "#training",
            "#intervals", "#hardrunning", "#newrunner"
        };
         static List<string> hashtagsDansih = new List<string>()
        {
            "#løb", "#løber", "#løbetur", "#trailtur", "#løbeven", "#løbevener", 
            "#runner", "#løbevenner", "#komiform", "#førsteløb", "#sundhed",
            "#godtræning", "#langtur", "#intervaller", "#intervaltræning"
        };
        static List<List<string>> hashtags = new List<List<string>>() { hashtagsEnglish, hashtagsDansih };
        static List<string> commentsEnglish = new List<string>()
        {
            "Very nice! :)", "Check out our running Page :)", "tag us to get a shoutout", "Hey there, nice profile!", "#thatsARunner", "hello "
        };
        static List<string> commentsDanish = new List<string>()
        {
            "God løbetur!", "Hvor mange kilometer løber du om ugen?", "heysa, hvordan forebygger du skader?", "hvilke sko er dine favoriter?"
        };
        static List<List<string>> comments = new List<List<string>>(){ commentsEnglish, commentsDanish};

        //-----------------------------------------------------------------------------------//
        // global variables 
        static string url = "https://www.instagram.com/accounts/login/?source=auth_switcher"; // login page for instagram
        static Random random = new Random();
        static int watched = 0;
        static int Liked = 0;
        static int followed = 0;
        static int commented = 0;

        /// <summary>
        /// The bot itself 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //logging in writting one letter at the time
            try
            {
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(random.Next(5192, 3120));
            }
            catch (Exception e)
            {
                Console.WriteLine("exception was throwned.. " + e);
            }


            // popup for condiotions (only one time pr. browser)
            bool acceptConditions = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div")).Displayed;
            Thread.Sleep(random.Next(600, 3521));
            if (acceptConditions == true)
            {
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/button[1]")).Click();
                Thread.Sleep(random.Next(2250, 3120));
            }
            Thread.Sleep(random.Next(2250, 3120));

            // writes username and password like a humon, letter by letter in random speed
            RealWritter(username, "//*[@id='loginForm']/div/div[1]/div/label/input", "username");
            Thread.Sleep(random.Next(1250, 3523));
            RealWritter(password, "//*[@id='loginForm']/div/div[2]/div/label/input", "password");
            Thread.Sleep(random.Next(3250, 5241));
            driver.FindElement(By.CssSelector("button[class='sqdOP  L3NKy   y3zKF     ']")).Click();  // login button
            Thread.Sleep(random.Next(1250, 2900));
            // end

            // popud for save login data
            Thread.Sleep(random.Next(3521,4420));
            bool applyNotificationsPopUp = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div")).Displayed;
            Thread.Sleep(random.Next(1250, 2900));
            if (applyNotificationsPopUp == true)
            {
                driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div[3]/button[1]")).Click();
                Thread.Sleep(random.Next(4210, 7210));
            }

            // scroll a random amount on the startpage
            scrollDownSlowly(400, 500, 25);  // OBS! 500 shoulnd be 3321 but isn't for testing purposes.
            Thread.Sleep(random.Next(709, 1612));

            var weigthedNumberForRefresh = new List<string> { "1", "1", "1", "1", "1", "1", "1", "2", "2", "2", };
            var randomPickedNumberForRefresh = random.Next(1, 10);
            if(weigthedNumberForRefresh[random.Next(0, 9)] == "2")
            {
                driver.Navigate().Refresh();
                Thread.Sleep(7000);
                bool applyNotificationsPopUp2 = false;
                try
                {
                    applyNotificationsPopUp2 = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div")).Displayed;
                }
                catch (Exception)
                {

                }
                
                Thread.Sleep(random.Next(1250, 2900));
                if (applyNotificationsPopUp2 == true)
                {
                    driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div[3]/button[1]")).Click();
                    Thread.Sleep(random.Next(2210, 4210));
                }
            }

            // navigates to a randoms specified hashtag within the list
            var fetchedHashtagsList = hashtags[language];
            driver.FindElement(By.XPath("//*[@id='react-root']/section/nav/div[2]/div/div/div[2]/div[1]")).Click();
            var searchInputField = "//*[@id='react-root']/section/nav/div[2]/div/div/div[2]/input";
            RealWritter(fetchedHashtagsList[random.Next(0, fetchedHashtagsList.Count)], searchInputField, "hashtag");
            Thread.Sleep(random.Next(1623, 1821));
            driver.FindElement(By.XPath("//*[@id='react-root']/section/nav/div[2]/div/div/div[2]/div[3]/div/div[2]/div/div[1]/a/div")).Click();
            Thread.Sleep(random.Next(5662, 8219));



            //*[@id="react-root"]/section/main/article/div[1]/div/div/div[1]/div[1]/a/div/div[2]
            //*[@id="react-root"]/section/main/article/div[1]/div/div/div[1]/div[2]/a/div/div[2]
            //*[@id="react-root"]/section/main/article/div[1]/div/div/div[1]/div[3]/a/div/div[2]
            //*[@id="react-root"]/section/main/article/div[1]/div/div/div[2]/div[1]/a/div/div[2]
            //*[@id="react-root"]/section/main/article/div[1]/div/div/div[3]/div[1]/a/div

            //*[@id="react-root"]/section/main/article/div[1]/div/div/div[2]/div[1]
            //*[@id="react-root"]/section/main/article/div[1]/div/div/div[2]/div[1]/a/div/div[2]








            var collum = random.Next(1, 3);
            var picture = random.Next(1, 3);
            Thread.Sleep(random.Next(500,700));
            driver.FindElement(By.XPath($"//*[@id='react-root']/section/main/article/div[1]/div/div/div[{collum}]/div[{picture}]/a/div/div[2]")).Click();
            Thread.Sleep(random.Next(799, 1263));

            // like, follow, comment, watch 
            var weigthedNumber = new List<string> { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "2", "2", "2", "3", "3", "4" };
            for (int i = 0; i < random.Next(12, 47); i++)
            {
                var randomPickedNumber = random.Next(1, weigthedNumber.Count); // pick a new random on entry
                switch (Int32.Parse(weigthedNumber[randomPickedNumber]))
                {
                    case 1: // See the pickture but clicks away
                        Thread.Sleep(random.Next(1523, 5620));
                        driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/a")).Click();
                        Thread.Sleep(random.Next(1523, 4322));
                        var weigthedNumber2 = new List<string> { "1", "1", "1", "1", "1", "1", "2", "2", "2", "2" };
                        var shouldVisitOrNotRandomNumber = random.Next(0, weigthedNumber2.Count);
                        var shouldVisitOrNot = weigthedNumber2[shouldVisitOrNotRandomNumber];
                        if(shouldVisitOrNot == "2")
                        {
                           
                            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/header/div[2]/div[1]/div[1]/span/a")).Click();
                            Thread.Sleep(random.Next(1852, 3021));


                            // scroll a random amount on users page
                            var scrollVar = random.Next(240, 563);
                            scrollDownSlowly(152, scrollVar, 45);  
                            Thread.Sleep(random.Next(621, 921));
                            driver.Navigate().Refresh();
                            Thread.Sleep(random.Next(4512, 6231));
                            scrollDownSlowly(0, 50, 25);
                            driver.FindElement(By.CssSelector("#react-root > section > main > div > div._2z6nI > article > div:nth-child(1) > div > div:nth-child(1) > div:nth-child(3) > a")).Click();
                            var howManyPickturesToSee = random.Next(1, 8);
                            for (int j = 0; j < howManyPickturesToSee; j++)
                            {
                                 driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/a[2]")).Click();
                                Thread.Sleep(random.Next(952, 2958));
                            }
                            driver.FindElement(By.XPath("/html/body/div[5]/div[3]/button")).Click(); // click exit and return to mainpage for 

                            driver.FindElement(By.XPath("//*[@id='react-root']/section/nav/div[2]/div/div/div[2]/div[1]")).Click(); //SearchOption field 
                            RealWritter(fetchedHashtagsList[random.Next(0, fetchedHashtagsList.Count)], searchInputField, "hashtag");
                            Thread.Sleep(random.Next(1201, 2821));
                            driver.FindElement(By.XPath("//*[@id='react-root']/section/nav/div[2]/div/div/div[2]/div[3]/div/div[2]/div/div[1]/a/div")).Click();
                            Thread.Sleep(random.Next(861, 1623));
                        }
                        watched++;
                        continue;
                    case 2: // likes the pictures and go further 
                        random.Next(892, 1521);
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button")).Click();
                        Liked++;
                        continue;
                    case 3: // Likes the picutre and follow the person 
                        random.Next(920, 1320);
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button")).Click();
                        random.Next(1369, 17120);
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/header/div[2]/div[1]/div[2]/button")).Click();

                        var followedUser = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/header/div[2]/div[1]/div[1]/span/a")).Text;
                        using (StreamWriter sw = File.AppendText(pahtToFollowedUsersTxtFile))
                        {
                            sw.WriteLine(followedUser);
                        }
                        Liked++;
                        followed++;
                        continue;
                    case 4: // Writes a comment to the picture 
                        Thread.Sleep(random.Next(500, 700));
                        driver.FindElement(By.XPath($"//*[@id='react-root']/section/main/article/div[1]/div/div/div[{collum}]/div[{picture}]/a/div/div[2]")).Click();
                        Thread.Sleep(random.Next(799, 1263));

                        random.Next(942, 3012);
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[2]/button")).Click(); // Comment icon/button
                        
                        var commentToWriteNumber = random.Next(0, comments[language].Count);
                        var commentToWrite = comments[language][commentToWriteNumber];
                        RealWritter(commentToWrite, "/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea", "comment");
                        Thread.Sleep(random.Next(1023, 2013));
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/button[2]")).Click();
                        Thread.Sleep(random.Next(702, 2299));
                        commented++;
                        continue;
                }
            }

            Console.WriteLine("Program stopped");
            
        }

        public static void scrollDownSlowly(int minDistanceToScroll, int maxDistanceToScroll, int howFastToScroll)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            for (int i = 0; i < random.Next(minDistanceToScroll, maxDistanceToScroll); i++)  // OBS! 500 shoulnd be 3321 but isn't for testing purposes.
            {
                js.ExecuteScript($"window.scrollBy(0,{random.Next(1, howFastToScroll)})", "");
            }
        }

        public static void RealWritter(string thingToWrite, string XPath, string typeToWrite)
        {
            var val = thingToWrite.ToCharArray();
            if(typeToWrite == "username")
            {
                for (int i = 0; i < thingToWrite.Length; i++)
                {
                    char c = thingToWrite[i];
                    string newLetter = new StringBuilder().Append(c).ToString();
                    driver.FindElement(By.XPath($"{XPath}")).SendKeys(newLetter);
                    Thread.Sleep(random.Next(55, 172));
                }
            }
            if (typeToWrite == "hashtag")
            {
                for (int i = 0; i < thingToWrite.Length; i++)
                {
                    char c = thingToWrite[i];
                    string newLetter = new StringBuilder().Append(c).ToString();
                    driver.FindElement(By.XPath($"{XPath}")).SendKeys(newLetter);
                    Thread.Sleep(random.Next(39, 95));
                }
            }
            if(typeToWrite == "comment")
            {
                for (int i = 0; i < thingToWrite.Length; i++)
                {
                    char c = thingToWrite[i];
                    string newLetter = new StringBuilder().Append(c).ToString();
                    driver.FindElement(By.XPath($"{XPath}")).SendKeys(newLetter);
                    Thread.Sleep(random.Next(29, 54));
                }
            }
            if (typeToWrite == "password")
            {
                for (int i = 0; i < thingToWrite.Length; i++)
                {
                    char c = thingToWrite[i];
                    string newLetter = new StringBuilder().Append(c).ToString();
                    driver.FindElement(By.XPath($"{XPath}")).SendKeys(newLetter);
                    Thread.Sleep(random.Next(37, 125));
                }
            }
        }
    }
}
