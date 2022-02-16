using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Quiz.Services;
using Quiz.Model;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Users users;
            string fileDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(fileDir, "Data/users.bin");
            if (File.Exists(path))
                users = DataManager.LoadUsers(path);
            else
                users = new Users();
            do
            {
                Menu.DisplayRegMenu();
                switch (Menu.GetChoice())
                {
                    case 1:
                        {
                            string login, password;
                            bool isSignIn = true;
                            do
                            {
                                Console.Clear();
                                if(!isSignIn)
                                {
                                    Console.WriteLine("Неверный логин или пароль!");
                                    Console.WriteLine("Попробуйте снова");
                                }   
                                Console.WriteLine("Введите логин и пароль для входа");
                                Console.Write("Логин: ");
                                login = Console.ReadLine();
                                Console.Write("Пароль: ");
                                password = Console.ReadLine();
                                isSignIn = users.SignIn(login, password);
                            } while (!isSignIn);
                        }
                        break;
                    case 2:
                        {
                            string login, password, birthday = "";
                            bool isSignUp = true;
                            do
                            {
                                Console.Clear();
                                if (!isSignUp)
                                {
                                    Console.WriteLine("Пользователь с таким логином уже существует!");
                                    Console.WriteLine("Попробуйте снова");
                                }
                                else
                                {
                                    Console.WriteLine("Введите дату рождения в формате(yy-mm-dd)");
                                    birthday = Console.ReadLine();
                                }
                                Console.WriteLine("Придумайте логин и пароль");
                                Console.Write("Логин: ");
                                login = Console.ReadLine();
                                Console.Write("Пароль: ");
                                password = Console.ReadLine();
                                isSignUp = users.SignUp(login, password, birthday);
                            } while (!isSignUp);
                        }
                        break;
                    default:
                        Console.WriteLine("  Неверный символ!");
                        break;
                }
            } while (Menu.AllowContinue());
            do
            {
                Menu.DisplayMainMenu();
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
