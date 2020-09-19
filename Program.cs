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

            IWebDriver driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl("https://www.hv.se/");
            


        }
    }
}
