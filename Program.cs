﻿using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace GoToHV
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitProgram = false;

            while (!quitProgram)
            {
              
               quitProgram = UserInput();
               
            }
        }

        public static bool UserInput()
        {
           // Console.ReadKey().Key != ConsoleKey.Escape
            Console.WriteLine("Hello!");
            Console.WriteLine("Enter your credentials: ");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Users user = new Users();

            user.UserName = username;
            user.Password = password;


            Console.WriteLine("Select what you want to do?");
            int userInputSelection = int.Parse(Console.ReadLine());

            Console.WriteLine($"{1}. Login to Ladok");
            Console.WriteLine($"{2}. Login to HV");
            Console.WriteLine($"{3}. Login to QUIT");
            
            switch (userInputSelection)
            {
                case 1:
                    LoginToLadok(user);
                    break;
                case 2:
                    LoginToHv(user);
                    break;
                case 3:
                    return true;
                    break;
                default:
                    return true;
                    break;
            }

            return false;
        }

        public static void LoginToLadok(Users user)
        {
            var driver = new ChromeDriver();

            driver.Url = "https://idp.hv.se/idp/profile/SAML2/Redirect/SSO;jsessionid=4oiqdac9opn6bcgu0xjcr9p1?execution=e1s1";

            Thread.Sleep(1000);
            IWebElement element = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/form/div[1]/input"));
            element.SendKeys(user.UserName);

            Thread.Sleep(1000);
            element = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/form/div[2]/input"));
            element.SendKeys(user.Password);

            Thread.Sleep(1000);
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
