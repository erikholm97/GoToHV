using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoToHV.Class
{
    class LinkedInUsers : Users
    {
        public void GoToProfile()
        {
            var driver = new ChromeDriver();

            driver.Url = "https://www.linkedin.com/uas/login?session_redirect=https%3A%2F%2Fwww.linkedin.com%2Ffeed%2F";

            IWebElement element = driver.FindElement(By.XPath("/html/body/div/main/div[2]/form/div[1]/input"));
            element.SendKeys("bla bla");

            element = driver.FindElement(By.XPath("/html/body/div/main/div[2]/form/div[2]/input"));
            element.SendKeys("bla bla");

            element = driver.FindElement(By.XPath("/ html / body / div / div / div / div[1] / form / div[4] / button"));
            element.Click();
        }
    }
}
