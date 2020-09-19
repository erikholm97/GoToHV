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


            //Todo den här ska vara en annan metod. Gör den mer lättläslig. exempelvis kan den heta LoginToHv(). Vi vill gärna få med vår instans från user så vi kan använda de uppgifterna för att logga in.
            //Tanken är att vi ska göra det möjligt för användaren att välja vilken sida de vill logga in på. Beroende på vilken sida har vi olika metoder som loggar in på var sin sida. Eftersom det är olika väg till att logga in (olika element etc som ska tryckas på) behöver vi olika metoder för att loga in på respektive sida. 
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
            element.SendKeys(username);

            Thread.Sleep(1000);
            element = driver.FindElement(By.XPath("/ html / body / div[2] / div[2] / div / main / div / div / div / form / div[2] / div[2] / input"));

            element.Click();
            element.SendKeys(password);

            element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/main/div/div/div/form/div[2]/div[4]/span"));

            element.Click();
        }
    }
}
