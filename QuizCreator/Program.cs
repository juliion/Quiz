using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizCreator.Services;
using QuizApp.Services;
using Menu = QuizCreator.Services.Menu;

namespace QuizCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager um = new UserManager();
            Manager m = new Manager();
            bool exit = false;
            int choice;
            do
            {
                Menu.DisplayRegMenu();
                choice = Menu.GetChoice();
                switch (choice)
                {
                    case 1:
                        um.DisplaySignIn();
                        break;
                    case 2:
                        um.DisplaySignUp();
                        break;
                }
            } while (choice < 1 || choice > 2);
            do
            {
                Menu.DisplayMainMenu();
                switch (Menu.GetChoice())
                {
                    case 1:
                        m.AddQuiz(Creator.CreateQuiz());
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("  Неверный символ!");
                        break;
                }
                if (exit)
                    break;
            } while (Menu.AllowContinue());
            Console.WriteLine("\n\nПрограмма завершена!");
        }
    }
}
