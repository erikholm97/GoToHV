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
            //Console.WriteLine("Enter your credentials: Username and password");
            //string username = Console.ReadLine();
            //string password = Console.ReadLine();

            //Users user = new Users();

            //user.UserName = username;
            //user.Password = password;

            var driver = new ChromeDriver();

            driver.Url = "https://www.hv.se";

            IWebElement element = driver.FindElement(By.ClassName("cf-container__close")); // locate the button, can be done with any other selector
            Thread.Sleep(1000);
            element.Click();
            Console.ReadLine();

            //laddar, finns ett problem
            IWebElement element2 = driver.FindElement(By.LinkText("Student")); // locate the button, can be done with any other selector
            Thread.Sleep(1000);
            element2.Click();
            Console.ReadLine();


        }
    }
}
