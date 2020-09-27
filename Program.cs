using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;
using GoToHV.Class;
using System.Xml;
using System.Net;

namespace GoToHV
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitProgram = false;

            while (!quitProgram)
            {
             // CheckStudentCredentials();
               quitProgram = UserInput();
               
            }

        }

        private static void CheckStudentCredentials()
        {
            Console.BackgroundColor = ConsoleColor.Black; // change color of console background
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Hello! We will soon let you knew if you are qualified to study at Universty West.");
            Console.ResetColor();
         
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter your current total credits: ");
            int totalCredits = int.Parse(Console.ReadLine());

            Console.Write("How many kilometers away do you live from universty? ");
            int currentAdress = int.Parse(Console.ReadLine());

            QualifiedCheck newStudent = new QualifiedCheck();
            newStudent.Age = age;
            newStudent.TotalCredits = totalCredits;
            newStudent.Adress = currentAdress;

            Console.WriteLine("Age: " + age);
            Console.WriteLine("Total Credits: " + totalCredits + "hp");
            Console.WriteLine("Kilometers away: " + currentAdress + "km");

            // if functions to see if user is qualified 
            if (newStudent.Age < 18 && totalCredits < 100 && currentAdress > 30 )
            {
                Console.WriteLine("Result coming up, please wait...");
                Thread.Sleep(3000);
                Console.WriteLine("");
                Console.WriteLine("_____________________________________________________________________");
                Console.WriteLine("You are not qualified to study in our universty, we are very sorry.");
                Console.WriteLine("Press [Enter] to quit the program!");
                Console.ReadLine();
                Environment.Exit(-1); // quite
            }

            else if (newStudent.Age > 18 && totalCredits > 100 && currentAdress < 30)
            {
                Console.WriteLine("Result coming up, please wait...");
                Thread.Sleep(3000);
                Console.WriteLine("_____________________________________________________________________");
                Console.WriteLine("You are qualified to study in our universty, we are happy to have you!");
                Console.WriteLine("Press [Enter] to continue.");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("Result coming up, please wait...");
                Thread.Sleep(3000);
                Console.WriteLine("_____________________________________________________________________");
                Console.WriteLine("You are not qualified to study in our universty, we are very sorry.");
                Console.WriteLine("Press [Enter] to quit the program!");
                Console.ReadLine();
                Environment.Exit(-1); // quite
            }
        }

        public static bool UserInput()
        {
           // Console.ReadKey().Key != ConsoleKey.Escape
            Console.WriteLine("Hello!");
            Console.WriteLine("Enter your credentials down below! ");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Users user = new Users();

            user.UserName = username;
            user.Password = password;

            Console.WriteLine($"{1}. Login to Ladok");
            Console.WriteLine($"{2}. Login to HV");
            Console.WriteLine($"{3}. Show info from API");
            Console.WriteLine($"{4}. Login to QUIT");

            Console.WriteLine("Select what you want to do?");
            int userInputSelection = int.Parse(Console.ReadLine());

         
        
            switch (userInputSelection)
            {
                case 1:
                   LoginToLadok(user);
                    break;
                case 2:
                    LoginToHv(user);
                    break;
                case 3:
                    TestApi(user);
                    break;
                case 4:
                    return true;
                    break;

            }

            return false;
        }

        private static void TestApi(Users user)
        {
            WebClient client = new WebClient();
            var strPageCode = client.DownloadString("https://localhost:44362/api/TodoItems"); // CREATING AN API ON PROGRESS

            Console.WriteLine(strPageCode);

 

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
