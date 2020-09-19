using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;


namespace GoToHV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.hv.se/");
            
        }
    }
}
