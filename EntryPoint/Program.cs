using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
class EntryPoint
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement radioButton;

    static void Main()
    {
        string url = "https://testing.todorvachev.com/radio-button-test/";
        string option = "3";

        driver.Navigate().GoToUrl(url);

        radioButton = driver.FindElement(By.CssSelector("#post-10 > div > form > p:nth-child(6) > input[type=radio]:nth-child("+ option +")"));

        radioButton.Click();
        Thread.Sleep(10000);

        if (radioButton.GetAttribute("checked") == "true")
        {
            Console.WriteLine("This radio button is checked!");
        }
        else
        {
            Console.WriteLine("This radio button is not checked!");
        }

        driver.Quit();
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

