using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizModel;

namespace QuizApp.Services
{
    public class UserManager
    {
        private Reader<Users> _usersReader;
        private Writer<Users> _usersWriter;
        public Users Users { get; set; }
        public User CurUser { get; set; }

        public UserManager(Reader<Users> usersReader, Writer<Users> usersWriter)
        {
            _usersReader = usersReader;
            _usersWriter = usersWriter;
            Users = _usersReader.Read() == null ? new Users() : _usersReader.Read();
        }

        public void DisplaySignUp()
        {
            string login, password, birthday = "";
            bool isSignUp = true;
            do
            {
                Console.Clear();
                if (!isSignUp)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пользователь с таким логином уже существует!");
                    Console.ResetColor();
                    Console.WriteLine("Попробуйте снова");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(">  Введите дату рождения в формате(yy-mm-dd): ");
                    birthday = Console.ReadLine();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Придумайте логин и пароль");
                Console.ResetColor();
                Console.Write(">  Логин: ");
                login = Console.ReadLine();
                Console.Write(">  Пароль: "); 
                password = Console.ReadLine();
                isSignUp = Users.SignUp(login, password, birthday);
            } while (!isSignUp);
            _usersWriter.Write(Users);
            CurUser = Users.FindUser(login);
        }
        public void DisplaySignIn()
        {
            string login, password;
            bool isSignIn = true;
            do
            {
                Console.Clear();
                if (!isSignIn)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный логин или пароль!");
                    Console.ResetColor();
                    Console.WriteLine("Попробуйте снова");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Введите логин и пароль для входа");
                Console.ResetColor();
                Console.Write(">  Логин: ");
                login = Console.ReadLine();
                Console.Write(">  Пароль: ");
                password = Console.ReadLine();
                isSignIn = Users.SignIn(login, password);
            } while (!isSignIn);
            CurUser = Users.FindUser(login);
        }
        public void DisplayChangePassword()
        {
            string newPassword, password;
            bool passwordCorrect = true;
            do
            {
                Console.Clear();
                if (!passwordCorrect)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный пароль!");
                    Console.ResetColor();
                    Console.WriteLine("Попробуйте снова");
                }
                Console.WriteLine();
                Console.Write(">  Введите ваш старый пароль: ");
                password = Console.ReadLine();
                passwordCorrect = Users.CheckPassword(CurUser.Login, password);
            } while (!passwordCorrect);
            Console.Write(">  Введите новый пароль: ");
            newPassword = Console.ReadLine();
            Users.ChangeUserPassword(CurUser.Login, newPassword);
            _usersWriter.Write(Users);
            CurUser = Users.FindUser(CurUser.Login);
        }
        public void DisplayChangeBirthday()
        {
            string newBirthday;
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Текущая дата рождения: {CurUser.Birthday.ToShortDateString()}");
            Console.ResetColor();
            Console.Write(">  Введите новую дату рождения в формате(yy-mm-dd): ");
            newBirthday = Console.ReadLine();
            Users.ChangeUserBirthday(CurUser.Login, newBirthday);
            _usersWriter.Write(Users);
            CurUser = Users.FindUser(CurUser.Login);
        }
    }
}
