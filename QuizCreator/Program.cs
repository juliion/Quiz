using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizCreator.Services;
using QuizApp.Services;
using QuizModel;
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
                        Menu.DisplayQiuzMenu();
                        Console.Write(">  Выберете область знаний викторины: ");
                        int choiceQuiz = Int32.Parse(Console.ReadLine());
                        QuizType type = (QuizType)choiceQuiz - 1;
                        List<string> titles = m.GetQuizzesTitles(type);
                        Menu.DisplayQuizzesTitlesMenu(titles);
                        Console.WriteLine();
                        Console.Write(">  Выберете тему: ");
                        int choiceTitle = Int32.Parse(Console.ReadLine());
                        string chosenTitle = titles[choiceTitle - 1];
                        m.RemoveQuiz(chosenTitle);
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"Викторина \"{chosenTitle}\" успешно удалена!");
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
