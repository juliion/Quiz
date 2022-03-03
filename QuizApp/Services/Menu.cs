using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public static class Menu
    {
        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t==============================================================");
            Console.ResetColor();
            Console.WriteLine("\t\t\t1 - Начать новую викторину");
            Console.WriteLine("\t\t\t2 - Посмотреть результаты своих прошлых викторин");
            Console.WriteLine("\t\t\t3 - Посмотреть Топ-20 по конкретной викторине");
            Console.WriteLine("\t\t\t4 - Изменить настройки");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t==============================================================");
            Console.ResetColor();
        }
        public static int GetChoice()
        {
            Console.Write("\n>  Выберите нужное действие: ");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        public static bool AllowContinue()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n>  Продлжить (y/n)? - ");
            Console.ResetColor();
            string answer = Console.ReadLine();
            return answer == "y" ? true : false;
        }
        public static void DisplayRegMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t  Добро пожаловать в приложение \"Викторина\"! ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("\t\t\t1 - Войти");
            Console.WriteLine("\t\t\t2 - Зарегестрироваться");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
        }
        public static void DisplayQiuzMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("\t\t\t1 - История");
            Console.WriteLine("\t\t\t2 - Физика");
            Console.WriteLine("\t\t\t3 - Смешаная викторина");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
        }
        public static void DisplayChangeSetMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("\t\t\t1 - Изменить дату рождения");
            Console.WriteLine("\t\t\t2 - Изменить пароль");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
        }
        public static void DisplayQuizzesTitlesMenu(List<string> titles)
        {
            Console.Clear();
            Console.WriteLine();
            int num = 1;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (var title in titles)
            {
                Console.WriteLine($"\t    {num} - {title}");
                num++;
            }
            Console.ResetColor();
        }
    }
}
