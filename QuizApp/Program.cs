using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuizApp.Services;
using QuizModel;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileQuizzes = @"../../../QuizCreator/Data/Quizzes.json";
            string fileUsers = @"../../Data/Users.json";
            string fileScores = @"../../Data/Scores.json";
            Reader<Users> usersReader = new JSONReader<Users>(fileUsers);
            Writer<Users> usersWriter = new JSONWriter<Users>(fileUsers);

            Reader<Scores> scoresReader = new JSONReader<Scores>(fileScores);
            Writer<Scores> scoresWriter = new JSONWriter<Scores>(fileScores);

            Reader<Quizzes> quizzesReader = new JSONReader<Quizzes>(fileQuizzes);

            UserManager um = new UserManager(usersReader, usersWriter);
            QuizManager qm = new QuizManager(quizzesReader);
            ScoreManager sm = new ScoreManager(scoresReader, scoresWriter);
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
                        {
                            Menu.DisplayQiuzMenu();
                            Console.WriteLine();
                            Console.Write(">  Выберете в какой области вы хотите проверить свои знания: ");
                            int choiceQuiz = Int32.Parse(Console.ReadLine());
                            QuizType chosenQuiz = (QuizType)choiceQuiz - 1;
                            string chosenTitle;
                            if (chosenQuiz == QuizType.Mixed)
                                chosenTitle = "Смешаная викторина";
                            else
                            {
                                List<string> titles = qm.GetQuizzesTitles(chosenQuiz);
                                Menu.DisplayQuizzesTitlesMenu(titles);
                                Console.WriteLine();
                                Console.Write(">  Выберете тему: ");
                                int choiceTitle = Int32.Parse(Console.ReadLine());
                                chosenTitle = titles[choiceTitle - 1];
                            }
                            Score s = qm.StartQuiz(chosenQuiz, chosenTitle, um.CurUser);
                            sm.AddScore(s);
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"Ваш результат: {s}");
                            Console.WriteLine();
                            Console.WriteLine("Место в топе:");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-------------");
                            Console.ResetColor();
                            sm.DispayUserScInTop(chosenTitle, s);
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
                                um.DisplayChangeBirthday();
                                break;
                            case 2:
                                um.DisplayChangePassword();
                                break;
                            default:
                                Console.WriteLine("  Неверный символ!");
                                break;
                        }
                        break;
                    case 5:
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
