using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Services;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Menu.Display();
                switch (Menu.GetChoice())
                {
                    case 1:
                        break;
                    case 2:
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
