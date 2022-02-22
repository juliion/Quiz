using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuizApp.Services;
using QuizApp.Model;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager um = new UserManager();
            QuizManager qm = new QuizManager();
            ScoreManager sm = new ScoreManager();
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
                        Menu.DisplayQiuzMenu();
                        Console.Write("раздел знаний викторины:");
                        int choiceQuiz = Int32.Parse(Console.ReadLine());
                        List<string> titles = qm.GetQuizzesTitles((QuizType)choiceQuiz - 1);
                        Menu.DisplayQuizzesTitlesMenu(titles);
                        Console.Write("Выберете тему:");
                        int choiceTitle = Int32.Parse(Console.ReadLine());
                        Score s = qm.StartQuiz((QuizType)choiceQuiz - 1, titles[choiceTitle - 1], um.CurUser);
                        sm.AddScore(s);
                        Console.Clear();
                        Console.WriteLine(s);
                        break;
                    case 2:
                        sm.DispayScoresUser(um.CurUser.Login);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("  Неверный символ!");
                        break;
                }


            } while (Menu.AllowContinue());
            Console.WriteLine("\n\nПрограмма завершена!");
        }
    }
}
