using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    [Serializable]
    public class Users : List<User>
    {
        public bool SignUp(string login, string password, DateTime birthday)
        {
            if (CheckUserExists(login))
                return false; 
            this.Add(new User(login, password, birthday));
            return true;
        }
        public bool SignIn(string login, string password, DateTime birthday)
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
