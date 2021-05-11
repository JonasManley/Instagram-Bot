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
        static string pahtToFollowedUsersTxtFile = "C:\\Users\\jmp\\Documents\\GitHub\\Instagram-Bot\\InstagramBot";  //need to be updated if first time you run on pc
        static IWebDriver driver = new ChromeDriver("C:\\Users\\jmp\\Documents\\GitHub\\Instagram-Bot\\InstagramBot");  //need to be updated if first time you run on pc
        static List<string> hashtagsEnglish = new List<string>()
        { 
            "#run", "#runner", "#running", "#runner", "#runninghigh"
            , "#runnershigh", "#trailrunning", "#workout", "#training", "#summertraining",
            "intervals", "hardrunning", "new runner"
        };
         static List<string> hashtagsDansih = new List<string>()
        {
            "#løb", "#løber", "#løbetur", "#trailtur", "#løbeven", "#løbevener", 
            "#runner", "#løbevenner", "#komiform", "#førsteløb", "#sundhed",
            "#godtræning", "#langtur", "#intervaller", "#intervaltræning"
        };
        static List<List<string>> hashtags = new List<List<string>>() { hashtagsEnglish, hashtagsDansih };
        static List<string> comments = new List<string>()
        {

        };

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
            Thread.Sleep(random.Next(2521,4120));
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
                bool applyNotificationsPopUp2 = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div")).Displayed;
                Thread.Sleep(random.Next(1250, 2900));
                if (applyNotificationsPopUp2 == true)
                {
                    driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div[3]/button[1]")).Click();
                    Thread.Sleep(random.Next(2210, 4210));
                }
            }

            // navigates to a randoms specified hash within the Niece
            var searchBoxXPath = "//*[@id='react - root']/section/nav/div[2]/div/div/div[2]/input";
            driver.FindElement(By.XPath("searchBoxXPath")).Click();

            var hashtagLangue = random.Next(0, 1);
            var fetchedHashtagsList = hashtags[hashtagLangue];

            RealWritter(fetchedHashtagsList[random.Next(0, fetchedHashtagsList.Count)], searchBoxXPath, "hashtag");
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Enter);
            Thread.Sleep(random.Next(562, 921));

            var collum = random.Next(1, 3);
            var picture = random.Next(1, 3);
            driver.FindElement(By.XPath($"//*[@id='react - root']/section/main/article/div[1]/div/div/div[{collum}]/div[{picture}]/a/div/div[2]")).Click();
            Thread.Sleep(random.Next(362, 621));

            // like, follow, comment, watch 
            var weigthedNumber = new List<string> { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "2", "2", "2", "3", "3", "4", "5", };
            for (int i = 0; i < random.Next(12, 47); i++)
            {
                var randomPickedNumber = random.Next(1, 10); // pick a new random on entry
                switch (Int32.Parse(weigthedNumber[randomPickedNumber]))
                {
                    case 1: // See the pickture but clicks away
                        random.Next(420, 5620);
                        driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/a")).Click();
                        var weigthedNumber2 = new List<string> { "1", "1", "1", "1", "1", "1", "2", "2", "2", "2" };
                        var shouldVisitOrNotRandomNumber = random.Next(0, weigthedNumber2.Count);
                        var shouldVisitOrNot = weigthedNumber2[shouldVisitOrNotRandomNumber];
                        if(shouldVisitOrNot == "2")
                        {
                            var clickPictureOrTextNumer = random.Next(0, weigthedNumber2.Count);
                            var clickPictureOrText = weigthedNumber2[clickPictureOrTextNumer];
                            if (clickPictureOrText == "1")
                            {
                                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/header/div[2]/div[1]/div[1]/span/a"));
                            }
                            else
                            {
                                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/header/div[1]/div/a/img"));
                            }

                            // scroll a random amount on users page
                            scrollDownSlowly(332, 762, 62);  // OBS! 500 shoulnd be 3321 but isn't for testing purposes.
                            Thread.Sleep(random.Next(621, 921));

                            // scroll a random amount on the startpage
                            scrollDownSlowly(0, 0, 0);  // OBS! 500 shoulnd be 3321 but isn't for testing purposes.
                            Thread.Sleep(random.Next(1212, 1539));

                            var collumOnuserPage = random.Next(1, 3);
                            var pictureOnuserPage = random.Next(1, 3);
                            driver.FindElement(By.XPath($"//*[@id='react - root']/section/main/article/div[1]/div/div/div[{collumOnuserPage}]/div[{pictureOnuserPage}]/a/div/div[2]")).Click();
                            Thread.Sleep(random.Next(1521, 2958));

                            var howManyPickturesToSee = random.Next(1, 8);
                            for (int j = 0; j < howManyPickturesToSee; i++)
                            {
                                 driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/a[2]")).Click();
                                Thread.Sleep(random.Next(652, 2958));
                            }
                            driver.FindElement(By.XPath("/html/body/div[5]/div[3]/button/div/svg")); // click exit and return to mainpage for 
                            driver.FindElement(By.XPath("searchBoxXPath")).Click();

                            RealWritter(fetchedHashtagsList[random.Next(0, fetchedHashtagsList.Count)], searchBoxXPath, "hashtag");
                            builder.SendKeys(Keys.Enter);
                            Thread.Sleep(random.Next(861, 1623));

                        }
                        watched++;
                        return;
                    case 2: // likes the pictures and go further 
                        random.Next(892, 1521);
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button")).Click();
                        Liked++;
                        return;
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
                        return;
                    case 4: // Writes a comment to the picture 
                        return;
                    case 5: // see picture and clicks around on user profile (1-5 pictures) and follows at the end 
                        return;
                }
            }
           

            
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
            else
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
