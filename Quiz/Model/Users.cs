﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    [Serializable]
    public class Users : List<User>
    {
        public bool SignUp(string login, string password, string birthday)
        {
            if (CheckUserExists(login))
                return false; 
            this.Add(new User(login, password, DateTime.Parse(birthday)));
            return true;
        }
        public bool SignIn(string login, string password)
        {
            User user = FindUser(login);
            if (!CheckUserExists(login)) 
                return false;
            return user.Password == password;
        }
        private bool CheckUserExists(string login)
        {
            return FindUser(login) != null;
        }
        private User FindUser(string login)
        {
            return this.FirstOrDefault(u => u.Login == login);
        }
    }
}
