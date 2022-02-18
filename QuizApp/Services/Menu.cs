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
            Console.WriteLine("\t ======================================================");
            Console.WriteLine("\t    1 - Начать новую викторину");
            Console.WriteLine("\t    2 - Посмотреть результаты своих прошлых викторин");
            Console.WriteLine("\t    3 - Посмотреть Топ-20 по конкретной викторине");
            Console.WriteLine("\t    4 - Изменить настройки");
            Console.WriteLine("\t ======================================================");
        }
        public static int GetChoice()
        {
            Console.Write("\n> Выберите нужное действие:");
            return int.Parse(Console.ReadLine());
        }
        public static bool AllowContinue()
        {
            Console.Write("\n> Продлжить (y/n)? - ");
            string answer = Console.ReadLine();
            return answer == "y" ? true : false;
        }
        public static void DisplayRegMenu()
        {
            Console.Clear();
            Console.WriteLine("\t    1 - Войти");
            Console.WriteLine("\t    2 - Зарегестрироваться");
        }
    }
}
