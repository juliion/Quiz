using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Services
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
            Console.WriteLine("\t\t\t1 - Создать новую викторину");
            Console.WriteLine("\t\t\t2 - Редактировать викторину");
            Console.WriteLine("\t\t\t3 - Удалить викторину");
            Console.WriteLine("\t\t\t4 - Выход");
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
            Console.Write("\n>  Продолжить (y/n)? - ");
            Console.ResetColor();
            string answer = Console.ReadLine();
            return answer == "y" ? true : false;
        }
        public static void DisplayRegMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t  Добро пожаловать в приложение для создания викторин! ");
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
        public static void DisplayEditMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("\t\t\t1 - Добавить вопрос");
            Console.WriteLine("\t\t\t2 - Удалить вопрос");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------------------------------------");
            Console.ResetColor();
        }
    }
}
