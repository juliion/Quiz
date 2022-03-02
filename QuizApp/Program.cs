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
                        {
                            Menu.DisplayQiuzMenu();
                            Console.WriteLine();
                            Console.Write(">  Выберете в какой области вы хотите проверить свои знания: ");
                            int choiceQuiz = Int32.Parse(Console.ReadLine());
                            List<string> titles = qm.GetQuizzesTitles((QuizType)choiceQuiz - 1);
                            Menu.DisplayQuizzesTitlesMenu(titles);
                            Console.WriteLine();
                            Console.Write(">  Выберете тему: ");
                            int choiceTitle = Int32.Parse(Console.ReadLine());
                            Score s = qm.StartQuiz((QuizType)choiceQuiz - 1, titles[choiceTitle - 1], um.CurUser);
                            sm.AddScore(s);
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"Ваш результат: {s}");
                        }
                        break;
                    case 2:
                        sm.DispayScoresUser(um.CurUser.Login);
                        break;
                    case 3:
                        {
                            Menu.DisplayQiuzMenu();
                            Console.WriteLine();
                            Console.Write(">  Выберете раздел знаний викторины:");
                            int choiceQuiz = Int32.Parse(Console.ReadLine());
                            List<string> titles = qm.GetQuizzesTitles((QuizType)choiceQuiz - 1);
                            Menu.DisplayQuizzesTitlesMenu(titles);
                            Console.WriteLine();
                            Console.Write(">  Выберете тему:");
                            int choiceTitle = Int32.Parse(Console.ReadLine());
                            int topAmount = 20;
                            sm.DispayTopScores(topAmount, titles[choiceTitle - 1]);
                        }
                        break;
                    case 4:
                        Menu.DisplayChangeSetMenu();
                        switch (Menu.GetChoice())
                        {
                            case 1:
                                um.DisplayChangeLogin();
                                break;
                            case 2:
                                um.DisplayChangePassword();
                                break;
                            default:
                                Console.WriteLine("  Неверный символ!");
                                break;
                        }
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
