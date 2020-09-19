using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace GoToHV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Enter your credentials: Username and password");
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            Users user = new Users();

            user.UserName = username;
            user.Password = password;


            Console.WriteLine("Select what you want to do?");
            int userInputSelection = int.Parse(Console.ReadLine());

            switch (userInputSelection)
            {
                case 1:
                    LoginToLadok(user);
                    break;
            }

            //LoginToHv(user);
            LoginToLadok(user);
        }

        public static void LoginToLadok(Users user)
        {
            var driver = new ChromeDriver();

            driver.Url = "https://idp.hv.se/idp/profile/SAML2/Redirect/SSO;jsessionid=4oiqdac9opn6bcgu0xjcr9p1?execution=e1s1";

            IWebElement element = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/form/div[1]/input"));
            element.SendKeys(user.UserName);

            element = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/form/div[2]/input"));
            element.SendKeys(user.Password);

            element = driver.FindElement(By.XPath("/ html / body / div / div / div / div[1] / form / div[4] / button"));
            element.Click(); 

        }

        public static void LoginToHv(Users user)
        {
            var driver = new ChromeDriver();
            
            driver.Url = "https://www.hv.se";

            IWebElement element = driver.FindElement(By.XPath("/ html / body / div[1] / header / div[1] / div / div / nav / ul / li[1] / a")); // locate the button, can be done with any other selector

            element.Click();

            Thread.Sleep(1000);
            element = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[4]/div/div[1]/div/div/div/div/ul/li[1]/a"));

            element.Click();

            Thread.Sleep(1000);
            element = driver.FindElement(By.XPath("/ html / body / div[1] / div[2] / div[10] / div / div / article / a"));

            element.Click();

            Thread.Sleep(1000);
            element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/main/div/div/div/form/div[2]/div[1]/input"));
            element.SendKeys(user.UserName);

            Thread.Sleep(1000);
            element = driver.FindElement(By.XPath("/ html / body / div[2] / div[2] / div / main / div / div / div / form / div[2] / div[2] / input"));

            element.Click();
            element.SendKeys(user.Password);

            element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/main/div/div/div/form/div[2]/div[4]/span"));

            element.Click();
        }
    }
}
