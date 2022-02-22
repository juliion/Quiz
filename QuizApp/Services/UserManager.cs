﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Model;

namespace QuizApp.Services
{
    public class UserManager
    {
        private string _fileName;
        public Users Users { get; set; }
        public User CurUser { get; set; }

        public UserManager()
        {
            _fileName = @"..\..\Data\users.dat";
            if (File.Exists(_fileName))
                Users = DataManager.LoadUsers(_fileName);
            else
                Users = new Users();
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
                isSignUp = Users.SignUp(login, password, birthday);
            } while (!isSignUp);
            DataManager.SaveUsers(_fileName, Users);
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
                    Console.WriteLine("Неверный логин или пароль!");
                    Console.WriteLine("Попробуйте снова");
                }
                Console.WriteLine("Введите логин и пароль для входа");
                Console.Write("Логин: ");
                login = Console.ReadLine();
                Console.Write("Пароль: ");
                password = Console.ReadLine();
                isSignIn = Users.SignIn(login, password);
            } while (!isSignIn);
            CurUser = Users.FindUser(login);
        }
        public void DisplayChangeLogin()
        {
            string newLogin;
            bool loginChanged = true;
            do
            {
                Console.Clear();
                if (!loginChanged)
                {
                    Console.WriteLine("Пользователь с таким логином уже существует!");
                    Console.WriteLine("Попробуйте снова");
                }
                Console.WriteLine($"Текущий логин: {CurUser.Login}");
                Console.Write("Введите новый логин: ");
                newLogin = Console.ReadLine();
                loginChanged = Users.ChangeUserLogin(CurUser.Login, newLogin);
            } while (!loginChanged);
            DataManager.SaveUsers(_fileName, Users);
            CurUser = Users.FindUser(newLogin);
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
                    Console.WriteLine("Неверный пароль!");
                    Console.WriteLine("Попробуйте снова");
                }
                Console.Write("Введите ваш старый пароль: ");
                password = Console.ReadLine();
                passwordCorrect = Users.CheckPassword(CurUser.Login, password);
            } while (!passwordCorrect);
            Console.Write("Введите новый пароль: ");
            newPassword = Console.ReadLine();
            Users.ChangeUserPassword(CurUser.Login, newPassword);
            DataManager.SaveUsers(_fileName, Users);
            CurUser = Users.FindUser(CurUser.Login);
        }
    }
}
